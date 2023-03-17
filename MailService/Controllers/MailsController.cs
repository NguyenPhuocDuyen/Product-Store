using MailService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] MailContent mailContent)
        {
            await sendMailService.SendMail(mailContent);

            return NoContent();
        }
    }
}
