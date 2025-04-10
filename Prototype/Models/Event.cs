﻿namespace Prototype.Models;

public class Event
{
    public int Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }

    public List<Person> EventOwners { get; set; }
    public List<Person> EventMembers { get; set; }
}