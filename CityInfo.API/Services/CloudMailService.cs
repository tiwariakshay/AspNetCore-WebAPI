using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CityInfo.API.Services
{
    public class CloudMailService : IMailService
    {
        private readonly IConfiguration _configuration;

        public CloudMailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void SendEmail()
        {
            Debug.WriteLine($"Sending Email from: {_configuration["mailSetting: mailFrom"]} To: {_configuration["mailSetting: mailTo"]} - CloudMailService");
            //Implement SendGrid
        }
    }
}
