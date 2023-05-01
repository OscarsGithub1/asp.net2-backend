using Backend.Models.DTO_s;
using Backend.Models.Entities;

namespace Backend.Factories
{
    public class ProductFactory : IProductFactory
    {
        public ProductEntity CreateProduct(string name, decimal price, string description, string size, string category, int rating)
        {
            var product = new CreateProductDto
            {
               name = name,
               price = price,
               description = description,
               size = size,
               category = category,
               rating = rating,

            };

            return product;
        }
        

         
        
    }
}
