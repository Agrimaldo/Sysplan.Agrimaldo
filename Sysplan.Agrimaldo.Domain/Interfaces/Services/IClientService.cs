
using Sysplan.Agrimaldo.Domain.Entities;
using Sysplan.Agrimaldo.Domain.Models;
using System;
using System.Collections.Generic;

namespace Sysplan.Agrimaldo.Domain.Interfaces.Services
{
    public interface IClientService
    {
        ReturnStructure<List<Client>> Get();
        ReturnStructure<Client> Post(Client client);
        ReturnStructure<Client> Put(Client client);
        ReturnStructure<Client> Delete(Guid Id);

    }
}
