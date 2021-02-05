using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using Quartz;
using Quartz.Impl;

namespace QuartzExample.Models
{
    public class JobScheduler
    {

        //burada triggerımızın ne sıklıkla çalışacağını belirledik
        //detaylı cron expression bilgisi için :
        //https://www.freeformatter.com/cron-expression-generator-quartz.html
        private static readonly string ScheduleCronExpression = ConfigurationManager.AppSettings["ExecuteTaskScheduleCronExpression"];
        public static async System.Threading.Tasks.Task StartAsync()
        {
            try
            {
                var scheduler = await StdSchedulerFactory.GetDefaultScheduler();
                if (!scheduler.IsStarted)
                {
                    await scheduler.Start();
                }

                //job
                var job = JobBuilder.Create<Jobclass>()
                    .WithIdentity("ExecuteTaskServiceCallJob1", "group1")
                    .Build();

                //trigger
                var trigger = TriggerBuilder.Create()
                    .WithIdentity("ExecuteTaskServiceCallTrigger1", "group1")
                    .WithCronSchedule(ScheduleCronExpression)                    
                    .Build();

                await scheduler.ScheduleJob(job, trigger);
            }
            catch (Exception ex)
            {

            }
        }
    }
}