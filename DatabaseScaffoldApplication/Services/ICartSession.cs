using DatabaseScaffoldApplication.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseScaffoldApplication.Services
{
   public interface ICartSession
    {
        void Set(Cart cart);
        void Clear();
        Cart Get();
        
    }
}
