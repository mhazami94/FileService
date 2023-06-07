using FileService.Application.Core.CQRS.QueryHandling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileService.Application.Owner.AuthenticateOwner
{
    public class AuthenticateOwnerQueryHandler : QueryHandler<AuthenticateOwnerQuery, OwnerViewModel>
    {
        public AuthenticateOwnerQueryHandler()
        {

        }
        public override Task<OwnerViewModel> ExecuteQuery(AuthenticateOwnerQuery query, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
