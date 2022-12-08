namespace EventManagement.Demo.ViewModels;

public class UpdateUserViewModel : ViewModelBase
{
    private string firstName = string.Empty;
    public string FirstName
    {
        get { return firstName; }
        set
        {
            firstName = value;
            OnPropertyChanged(nameof(FirstName));
        }
    }

    private string lastName = string.Empty;
    public string LastName
    {
        get { return lastName; }
        set
        {
            lastName = value;
            OnPropertyChanged(nameof(LastName));
        }
    }
}
