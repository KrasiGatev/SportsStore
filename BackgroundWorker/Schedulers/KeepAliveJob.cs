using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using System.Net;

namespace BackgroundWorker.Schedulers
{
    public class KeepAliveJob : IJob
    {
        public void Execute(IJobExecutionContext context)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadString("http://simpleonlinestoreusingmvc.apphb.com/");
            }
        }
    }
}