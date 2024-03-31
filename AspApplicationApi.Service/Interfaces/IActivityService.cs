using AspApplicationApi.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspApplicationApi.Service.Interfaces
{
    public interface IActivityService
    {
        List<TypeActivity> GetAllActivity();
    }
}
