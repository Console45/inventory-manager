using InventoryManager.Models;

namespace InventoryManager.Views;

public partial class ProductsPage : ContentPage
{

    public ProductsPage()
    {
		InitializeComponent();
        string user = Preferences.Get("User", "Welcome");
        Header.Text = "Welcome, " + user;

    }
}
