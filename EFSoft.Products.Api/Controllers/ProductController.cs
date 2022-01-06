namespace EFSoft.Products.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController : ControllerBase
{
    private readonly ICommandExecutor _commandExecutor;
    private readonly IQueryExecutor _queryExecutor;

    public ProductController(
            ICommandExecutor commandExecutor,
            IQueryExecutor queryExecutor)
    {
        _commandExecutor = commandExecutor
            ?? throw new ArgumentNullException(nameof(commandExecutor));
        _queryExecutor = queryExecutor
            ?? throw new ArgumentNullException(nameof(queryExecutor));

    }

    [HttpGet]
    [Route("{productId:guid}")]
    [ProducesResponseType(typeof(GetProductQueryResult), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid productId)
    {
        var results = await _queryExecutor.ExecuteAsync<GetProductQueryParameters, GetProductQueryResult>(
         new GetProductQueryParameters(productId));

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
    public async Task<IActionResult> Post([FromBody] CreateProductCommandParameters parameters)
    {
        await _commandExecutor.ExecuteAsync(parameters);

        return Ok();
    }

    [HttpPut()]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Put([FromBody] UpdateProductCommandParameters parameters)
    {
        await _commandExecutor.ExecuteAsync(parameters);

        return Ok();
    }

    [HttpDelete()]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Delete([FromBody] DeleteProductCommandParameters parameters)
    {
        await _commandExecutor.ExecuteAsync(parameters);

        return Ok();
    }
}
