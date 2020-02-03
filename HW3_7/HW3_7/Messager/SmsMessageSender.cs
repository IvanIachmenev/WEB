using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace HW3_7.Messager
{
    public class SmsMessageSender : IMessageSender
    {
        private string SmsMessageSenderContext;

        public SmsMessageSender(HttpContext context)
        {
            var is_req = context.Request.Cookies.TryGetValue("text", out string val);
            if(is_req)
            {
                SmsMessageSenderContext = val;
            }
            else
            {
                context.Response.Cookies.Append("text", "TEXT NULL");
                SmsMessageSenderContext = "text empty";
            }
        }

        public string Send()
        {
            return SmsMessageSenderContext;
        }
    }
}
