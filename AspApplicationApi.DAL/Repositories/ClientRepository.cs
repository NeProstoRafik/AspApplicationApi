using AspApplicationApi.DAL.interfaces;
using AspApplicationApi.Domain.Entity;
using AspApplicationApi.Domain.ViewModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspApplicationApi.DAL.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ApplicationResponce> GetUnSubmit(Guid client)
        {
            var IsUnSubmit= _context.AllApplications
                   .Any(x => x.Autor == client && x.Submit == false);
            if (IsUnSubmit)
            {
                var application = await _context.AllApplications.FirstOrDefaultAsync(x => x.Autor == client);
                var applicationFromClient = new ApplicationResponce
                {
                    Id = application.Id,
                    Autor = application.Autor,
                    Description = application.Description,
                    Name = application.Name,
                    Outline = application.Outline,
                    Type = application.Type,
                };
                return applicationFromClient;
            }
            return null;
            
        }
     
    }
}
