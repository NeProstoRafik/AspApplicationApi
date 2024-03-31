using AspApplicationApi.Domain.Entity;
using AspApplicationApi.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspApplicationApi.Service.Interfaces
{
    public interface IClientService
    {
        Task<ApplicationResponce> GetUnSubmit(Guid client);
    }
}
