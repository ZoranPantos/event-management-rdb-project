using EventManagement.Demo.Commands;
using EventManagement.Demo.Infrastructure.Repositories;
using System.Windows.Input;

namespace EventManagement.Demo.ViewModels;

public class UpdateUserViewModel : ViewModelBase
{
    private readonly IEventManagementRepository eventManagementRepository;

    private string firstName = string.Empty;
    public string FirstName
    {
        get => firstName;
        set
        {
            firstName = value;
            OnPropertyChanged(nameof(FirstName));
        }
    }

    private string lastName = string.Empty;
    public string LastName
    {
        get => lastName;
        set
        {
            lastName = value;
            OnPropertyChanged(nameof(LastName));
        }
    }

    public ICommand SaveCommand { get; }
    public ICommand CancelCommand { get; }

    public UpdateUserViewModel(IEventManagementRepository eventManagementRepository)
    {
        this.eventManagementRepository = eventManagementRepository;

        SaveCommand = new UpdateUserCommand(this, this.eventManagementRepository);
    }
}
