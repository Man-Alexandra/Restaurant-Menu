// ViewModels/ProductViewModel.cs
using Restaurant_Menu.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

public class ProductViewModel : INotifyPropertyChanged
{
    private Product _selectedProduct;

    // The displayed products
    public ObservableCollection<Product> Products { get; set; } = new();

    // The original unfiltered list
    private List<Product> _allProducts = new();

    public Product SelectedProduct
    {
        get => _selectedProduct;
        set
        {
            _selectedProduct = value;
            OnPropertyChanged();
        }
    }

    public ICommand AddProductCommand { get; set; }

    public ProductViewModel()
    {
        AddProductCommand = new RelayCommand(AddProduct);
        LoadProducts(); // Initialize products
    }

    private void LoadProducts()
    {
        using var context = new Restaurant_Menu.Data.RestaurantDbContext();
        _allProducts = context.Products.ToList();

        Products.Clear();
        foreach (var p in _allProducts)
            Products.Add(p);
    }

    private void AddProduct()
    {
        var newProduct = new Product
        {
            ProductId = Products.Count + 1,
            Name = "New Product",
            Price = 12.50M,
            PortionQtyGrams = 150,
            TotalQtyGrams = 800
        };

        _allProducts.Add(newProduct);
        Products.Add(newProduct);
    }

    public void FilterProducts(string keyword)
    {
        keyword = keyword.ToLower();

        var filtered = _allProducts
            .Where(p => p.Name.ToLower().Contains(keyword) || p.Description.ToLower().Contains(keyword))
            .ToList();

        Products.Clear();
        foreach (var p in filtered)
            Products.Add(p);
    }

    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
// Utility RelayCommand class
public class RelayCommand : ICommand
{
    private readonly Action _execute;
    private readonly Func<bool>? _canExecute;

    public RelayCommand(Action execute, Func<bool>? canExecute = null)
    {
        _execute = execute;
        _canExecute = canExecute;
    }

    public event EventHandler? CanExecuteChanged;
    public bool CanExecute(object? parameter) => _canExecute?.Invoke() ?? true;
    public void Execute(object? parameter) => _execute();
    public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}
