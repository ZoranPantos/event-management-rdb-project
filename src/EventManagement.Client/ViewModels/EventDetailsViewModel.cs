﻿using EventManagement.Demo.Models;
using System;
using System.Collections.ObjectModel;
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

    public EventDetailsViewModel()
    {
        PopulateViewModel();
    }

    private void PopulateViewModel()
    {

    }
}
