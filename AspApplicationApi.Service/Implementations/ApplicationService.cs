using AspApplication.Application.BaseResponse;
using AspApplication.Application.Contracts;
using AspApplication.Application.Converter;
using AspApplication.Application.Interfaces;
using AspApplication.DataAccess.interfaces;
using FluentValidation;

namespace AspApplication.Application.Implementations;

public class ApplicationService : IApplicationService
{
    private readonly IApplicationRepository _applicationRepository;
    private readonly IValidator<ApplicationDTO> _validatorCreate;
    private readonly IValidator<ApplicationDTOUpdate> _validatorUpdate;
    private readonly IValidator<AspApplication.Domain.Entity.Application> _validatorSubmit;

    public ApplicationService(IApplicationRepository applicationRepository, IValidator<ApplicationDTO> validatorCreate, IValidator<ApplicationDTOUpdate> validatorUpdate, IValidator<Domain.Entity.Application> validatorSubmit)
    {
        _applicationRepository = applicationRepository;
        _validatorCreate = validatorCreate;
        _validatorUpdate = validatorUpdate;
        _validatorSubmit = validatorSubmit;
    }

    public async Task<Response<ApplicationResponce>> Create(ApplicationDTO model)
    {
        var baseResponse = new Response<ApplicationResponce>();
        var result = _validatorCreate.Validate(model);
        if (result.IsValid is false)
        {
            baseResponse.Errors = result.ToString();
            return baseResponse;
        }
        var client = await _applicationRepository.GetApplicationForClientIdAsync(model.Author);

        if (client != null)
        {
            baseResponse.StatusCode = AspApplication.Domain.Enum.StatusCode.BadRequest;
            baseResponse.Errors = "у пользователя может быть только одна не отправленная заявка";
            return baseResponse;
        }
        var allApplication = ApplicationConverter.ConvertToApplication(model);
        var application = ApplicationConverter.ConvertToApplicationResponse(allApplication);

        await _applicationRepository.CreateAsync(allApplication);
        SetOkAndDataResponse(application, baseResponse);

        return baseResponse;
    }

    public async Task<Response> Delete(Guid id)
    {
        var application = await _applicationRepository.GetAsync(id);
        var baseResponse = new Response();
        if (application == null)
        {
            baseResponse.StatusCode = Domain.Enum.StatusCode.NotFound;
            baseResponse.Errors = "Заявка не найдена";
            return baseResponse;
        }
        if (application.Submit == true)
        {
            baseResponse.StatusCode = Domain.Enum.StatusCode.BadRequest;
            baseResponse.Errors = "нельзя отменить / удалить заявки отправленные на рассмотрение";
            return baseResponse;
        }
        await _applicationRepository.Delete(application);
        baseResponse.StatusCode = Domain.Enum.StatusCode.OK;

        return baseResponse;
    }

    public async Task<Response<ApplicationResponce>> Get(Guid id)
    {
        var application = await _applicationRepository.GetAsync(id);
        var baseResponse = new Response<ApplicationResponce>();
        if (application == null)
        {
            baseResponse.StatusCode = Domain.Enum.StatusCode.NotFound;
            baseResponse.Errors = "Заявка не найдена";
            return baseResponse;
        }
        var app = ApplicationConverter.ConvertToApplicationResponse(application);

        SetOkAndDataResponse(app, baseResponse);
        return baseResponse;
    }

    public async Task<Response<ApplicationResponce>> Update(Guid id, ApplicationDTOUpdate model)
    {
        var baseResponse = new Response<ApplicationResponce>();
        var result = _validatorUpdate.Validate(model);
        if (result.IsValid is false)
        {
            baseResponse.Errors = result.ToString();
            return baseResponse;
        }

        var application = await _applicationRepository.GetAsync(id);
        if (application == null)
        {
            baseResponse.StatusCode = Domain.Enum.StatusCode.NotFound;
            baseResponse.Errors = "Заявка не найдена";
            return baseResponse;
        }

        if (application.Submit == true)
        {
            baseResponse.StatusCode = Domain.Enum.StatusCode.BadRequest;
            baseResponse.Errors = "нельзя редактировать отправленные на рассмотрение заявки";
            return baseResponse;
        }

        application.Name = model.Name;
        application.Description = model.Description;
        application.Outline = model.Outline;
        application.Type = model.Type;

        await _applicationRepository.Update(application);

        var appResponse = ApplicationConverter.ConvertToApplicationResponse(application);
        SetOkAndDataResponse(appResponse, baseResponse);

        return baseResponse;
    }

    public async Task<Response> UpdateSubmit(Guid id)
    {
        var baseResponse = new Response();
        var application = await _applicationRepository.GetAsync(id);
        if (application == null)
        {
            baseResponse.StatusCode = Domain.Enum.StatusCode.NotFound;
            baseResponse.Errors = "Заявка не найдена";
            return baseResponse;
        }

        var result = _validatorSubmit.Validate(application);
        if (result.IsValid is false)
        {
            baseResponse.Errors = result.ToString();
            return baseResponse;
        }

        application.Submit = true;
        await _applicationRepository.Update(application);
        baseResponse.StatusCode = Domain.Enum.StatusCode.OK;

        return baseResponse;
    }

    public async Task<Response<List<ApplicationResponce>>> GetApplicationsAfterDate(DateTime date)
    {
        var listApplications = new List<ApplicationResponce>();
        var baseResponse = new Response<List<ApplicationResponce>>();
        var list = await _applicationRepository.GetApplicationsAfterDateAsync(date);
        if (list == null || list.Count == 0)
        {
            baseResponse.StatusCode = Domain.Enum.StatusCode.NotFound;
            baseResponse.Errors = "Заявки не найдена";
            return baseResponse;
        }

        foreach (var app in list)
        {
            var application = ApplicationConverter.ConvertToApplicationResponse(app);
            listApplications.Add(application);
        }

        SetOkAndDataListResponse(listApplications, baseResponse);

        return baseResponse;
    }

    public async Task<Response<List<ApplicationResponce>>> UnsubmittedOlder(DateTime date)
    {
        var baseResponse = new Response<List<ApplicationResponce>>();
        var listApplications = new List<ApplicationResponce>();

        var list = await _applicationRepository.UnsubmittedOlderAsync(date);
        if (list == null || list.Count == 0)
        {
            baseResponse.StatusCode = Domain.Enum.StatusCode.NotFound;
            baseResponse.Errors = "Заявки не найдена";
            return baseResponse;
        }

        foreach (var app in list)
        {
            var application = ApplicationConverter.ConvertToApplicationResponse(app);
            listApplications.Add(application);
        }
        SetOkAndDataListResponse(listApplications, baseResponse);

        return baseResponse;
    }

    private void SetOkAndDataResponse(ApplicationResponce appResponce, Response<ApplicationResponce> response)
    {
        response.StatusCode = Domain.Enum.StatusCode.OK;
        response.Data = appResponce;
    }

    private void SetOkAndDataListResponse(List<ApplicationResponce> listappResponce, Response<List<ApplicationResponce>> response)
    {
        response.StatusCode = Domain.Enum.StatusCode.OK;
        response.Data = listappResponce;
    }
}
