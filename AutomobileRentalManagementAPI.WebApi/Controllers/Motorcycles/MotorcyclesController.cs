using AutoMapper;
using AutomobileRentalManagementAPI.Application.Motorcycles.CreateMotorcycle;
using AutomobileRentalManagementAPI.WebApi.Common;
using AutomobileRentalManagementAPI.WebApi.Controllers.Motorcycles.Create;
using AutomobileRentalManagementAPI.WebApi.Controllers.Motorcycles.Get;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutomobileRentalManagementAPI.WebApi.Controllers.Motorcycles
{
    public class MotorcyclesController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public MotorcyclesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ApiResponseWithData<CreateMotorcycleResponse>), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Create([FromBody] CreateMotorcycleRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await new CreateMotorcycleRequestValidator().ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateMotorcycleCommand> (request);
            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<CreateMotorcycleResponse>
            {
                Success = true,
                Message = "Motorcycle created successfully",
                Data = _mapper.Map<CreateMotorcycleResponse> (response)
            });
        }

        //[HttpGet("{licensePlate}")]
        //[ProducesResponseType(typeof(ApiResponseWithData<GetMotorcycleResponse>), StatusCodes.Status200OK)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        //public async Task<IActionResult> GetMotorcycle([FromRoute] string licensePlate, CancellationToken cancellationToken)
        //{
        //    var request = new GetMotorcycleRequest { LicensePlate = licensePlate };
        //    var validationResult = await new GetMotorcycleRequestValidator().ValidateAsync(request, cancellationToken);

        //    if (!validationResult.IsValid)
        //        return BadRequest(validationResult.Errors);

        //    var command = _mapper.Map<GetMotorcycleCommand>(request.LicensePlate);
        //    var response = await _mediator.Send(command, cancellationToken);

        //    return Ok(new ApiResponseWithData<GetMotorcycleResponse>
        //    {
        //        Success = true,
        //        Message = "Motorcycle retrieved successfully",
        //        Data = _mapper.Map<GetMotorcycleResponse>(response)
        //    });
        //}

    }
}
