using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ionicDemoApI.Services
{
    public class CloudMailService: IMailService
    {
        private readonly string _mailTo = "admin@qq.com";
        private readonly string _mailFrom = "noreply@alibaba.com";
        private readonly ILogger _logger;

        public CloudMailService(ILogger<string> logger)
        {
            _logger = logger;
        }

        public void Send(string subject, string msg)
        {
            //release 模式下 Debug 无效
            _logger.LogInformation($"从{_mailFrom}给{_mailTo}通过{nameof(CloudMailService)}发送了邮件");
        }
    }
}
