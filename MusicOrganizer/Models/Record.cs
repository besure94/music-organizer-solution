using System.Collections.Generic;
using MySqlConnector;

namespace MusicOrganizer.Models
{
  public class Record
  {
    public string Title { get; set; }
    public string ArtworkUrl { get; set; }
    public int Id { get; set; }

    public Record(string title, string artworkUrl)
    {
      Title = title;
      ArtworkUrl = !string.IsNullOrEmpty(artworkUrl) ? artworkUrl : " ";
      // ArtworkUrl = artworkUrl;
      System.Console.WriteLine(ArtworkUrl);
    }

    public Record(string title, string artworkUrl, int id)
    {
      Title = title;
      ArtworkUrl = artworkUrl;
      Id = id;
    }

    public override bool Equals(System.Object otherRecord)
    {
      if (!(otherRecord is Record))
      {
        return false;
      }
      else
      {
        Record newRecord = (Record) otherRecord;
        bool idEquality = (this.Id == newRecord.Id);
        bool titleEquality = (this.Title == newRecord.Title);
        bool artworkUrlEquality = (this.ArtworkUrl == newRecord.ArtworkUrl);
        return (idEquality && titleEquality && artworkUrlEquality);
      }
    }

    public override int GetHashCode()
    {
      return Id.GetHashCode();
    }

    public void Save()
    {
      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "INSERT INTO records (title, artworkUrl) VALUES (@RecordTitle, @RecordArtworkUrl);";
      MySqlParameter param = new MySqlParameter();
      MySqlParameter paramTwo = new MySqlParameter();
      param.ParameterName = "@RecordTitle";
      paramTwo.ParameterName = "@RecordArtworkUrl";
      param.Value = this.Title;
      paramTwo.Value = this.ArtworkUrl;
      cmd.Parameters.Add(param);
      cmd.Parameters.Add(paramTwo);
      cmd.ExecuteNonQuery();
      Id = (int) cmd.LastInsertedId;
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

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
      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "DELETE FROM records;";
      cmd.ExecuteNonQuery();
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
    }

    public static Record Find(int id)
    {
      MySqlConnection conn = new MySqlConnection(DBConfiguration.ConnectionString);
      conn.Open();
      MySqlCommand cmd = conn.CreateCommand() as MySqlCommand;
      cmd.CommandText = "SELECT * FROM records WHERE id = @ThisId;";
      MySqlParameter param = new MySqlParameter();
      param.ParameterName = "@ThisId";
      param.Value = id;
      cmd.Parameters.Add(param);
      MySqlDataReader rdr = cmd.ExecuteReader() as MySqlDataReader;
      int recordId = 0;
      string recordTitle = "";
      string recordArtwork = "";
      while (rdr.Read())
      {
        recordId = rdr.GetInt32(0);
        recordTitle = rdr.GetString(1);
        recordArtwork = rdr.GetString(2);
      }
      Record foundRecord = new Record(recordTitle, recordArtwork, recordId);
      conn.Close();
      if (conn != null)
      {
        conn.Dispose();
      }
      return foundRecord;
    }
  }
}