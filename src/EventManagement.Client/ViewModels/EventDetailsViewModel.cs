using EventManagement.Demo.Commands;
using EventManagement.Demo.Infrastructure.Repositories;
using EventManagement.Demo.Models;
using EventManagement.Demo.Stores;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace EventManagement.Demo.ViewModels;

public class EventDetailsViewModel : ViewModelBase
{
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

    private DateTime date;
    public DateTime Date
    {
        get => date;
        set
        {
            date = value;
            OnPropertyChanged(nameof(Date));
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

    private bool isSuspended;
    public bool IsSuspended
    {
        get => isSuspended;
        set
        {
            isSuspended = value;
            OnPropertyChanged(nameof(IsSuspended));
        }
    }

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

    private string groupName = string.Empty;
    public string GroupName
    {
        get => groupName;
        set
        {
            groupName = value;
            OnPropertyChanged(nameof(GroupName));
        }
    }

    public ObservableCollection<Topic> Topics { get; set; }
    public ObservableCollection<SingleEventSponsorViewModel> Sponsors { get; set; }
    public ObservableCollection<SingleEventAttendeeViewModel> Attendees { get; set; }

    public ICommand RescheduleEventCommand { get; }
    public ICommand GoBack { get; }

    public EventDetailsViewModel(IEventManagementRepository repository, int eventId, Func<ViewModelBase> createViewModel, NavigationStore navigationStore)
    {
        PopulateViewModel(repository, eventId);

        GoBack = new NavigateCommand(navigationStore, createViewModel);
    }

    private void PopulateViewModel(IEventManagementRepository repository, int eventId)
    {
        var _event = repository.GetEvent(eventId);

        Title = _event.Title;
        Description = _event.Description;
        Date = _event.Date;
        DailySchedule = _event.DailySchedule;
        IsRecurring = _event.IsReccuring;
        IsOpen = _event.IsOpen;
        IsSuspended = _event.IsSuspended;
        Location = _event.Location.ToString();

        Topics = new(repository.GetAllTopicsForEvent(eventId).ToList<Topic>());

        var sponsors = repository.GetEventSponsors(eventId);
        Sponsors = new();

        foreach (var sponsor in sponsors)
            Sponsors.Add(new SingleEventSponsorViewModel(sponsor));

        var attendees = repository.GetAttendees(eventId);
        Attendees = new();

        foreach (var attendee in attendees)
            Attendees.Add(new SingleEventAttendeeViewModel(attendee));
    }
}
