using EventManagement.Demo.Commands;
using EventManagement.Demo.DTOs;
using EventManagement.Demo.Infrastructure.Repositories;
using EventManagement.Demo.Models;
using EventManagement.Demo.Stores;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EventManagement.Demo.ViewModels;

public class CreateEventViewModel : ViewModelBase
{
    public int GroupId { get; set; }

    private string title = string.Empty;
    public string Title
    {
        get => title;
        set
        {
            title = value;
            OnPropertyChanged(nameof(Title));
        }
    }

    private string description = string.Empty;
    public string Description
    {
        get => description;
        set
        {
            description = value;
            OnPropertyChanged(nameof(Description));
        }
    }

    private string dailySchedule = string.Empty;
    public string DailySchedule
    {
        get => dailySchedule;
        set
        {
            dailySchedule = value;
            OnPropertyChanged(nameof(DailySchedule));
        }
    }

    private DateTime date = DateTime.Now.AddDays(1);
    public DateTime Date
    {
        get => date;
        set
        {
            date = value;
            OnPropertyChanged(nameof(Date));
        }
    }

    private bool isOpen;
    public bool IsOpen
    {
        get => isOpen;
        set
        {
            isOpen = value;
            OnPropertyChanged(nameof(IsOpen));
        }
    }

    private bool isRecurring;
    public bool IsRecurring
    {
        get => isRecurring;
        set
        {
            isRecurring = value;
            OnPropertyChanged(nameof(IsRecurring));
        }
    }

    // TmpLocation will be used to store new location to the database
    public Location TmpLocation { get; set; } = new();
    private string location = string.Empty;
    public string Location
    {
        get => location;
        set
        {
            location = value;
            OnPropertyChanged(nameof(Location));
        }
    }

    public ObservableCollection<Topic> TmpTopics = new();
    private string topics = string.Empty;
    public string Topics
    {
        get => topics;
        set
        {
            topics = value;
            OnPropertyChanged(nameof(Topics));
        }
    }

    public ObservableCollection<SponsorWithMoneyDTO> SponsorDTOs = new();
    private string sponsors = string.Empty;
    public string Sponsors
    {
        get => sponsors;
        set
        {
            sponsors = value;
            OnPropertyChanged(nameof(Sponsors));
        }
    }

    public ICommand AddLocationCommand { get; }
    public ICommand AddTopicCommand { get; }
    public ICommand AddSponsorCommand { get; }
    public ICommand SaveEventCommand { get; }
    public ICommand CancelCommand { get; }

    public CreateEventViewModel(IEventManagementRepository repository, int groupId, NavigationStore navigationStore, Func<ViewModelBase> createViewModel)
    {
        GroupId = groupId;

        AddLocationCommand = new AddLocationCommand(this);
        AddTopicCommand = new AddTopicCommand(this);
        AddSponsorCommand = new AddSponsorCommand(this);
        SaveEventCommand = new SaveEventCommand(repository, this, navigationStore, createViewModel);
        CancelCommand = new NavigateCommand(navigationStore, createViewModel);
    }
}
