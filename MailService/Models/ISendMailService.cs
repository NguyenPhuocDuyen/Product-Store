using Models.ViewModel;
using System.Threading.Tasks;

namespace MailService.Models
{
    public interface ISendMailService
    {
        Task SendMail(MailContent mailContent);

        Task SendEmailAsync(string email, string subject, string htmlMessage);
    }
}
