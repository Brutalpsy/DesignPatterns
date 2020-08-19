using ShoppingCart.Business.Repositories;
using System;
using System.Linq;

namespace ShoppingCart.Business.Commands
{
    public class RemoveAllFromCartCommand : ICommand
    {
        private readonly IShoppingCartRepository shoppingCartRepository;
        private readonly IProductRepository productRepository;

        public RemoveAllFromCartCommand(IShoppingCartRepository shoppingCartRepository,
            IProductRepository productRepository)
        {
            this.shoppingCartRepository = shoppingCartRepository;
            this.productRepository = productRepository;
        }

        public bool CanExecute()
        {
            return shoppingCartRepository.All().Any();
        }

        public void Execute()
        {
            var items = shoppingCartRepository.All().ToList(); 

            foreach ((Models.Product Product, int Quantity) in items)
            {
                productRepository.IncreaseStockBy(Product.ArticleId, Quantity);

                shoppingCartRepository.RemoveAll(Product.ArticleId);
            }
        }

        public void Undo()
        {
            throw new NotImplementedException();
        }
    }
}
