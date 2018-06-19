$kubeGroup = "hack9-kube"
$kubeName = "hack9cluster"

az aks browse --resource-group $kubeGroup --name $kubeName

az login -u hacker5@OTAPRD485ops.onmicrosoft.com

az aks get-credentials --resource-group $kubeGroup --name $kubeName
kubectl config current-context # give current details where kubectl sends commands
kubectl config get-contexts 

## Challenge 2 
# Build up yaml file and call:
kubectl apply -f hack9.yaml


## Challenge 3
kubectl get storageclass

kubectl apply -f azure-premium.yaml
kubectl get pods --all-namespaces

#docker pull mcr.microsoft.com/powershell - powershell core


kubectl get configmaps myconfigmap
kubectl get pods
kubectl describe pod



#challenge 4 

kubectl config view # gives url to access api programatically
kubectl get secrets | kubectl describe secret


choco install kubernetes-helm
helm init --client-only
helm repo add svc-cat https://svc-catalog-charts.storage.googleapis.com
helm repo add azure https://kubernetescharts.blob.core.windows.net/azure
helm repo add brigade https://azure.github.io/brigade
helm repo add incubator https://kubernetes-charts-incubator.storage.googleapis.com/


