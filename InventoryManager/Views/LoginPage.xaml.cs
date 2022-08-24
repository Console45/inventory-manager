using InventoryManager.Services;

namespace InventoryManager.Views;

public partial class LoginPage : ContentPage
{


    public LoginPage()
    {
        InitializeComponent();
    }

    private string userName { get; set; }
    private string password { get; set; }


    void onUserNameTextChange(object sender, TextChangedEventArgs e)
    {
        userName = UserName.Text;
    }

    void onPasswordTextChange(object sender, TextChangedEventArgs e)
    {
        password = Password.Text;
    }

     async void onLogin(object sender, EventArgs args)
    {


        if (string.IsNullOrEmpty(userName))
        {
           await DisplayAlert("Alert", "Enter your Username", "OK");
            return;
        }
        if (string.IsNullOrEmpty(password))
        {
            await DisplayAlert("Alert", "Enter your Password", "OK");
            return;

        }

        Models.User user = await UserService.GetUserByUserName(userName);

        if (user == null)
        {
            await DisplayAlert("Alert", "Account not found", "OK");
            return;

        }

        if (user.password == password)
        {
            await DisplayAlert("Alert", "Login is Successful", "OK");
            return;

        }
        else
        {
            await DisplayAlert("Alert", "Invalid Password", "OK");
            return;

        }

    }
}
