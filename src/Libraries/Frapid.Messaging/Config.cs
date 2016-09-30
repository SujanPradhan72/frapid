﻿using System.IO;
using System.Text;
using System.Web.Hosting;
using Newtonsoft.Json;

namespace Frapid.Messaging
{
    public sealed class MessagingConfig
    {
        public bool TestMode { get; set; }

        public static MessagingConfig Get(string tenant)
        {
            string path = $"/Tenants/{tenant}/Configs/Smtp.json";
            path = HostingEnvironment.MapPath(path);

            if(path != null &&
               File.Exists(path))
            {
                string contents = File.ReadAllText(path, Encoding.UTF8);
                return JsonConvert.DeserializeObject<MessagingConfig>(contents);
            }

            return new MessagingConfig();
        }
    }
}