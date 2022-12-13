using EventManagement.Demo.Infrastructure.Repositories;
using EventManagement.Demo.Stores;
using System.Windows.Input;

namespace EventManagement.Demo.ViewModels;

public class MainViewModel : ViewModelBase
{
    private readonly NavigationStore navigationStore;

    public ViewModelBase CurrentViewModel => navigationStore.CurrentViewModel;

    public ICommand HomeCommand { get; set; }
    public ICommand MyGroupsCommand { get; set; }
    public ICommand MyApplicationsCommand { get; set; }
    public ICommand ProfileCommand { get; set; }

    public MainViewModel(NavigationStore navigationStore)
    {
        this.navigationStore = navigationStore;
        this.navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
    }

    private void OnCurrentViewModelChanged() => OnPropertyChanged(nameof(CurrentViewModel));
}
