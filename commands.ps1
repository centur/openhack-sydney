az login -u hacker5@OTAPRD485ops.onmicrosoft.com

az aks get-credentials --resource-group hack9-kube --name hack9cluster

## Challenge 2 
Build up yaml file and call:
kubectl apply -f hack9.yaml


## Challenge 3

kubectl get storageclass

kubectl apply -f azure-premium.yaml
kubectl config current-context
kubectl config get-contexts


docker pull mcr.microsoft.com/powershell - powershell core