using apicoreapp.Models;
using k8s;
using k8s.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace apicoreapp.Logic
{
    public class K8Commands
    {
        readonly string _commandGetServices = "get services --namespace default -o json";
        readonly string _kubectl = "kubectl";

        private JObject RunCommand(string filename, string arguments)
        {
            var process = new Process()
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = filename,
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                }
            };
            process.Start();
            string result = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            return JObject.Parse(result);
        }

        public Task<IEnumerable<Tenant>> GetServices()
        {
            var result = RunCommand(_kubectl, _commandGetServices);

            var items = result["items"];

            var tenantList = new List<Tenant>();

            foreach(var item in result["items"])
            {
                var name = item["metadata"]["name"];
          
                var ip = item.SelectToken("status.loadBalancer.ingress[0].ip");

                var port = item.SelectToken("spec.ports[0].targetPort") ?? "";
                var rmPort = item.SelectToken("spec.ports[1].targetPort") ?? "" ;

                tenantList.Add(new Tenant()
                {
                    Name = name.ToString(),
                    Endpoint = new Endpoint() { Minecraft = $"{ip}:{port}", Rcon = $"{ip}:{port}" }}
                );
            }

            return Task.FromResult(tenantList.AsEnumerable());
        } 

    }
}
