using EventManagement.Demo.Infrastructure.Repositories;
using EventManagement.Demo.Stores;
using EventManagement.Demo.ViewModels;
using System;

namespace EventManagement.Demo.Commands;

public class SaveEventCommand : CommandBase
{
    private readonly NavigationStore navigationStore;
    private readonly Func<ViewModelBase> createViewModel;

    private readonly IEventManagementRepository repository;
    private readonly CreateEventViewModel viewModel;

    public SaveEventCommand(
        IEventManagementRepository repository,
        CreateEventViewModel viewModel,
        NavigationStore navigationStore,
        Func<ViewModelBase> createViewModel)
    {
        this.repository = repository;
        this.viewModel = viewModel;
        this.navigationStore = navigationStore;
        this.createViewModel = createViewModel;
    }

    public override void Execute(object? parameter)
    {
        repository.CreateEvent(viewModel);

        navigationStore.CurrentViewModel = createViewModel();
    }
}
