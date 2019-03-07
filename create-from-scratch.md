# Quickstart

1. Download database backup from https://github.com/Microsoft/sql-server-samples/releases/download/wide-world-importers-v1.0/WideWorldImporters-Full.bak
1. Create the namespace `kubectl create ns hello-kube`
1. Create the auth token for azure container registry `kubectl create secret docker-registry acr-auth --docker-server snpcontainers2.azurecr.io --docker-username XXXXXXXX --docker-password XXXXXXXX --docker-email teddertj@fhlbcin.com -n hello-kube`
1. Create the sql password `kubectl create secret generic mssql --from-literal=SA_PASSWORD="c6en%YUpHawa" -n hello-kube`
1. Deploy persistent volume claim for sql server pod `kubectl apply -n hello-kube -f ./k8s/hello-kube-sql-pvc.yaml`
1. Deploy sql server pod `kubectl apply -n hello-kube -f ./k8s/hello-kube-sql-server.yaml`
1. Copy backup into pod and restore
    1. `kubectl exec hk-sql-deployment-68b4f696d5-wnzqn -n hello-kube -- bash -c "mkdir /var/opt/mssql/backup"`
    1. `kubectl cp ./WideWorldImporters-Full.bak  hk-sql-deployment-68b4f696d5-wnzqn:/var/opt/mssql/backup/ -n hello-kube`
    1. Connect with mgt tools and do a restore
1. Deploy rabbitmq pod `kubectl apply -n hello-kube -f ./k8s/rabbitmq.yaml`
1. Deploy redis `kubectl apply -n hello-kube -f ./k8s/redis.yaml`
1. Deploy hello-kube service `kubectl apply -n hello-kube -f ./k8s/hello-kube-service.yaml`
1. Deploy hello-kube web `kubectl apply -n hello-kube -f ./k8s/hello-kube-web.yaml`
