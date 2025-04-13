using System;

namespace Prototype.Models;


public class Application
{
    private static readonly Lazy<Application> _instance = new Lazy<Application>(() => new Application());

    private List<Organization> _organizations;
    private List<Person> _members;
    private List<Event> _events;

    private Application()
    {
        this._organizations = new List<Organization>();
        this._members = new List<Person>();
        this._events = new List<Event>();

        Person admin = new Person("admin@admin", BCrypt.Net.BCrypt.HashPassword("admin"));
        admin.FirstName = "Admin";
        admin.LastName = "Admin";

        Organization adminOrg = new Organization("admin", admin);
        admin.OrganizationId = adminOrg.Id;

        this._members.Add(admin);
        this._organizations.Add(adminOrg);
    }

    public static Application Instance => _instance.Value;

    public void AddOrganization(Organization organization)
    {
        if (!this._organizations.Contains(organization))
        {
            int listCount = this._organizations.Count;
            int lastItemId = listCount > 0 ? this._organizations[listCount - 1].Id : 0;
            organization.Id = lastItemId + 1;

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

    public Organization GetOrganization(int id)
    {
        foreach (Organization organization in this._organizations)
        {
            if (organization.Id == id)
            {
                return organization;
            }
        }

        return null;
    }

    public List<Organization> GetOrganizations()
    {
        return new List<Organization>(this._organizations);
    }

    public void AddMember(Person person)
    {
        if (!this._members.Contains(person))
        {
            int listCount = this._members.Count;
            int lastItemId = listCount > 0 ? this._members[listCount - 1].Id : 0;
            person.Id = lastItemId + 1;

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

    public void AddEvent(Event newEvent)
    {
        if (!this._events.Contains(newEvent))
        {
            int listCount = this._events.Count;
            int lastItemId = listCount > 0 ? this._events[listCount - 1].Id : 0;
            newEvent.Id = lastItemId + 1;

            this._events.Add(newEvent);
        }
    }

    public void RemoveEvent(Event newEvent)
    {
        if (this._events.Contains(newEvent))
        {
            this._events.Remove(newEvent);
        }
    }

    public Event GetEvent(int id)
    {
        foreach (Event @event in this._events)
        {
            if (@event.Id == id)
            {
                return @event;
            }
        }

        return null;
    }

    public List<Event> GetEvents()
    {
        return new List<Event>(this._events);
    }
}