# Running the container locally with config volume
```ps
docker run --rm -v d:/src/Sandbox/HelloKube/HelloKube.service/config/:/config hello-kube-service
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