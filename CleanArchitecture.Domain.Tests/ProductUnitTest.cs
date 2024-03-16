using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Validation;
using FluentAssertions;

namespace CleanArchitecture.Domain.Tests
{
    public class ProductUnitTest
    {
        [Fact(DisplayName = "CreateProduct")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "Product Image");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "CreateProductNegativeId")]
        public void CreateProduct_NegativeIdValue_DomainException()
        {
            Action action = () => new Product(-1, "Product Name", "Product Description", 9.99m, 99, "Product Image");
            action.Should().Throw<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "CreateProductShortName")]
        public void CreateProduct_ShortNameValue_DomainException()
        {
            Action action = () => new Product(1, "Pr", "Product Description", 9.99m, 99, "Product Image");
            action.Should().Throw<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "CreateProductLongImageName")]
        public void CreateProduct_LongImageName_DomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "Imageeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeee");
            action.Should().Throw<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "CreateProductNullImageName")]
        public void CreateProduct_NullImageName_DomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, null);
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "CreateProductEmptyImageName")]
        public void CreateProduct_EmptyImageName_DomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, 99, "");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "CreateProductInvalidStockValue")]
        public void CreateProduct_InvalidStockValue_DomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", 9.99m, -5, "");
            action.Should().Throw<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "CreateProductInvalidPriceValue")]
        public void CreateProduct_InvalidPriceValue_DomainException()
        {
            Action action = () => new Product(1, "Product Name", "Product Description", -9.99m, 5, "");
            action.Should().Throw<DomainExceptionValidation>();
        }
    }
}
