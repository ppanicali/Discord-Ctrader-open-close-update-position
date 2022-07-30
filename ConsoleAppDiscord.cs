// console app to be called from ctrader, it s net 5.0 cannot be executed in ctrader targeting net4

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;


namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string token = "https://discord.com/api/webhooks/channelid/token";

            WebRequest wr = (HttpWebRequest)WebRequest.Create(token);

            wr.ContentType = "application/json";

            wr.Method = "POST";

            using (var sw = new StreamWriter(wr.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(new
                {
                    username = "Assistant_bot",
                    content = string.Join(" ", args),


                });
                sw.Write(json);
            }
            var response = (HttpWebResponse)wr.GetResponse();

        }
    }
}
