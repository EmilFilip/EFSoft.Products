namespace EFSoft.Products.Api.UpdateProduct;

public class UpdateProductValidator : AbstractValidator<UpdateProductRequest>
{
    public UpdateProductValidator()
    {
        _ = RuleFor(e => e.ProductId)
            .NotNull().WithMessage("ProductId cannot be null")
            .NotEmpty().WithMessage("ProductId cannot be empty");

        _ = RuleFor(e => e.Description)
            .NotNull().WithMessage("Description cannot be null")
            .NotEmpty().WithMessage("Description cannot be empty");
    }
}
