using Microsoft.AspNetCore.Mvc;
using AutomobileRentalManagementAPI.Domain.DomainEntities;
using AutomobileRentalManagementAPI.Application.MessageQueue.Interfaces;

namespace AutomobileRentalManagementAPI.Presentation.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
    //public class UsersController : ControllerBase
    //{
    //    private readonly IUserPublisher _userPublisher;

    //    public UsersController(IUserPublisher userPublisher)
    //    {
    //        _userPublisher = userPublisher;
    //    }

    //    [HttpPost("publish")]
    //    public async Task<IActionResult> PublishUser([FromBody] UserDomain user)
    //    {
    //        await _userPublisher.PublishAsync(user);
    //        return Ok("User sent to queue successfully!");
    //    }
    //}
}
