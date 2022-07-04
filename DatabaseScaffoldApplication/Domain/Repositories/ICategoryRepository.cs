using DatabaseScaffoldApplication.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseScaffoldApplication.Domain.Models
{
    public interface ICategoryRepository: IRepository<Category>
    {
        List<Category> FilterByCategoryName(string cateoryName);
    }
}
