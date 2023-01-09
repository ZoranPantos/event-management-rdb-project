using EventManagement.Demo.Infrastructure.Repositories;
using EventManagement.Demo.Stores;
using EventManagement.Demo.ViewModels;
using System;
using System.ComponentModel;

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

        viewModel.PropertyChanged += OnViewModelPropertyChanged;
    }

    private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName.Equals(nameof(CreateEventViewModel.Title)) ||
            e.PropertyName.Equals(nameof(CreateEventViewModel.Description)) ||
            e.PropertyName.Equals(nameof(CreateEventViewModel.DailySchedule)) ||
            e.PropertyName.Equals(nameof(CreateEventViewModel.Date)) ||
            e.PropertyName.Equals(nameof(CreateEventViewModel.Topics)) ||
            e.PropertyName.Equals(nameof(CreateEventViewModel.Location)))
        {
            OnCanExecuteChanged();
        }
    }

    public override void Execute(object? parameter)
    {
        repository.CreateEvent(viewModel);
        navigationStore.CurrentViewModel = createViewModel();
    }

    public override bool CanExecute(object? parameter)
    {
        return !string.IsNullOrEmpty(viewModel.Title) &&
            !string.IsNullOrEmpty(viewModel.Description) &&
            !string.IsNullOrEmpty(viewModel.DailySchedule) &&
            !string.IsNullOrEmpty(viewModel.Location) &&
            !string.IsNullOrEmpty(viewModel.Topics) &&
            viewModel.Date > DateTime.Now &&
            base.CanExecute(parameter);
    }
}
