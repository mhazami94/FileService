using FileService.Domain.Owner;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileService.Application.Owner
{
    public class OwnerUniquenessChacker : IOwnerUniquenessChacker
    {
        public Task<bool> IsOwnerUnique(string email)
        {
            throw new NotImplementedException();
        }
    }
}
