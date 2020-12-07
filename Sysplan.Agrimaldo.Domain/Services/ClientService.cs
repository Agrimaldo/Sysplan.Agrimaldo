
using Sysplan.Agrimaldo.Domain.Entities;
using Sysplan.Agrimaldo.Domain.Interfaces.Repositories;
using Sysplan.Agrimaldo.Domain.Interfaces.Services;
using Sysplan.Agrimaldo.Domain.Models;
using System;
using System.Collections.Generic;

namespace Sysplan.Agrimaldo.Domain.Services
{
    public class ClientService : IClientService
    {
        protected IRepository repository { get; }

        public ClientService(IRepository _repository)
        {
            repository = _repository;
        }

        public ReturnStructure<Client> Delete(Guid Id)
        {
            var _client = repository.GetOne<Client>(false, a => a.Id.Equals(Id));

            if (_client == null)
                return ReturnStructure<Client>.Return(false, "Cliente não encontrado");

            var _result = repository.Delete<Client>(_client);

            if(_result.Success)
                return ReturnStructure<Client>.Return(true, "Cliente excluído com sucesso");
            else
                return ReturnStructure<Client>.Return(false, "Ocorreu um erro no processo de remoção");
        }

        public ReturnStructure<List<Client>> Get()
        {
            var _result = repository.List<Client>();
            return ReturnStructure<List<Client>>.Return(_result);
        }

        public ReturnStructure<Client> Post(Client client)
        {
            return repository.Add<Client>(client);
        }

        public ReturnStructure<Client> Put(Client client)
        {
            return repository.Update<Client>(client);
        }
    }
}
