using AspApplicationApi.DAL.interfaces;
using AspApplicationApi.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AspApplicationApi.DAL.Repositories
{
    public class ApplicationRepository : IApplicationRepository
    {
        private readonly ApplicationDbContext _context;

        public ApplicationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Create(AllApplications entity)
        {
            await _context.AllApplications.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(AllApplications entity)
        {
            _context.AllApplications.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<AllApplications> Get(Guid id)
        {
            return await _context.AllApplications.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<AllApplications> GetClientId(Guid id)
        {
            return await _context.AllApplications.Where(x=>x.Submit==false).FirstOrDefaultAsync(x => x.Autor == id);
          
        }
        public async Task<AllApplications> Update(AllApplications entity)
        {
            _context.AllApplications.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
      
        public async Task<AllApplications> SendToSubmid(AllApplications entity)
        {
            _context.AllApplications.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<List<AllApplications>> GetApplicationsAfterDate(DateTime date)
        {
            return await _context.AllApplications.Where(a => a.DateTime > date).ToListAsync();
           
        }
        public async Task<List<AllApplications>> UnsubmittedOlder(DateTime date)
        {
            return await _context.AllApplications.Where(a => a.DateTime < date)
                .Where(x=>x.Submit==false).ToListAsync();
        }
    }
}
