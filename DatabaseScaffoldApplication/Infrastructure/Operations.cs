using Microsoft.AspNetCore.Authorization.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DatabaseScaffoldApplication.Infrastructure
{
    public class Operations
    {
        public static OperationAuthorizationRequirement Detail = new OperationAuthorizationRequirement { Name = "Detail" };
        public static OperationAuthorizationRequirement Edit = new OperationAuthorizationRequirement { Name = "Edit" };
        public static OperationAuthorizationRequirement Save = new OperationAuthorizationRequirement { Name = "Save" };
        public static OperationAuthorizationRequirement Delete = new OperationAuthorizationRequirement { Name = "Delete" };
    }

}
