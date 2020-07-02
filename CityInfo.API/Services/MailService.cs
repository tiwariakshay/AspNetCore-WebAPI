using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Services
{
    public class MailService : IMailService
    {
        private string _mailTo = "";
        private string _mailFrom = "";
        private readonly IConfiguration _configuration;

        public MailService(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        public void SendEmail()
        {
            // Send Email
            Debug.WriteLine($"Sending Email from: {_configuration["mailSetting: mailFrom"]} To: {_configuration["mailSetting: mailTo"]} - MailService");
        }
    }


}
