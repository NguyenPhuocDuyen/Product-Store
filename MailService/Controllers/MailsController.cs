using MailService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ViewModel;
using System.Threading.Tasks;

namespace MailService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MailsController : ControllerBase
    {
        private readonly ISendMailService sendMailService;

        public MailsController(ISendMailService sendMailService)
        {
            this.sendMailService = sendMailService;
        }

        //gửi email
        [HttpPost("PostMail")]
        public async Task<IActionResult> PostMail([FromBody] MailContent mailContent)
        {
            await sendMailService.SendMail(mailContent);

            return NoContent();
        }
    }
}
