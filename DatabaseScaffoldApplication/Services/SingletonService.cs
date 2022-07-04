using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseScaffoldApplication.Services
{
    public interface ISingletonService
    {
        public string Id { get; set; }

    }

    public class SingletonService: ISingletonService
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

    }
}
