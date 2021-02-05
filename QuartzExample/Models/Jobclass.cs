using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Quartz;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using QuartzExample.Models;

namespace QuartzExample.Models
{
    public class Jobclass : IJob
    {
        public static readonly string SchedulingStatus = ConfigurationManager.AppSettings["ExecuteTaskServiceCallSchedulingStatus"];

        public Task Execute(IJobExecutionContext context)
        {
            var task = Task.Run(() =>
            {
                if (SchedulingStatus.Equals("ON"))
                {
                    try
                    {
                        //istediğin işlemi yapabilirsin

                    }
                    catch (Exception ex)
                    {
                    }
                }
            });
            return task;
        }
    }
}