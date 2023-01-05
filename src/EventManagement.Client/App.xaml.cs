using EventManagement.Demo.Commands;
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
        //navigationStore.CurrentViewModel = new ForthcomingEventsViewModel(repository);
        navigationStore.CurrentViewModel = new CreateEventViewModel();

        MainWindow = new MainWindow()
        {
            DataContext = new MainViewModel(navigationStore)
            {
                ProfileCommand = new NavigateCommand(navigationStore, CreateProfileViewModel),
                MyApplicationsCommand = new NavigateCommand(navigationStore, CreateApplicationsViewModel),
                MyGroupsCommand = new NavigateCommand(navigationStore, CreateGroupsViewModel),
                HomeCommand = new NavigateCommand(navigationStore, CreateForthcomingEventsViewModel)
            }
        };

        MainWindow.Show();

        base.OnStartup(e);
    }

    private UpdateProfileViewModel CreateUpdateProfileViewModel() =>
        new(repository, navigationStore, CreateProfileViewModel);

    private ProfileViewModel CreateProfileViewModel() =>
        new(repository, navigationStore, CreateUpdateProfileViewModel);

    private ApplicationsViewModel CreateApplicationsViewModel() => new(repository);

    private GroupsViewModel CreateGroupsViewModel() => new(repository, navigationStore);

    private ForthcomingEventsViewModel CreateForthcomingEventsViewModel() => new(repository);
}
