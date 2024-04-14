using AspApplication.Application.BaseResponse;
using AspApplication.Application.Contracts;

namespace AspApplication.Application.Interfaces;

public interface IClientService
{
    Task<Response<ApplicationResponce>> GetUnsubmit(Guid client);
}
