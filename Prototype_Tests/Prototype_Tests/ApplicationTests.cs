using System;
using System.Collections.Generic;
using Xunit;
using Prototype.Models;

public class ApplicationTests
{
    [Fact]
    public void AddOrganization_ShouldAddNewOrg()
    {
        var app = Application.Instance;
        var org = new Organization("TestOrg", new Person("test@mail.com", "1234"));
        app.AddOrganization(org);
        Assert.Contains(org, app.GetOrganizations());
    }
    // TEST KOMMENTAR OKOMOMO
     // LETZTER KOMMENTAR FÜR HEUTE


    // KOEMNTETE 
    [Fact]
    public void RemoveOrganization_ShouldRemoveOrg()
    {
        var app = Application.Instance;
        var org = new Organization("ToRemoveOrg", new Person("test2@mail.com", "1234"));
        app.AddOrganization(org);
        app.RemoveOrganization(org);
        Assert.DoesNotContain(org, app.GetOrganizations());
    }

    [Fact]
    public void AddMember_ShouldAddPerson()
    {
        var app = Application.Instance;
        var person = new Person("unique@mail.com", "pw");
        app.AddMember(person);
        Assert.Contains(person, app.GetMembers());
    }

    [Fact]
    public void GetPerson_ByEmail_ShouldReturnCorrectUser()
    {
        var app = Application.Instance;
        var person = new Person("findme@mail.com", "pw");
        app.AddMember(person);
        var result = app.GetPerson("findme@mail.com");
        Assert.Equal(person, result);
    }

    [Fact]
    public void AddEvent_ShouldAddEventToList()
    {
        var app = Application.Instance;
        var ev = new Event("TestEvent", new Person("eventowner@mail.com", "pw"));
        app.AddEvent(ev);
        Assert.Contains(ev, app.GetEvents());
    }

    [Fact]
    public void GetEvent_ById_ShouldReturnCorrectEvent()
    {
        var app = Application.Instance;
        var ev = new Event("EventById", new Person("event2@mail.com", "pw"));
        app.AddEvent(ev);
        var result = app.GetEvent(ev.Id);
        Assert.Equal(ev, result);
    }
}
