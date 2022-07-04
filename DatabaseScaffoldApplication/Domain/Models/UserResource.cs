using DatabaseScaffoldApplication.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseScaffoldApplication.Domain.Models
{
    public class UserResource
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }

        public string ApplicationUserId { get; set; }

    }
}
