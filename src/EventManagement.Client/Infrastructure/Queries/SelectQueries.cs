namespace EventManagement.Demo.Infrastructure.Queries;

public class SelectQueries
{
    public const string getUserWithId =
        @$"SELECT FirstName, LastName, Interests, Age, MemberSince, IsSuspended
        FROM event_management.`user` u
        INNER JOIN event_management.regular_user ru ON u.Id=USER_Id
        WHERE u.Id=@id";

    public const string getAllApplicationsForSpecificUser =
        @$"SELECT a.REGULAR_USER_USER_Id, a.EVENT_Id, e.Title, e.`Date`, g.Title FROM event_management.applies_to a
        INNER JOIN event_management.`event` e ON a.EVENT_Id=e.Id
        INNER JOIN event_management.organizes o ON o.EVENT_Id=e.Id
        INNER JOIN event_management.`group` g ON o.GROUP_Id=g.Id
        WHERE a.REGULAR_USER_USER_Id=@id";

    public const string getGroupWithId =
        $@"SELECT Id, Title, `Description`, IsPublic, IsSuspended, MemberCount
        FROM event_management.`group` WHERE Id=@groupId";

    public const string getGroupVenue =
        $@"SELECT v.Id, FullName FROM event_management.venue v
        INNER JOIN event_management.`group` g ON v.Id=g.VENUE_Id
        WHERE g.Id=@groupId";

    public const string getGroupMembers =
        $@"SELECT Id, FirstName, LastName, Age, Interests FROM event_management.registers r
        INNER JOIN event_management.regular_user ru
        ON r.REGULAR_USER_USER_Id=ru.USER_Id
        INNER JOIN event_management.`user` u ON u.Id=ru.USER_Id
        WHERE r.GROUP_Id=@groupId";

    public const string getGroupEvents =
        $@"SELECT Id, Title FROM event_management.`event` e
        INNER JOIN event_management.organizes o ON e.Id=o.EVENT_Id
        WHERE o.GROUP_Id=@groupId";

    public const string getAiringEventsWithGroupName =
        $@"SELECT * FROM event_management.forthcoming_events_view";

    public const string getAllTopicsForEvent =
        $@"SELECT * FROM event_management.topic t
        INNER JOIN event_management.has h ON t.Id=h.TOPIC_Id
        WHERE h.EVENT_Id=@eventId";

    public const string getSponsorNamesForEvent =
        $@"SELECT `Name` FROM event_management.sponsor s
        INNER JOIN event_management.sponsors ss
        ON s.Id=ss.SPONSOR_Id
        WHERE ss.EVENT_Id=@eventId";

    public const string getLocation =
        $@"SELECT * FROM event_management.location l
        WHERE l.Id=@locationId";

    public const string getEvent =
        $@"SELECT * FROM event_management.`event` e
        WHERE e.Id=@eventId";

    public const string getSponsorNameAndMoneyProvidedForEvent =
        $@"SELECT `Name`, MoneyProvided FROM event_management.sponsor s
        INNER JOIN event_management.sponsors ss
        ON s.Id=ss.SPONSOR_Id
        WHERE ss.EVENT_Id=@eventId;";
}
