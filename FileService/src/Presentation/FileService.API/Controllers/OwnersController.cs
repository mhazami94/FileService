using AutoMapper;
using FileService.API.Controllers.Base;
using FileService.Application.Owner;
using FileService.Application.Owner.AuthenticateOwner;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FileService.API.Controllers
{
    [Route("api/owners")]
    [Authorize]
    public class OwnersController : BaseController
    {
        private readonly IMapper _mapper;

        protected OwnersController(IMediator mediator, IMapper mapper) : base(mediator)
        {
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost, Route("login")]
        [ProducesResponseType(typeof(OwnerViewModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromBody] AuthenticateOwnerRequest request)
        {
            var query = new AuthenticateOwnerQuery(request.Email, request.Password);
            return await Response(query);
        }
    }
}
