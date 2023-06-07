using AutoMapper;
using FileService.API.Controllers.Base;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FileService.API.Controllers
{
    [Route("api/files")]
    public class FilesController : BaseController
    {
        private readonly IMapper _mapper;

        protected FilesController(IMediator mediator, IMapper mapper) : base(mediator)
        {
            _mapper = mapper;
        }


    }
}
