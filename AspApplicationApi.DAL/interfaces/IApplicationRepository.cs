using AspApplication.Domain.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspApplication.DataAccess.interfaces;

public interface IApplicationRepository
{
    Task CreateAsync(Application entity);
    Task<Application?> GetAsync(Guid id); 						  
    Task Delete(Application entity);
    Task<Application> Update(Application entity);            
    Task<List<Application>> GetApplicationsAfterDateAsync(DateTime date);
    Task<List<Application>> UnsubmittedOlderAsync(DateTime date);
    Task<Application> GetApplicationForClientIdAsync(Guid id);
}
