namespace EFSoft.Products.Api.CreateProduct;

public class CreateProductRequestValidator : AbstractValidator<CreateProductRequest>
{
    public CreateProductRequestValidator()
    {
        _ = RuleFor(e => e.Description)
            .NotNull().WithMessage("Description cannot be null")
            .NotEmpty().WithMessage("Description cannot be empty");
    }
}
