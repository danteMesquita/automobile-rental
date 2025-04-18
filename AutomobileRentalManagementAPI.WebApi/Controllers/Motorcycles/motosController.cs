using AutoMapper;
using AutomobileRentalManagementAPI.Application.Features.Motorcycles.CreateMotorcycle;
using AutomobileRentalManagementAPI.Application.Features.Motorcycles.DeleteMotorcycle;
using AutomobileRentalManagementAPI.Application.Features.Motorcycles.GetMotorcycle;
using AutomobileRentalManagementAPI.Application.Features.Motorcycles.UpdateMotorcycle;
using AutomobileRentalManagementAPI.WebApi.Common;
using AutomobileRentalManagementAPI.WebApi.Controllers.Motorcycles.Create;
using AutomobileRentalManagementAPI.WebApi.Controllers.Motorcycles.Get;
using AutomobileRentalManagementAPI.WebApi.Controllers.Motorcycles.Put;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AutomobileRentalManagementAPI.WebApi.Controllers.Motorcycles
{
    public class motosController : BaseController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public motosController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateMotorcycleRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await new CreateMotorcycleRequestValidator().ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            var command = _mapper.Map<CreateMotorcycleCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Created(string.Empty, new ApiResponseWithData<CreateMotorcycleResponse>
            {
                Success = true,
                mensagem = "Motorcycle created successfully", // TODO: Ajustar mensagens para ficar igual a do swagger deles
                Data = _mapper.Map<CreateMotorcycleResponse>(response)
            });
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<GetMotorcycleResponse>), StatusCodes.Status200OK)]
        public async Task<IActionResult> Get([FromQuery] GetMotorcycleRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await new GetMotorcycleRequestValidator().ValidateAsync(request, cancellationToken);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            var command = _mapper.Map<GetMotorcycleCommand>(request.placa);
            var response = await _mediator.Send(command, cancellationToken);
            var responseMap = _mapper.Map<GetMotorcycleResponse>(response);

            return Ok(responseMap);
        }

        [HttpPut("{id}/placa")]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Put([FromRoute] string id, [FromBody] UpdateMotorcycleRequest request, CancellationToken cancellationToken)
        {
            var validationResult = await new UpdateMotorcycleRequestValidator().ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid) return BadRequest(validationResult.Errors);

            var command = _mapper.Map<UpdateMotorcycleCommand>(request);
            var response = await _mediator.Send(command, cancellationToken);

            return Ok(new ApiResponse()
            {
                mensagem = "Placa modificada com sucesso"
            });
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(GetMotorcycleResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Get([FromRoute] string id, CancellationToken cancellationToken)
        {
            Guid navigationId = Guid.Parse(id);

            var command = _mapper.Map<GetMotorcycleCommand>(navigationId);
            var response = await _mediator.Send(command, cancellationToken);
            var mappedResponse = _mapper.Map<GetMotorcycleResponse>(response);

            return Ok(mappedResponse);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Delete([FromRoute] string id, CancellationToken cancellationToken)
        {
            Guid navigationId = Guid.Parse(id);

            var command = _mapper.Map<DeleteMotorcycleCommand>(navigationId);
            await _mediator.Send(command, cancellationToken);

            return Ok();
        }
    }
}