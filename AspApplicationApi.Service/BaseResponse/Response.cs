using AspApplication.Domain.Enum;

namespace AspApplication.Application.BaseResponse;

public class Response<T>
{    
    public string? Errors { get; set; }
    public StatusCode StatusCode { get; set; }
    public T? Data { get; set; }

}
public class Response 
{
    public string? Errors { get; set; }
    public StatusCode StatusCode { get; set; } 

}