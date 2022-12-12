using EventManagement.Demo.Infrastructure.Repositories;
using EventManagement.Demo.Stores;
using EventManagement.Demo.ViewModels;
using System;

namespace EventManagement.Demo.Commands;

public class NavigateCommand : CommandBase
{
    private readonly NavigationStore navigationStore;
    private readonly Func<ViewModelBase> createViewModel;

    public NavigateCommand(NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
    {
        this.navigationStore = navigationStore;
        this.createViewModel = createViewModel;
    }

    public override void Execute(object? parameter) =>
        navigationStore.CurrentViewModel = createViewModel();
}
