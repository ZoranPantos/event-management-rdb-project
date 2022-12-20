using EventManagement.Demo.Infrastructure.Repositories;
using EventManagement.Demo.Stores;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EventManagement.Demo.ViewModels;

public class GroupsViewModel : ViewModelBase
{
    public ObservableCollection<SingleGroupViewModel> Groups { get; set; }

    public GroupsViewModel(IEventManagementRepository repository, NavigationStore navigationStore)
    {
        Groups = new();

        PopulateViewModel(repository, navigationStore);
    }

    private void PopulateViewModel(IEventManagementRepository repository, NavigationStore navigationStore)
    {
        // Get this user Id from some upper layers
        var groupDTOs = repository.GetAllGroupsCreatedBySpecificUser(2);

        foreach (var groupDTO in groupDTOs)
            Groups.Add(new SingleGroupViewModel(groupDTO, repository, navigationStore));
    }
}
