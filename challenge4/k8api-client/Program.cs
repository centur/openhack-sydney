using System;
using System.Diagnostics;

namespace k8api_client
{
    class Program
    {
        static void Main(string[] args)
        {
            var startInfo = new ProcessStartInfo
            {
                FileName = @"C:\Program Files\Docker\Docker\resources\bin\kubectl.exe",
                Arguments = @"get services",
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
            };
            try
            {
                // Start the process with the info we specified.
                // Call WaitForExit and then the using statement will close.
                using (var exeProc = Process.Start(startInfo))
                {
                    exeProc.WaitForExit();
                    var output = exeProc.StandardOutput.ReadToEnd();
                    Console.WriteLine(output);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
