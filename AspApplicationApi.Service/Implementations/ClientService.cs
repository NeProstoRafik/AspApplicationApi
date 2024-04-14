using AspApplication.Application.BaseResponse;
using AspApplication.Application.Contracts;
using AspApplication.Application.Converter;
using AspApplication.Application.Interfaces;
using AspApplication.DataAccess.interfaces;

namespace AspApplication.Application.Implementations;

public class ClientService : IClientService
{
    private readonly IClientRepository _clientRepository;


    public ClientService(IClientRepository clientRepository)
    {
        _clientRepository = clientRepository;
    }

    public async Task<Response<ApplicationResponce>> GetUnsubmit(Guid client)
    {
        var baseResponse = new Response<ApplicationResponce>();
        var application = await _clientRepository.GetUnsubmit(client);
        if (application == null)
        {
            baseResponse.StatusCode = AspApplication.Domain.Enum.StatusCode.NotFound;
            baseResponse.Errors = "Автор не найден или у него нет заявок";
            return baseResponse;
        }
        var applicationResponce = ApplicationConverter.ConvertToApplicationResponse(application);
        
        baseResponse.StatusCode = AspApplication.Domain.Enum.StatusCode.OK;
        baseResponse.Data = applicationResponce;
        return baseResponse;
    }
}
