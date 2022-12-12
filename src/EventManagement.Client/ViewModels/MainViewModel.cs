using EventManagement.Demo.Infrastructure.Repositories;
using EventManagement.Demo.Stores;
using System.Windows.Input;

namespace EventManagement.Demo.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly NavigationStore navigationStore;

    public ViewModelBase CurrentViewModel => navigationStore.CurrentViewModel;

    public ICommand HomeCommand { get; }
    public ICommand MyGroupsCommand { get; }
    public ICommand MyApplicationsCommand { get; }
    public ICommand ProfileCommand { get; }

    public MainViewModel(NavigationStore navigationStore)
    {
        this.navigationStore = navigationStore;
        this.navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
    }

    private void OnCurrentViewModelChanged() => OnPropertyChanged(nameof(CurrentViewModel));
}
