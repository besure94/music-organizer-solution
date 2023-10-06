using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Artist
  {
    public string Name { get; set; }
    // public int Id { get; }
    private static List<Artist> _instances = new List<Artist> {};

    public Artist(string name)
    {
      Name = name;
      _instances.Add(this);
    }

    public static List<Artist> GetAll()
    {
      return _instances;
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }
  }
}