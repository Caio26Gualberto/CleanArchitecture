using CleanArchitecture.Domain.Validation;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics;

namespace CleanArchitecture.Domain.Entities
{
    public sealed class Product : EntityBase
    {
        public Product(string name, string description, decimal price, int stock, string image)
        {
            ValidateDomain(name, description, price, stock, image);
        }

        public Product(int id, string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(id < 0, "Valor do Id inválido");
            Id = id;
            ValidateDomain(name, description, price, stock, image);
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public void Update(string name, string description, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, description, price, stock, image);
            CategoryId = categoryId;
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Nome inválido, por favor preencha corretamente!");
            DomainExceptionValidation.When(name.Length < 3, "Name inválido, muito curto, minimo de 3 caracteres");
            DomainExceptionValidation.When(string.IsNullOrEmpty(description), "Descrição inválida, por favor preencha corretamente!");
            DomainExceptionValidation.When(description.Length < 5, "Descrição inválida, muito curto, minimo de 5 caracteres");
            DomainExceptionValidation.When(price < 0, "Preço inválido, não pode ser menor que 0");
            DomainExceptionValidation.When(stock < 0, "Estoque inválido, não pode ser menor que 0");
            DomainExceptionValidation.When(image.Length > 250, "Nome da imagem inválida, muito grande, máximo de 250 caracteres");
            
            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;
        }
    }
}
