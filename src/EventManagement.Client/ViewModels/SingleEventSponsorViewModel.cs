using EventManagement.Demo.DTOs;

namespace EventManagement.Demo.ViewModels;

public class SingleEventSponsorViewModel : ViewModelBase
{
    private SingleEventSponsorDTO sponsorDTO;

    public string Name => sponsorDTO.Name;
    public decimal MoneyProvided => sponsorDTO.MoneyProvided;

    public SingleEventSponsorViewModel(SingleEventSponsorDTO sponsorDTO)
    {
        this.sponsorDTO = sponsorDTO;
    }
}
