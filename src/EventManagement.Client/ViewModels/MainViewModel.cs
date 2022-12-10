using EventManagement.Demo.Infrastructure;

namespace EventManagement.Demo.ViewModels;

public class MainViewModel : ViewModelBase
{
    public ViewModelBase CurrentViewModel { get; }

    // Temporarily hardcoded
    public MainViewModel() => CurrentViewModel = new UserInfoViewModel(new EventManagementRepository());
}
