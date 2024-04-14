using AspApplication.Application.BaseResponse;
using AspApplication.Application.Contracts;


namespace AspApplication.Application.Interfaces;

public interface IApplicationService
{
    Task<Response<ApplicationResponce>> Create(ApplicationDTO model);
    Task<Response> Delete(Guid id);
    Task<Response<ApplicationResponce>> Update(Guid id, ApplicationDTOUpdate model);
    Task<Response<ApplicationResponce>> Get(Guid id);
    Task<Response> UpdateSubmit(Guid id);
    Task<Response<List<ApplicationResponce>>> GetApplicationsAfterDate(DateTime date);
    Task<Response<List<ApplicationResponce>>> UnsubmittedOlder(DateTime date);
}
