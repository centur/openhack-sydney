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
    public interface IHelmCommands
    {
        //helm upgrade --install minecraft334.\minecraft
        //helm delete minecraft334
        void CreateService(string serviceName);
           
        void DeleteService(string serviceName);
    }

    public class HelmCommands: IHelmCommands
    {
        readonly string _createServiceCommand = @"upgrade --install {0} ./minecraft";
        readonly string _deleteServiceCommand = "delete {0}";

        readonly string _helmFile = "helm";

        public void CreateService(string serviceName)
        {
            RunCommand(_helmFile, string.Format(_createServiceCommand, serviceName));
        }

        public void DeleteService(string serviceName)
        {
            RunCommand(_helmFile, string.Format(_deleteServiceCommand, serviceName));
        }

        private void RunCommand(string filename, string arguments)
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
        }
    }
}
