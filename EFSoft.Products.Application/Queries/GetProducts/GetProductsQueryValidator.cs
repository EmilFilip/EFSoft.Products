namespace EFSoft.Products.Application.Queries.GetProducts;

public class GetProductsQueryValidator : AbstractValidator<GetProductsQuery>
{
    public GetProductsQueryValidator()
    {
        RuleFor(e => e.ProductIds)
            .Must(collection => collection == null || collection.All(item => !string.IsNullOrEmpty(item.ToString())))
            .WithMessage("Please specify at least one CustomerId");
    }
}
