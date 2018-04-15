using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ionicDemoApI.Services
{
    public interface IMailService
    {
        void Send(string subject, string msg);
    }
    public class LocalMailService: IMailService
    {
        //private string _mailTo = "developer@qq.com";
        // private string _mailFrom = "noreply@alibaba.com";
        private readonly string _mailTo = Startup.Configuration["mailSettings:mailToAddress"];
        private readonly string _mailFrom = Startup.Configuration["mailSettings:mailFromAddress"];

        public void Send(string subject, string msg)
        {
            Debug.WriteLine($"从{_mailFrom}给{_mailTo}通过{nameof(LocalMailService)}发送了邮件");
        }
    }
}
