namespace CleanArchitecture.Application.ProdcutsCQRS.Commands
{
    public class ProductUpdateCommand : ProductCommand
    {
        public int Id { get; set; }
    }
}
