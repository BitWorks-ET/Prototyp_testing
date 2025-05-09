﻿namespace Prototype.Models;

public class Organization
{
    public int Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public string Domain { get; set; }
    
    public List<Event> Events { get; set; }

    public List<Person> OrgAdmins { get; set; }
    public List<Person> OrgMembers { get; set; }

    public Organization(string name, Person organizer)
    {
        this.Name = name;

        this.Events = new List<Event>();

        this.OrgAdmins = new List<Person> { organizer };
        this.OrgMembers = new List<Person>();
    }
}