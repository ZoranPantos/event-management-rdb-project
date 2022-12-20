using EventManagement.Demo.Infrastructure.Repositories;
using System.Collections.ObjectModel;

namespace EventManagement.Demo.ViewModels;

public class GroupDetailsViewModel : ViewModelBase
{
    private readonly int groupId;

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

    private string activeStatus = string.Empty;
    public string ActiveStatus
    {
        get => activeStatus;
        set
        {
            activeStatus = value;
            OnPropertyChanged(nameof(ActiveStatus));
        }
    }

    private string publicStatus = string.Empty;
    public string PublicStatus
    {
        get => publicStatus;
        set
        {
            publicStatus = value;
            OnPropertyChanged(nameof(PublicStatus));
        }
    }

    private string venue = string.Empty;
    public string Venue
    {
        get => venue;
        set
        {
            venue = value;
            OnPropertyChanged(nameof(Venue));
        }
    }

    private int memberCount;
    public int MemberCount
    {
        get => memberCount;
        set
        {
            memberCount = value;
            OnPropertyChanged(nameof(MemberCount));
        }
    }

    public ObservableCollection<SingleGroupMemberViewModel> Members { get; set; }
    public ObservableCollection<SingleGroupEventViewModel> Events { get; set; }

    public GroupDetailsViewModel(int groupId, IEventManagementRepository repository)
    {
        this.groupId = groupId;

        PopulateViewModel(repository);
    }

    private void PopulateViewModel(IEventManagementRepository repository)
    {
        var group = repository.GetGroupWithId(groupId);
        group.Venue = repository.GetGroupVenue(groupId);

        Title = group.Title;
        Description = group.Description;
        MemberCount = group.MemberCount;
        ActiveStatus = group.IsSuspended ? "Suspended" : "Active";
        PublicStatus = group.IsPublic ? "Public" : "Private";
        Venue = group.Venue.FullName;

    }
}
