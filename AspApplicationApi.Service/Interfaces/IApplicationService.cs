using AspApplicationApi.Domain.Entity;
using AspApplicationApi.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspApplicationApi.Service.Interfaces
{
    public interface IApplicationService
    {
        Task<ApplicationResponce> Create(ApplicationDTO model);
        Task<bool> Delete(Guid id);
        Task<ApplicationResponce> Update(Guid id, ApplicationDTOUpdate model);
        Task<ApplicationResponce> Get(Guid id);
        Task<bool> UpdateSubmid(Guid id);
        Task<List<ApplicationResponce>> GetApplicationsAfterDate(DateTime date);
        Task<List<ApplicationResponce>> UnsubmittedOlder(DateTime date);
    }
}
