using EventManagement.Demo.Commands;
using EventManagement.Demo.Infrastructure.Repositories;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace EventManagement.Demo.ViewModels;

public class ApplicationsViewModel : ViewModelBase
{
    public ObservableCollection<SingleApplicationViewModel> Applications { get; set; }

    public ApplicationsViewModel(IEventManagementRepository repository)
    {
        Applications = new();

        PopulateViewModel(repository);
    }

    private void PopulateViewModel(IEventManagementRepository repository)
    {
        // Get this user Id from some upper layers
        var applicationDTOs = repository.GetAllApplicationsForSpecificUser(2);

        foreach (var applicationDTO in applicationDTOs)
            Applications.Add(new SingleApplicationViewModel(applicationDTO, repository, Applications));
    }
}
