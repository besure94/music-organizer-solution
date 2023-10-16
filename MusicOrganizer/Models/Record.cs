using System.Collections.Generic;
using MySqlConnector;

namespace MusicOrganizer.Models
{
  public class Record
  {
    public string Title { get; set; }
    public string ArtworkUrl { get; set; }
    public int Id { get; set; }
    private static List<Record> _instances = new List<Record> { };

    public Record(string title, string artworkUrl)
    {
      Title = title;
      ArtworkUrl = artworkUrl;
      _instances.Add(this);
      Id = _instances.Count;
    }

    public Record(string title, string artworkUrl, int id)
    {
      Title = title;
      ArtworkUrl = artworkUrl;
      Id = id;
    }

    // public override bool Equals(System.Object otherRecord)
    // {
    //   if (!(otherRecord is Record))
    //   {
    //     return false;
    //   }
    //   else
    //   {
    //     Record newRecord = (Record) otherRecord;
    //     // bool idEquality = (this.Id == newRecord.Id);
    //     bool titleEquality = (this.Title == newRecord.Title);
    //     bool artworkUrlEquality = (this.ArtworkUrl == newRecord.ArtworkUrl);
    //     return (titleEquality && artworkUrlEquality);
    //   }
    // }

    // public void Save()
    // {
    //   MySqlConnection conn = DB.Connection();
    //   conn.Open();
    //   MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
    //   cmd.CommandText = "INSERT INTO records (title, artworkUrl) VALUES (@RecordTitle, @RecordArtworkUrl);";
    //   MySqlParameter param = new MySqlParameter();
    //   MySqlParameter paramTwo = new MySqlParameter();
    //   param.ParameterName = "@RecordTitle";
    //   paramTwo.ParameterName = "@RecordArtworkUrl";
    //   param.Value = this.Title;
    //   paramTwo.Value = this.ArtworkUrl;
    //   cmd.Parameters.Add(param);
    //   cmd.Parameters.Add(paramTwo);
    //   cmd.ExecuteNonQuery();
    //   Id = (int) cmd.LastInsertedId;
    //   conn.Close();
    //   if (conn != null)
    //   {
    //     conn.Dispose();
    //   }
    // }

    public static List<Record> GetAll()
    {
      List<Record> allRecords = new List<Record> { };
      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "SELECT * FROM records;";
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      while (rdr.Read())
      {
        int recordId = rdr.GetInt32(0);
        string recordTitle = rdr.GetString(1);
        string recordArtworkUrl = rdr.GetString(2);
        Record newRecord = new Record(recordTitle, recordArtworkUrl, recordId);
        allRecords.Add(newRecord);
      }
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return allRecords;

    }

    public static void ClearAll()
    {

    }

    public static Record Find(int searchId)
    {
      Record placeholderRecord = new Record("placeholder record", "placeholder artwork");
      return placeholderRecord;
    }
  }
}