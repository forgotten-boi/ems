using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using EMS.Website.Services;

namespace EMS.Website.Services
{
    public static class EmailSenderExtensions
    {
        public static Task SendEmailConfirmationAsync(this IEmailSender emailSender, string email, string link)
        {
            return emailSender.SendEmailAsync(email, "Confirm your email",
                $"Your account has been created. Please follow this link: <a href='{HtmlEncoder.Default.Encode(link)}'>link</a>");
        }
    }
}
