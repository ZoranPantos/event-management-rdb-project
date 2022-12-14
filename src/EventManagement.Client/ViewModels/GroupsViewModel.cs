using EventManagement.Demo.Infrastructure.Repositories;
using System.Collections.ObjectModel;

namespace EventManagement.Demo.ViewModels;

public class GroupsViewModel : ViewModelBase
{
    public ObservableCollection<SingleGroupViewModel> Groups { get; set; }

    public GroupsViewModel(IEventManagementRepository repository)
    {
        Groups = new();

        PopulateViewModel(repository);
    }

    private void PopulateViewModel(IEventManagementRepository repository)
    {
        // Get this user Id from some upper layers
        var groupDTOs = repository.GetAllGroupsCreatedBySpecificUser(2);

        foreach (var groupDTO in groupDTOs)
            Groups.Add(new SingleGroupViewModel(groupDTO));
    }
}
