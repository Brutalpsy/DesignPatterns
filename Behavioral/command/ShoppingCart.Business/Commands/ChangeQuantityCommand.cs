using ShoppingCart.Business.Models;
using ShoppingCart.Business.Repositories;

namespace ShoppingCart.Business.Commands
{
    public class ChangeQuantityCommand : ICommand
    {
        public enum Operation
        {
            Increase,
            Decrease
        }

        private readonly Operation _operation;
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IProductRepository _productRepository;
        private readonly Product _product; 

        public ChangeQuantityCommand(Operation operation,
            IShoppingCartRepository shoppingCartRepository,
            IProductRepository productRepository,
            Product product)
        {
            _operation = operation;
            _shoppingCartRepository = shoppingCartRepository;
            _productRepository = productRepository;
            _product = product;
        }

        public bool CanExecute()
        {
            switch (_operation)
            {
                case Operation.Decrease:
                    return _shoppingCartRepository.Get(_product.ArticleId).Quantity != 0;
                case Operation.Increase:
                    return (_productRepository.GetStockFor(_product.ArticleId) - 1) >= 0; 
            }

            return false;
        }

        public void Execute()
        {
            switch (_operation)
            {
                case Operation.Decrease:
                    _productRepository.IncreaseStockBy(_product.ArticleId, 1);
                    _shoppingCartRepository.DecraseQuantity(_product.ArticleId);
                    break;
                case Operation.Increase:
                    _productRepository.DecreaseStockBy(_product.ArticleId, 1);
                    _shoppingCartRepository.IncreaseQuantity(_product.ArticleId);
                    break;
            }
        }

        public void Undo()
        {
            switch (_operation)
            {
                case Operation.Decrease:
                    _productRepository.DecreaseStockBy(_product.ArticleId, 1);
                    _shoppingCartRepository.IncreaseQuantity(_product.ArticleId);
                    break;
                case Operation.Increase:
                    _productRepository.IncreaseStockBy(_product.ArticleId, 1);
                    _shoppingCartRepository.DecraseQuantity(_product.ArticleId);
                    break;
            }
        }
    }
}
