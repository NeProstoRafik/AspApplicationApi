using AspApplication.Domain.Entity;

namespace AspApplication.DataAccess.interfaces;

public interface IClientRepository
{
    Task<Application?> GetUnsubmit(Guid id);
}
