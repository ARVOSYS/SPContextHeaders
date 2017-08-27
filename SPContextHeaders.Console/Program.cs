using SP.Cmd.Deploy;
using System;
using System.Net;

namespace SPContextHeaders.Test
{
    class Program
    {
        static void Main(string[] args)
        {

            var tasks = new SPFunctions() {
                {
                    "headers", options => {
                        WebHeaderCollection headers = ContextHeaders.GetHeaders(options.Context);

                        Console.WriteLine(headers.ToString());

                        var bp1 = ""; bp1 += ""; // Breakpoint
                    }
                }
            };

            SharePoint.Exec(args, tasks);

            var bp = ""; bp += ""; // Breakpoint

        }
    }
}
