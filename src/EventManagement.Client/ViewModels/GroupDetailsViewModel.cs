using EventManagement.Demo.Commands;
using EventManagement.Demo.Infrastructure.Repositories;
using EventManagement.Demo.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EventManagement.Demo.ViewModels;

public class GroupDetailsViewModel : ViewModelBase
{
    private readonly IEventManagementRepository repository;
    private readonly NavigationStore navigationStore;
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

    public ICommand NewEventCommand { get; }

    public GroupDetailsViewModel(int groupId, IEventManagementRepository repository, NavigationStore navigationStore)
    {
        this.groupId = groupId;
        this.repository = repository;
        this.navigationStore = navigationStore;

        Members = new();
        Events = new();

        PopulateViewModel(repository, navigationStore);

        NewEventCommand = new NavigateCommand(navigationStore, CreateCreateEventViewModel);
    }

    private void PopulateViewModel(IEventManagementRepository repository, NavigationStore navigationStore)
    {
        var group = repository.GetGroupWithId(groupId);
        group.Venue = repository.GetGroupVenue(groupId);

        Title = group.Title;
        Description = group.Description;
        MemberCount = group.MemberCount;
        ActiveStatus = group.IsSuspended ? "Suspended" : "Active";
        PublicStatus = group.IsPublic ? "Public" : "Private";
        Venue = group.Venue.FullName;

        var groupMemberDTOs = repository.GetGroupMembers(groupId);

        foreach (var groupMemberDTO in groupMemberDTOs)
            Members.Add(new SingleGroupMemberViewModel(groupMemberDTO));

        var groupEventDTOs = repository.GetGroupEvents(groupId);

        foreach (var groupEventDTO in groupEventDTOs)
            Events.Add(new SingleGroupEventViewModel(groupEventDTO, repository, Events, navigationStore, groupId));
    }

    private CreateEventViewModel CreateCreateEventViewModel()
    {
        return new CreateEventViewModel(repository, groupId, navigationStore, CreateGroupDetailsViewModel);
    }

    private GroupDetailsViewModel CreateGroupDetailsViewModel()
    {
        return new GroupDetailsViewModel(groupId, repository, navigationStore);
    }
}
