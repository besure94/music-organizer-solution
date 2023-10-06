using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Record
  {
    public string Title { get; set; }
    public Record(string title)
    {
      Title = title;
    }
  }
}