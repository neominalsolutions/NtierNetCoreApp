using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseScaffoldApplication.Services
{
    public interface ITransientService
    {
        public string Id { get; set; }

    }

    public class TransientService: ITransientService
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

    }
}
