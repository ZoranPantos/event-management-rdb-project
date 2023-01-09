namespace EventManagement.Demo.Infrastructure.Queries;

public class InsertQueries
{
    public const string applyToEvent =
        @$"INSERT INTO event_management.applies_to
        VALUES (@userId, @eventId)";

    public const string addSponsor =
        $@"INSERT INTO event_management.sponsor
        (`Name`, DomainOfWork, CurrentCEO, EstablishmentYear, Headquarters, Motto, ContactMail)
        VALUES (@name, @domain, @ceo, @year, @headquarters, @motto, @email)";

    public const string addSponsorship =
        $@"INSERT INTO event_management.sponsors
        VALUES (@sponsorId, @eventId, @money)";

    public const string addLocation =
        $@"INSERT INTO event_management.location
        (City, Street, Number, Latitude, Longitude)
        VALUES (@city, @street, @number, @latitude, @longitude)";

    public const string addTopic =
        $@"INSERT INTO event_management.topic
        (Title, Description)
        VALUES (@title, @description)";

    public const string addHasTopic =
        $@"INSERT INTO event_management.has
        VALUES (@eventId, @topicId)";

    public const string addOrganizesEvent =
        $@"INSERT INTO event_management.organizes
        VALUES (@eventId, @groupId)";

    public const string addEvent =
        $@"INSERT INTO event_management.`event`
        (`Date`, Title, Description, DailySchedule, IsRecurring, IsOpen, IsSuspended, LOCATION_Id)
        VALUES (@date, @title, @description, @schedule, @isRecurring, @isOpen, @isSuspended, @locationId)";
}
