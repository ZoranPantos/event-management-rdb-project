using EventManagement.Demo.Commands;
using EventManagement.Demo.Infrastructure.Repositories;
using EventManagement.Demo.Models;
using EventManagement.Demo.Stores;
using System;
using System.Windows.Input;

namespace EventManagement.Demo.ViewModels;

public class ProfileViewModel : ViewModelBase
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

    private string telNumbers = string.Empty;
    public string TelNumbers
    {
        get => telNumbers;
        set
        {
            telNumbers = value;
            OnPropertyChanged(nameof(TelNumbers));
        }
    }
    
    public ICommand EditCommand { get; }

    public ProfileViewModel(
        IEventManagementRepository repository,
        NavigationStore navigationStore,
        Func<ViewModelBase> createViewModel)
    {
        PopulateViewModel(repository);
        EditCommand = new NavigateCommand(navigationStore, createViewModel);
    }

    private void PopulateViewModel(IEventManagementRepository repository)
    {
        var resultUser = repository.GetUserWithId(2);

        FirstName = resultUser.FirstName;
        LastName = resultUser.LastName;
        Age = resultUser.Age;
        DateJoined = resultUser.MemberSince;
        Status = resultUser.IsSuspended ? "Suspended" : "Active";
        Interests = resultUser.Interests;
        TelNumbers = repository.GetAllTelephonesAsString(2);
    }
}
