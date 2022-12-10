namespace EventManagement.Demo.Infrastructure.Queries;

public class SelectQueries
{
    public const string getUserWithId =
        @$"SELECT FirstName, LastName, Interests, Age, MemberSince, IsSuspended
        FROM event_management.`user` u
        INNER JOIN event_management.regular_user ru ON u.Id=USER_Id
        WHERE u.Id=@id";
}
