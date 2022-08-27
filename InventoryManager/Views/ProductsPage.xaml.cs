using InventoryManager.Models;
using InventoryManager.Services;

namespace InventoryManager.Views;

public partial class ProductsPage : ContentPage
{

    public ProductsPage()
    {
        InitializeComponent();
        string user = Preferences.Get("User", "Welcome");
        Header.Text = "Welcome, " + user;

        run();

    }

    async void run()
    {
        List<Product> products = await ProductService.GetProducts();
    }
}
