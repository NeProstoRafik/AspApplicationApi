using AspApplication.Domain.Entity;

namespace AspApplication.Application.Interfaces;

public interface IActivityService
{
    List<TypeActivity> GetAllActivity();
}
