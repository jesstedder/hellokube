# Running the container locally with config volume
```ps
docker run -v d:/src/Sandbox/HelloKube/externalconfig/:/config hello-kube-service

$ docker run --name hello-kube-web -p 5000:5000 -e ASPNETCORE_URLS="http://*:5000" -v d:/src/Sandbox/HelloKube/externalconfig/:/config snpcontainers2.az urecr.io/hello-kube-web

```
# Startup sql server
```ps
docker run -e 'ACCEPT_EULA=Y' -e 'MSSQL_SA_PASSWORD=c6en!YUpHawa' \
   -p 1401:1433 --name hksql1 \
   -v hksql1data:/var/opt/mssql \
   -d microsoft/mssql-server-linux:2017-latest
```

# k8s commands
```ps
kubectl create secret generic mssql --from-literal=SA_PASSWORD="c6en%YUpHawa" -n hello-kube

# creating a folder in a pod
kubectl exec hk-sql-deployment-65b58d7bd4-mrjld -n hello-kube -- bash -c "mkdir /var/opt/mssql/backup"

# copy the backup file
kubectl cp ./WideWorldImporters-Full.bak  hk-sql-deployment-65b58d7bd4-mrjld:/var/opt/mssql/backup/ -n hello-kube
```