using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Negocio.Dto;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Presentacion.API_Rest {
    [Route("api/sms")]
    [ApiController]
    public class SMSController : ControllerBase {
        [HttpPost("enviarSMS")]
        public IActionResult EnviarSMS(MensajeSMSRequest model) {
            try {
                string token = Request.Headers.FirstOrDefault().Value.FirstOrDefault();
                var accountSid = "AC8342f50b61390cadde3062b9a2f6de19";
                var authToken = "1bdd0bab019fc3bb96d35eef3826c6fe";
                TwilioClient.Init(accountSid, authToken);

                //Solo numeros verificados
                var to = new PhoneNumber(model.Numero);
                var de = new PhoneNumber("+16055705523");

                var message = MessageResource.Create(
                body:model.Mensaje,
                from: de,
                to: to);

                return Ok("Se ha enviado el mensaje");
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
