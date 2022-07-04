using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseScaffoldApplication.Services
{
    public interface IScopeService
    {
        public string Id { get; set; }

    }

    public class ScopeService: IScopeService
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

    }
}
