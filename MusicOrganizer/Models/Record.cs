using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Record
  {
    public string Title { get; set; }
    private static List<Record> _instances = new List<Record> { };

    public Record(string title)
    {
      Title = title;
      _instances.Add(this);
    }

    public static List<Record> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }
  }
}