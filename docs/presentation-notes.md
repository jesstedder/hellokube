# Titles
## Virtual Machines are obselete
## Application Virtualization with Containers : Next gen app hosting

# Outline
* I don't have kids, watch tv, and have trouble sleeping.  So what do I do with my free time?  I run, go out, and design distributed software.... sometimes all at the same time!
    * Running slide, add bubble of code
    * Coding slide
    * Wine slide
    * Me coding at dutch's with board in the background
 * In fact, this pic is very meta, I designed and built the distributed system that powers the beer menu for Dutch's while drinking wine at dutch's.
 * Let's talk about containers though.  Who is familiar with Docker containers?
 * What are containers?
    * Let's start with what they aren't.
    * We are talking about docker containers today.  This is in NO WAY related to the GOOD / Blackberry container.
    * Containers are not virtual machines
    * Why do we use virtual machines?
        * Portability is a key factor
        * Applicaitons running on virtual machines are not portable but the infrastructure is.
        * what good is the infrastructure without the apps?
    * Containers are a key technology for making apps portable
    * Containers are immutable - the are exactly the same from environment to environment.  If a container image is changed, it is a new image.
    * COntainers are a single process and include the minimum number of dependencies for that process to run.  Look at task manager - think of a container as a process running on a VM.
    * Who's using them?  Google runs its entire global business in containers.  Amazon runs its shopping cart in containers.  Citibank runs its mobile banking in containers.
    * SLIDE:  VM cluster... vms floating over host os on metal
    * SLIDE: containers floating over VMs from previous lside
    * Lets define some terminology
        * Docker file - code that defines how to build a container.  Typically starts with a base container, for example microsoft/servercore.
        * Container image - The package that contains everything needed to run the process.  This is the output of the build process.  This is immutable.
        * Container instance - a running instance of a container image
        * Docker engine - the subsystem on the host os that manages and executes containers
    * DEMO 1
        * All developers should have rabbitmq running.  Let me show you how easy this is with a container.  Pivotal publishes container images for each release of RMQ.
        * Spin up two versions of RMQ, log into console
        * Cool, right?
        * Now let's do the classic hello world example.  Of course I'm not going to make it that simple, we're going to use a web app that says hello and shows the server time.
        * Andddd... we're going to create three versions, english, french, and german
        * Show the docker file
        * Docker build english, run, open in browser
        * spin up the other two and show them
        * Goto prime
        * In addition to saying hello world, it can also calculate primes, we'll use this to demonstrate auto scaling under load
    * SLIDE:  Library pic from cincinnati
    * Container registries are simply libraries of container images.  If you are familiar with it, this is similar to the file share on build1 where all of the spadefoot packages live.
    * SLIDE:  Cincinnati Symphony orchestra
    * Container orchestrators are systems for automating deployment, scaling, and management of containerized applications.
    * There are several orchestrators out there, but kubernetes has become the industry leader.  Originally developed by google, MS, amazon, and IBM are all now contributors as well.
    * Kubernetes is often abbreviated k8s.  Interesting fact - i18n short for internationalization
    * SLIDE:  ???
    * Container as a service - all the major cloud providers offer kubernetes as a managed service.
    * Demo 2
        * Apply hello-eawg yaml
        * Show diagram of what all its building
        * Browse to hello world
        * ok, now we're going to put it under load and watch it scale out
        * Mention DNS here when typing the address for the svc
        * run load generator, wait a couple minutes... take questions?
        * Refresh several times and mention load balancer
        * Switch to french using k8s dashboard version while under load
        * kill load generator
        * Come back in a few minutes to show it sccaled down
    * SLIDE:  ??
    * But jess - that's just hello world, can we run a real production workload?
    * SLIDE:  Diagram of multi tier app
    * Yes - take a look at this.  Its a .net web app, a .net backend service, both communicating with SQL server, rabbitmq, and a cache server all running in containers.



