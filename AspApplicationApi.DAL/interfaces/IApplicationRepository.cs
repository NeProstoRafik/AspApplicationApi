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
        Task CreateAsync(AllApplications entity);
        Task<AllApplications> GetAsync(Guid id); 						  
        Task Delete(AllApplications entity);
        Task<AllApplications> Update(AllApplications entity);            
        Task<List<AllApplications>> GetApplicationsAfterDateAsync(DateTime date);
        Task<List<AllApplications>> UnsubmittedOlderAsync(DateTime date);
        Task<AllApplications> GetApplicationForClientIdAsync(Guid id);
    }
}
