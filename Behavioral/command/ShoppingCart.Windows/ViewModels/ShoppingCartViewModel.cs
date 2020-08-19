using ShoppingCart.Business.Commands;
using ShoppingCart.Business.Repositories;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace ShoppingCart.Windows.ViewModels
{
    public class ShoppingCartViewModel : ViewModelBase
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;
        private readonly IProductRepository _productRepository;

        public System.Windows.Input.ICommand RemoveAllFromCartCommand { get; private set; }
        public System.Windows.Input.ICommand CheckoutCommand { get; private set; }

        public ObservableCollection<ProductViewModel> Products { get; private set; }
        public ObservableCollection<ProductViewModel> LineItems { get; private set; }

        public ShoppingCartViewModel(IShoppingCartRepository shoppingCartRepository, IProductRepository productRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
            _productRepository = productRepository;
        }

        public void InitializeViewModel()
        {

            var removeFromCartCommand = new RemoveAllFromCartCommand(_shoppingCartRepository, _productRepository);

            RemoveAllFromCartCommand = new RelayCommand(execute: () =>
            {
                removeFromCartCommand.Execute();
                Refresh();
            }, canExecute: ()=> removeFromCartCommand.CanExecute());

            CheckoutCommand = new RelayCommand(execute: () =>
            {
                var total = LineItems.Sum(x => x.Product.Price * x.Quantity);
                MessageBox.Show($"Shopping cart total: ${total}");

            }, canExecute: () => removeFromCartCommand.CanExecute());

            Refresh();
        }

        public void Refresh()
        {
            var products = _productRepository
                .All()
                .Select(product => new ProductViewModel(this,
                                        _shoppingCartRepository,
                                        _productRepository,
                                        product));

            var lineItems = _shoppingCartRepository
                .All()
                .Select(x => new ProductViewModel(this,
                                    _shoppingCartRepository,
                                    _productRepository,
                                    x.Product,
                                    x.Quantity));

            Products = new ObservableCollection<ProductViewModel>(products);
            LineItems = new ObservableCollection<ProductViewModel>(lineItems);

            OnPropertyRaised(nameof(Products));
            OnPropertyRaised(nameof(LineItems));
        }
    }
}
