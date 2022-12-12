using EventManagement.Demo.ViewModels;
using System;

namespace EventManagement.Demo.Stores;

// Single shared source of truth. We only want one instance of this class throughout the app

public class NavigationStore
{
    private ViewModelBase currentViewModel;

    public ViewModelBase CurrentViewModel
    {
        get => currentViewModel;
        set
        {
            currentViewModel = value;
            OnCurrentViewModelChanged();
        }
    }

    // Event which will notify MainViewModel that the CurrentViewModel has changed and it needs to update its field
    public event Action? CurrentViewModelChanged;

    private void OnCurrentViewModelChanged() => CurrentViewModelChanged?.Invoke();
}
