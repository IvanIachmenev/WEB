using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System.Net.Http;

namespace HW3_7.Messager
{
    public class EmailMessageSender : IMessageSender
    {
        private string text;
        
        public EmailMessageSender(HttpContext context)
        {
            string result = context.Session.GetString("text");
            if(result == null)
            {
                text = "empty text";
                context.Session.SetString("text", text);
            }
            else
            {
                text = result;
            }
        }

        public string Send()
        {
            return text;
        }
    }
}
