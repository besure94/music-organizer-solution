using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Artist
  {
    public string Name { get; }

    public Artist(string name)
    {
      Name = name;
    }
  }
}