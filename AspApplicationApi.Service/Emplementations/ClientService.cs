using AspApplicationApi.DAL.interfaces;
using AspApplicationApi.DAL.Repositories;
using AspApplicationApi.Domain.Entity;
using AspApplicationApi.Domain.ViewModel;
using AspApplicationApi.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspApplicationApi.Service.Emplementations
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;
        private ILogger<ClientService> _logger;

        public ClientService(IClientRepository clientRepository, ILogger<ClientService> logger = null)
        {
            _clientRepository = clientRepository;
            _logger = logger;
        }

        public async Task<ApplicationResponce> GetUnSubmit(Guid client)
        {
            try
            {
                _logger.LogInformation($"вывод заявок по ИД");

                var application = await _clientRepository.GetUnSubmit(client);
                return application;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"у докладчика нет заявок или нет клиента");
            }
            return null;
        }
    }
}
