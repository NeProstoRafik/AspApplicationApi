using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspApplicationApi.Domain.Entity;


namespace AspApplicationApi.DAL.interfaces
{
    public interface IApplicationRepository
    {
        Task Create(AllApplications entity);
        Task<AllApplications> Get(Guid id); 						  
        Task Delete(AllApplications entity);
        Task<AllApplications> Update(AllApplications entity);      
        Task<AllApplications> SendToSubmid(AllApplications entity);
        Task<List<AllApplications>> GetApplicationsAfterDate(DateTime date);
        Task<List<AllApplications>> UnsubmittedOlder(DateTime date);
        Task<AllApplications> GetClientId(Guid id);
    }
}
