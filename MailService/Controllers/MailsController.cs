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

        //send email
        // POST: api/Mails/PostMail
        [HttpPost("PostMail")]
        public async Task<ActionResult> PostMail([FromBody] MailContent mailContent)
        {
            await sendMailService.SendMail(mailContent);
            return NoContent();
        }
    }
}
