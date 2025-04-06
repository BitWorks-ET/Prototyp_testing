namespace Prototype.Models;


/// <summary>
/// The Application class is a singleton.
/// It manages a list with every Organization instance.
/// It provides methods to add and remove organizations.
/// It manages a list with every User instance.
/// It provides methods to check if an account exists and to create one.
/// </summary>
public class Application
{
    private static readonly Lazy<Application> _instance = new Lazy<Application>(() => new Application());

    private List<Organization> _organizations;
    private List<Person> _members;

    private Application()
    {
        this._organizations = new List<Organization>();
        this._members = new List<Person>();
    }

    public static Application Instance => _instance.Value;

    public void AddOrganization(Organization organization)
    {
        if (!this._organizations.Contains(organization))
        {
            this._organizations.Add(organization);
        }
    }

    public void RemoveOrganization(Organization organization)
    {
        if (this._organizations.Contains(organization))
        {
            this._organizations.Remove(organization);
        }
    }

    public List<Organization> GetOrganizations()
    {
        return new List<Organization>(this._organizations);
    }

    public void AddMember(Person person)
    {
        if (!this._members.Contains(person))
        {
            this._members.Add(person);
        }
    }

    public void RemoveMember(Person person)
    {
        if (this._members.Contains(person))
        {
            this._members.Remove(person);
        }
    }

    public Person GetPerson(String eMail)
    {
        foreach (Person member in this._members)
        {
            if (member.eMail == eMail)
            {
                return member;
            }
        }

        return null;
    }

    public List<Person> GetMembers()
    {
        return new List<Person>(this._members);
    }
}