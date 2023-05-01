using Backend.Models.Entities;
using Microsoft.Identity.Client;

namespace Backend.Factories
{
    public interface IProductFactory
    {
        ProductEntity CreateProduct(string name, decimal price, string description, string size, string category, int rating);
    }
}
