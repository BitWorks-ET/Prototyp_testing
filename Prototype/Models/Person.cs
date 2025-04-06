namespace Prototype.Models;

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime? Birthday { get; set; }
    public Gender? Gender { get; set; }
    public string PhoneNumber { get; set; }
    public string JobTitle { get; set; }

    public int Id { get; set; }
    public string eMail { get; set; }
    public string PasswordHash { get; set; }
}