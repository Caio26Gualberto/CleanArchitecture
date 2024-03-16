using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Validation;
using FluentAssertions;

namespace CleanArchitecture.Domain.Tests
{
    public class CategoryUnitTest
    {
        [Fact(DisplayName = "CreateCategory")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "CreateCategoryNegativeId")]
        public void CreateCategory_NegativeIdValue_DomainException()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should().Throw<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "CreateCategoryShortName")]
        public void CreateCategory_ShortNameValue_DomainException()
        {
            Action action = () => new Category(1, "Ca");
            action.Should().Throw<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "CreateCategoryRequiredName")]
        public void CreateCategory_MissingNameValue_DomainException()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "CreateCategoryNullName")]
        public void CreateCategory_WithNullNameValue_DomainException()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<DomainExceptionValidation>();
        }
    }
}
