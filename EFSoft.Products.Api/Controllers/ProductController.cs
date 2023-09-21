namespace EFSoft.Products.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly IMediator _mediator;

    public ProductController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("{productId:guid}")]
    [ProducesResponseType(typeof(GetProductQueryResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid productId)
    {
        var results = await _mediator.Send(new GetProductQuery(productId));

        if (results == null)
        {
            return NotFound();
        }

        return Ok(results);
    }

    [HttpGet]
    [ProducesResponseType(typeof(List<GetProductQueryResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get()
    {
        return Ok("Products microservice is working fine");
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Post([FromBody] CreateProductCommand parameters)
    {
        await _mediator.Send(parameters);

        return Ok();
    }

    [HttpPut()]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Put([FromBody] UpdateProductCommand parameters)
    {
        await _mediator.Send(parameters);

        return Ok();
    }

    [HttpDelete()]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete(Guid productId)
    {
        await _mediator.Send(new GetProductQuery(productId));

        return Ok();
    }
}
