using InventoryManager.Models;
using InventoryManager.Views;

namespace InventoryManager;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        Routing.RegisterRoute("HomePage", typeof(HomePage));
        Routing.RegisterRoute("LoginPage", typeof(LoginPage));
    }

    async void onLogout(object sender, EventArgs args)
    {
        await Shell.Current.GoToAsync("LoginPage");

    }
}

