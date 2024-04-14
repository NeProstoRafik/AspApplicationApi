using AspApplication.DataAccess.interfaces;
using AspApplication.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace AspApplication.DataAccess.Repositories;

public class ApplicationRepository : IApplicationRepository
{
    private readonly ApplicationDbContext _context;

    public ApplicationRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Application entity)
    {
        await _context.AllApplications.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task Delete(Application entity)
    {
        _context.AllApplications.Remove(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<Application?> GetAsync(Guid id)
    {
        return await _context.AllApplications.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Application?> GetApplicationForClientIdAsync(Guid id)
    {
        return await _context.AllApplications.Where(x => x.Submit == false).FirstOrDefaultAsync(x => x.Autor == id);

    }

    public async Task<Application> Update(Application entity)
    {
        _context.AllApplications.Update(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<List<Application>> GetApplicationsAfterDateAsync(DateTime date)
    {
        return await _context.AllApplications.Where(a => a.DateTime > date.ToUniversalTime())
            .Where(x => x.Submit == true).AsNoTracking().ToListAsync();

    }

    public async Task<List<Application>> UnsubmittedOlderAsync(DateTime date)
    {
        return await _context.AllApplications.Where(a => a.DateTime < date.ToUniversalTime())
            .Where(x => x.Submit == false).AsNoTracking().ToListAsync();
    }
}
