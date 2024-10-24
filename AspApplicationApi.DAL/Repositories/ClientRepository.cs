using AspApplication.DataAccess.interfaces;
using AspApplication.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace AspApplication.DataAccess.Repositories;

public class ClientRepository : IClientRepository
{
    private readonly ApplicationDbContext _context;

    public ClientRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Application?> GetUnsubmit(Guid client)
    {
        var application = await _context.AllApplications
                                   .Where(x => x.Submit == false)
                                   .FirstOrDefaultAsync(x => x.Autor == client);
        if (application == null)
            return null;

        return application;      
    }
}
