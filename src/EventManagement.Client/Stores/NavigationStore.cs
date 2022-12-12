using EventManagement.Demo.ViewModels;

namespace EventManagement.Demo.Stores;

public class NavigationStore
{
    private ViewModelBase currentViewModel;

    public ViewModelBase CurrentViewModel
    {
        get => currentViewModel;
        set
        {
            currentViewModel = value;
        }
    }
}
