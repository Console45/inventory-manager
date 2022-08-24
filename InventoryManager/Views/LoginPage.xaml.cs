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


        Models.User user = await UserService.GetUserByUserName(userName);

        if (string.IsNullOrEmpty(password))
        {
            await DisplayAlert("Alert", "Enter a Password", "OK");

        }


        if (user.password == "Cosmos")
        {
            LoginBtn.Text = password;
        };
        LoginBtn.Text = password;


    }
}
