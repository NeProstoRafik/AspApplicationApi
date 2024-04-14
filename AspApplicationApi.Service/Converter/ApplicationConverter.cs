using AspApplication.Application.Contracts;

namespace AspApplication.Application.Converter;

public class ApplicationConverter
{
    public static ApplicationResponce ConvertToApplicationResponse(AspApplication.Domain.Entity.Application application)
    {
        return new ApplicationResponce()
        {
            Author = application.Autor,
            Description = application.Description,
            Id = application.Id,
            Name = application.Name,
            Outline = application.Outline,
            Type = application.Type,
        };
    }
    public static AspApplication.Domain.Entity.Application ConvertToApplication(ApplicationDTO model)
    {
        return new AspApplication.Domain.Entity.Application()
        {
            Autor = model.Author,
            Type = model.Type,
            Description = model.Description,
            Name = model.Name,
            Outline = model.Outline,
        };
    }
}
