namespace EventManagement.Demo.Infrastructure.Queries;

public class DeleteQueries
{
    public const string deleteApplicationForEvent =
        $@"DELETE FROM event_management.applies_to a
        WHERE a.REGULAR_USER_USER_Id=@userId AND a.EVENT_Id=@eventId";

    public const string deleteEvent =
        $@"DELETE FROM event_management.`event` e
        WHERE e.Id=@eventId";
}
