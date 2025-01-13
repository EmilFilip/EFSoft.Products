namespace EFSoft.Products.Api.GetProducts;

public class GetProductsRequestValidator : AbstractValidator<GetProductsRequest>
{
    public GetProductsRequestValidator()
    {
        _ = RuleFor(e => e.ProductIds)
            .Must(collection => collection?.Count() > 0)
            .WithMessage("ProductIds cannot be null")
            .Must(collection => collection != null)
            .WithMessage("Please specify at least one ProductsId");
    }
}
