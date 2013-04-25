using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Quartz;
using BackgroundWorker.Schedulers;
using Quartz.Impl;

namespace BackgroundWorker
{
    class Program
    {
        static void Main(string[] args)
        {
            var schedulerFactory = new StdSchedulerFactory();
            var scheduler = schedulerFactory.GetScheduler();
            var keepAliveJob = JobBuilder.Create<KeepAliveJob>().Build();
            var keepAliveTrigger = TriggerBuilder.Create()
                            .WithSimpleSchedule(x => x.WithIntervalInMinutes(19).RepeatForever())
                            .Build();

            scheduler.ScheduleJob(keepAliveJob, keepAliveTrigger);
            scheduler.Start();   
        }
    }
}
