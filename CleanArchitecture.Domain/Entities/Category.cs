using CleanArchitecture.Domain.Validation;

namespace CleanArchitecture.Domain.Entities
{
    public sealed class Category : EntityBase
    {
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Valor do Id inválido");
            Id = id;
            ValidateDomain(name);
        }
        public Category(string name)
        {
            ValidateDomain(name);
        }

        public string Name { get; private set; }
        public ICollection<Product> Products { get; set; }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome inválido, por favor preencha corretamente!");
            DomainExceptionValidation.When(name.Length < 3, "Name inválido, muito curto, minimo de 3 caracteres");
            Name = name;
        }

        public void Update(string name)
        {
            ValidateDomain(name);
        }
    }
}
