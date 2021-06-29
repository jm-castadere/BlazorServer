using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorServer.Opts
{
    public class ApiOptions
    {
        //Url of appsetting -> "Url": "http//Localhost:6000"
        public string Url { get; set; }

        //Resilience manuell
        //public int Delay { get; set; }
        //public int RetryMax { get; set; }


    }
}
