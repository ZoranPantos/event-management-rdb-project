using EventManagement.Demo.Infrastructure.Repositories;
using EventManagement.Demo.Stores;
using EventManagement.Demo.ViewModels;
using System;

namespace EventManagement.Demo.Commands;

public class NavigateCommand : CommandBase
{
    private readonly NavigationStore navigationStore;
    private readonly IEventManagementRepository repository;

    public NavigateCommand(NavigationStore navigationStore, IEventManagementRepository repository)
    {
        this.navigationStore = navigationStore;
        this.repository = repository;
    }

    public override void Execute(object? parameter)
    {
        navigationStore.CurrentViewModel = new UpdateUserViewModel(repository);
    }
}
