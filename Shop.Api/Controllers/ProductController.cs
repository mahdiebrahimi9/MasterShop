using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Shop.Application.ProductAgg.AddAnswer;
using Shop.Application.ProductAgg.AddComment;
using Shop.Application.ProductAgg.AddFaq;
using Shop.Application.ProductAgg.AddImage;
using Shop.Application.ProductAgg.Create;
using Shop.Application.ProductAgg.Edit;
using Shop.Application.ProductAgg.EditComment;
using Shop.Application.ProductAgg.EditFaq;
using Shop.Application.ProductAgg.Remove;
using Shop.Application.ProductAgg.RemoveComment;
using Shop.Application.ProductAgg.RemoveFaq;
using Shop.Query.Products.GetCommentList;
using Shop.Query.Products.GetFaqList;
using Shop.Query.Products.GetProductById;
using Shop.Query.Products.GetProductList;
using Microsoft.AspNetCore.Authorization;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("[action]")]
        public async Task<ActionResult> GetProductList()
        {
            var query = await _mediator.Send(new GetProductListQuery());
            return Ok(query);
        }

        [HttpGet("[action]/{productId:long}")]
        public async Task<ActionResult> GetProductById(long productId)
        {

            var query = await _mediator.Send(new GetProductByIdQuery(productId));
            return Ok(query);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> AddProduct(CreateProductCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> EditProduct(EditProductCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("[action]/{productId:long}")]
        public async Task<ActionResult> RemoveProduct(long productId)
        {

            await _mediator.Send(new RemoveProductCommand(productId));
            return Ok();
        }

        [HttpGet("[action]/{productId:long}")]
        public async Task<ActionResult> GetCommentListByProductId(long productId)
        {
            var query = await _mediator.Send(new GetCommentListQuery(productId));
            return Ok(query);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> AddComment(AddCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> EditComment(EditCommentCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("[action]/{commentId:long}")]
        public async Task<ActionResult> RemoveComment(long commentId)
        {
            await _mediator.Send(new RemoveCommentCommand(commentId));
            return Ok();
        }

        [HttpGet("[action]/{productId:long}")]
        public async Task<ActionResult> GetFaqListByProductId(long productId)
        {
            var query = await _mediator.Send(new GetFaqListQuery(productId));
            return Ok(query);
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> AddFaq(AddFaqCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPut("[action]")]
        public async Task<ActionResult> EditFaq(EditFaqCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpDelete("[action]/{faqId:long}")]
        public async Task<ActionResult> RemoveFaq(long faqId)
        {
            await _mediator.Send(new RemoveFaqCommand(faqId));
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> AddAnswer(AddAnswerCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<ActionResult> AddProductImage(AddImageCommand command)
        {
            await _mediator.Send(command);
            return Ok();
        }
    }
}
