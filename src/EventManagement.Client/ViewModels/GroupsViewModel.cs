using EventManagement.Demo.Infrastructure.Repositories;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EventManagement.Demo.ViewModels;

public class GroupsViewModel : ViewModelBase
{
    public ObservableCollection<SingleGroupViewModel> Groups { get; set; }

    // I need to send group Id to this command from the SingleGroupViewModel when I call it
    // This command should create appropriate view-model with the help of the group Id
    public ICommand VisitGroupCommand { get; }

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
