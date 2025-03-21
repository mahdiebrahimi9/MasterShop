using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.UserAgg.AddAddress;
using Shop.Application.UserAgg.Create;
using Shop.Application.UserAgg.Edit;
using Shop.Application.UserAgg.EditAddress;
using Shop.Application.UserAgg.Remove;
using Shop.Application.UserAgg.RemoveAddress;
using Shop.Query.Users.GetAddressById;
using Shop.Query.Users.GetAddressList;
using Shop.Query.Users.GetUserById;
using Shop.Query.Users.GetUserList;
using Shop.Query.Users.Login;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetUserList()
        {
            var query = await _mediator.Send(new GetUserLIstQuery());
            return Ok(query);
        }

        [HttpGet("[action]/{userId:long}")]
        public async Task<ActionResult> GetUserById(long userId)
        {
            var query = await _mediator.Send(new GetUserByIdQuery(userId));
            return Ok(query);
        }
        
      

        [HttpPut("[action]")]
        public async Task<ActionResult> EditUser(EditUserCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("[action]/{userId:long}")]
        public async Task<ActionResult> RemoveUserById(long userId)
        {
            await _mediator.Send(new RemoveUserCommand(userId));
            return Ok();
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetAddressListByUserId(long userId)
        {
            var query = await _mediator.Send(new GetAddressListQuery(userId));
            return Ok(query);
        }

        [HttpGet("[action]/{addressId:long}")]
        public async Task<ActionResult> GetAddressById(long addressId)
        {
            var query = await _mediator.Send(new GetAddressByIdQuery(addressId));
            return Ok(query);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> AddAddress(AddAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> EditAddress(EditAddressCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("[action]/{userId:long}/{addressId:long}")]
        public async Task<ActionResult> RemoveAddressById(long userId, long addressId)
        {
            await _mediator.Send(new RemoveAddressCommand(userId, addressId));
            return Ok();
        }
    }
}
