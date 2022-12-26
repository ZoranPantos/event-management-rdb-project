namespace EventManagement.Demo.Infrastructure.Queries;

public class InsertQueries
{
    public const string applyToEvent =
        @$"INSERT INTO event_management.applies_to
        VALUES (@userId, @eventId);";
}
