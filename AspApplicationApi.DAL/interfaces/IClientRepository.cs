using AspApplicationApi.Domain.Entity;
using AspApplicationApi.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspApplicationApi.DAL.interfaces
{
    public interface IClientRepository
    {
        Task<ApplicationResponce> GetUnSubmit(Guid id);
    }
}
