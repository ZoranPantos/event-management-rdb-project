using System.Windows.Input;

namespace EventManagement.Demo.ViewModels;

public class UpdateUserViewModel : ViewModelBase
{
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
}
