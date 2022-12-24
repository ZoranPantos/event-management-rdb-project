using System;
using System.Windows.Input;

namespace EventManagement.Demo.ViewModels;

public class SingleAiringEventViewModel : ViewModelBase
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

    private string groupName = string.Empty;
    public string GroupName
    {
        get => groupName; set
        {
            groupName = value;
            OnPropertyChanged(nameof(GroupName));
        }
    }

    private DateTime airingDate;
    public DateTime AiringDate
    {
        get => airingDate; set
        {
            airingDate = value;
            OnPropertyChanged(nameof(AiringDate));
        }
    }

    private string fullAddress = string.Empty;
    public string FullAddress
    {
        get => fullAddress;
        set
        {
            fullAddress = value;
            OnPropertyChanged(nameof(FullAddress));
        }
    }

    private string sponsor = string.Empty;
    public string Sponsor
    {
        get => sponsor;
        set
        {
            sponsor = value;
            OnPropertyChanged(nameof(Sponsor));
        }
    }

    private string topics = string.Empty;
    public string Topics
    {
        get => topics; set
        {
            topics = value;
            OnPropertyChanged(nameof(Topics));
        }
    }

    public ICommand ApplyToEventCommand { get; }
}
