using EventManagement.Demo.Infrastructure.Repositories;
using EventManagement.Demo.Stores;
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
    private readonly NavigationStore navigationStore;
    private readonly IEventManagementRepository repository;

    public App()
    {
        navigationStore = new();
        repository = new EventManagementRepository();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        navigationStore.CurrentViewModel = new ProfileViewModel(repository, navigationStore, CreateUpdateUserViewModel);

        MainWindow = new MainWindow()
        {
            DataContext = new MainViewModel(navigationStore)
        };

        MainWindow.Show();

        base.OnStartup(e);
    }

    private UpdateProfileViewModel CreateUpdateUserViewModel()
    {
        return new UpdateProfileViewModel(repository, navigationStore, CreateUserInfoViewModel);
    }

    private ProfileViewModel CreateUserInfoViewModel()
    {
        return new ProfileViewModel(repository, navigationStore, CreateUpdateUserViewModel);
    }
}
