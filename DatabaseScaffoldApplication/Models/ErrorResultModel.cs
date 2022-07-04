using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseScaffoldApplication.Models
{
    public class ErrorResultModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
    }

}
