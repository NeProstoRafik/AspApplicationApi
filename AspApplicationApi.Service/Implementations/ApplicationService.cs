using AspApplicationApi.DAL.interfaces;
using AspApplicationApi.Domain.Entity;
using AspApplicationApi.Domain.ViewModel;
using AspApplicationApi.Service.Interfaces;
using Microsoft.Extensions.Logging;
using static System.Net.Mime.MediaTypeNames;

namespace AspApplicationApi.Service.Emplementations
{
    public class ApplicationService : IApplicationService
    {
        private readonly IApplicationRepository _applicationRepository;
        private ILogger<ApplicationService> _logger;
        public ApplicationService(IApplicationRepository applicationRepository, ILogger<ApplicationService> logger)
        {
            _applicationRepository = applicationRepository;
            _logger = logger;
        }

        public async Task<ApplicationResponce> Create(ApplicationDTO model)
        {
            try
            {
                var client = await _applicationRepository.GetApplicationForClientIdAsync(model.Autor);
                if (client != null)
                {
                    return null;
                }
                var allApplication = new AllApplications()
                {
                    Autor = model.Autor,
                    Type = model.Type,
                    Description = model.Description,
                    Name = model.Name,
                    Outline = model.Outline,
                };
                var application = new ApplicationResponce()
                {
                    Autor = model.Autor,
                    Type = model.Type,
                    Description = model.Description,
                    Name = model.Name,
                    Outline = model.Outline,
                    Id = allApplication.Id,
                };
               
                await _applicationRepository.CreateAsync(allApplication);
                _logger.LogInformation($"заявка создана");
                return application;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"не создалась");
            }
            return null;
        }

        public async Task<bool> Delete(Guid id)
        {
            try
            {
                var application = await _applicationRepository.GetAsync(id);
              
                if (application == null || application.Submit == true)
                {
                    _logger.LogInformation($"заявку нельзя удалять");
                    return false;
                }
                await _applicationRepository.Delete(application);
                _logger.LogInformation($"заявка удаленна");
                return true;
             

            }
            catch (Exception ex)
            {
                _logger.LogInformation($"ошибка удаления");
            }
            return false;
        }

        public async Task<ApplicationResponce> Get(Guid id)
        {
            try
            {
               
                var application = await _applicationRepository.GetAsync(id);
                var app = new ApplicationResponce
                {
                    Id = application.Id,
                    Description = application.Description,
                    Name = application.Name,
                    Autor = application.Autor,
                    Outline = application.Outline,
                    Type = application.Type,
                };
                _logger.LogInformation($"заявка получена по ИД");
                return app;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"заявка не сущесвтует");
            }
            return null;
        }

        public async Task<ApplicationResponce> Update(Guid id, ApplicationDTOUpdate model)
        {
            try
            {
                var application = await _applicationRepository.GetAsync(id);
                if (application == null || application.Submit==true)
                {
                    _logger.LogInformation($"заявку нельзя изменять");
                    return null;
                }
                application.Name = model.Name;
                application.Description = model.Description;
                application.Outline = model.Outline;
              
                await _applicationRepository.Update(application);
                _logger.LogInformation($"заявка обновлена");
                var appResponce = new ApplicationResponce
                {
                    Description = application.Description,
                    Autor = application.Autor,
                    Id = id,
                    Name = model.Name,
                    Outline = model.Outline,
                    Type = application.Type,
                };
                return appResponce;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"заявка не обновлена");
            }
            return null;
        }

        public async Task<bool> UpdateSubmid(Guid id)
        {
            try
            {
                var application = await _applicationRepository.GetAsync(id);
                if (application==null)
                {
                    return false;
                }
                application.Submit = true;
                await _applicationRepository.Update(application);
                _logger.LogInformation($"заявка получила одобрение");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"заявка не обновлена");
                return false;
            }
         
        }

        public async Task<List<ApplicationResponce>> GetApplicationsAfterDate(DateTime date)
        {
            var listApplications = new List<ApplicationResponce>();
            try
            {
                var list = await _applicationRepository.GetApplicationsAfterDateAsync(date);
                       
                foreach (var app in list)
                {
                    var application = new ApplicationResponce();
                    application.Autor = app.Autor;
                    application.Id = app.Id;
                    application.Name = app.Name;
                    application.Outline = app.Outline;
                    application.Description = app.Description;
                    application.Type = app.Type;
                    listApplications.Add(application);
                }
                return listApplications;
                _logger.LogInformation($"все заявки после даты");
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"нет заявок");
            }
            return listApplications;
        }
        public async Task<List<ApplicationResponce>> UnsubmittedOlder(DateTime date)
        {
            var listApplications = new List<ApplicationResponce>();
            try
            {
                var list = await _applicationRepository.UnsubmittedOlderAsync(date);

                foreach (var app in list)
                {
                    var application = new ApplicationResponce();
                    application.Autor = app.Autor;
                    application.Id = app.Id;
                    application.Name = app.Name;
                    application.Description = app.Description;
                    application.Outline = app.Outline;
                    application.Type = app.Type;
                    listApplications.Add(application);
                }
                _logger.LogInformation($"заявки до даты и не отправленные");
                return listApplications;
            
            }
            catch (Exception ex)
            {
                _logger.LogInformation($"нет заявок");
            }
            return listApplications;
        }
    }
}
