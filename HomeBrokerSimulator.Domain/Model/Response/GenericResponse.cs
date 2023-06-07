using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBrokerSimulator.Domain.Model.Response
{
    public class GenericResponse
    {
        public string message {get; set;}

        public GenericResponse(string message)
        {
            this.message = message;
        }
    }
}
