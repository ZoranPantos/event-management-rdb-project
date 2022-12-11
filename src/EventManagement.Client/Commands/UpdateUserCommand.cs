using EventManagement.Demo.Infrastructure.Repositories;
using EventManagement.Demo.ViewModels;
using System.ComponentModel;

namespace EventManagement.Demo.Commands;

public class UpdateUserCommand : CommandBase
{
    private readonly UpdateUserViewModel updateUserViewModel;
    private readonly IEventManagementRepository eventManagementRepository;

    public UpdateUserCommand(
        UpdateUserViewModel updateUserViewModel,
        IEventManagementRepository eventManagementRepository)
    {
        this.updateUserViewModel = updateUserViewModel;
        this.eventManagementRepository = eventManagementRepository;

        updateUserViewModel.PropertyChanged += OnViewModelPropertyChanged;
    }

    private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName.Equals(nameof(UpdateUserViewModel.FirstName)) ||
            e.PropertyName.Equals(nameof(UpdateUserViewModel.LastName)))
        {
            OnCanExecuteChanged();
        }
    }

    public override void Execute(object? parameter)
    {
        // TODO: get this user id from some upper layers
        eventManagementRepository.UpdateUserWithId(2, updateUserViewModel);
    }

    public override bool CanExecute(object? parameter)
    {
        return !string.IsNullOrEmpty(updateUserViewModel.FirstName) &&
            !string.IsNullOrEmpty(updateUserViewModel.LastName) &&
            base.CanExecute(parameter);
    }
}
