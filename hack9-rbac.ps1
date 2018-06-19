#az login -u hacker5@OTAPRD485ops.onmicrosoft.com
$kubeGroup = "hack9-kube"
$kubeName = "hack9cluster"
# Log analytics format that should work is the path from original portal URL 
#https://portal.azure.com/#@f7607a96-c49e-4f71-b45e-95810162231d/resource
#/subscriptions/c2552248-0156-478a-bb4a-e92bd9a238de/resourceGroups/hack9-kube/providers/Microsoft.OperationalInsights/workspaces/hack9-sidecar/Overview

$LogAnalyticsWorkspace = "/subscriptions/c2552248-0156-478a-bb4a-e92bd9a238de/resourceGroups/hack9-kube/providers/Microsoft.OperationalInsights/workspaces/hack9-sidecar"



az aks create --resource-group $kubeGroup --name $kubeName --enable-rbac --generate-ssh-keys 

az aks get-credentials --resource-group $kubeGroup --name $kubeName

kubectl apply -f hack9-rbac.yaml