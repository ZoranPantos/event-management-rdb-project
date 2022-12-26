using EventManagement.Demo.DTOs;
using System;
using System.Windows.Input;

namespace EventManagement.Demo.ViewModels;

public class SingleForthcomingEventViewModel : ViewModelBase
{
    //private string title = string.Empty;
    //public string Title
    //{
    //    get => title;
    //    set
    //    {
    //        title = value;
    //        OnPropertyChanged(nameof(Title));
    //    }
    //}

    //private string description = string.Empty;
    //public string Description
    //{
    //    get => description;
    //    set
    //    {
    //        description = value;
    //        OnPropertyChanged(nameof(Description));
    //    }
    //}

    //private string groupName = string.Empty;
    //public string GroupName
    //{
    //    get => groupName; set
    //    {
    //        groupName = value;
    //        OnPropertyChanged(nameof(GroupName));
    //    }
    //}

    //private DateTime airingDate;
    //public DateTime AiringDate
    //{
    //    get => airingDate; set
    //    {
    //        airingDate = value;
    //        OnPropertyChanged(nameof(AiringDate));
    //    }
    //}

    //private string fullAddress = string.Empty;
    //public string FullAddress
    //{
    //    get => fullAddress;
    //    set
    //    {
    //        fullAddress = value;
    //        OnPropertyChanged(nameof(FullAddress));
    //    }
    //}

    //private string sponsor = string.Empty;
    //public string Sponsor
    //{
    //    get => sponsor;
    //    set
    //    {
    //        sponsor = value;
    //        OnPropertyChanged(nameof(Sponsor));
    //    }
    //}

    //private string topics = string.Empty;
    //public string Topics
    //{
    //    get => topics; set
    //    {
    //        topics = value;
    //        OnPropertyChanged(nameof(Topics));
    //    }
    //}

    //private string dailySchedule = string.Empty;
    //public string DailySchedule
    //{
    //    get => dailySchedule;
    //    set
    //    {
    //        dailySchedule = value;
    //        OnPropertyChanged(nameof(DailySchedule));
    //    }
    //}

    private readonly ForthcomingEventDTO airingEventDTO;

    public int EventId => airingEventDTO.EventId;
    public string Title => airingEventDTO.EventTitle;
    public string Description => airingEventDTO.Description;
    public string GroupName => airingEventDTO.GroupName;
    public DateTime AiringDate => airingEventDTO.Date;
    public string DailySchedule => airingEventDTO.DailySchedule;
    public string Topics => airingEventDTO.Topics;
    public string Sponsors => airingEventDTO.Sponsors;

    public string FullAddress { get; set; } = string.Empty;

    public ICommand ApplyToEventCommand { get; }

    public SingleForthcomingEventViewModel(ForthcomingEventDTO airingEventDTO)
    {
        this.airingEventDTO = airingEventDTO;

        FullAddress = $"{this.airingEventDTO.City}, {this.airingEventDTO.Street}, {this.airingEventDTO.Number}";
        
    }
}
