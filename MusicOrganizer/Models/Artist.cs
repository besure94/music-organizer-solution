using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Artist
  {
    public string Name { get; set; }
    public int Id { get; }
    private static List<Artist> _instances = new List<Artist> {};
    public List<Record> Records { get; set; }

    public Artist(string name)
    {
      Name = name;
      _instances.Add(this);
      Id = _instances.Count;
      Records = new List<Record>{};
    }

    public static List<Artist> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static Artist Find(int searchId)
    {
      return _instances[searchId-1];
    }

    public void AddRecord(Record record)
    {
      Records.Add(record);
    }
  }
}