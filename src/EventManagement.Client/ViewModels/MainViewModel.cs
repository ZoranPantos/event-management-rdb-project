using EventManagement.Demo.Infrastructure.Repositories;
using System.Windows.Input;

namespace EventManagement.Demo.ViewModels;

public class MainViewModel : ViewModelBase
{
    public ViewModelBase CurrentViewModel { get; }

    public ICommand HomeCommand { get; }
    public ICommand MyGroupsCommand { get; }
    public ICommand MyApplicationsCommand { get; }
    public ICommand ProfileCommand { get; }

    // Temporarily hardcoded
    public MainViewModel() => CurrentViewModel = new UserInfoViewModel(new EventManagementRepository());
}
