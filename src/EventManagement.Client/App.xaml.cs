using EventManagement.Demo.ViewModels;
using System.Windows;

namespace EventManagement.Client;

public partial class App : Application
{
    /*
         Demo will be operated by a single user. Here we will specify an ID of a user that will be used for
         testing purposes throughout the Demo.
    */
    private const int currentUserId = 2;

    protected override void OnStartup(StartupEventArgs e)
    {
        MainWindow = new MainWindow()
        {
            DataContext = new MainViewModel()
        };

        MainWindow.Show();

        base.OnStartup(e);
    }
}
