using System;

namespace EventManagement.Demo.ViewModels;

public class UserInfoViewModel : ViewModelBase
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

    private int age;
    public int Age
    {
        get => age;
        set
        {
            age = value;
            OnPropertyChanged(nameof(Age));
        }
    }

    private DateTime dateJoined;
    public DateTime DateJoined
    {
        get => dateJoined;
        set
        {
            dateJoined = value;
            OnPropertyChanged(nameof(DateJoined));
        }
    }

    private string status = string.Empty;
    public string Status
    {
        get => status;
        set
        {
            status = value;
            OnPropertyChanged(nameof(Status));
        }
    }

    private string interests = string.Empty;
    public string Interests
    {
        get => interests;
        set
        {
            interests = value;
            OnPropertyChanged(nameof(Interests));
        }
    }
}
