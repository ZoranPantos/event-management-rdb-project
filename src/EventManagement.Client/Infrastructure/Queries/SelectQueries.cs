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
}
