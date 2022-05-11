using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasterDataAPITest.Data
{
    internal class GenericErrorResponse
    {
        public Guid CRI { get; set; }
        public string? FailureCode { get; set; }
    }
}