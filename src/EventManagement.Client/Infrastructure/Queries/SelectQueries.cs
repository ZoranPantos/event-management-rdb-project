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
}
