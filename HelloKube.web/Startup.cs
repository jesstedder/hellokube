using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MassTransit;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//dotnet install tool dotnet-dev-certs -g --version 2.1.0-preview1-final' and then run 'dotnet-dev-certs https --trust'.

namespace HelloKube
{
    public class Startup
    {
        //NOTE:  This is a hack, need to figure out how to inject the SignalR context into the MassTransit consumer
        public static IHubContext<Hubs.NotificationHub> NotificationHubContext;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private IBusControl _bus;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(sharedOptions =>
            {
                sharedOptions.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                sharedOptions.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
                .AddAzureAd(options => Configuration.Bind("AzureAd", options))
            .AddCookie();

            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<core.dal.WideWorldContext>(options=>options.UseSqlServer(Configuration["SqlServer:ConnectionString"]));
            
            var x = services.AddSignalR();
            HelloKube.core.services.CacheService.ConnectionString = Configuration["Redis:ConnectionString"];

            services.AddTransient<core.services.OrderDataService>();
            
            //var provider = services.BuildServiceProvider();

            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseSignalR(routes =>
            {
                routes.MapHub<Hubs.NotificationHub>("/hubs/notification");
            });
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

        //NOTE:  This is a hack, need to figure out how to inject the SignalR context into the MassTransit consumer
            NotificationHubContext = app.ApplicationServices.GetService<IHubContext<Hubs.NotificationHub>>();


            _bus = Bus.Factory.CreateUsingRabbitMq(sbc =>
            {
                var host = sbc.Host(new Uri(Configuration["RabbitMQ:Uri"]), h =>
                {
                    h.Username(Configuration["RabbitMQ:UserName"]);
                    h.Password(Configuration["RabbitMQ:Password"]);
                });

                sbc.ReceiveEndpoint(host, Configuration["RabbitMQ:EndpointQueue"], endpoint =>
                    {
                        
                        endpoint.Consumer<HelloKube.Hubs.ServerTimeConsumer>();
                    });
            });
            _bus.Start();

            applicationLifetime.ApplicationStopping.Register(OnStopping);

        }

        private void OnStopping(){
            _bus.Stop();
        }
    }
}
