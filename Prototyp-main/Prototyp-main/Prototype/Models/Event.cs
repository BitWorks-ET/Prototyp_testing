namespace Prototype.Models;

public class Event
{
    public int Id { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public DateOnly Date { get; set; }
    public TimeOnly Time { get; set; }

    public List<Person> EventOwners { get; set; }
    public List<Person> EventMembers { get; set; }

    public Event(string name, Person owner)
    {
        this.Name = name;

        this.EventOwners = new List<Person> {owner};
        this.EventMembers = new List<Person>();
    }

    public Event ShallowCopy()
    {
        return (Event)this.MemberwiseClone();
    }
}