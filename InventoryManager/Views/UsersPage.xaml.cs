using System.Reflection.PortableExecutable;
using InventoryManager.Services;


namespace InventoryManager.Views;

public partial class UsersPage : ContentPage
{
    public static IEnumerable<Models.User> All { get; private set; }
    public Models.Role role;
    public UsersPage()
	{
		InitializeComponent();
        string user = Preferences.Get("User", "Welcome");
        string role = Preferences.Get("Role", "");
        if(role != "Admin")
        {
            AddUser.IsVisible = false;
        }
        Header.Text = "Welcome, " + user;
        run();
        List<Models.Role> roles = new List<Models.Role>() { Models.Role.Admin, Models.Role.Attendant };
        Picker.ItemsSource = roles;

    }

   async void run()
    {
        All = await UserService.GetUsers();
        UsersView.ItemsSource = All;
    }

    void OnPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        int selectedIndex = picker.SelectedIndex;

        if (selectedIndex != -1)
        {
             role = (Models.Role)picker.ItemsSource[selectedIndex];
        }
    }



    async void onAddUser(object sender, EventArgs e)
    {
        string userName = UserName.Text;
        string password = Password.Text;
        

        Models.User user = await UserService.GetUserByUserName(userName);

        if (string.IsNullOrEmpty(userName))
        {
            await DisplayAlert("Alert", "Enter a Username", "OK");
            return;
        }
        if (string.IsNullOrEmpty(password))
        {
            await DisplayAlert("Alert", "Enter a Password", "OK");
            return;

        }

        if (string.IsNullOrEmpty(role.ToString()))
        {
            await DisplayAlert("Alert", "Select a role", "OK");
            return;

        }
        if (user != null)
        {
            await DisplayAlert("Alert", "User already exist", "OK");
        }

     int res =    await UserService.AddUser(new Models.User() { role = role, password = password, userName = userName });
        if(res == 1)
        {
            await DisplayAlert("Alert", "User created successfully", "OK");
       
            run();
            UserName.Text = "";
            Password.Text = "";

        }
        else
        {
            await DisplayAlert("Alert", "Failed to create user", "OK");
        }

    }
}
