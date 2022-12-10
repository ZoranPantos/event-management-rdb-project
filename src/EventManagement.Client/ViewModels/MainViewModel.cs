using EventManagement.Demo.Infrastructure;
using EventManagement.Demo.Infrastructure.Repositories;

namespace EventManagement.Demo.ViewModels;

public class MainViewModel : ViewModelBase
{
    public ViewModelBase CurrentViewModel { get; }

    // Temporarily hardcoded
    public MainViewModel() => CurrentViewModel = new UpdateUserViewModel(new EventManagementRepository());
}
