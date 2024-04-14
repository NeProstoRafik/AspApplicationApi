using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AspApplication.Domain.Enum
{
    public enum StatusCode
    {
        Error = 0,
        OK = 200,
        BadRequest=400,
        NotFound = 404,  
        InternalServerError = 500,
    }
}
