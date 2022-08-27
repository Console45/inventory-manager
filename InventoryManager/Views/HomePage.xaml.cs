namespace InventoryManager.Views;

public partial class HomePage : ContentPage
{


    public HomePage()
    {

        InitializeComponent();
        string user = Preferences.Get("User", "Welcome");
        Header.Text = "Welcome, " + user;


    }

}


