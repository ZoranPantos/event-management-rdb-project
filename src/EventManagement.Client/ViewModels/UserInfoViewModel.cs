using EventManagement.Demo.Commands;
using EventManagement.Demo.Infrastructure.Repositories;
using EventManagement.Demo.Models;
using EventManagement.Demo.Stores;
using System;
using System.Windows.Input;

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
    
    public ICommand EditCommand { get; }

    public UserInfoViewModel(
        IEventManagementRepository repository,
        NavigationStore navigationStore,
        Func<ViewModelBase> createViewModel)
    {
        PopulateViewModel(repository.GetUserWithId(2));

        EditCommand = new NavigateCommand(navigationStore, createViewModel);
    }

    private void PopulateViewModel(RegularUser resultUser)
    {
        FirstName = resultUser.FirstName;
        LastName = resultUser.LastName;
        Age = resultUser.Age;
        DateJoined = resultUser.MemberSince;
        Status = resultUser.IsSuspended ? "Suspended" : "Active";
        Interests = resultUser.Interests;
    }
}
