using Backend.Models.Entities;

namespace Backend.Factories
{
    public class ShoppingCartFactory : IShoppingCartFactory
    {
        public ShoppingCartEntity CreateShoppingCart()
        {
            var shoppingCart = new ShoppingCartEntity();
            shoppingCart.Items = new List<ShoppingCartItemEntity>();
            return shoppingCart;
        }

        //Kanske måste använda mina DTOS istället
    }
}
