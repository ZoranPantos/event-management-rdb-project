namespace EventManagement.Demo.Infrastructure.Queries;

public class UpdateQueries
{
    public const string updateUserWithId =
        @$"UPDATE event_management.`user`
        SET FirstName=@newFirstName, LastName=@newLastName
        WHERE Id=@id";
}
