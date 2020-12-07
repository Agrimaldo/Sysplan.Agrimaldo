using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sysplan.Agrimaldo.Domain.Entities;
using Sysplan.Agrimaldo.Domain.Interfaces.Services;
using Sysplan.Agrimaldo.Domain.Models;

namespace Sysplan.Agrimaldo.API.Controllers
{
    [ApiController, Route("[controller]")]
    public class ClientController : ControllerBase
    {
        readonly IClientService clientService;
        public ClientController(IClientService _clientService)
        {
            clientService = _clientService;
        }

        public IActionResult Get()
        {
            var result = clientService.Get();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Client client)
        {
            var result = clientService.Post(client);
            return Ok(result);
        }

        [HttpPut]
        public IActionResult Put([FromBody] Client client)
        {
            var result = clientService.Put(client);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete([FromBody] Guid id)
        {
            var result = clientService.Delete(id);
            return Ok(result);
        }
    }
}
