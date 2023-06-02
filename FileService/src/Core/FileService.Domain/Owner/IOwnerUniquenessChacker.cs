using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileService.Domain.Owner
{
    public interface IOwnerUniquenessChacker
    {
        Task<bool> IsOwnerUnique(string email);
    }
}
