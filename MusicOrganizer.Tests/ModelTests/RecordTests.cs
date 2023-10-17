using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MusicOrganizer.Models;
using System;

namespace MusicOrganizer.Tests
{
  [TestClass]
  public class RecordTests : IDisposable
  {
    public IConfiguration Configuration { get; set; }

    public void Dispose()
    {
      Record.ClearAll();
    }
    public RecordTests()
    {
      IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");
      Configuration = builder.Build();
      DBConfiguration.ConnectionString = Configuration["ConnectionStrings:TestConnection"];
    }

    [TestMethod]
    public void RecordConstructor_CreatesInstanceOfRecord_Record()
    {
      Record newRecord = new Record("test", "test URL");
      Assert.AreEqual(typeof(Record), newRecord.GetType());
    }

    [TestMethod]
    public void GetTitle_ReturnsTitle_String()
    {
      string title = "Definitely Maybe";
      Record newRecord = new Record(title, "test URL");
      string result = newRecord.Title;
      Assert.AreEqual(title, result);
    }

    [TestMethod]
    public void SetTitle_SetTitle_String()
    {
      string title = "Definitely Maybe";
      Record newRecord = new Record(title, "test URL");
      string updatedTitle = "What's the Story, Morning Glory?";
      newRecord.Title = updatedTitle;
      string result = newRecord.Title;
      Assert.AreEqual(updatedTitle, result);
    }

    [TestMethod]
    public void GetArtworkUrl_ReturnsArtworkUrl_String()
    {
      string artworkUrl = "test URL";
      Record newRecord = new Record("Melvins", artworkUrl);
      string result = newRecord.ArtworkUrl;
      Assert.AreEqual(artworkUrl, result);
    }

    [TestMethod]
    public void Equals_ReturnsTrueIfRecordsAreTheSame_Record()
    {
      Record firstRecord = new Record("The Battle for Los Angeles", "album.jpg");
      Record secondRecord = new Record("The Battle for Los Angeles", "album.jpg");
      Assert.AreEqual(firstRecord, secondRecord);
    }

    [TestMethod]
    public void GetAll_ReturnsEmptyListFromDatabase_RecordList()
    {
      List<Record> newList = new List<Record> { };
      List<Record> result = Record.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetAll_ReturnsRecords_RecordList()
    {
      string title01 = "Definitely Maybe";
      string title02 = "What's the Story, Morning Glory?";
      string title03 = "In the Graveyard";
      string artworkUrl01 = "test URL one";
      string artworkUrl02 = "test URL two";
      string artworkUrl03 = "test URL three";
      Record newRecord01 = new Record(title01, artworkUrl01);
      newRecord01.Save();
      Record newRecord02 = new Record(title02, artworkUrl02);
      newRecord02.Save();
      Record newRecord03 = new Record(title03, artworkUrl03);
      newRecord03.Save();
      List<Record> newList = new List<Record> { newRecord01, newRecord02, newRecord03 };
      List<Record> result = Record.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetId_RecordsInstantiateWithAnIdAndGetterReturns_Int()
    {
      string title = "Victim in Pain";
      Record newRecord = new Record(title, "test URL");
      newRecord.Save();
      Record foundRecord = Record.Find(newRecord.Id);
      Assert.AreEqual(foundRecord.Id, newRecord.Id);
    }

    [TestMethod]
    public void Find_ReturnsCorrectItemFromDatabase_Record()
    {
      Record newRecord = new Record("Oracular Spectacular", "artwork.jpg");
      newRecord.Save();
      Record newRecordTwo = new Record("Echoes", "album.jpg");
      newRecordTwo.Save();
      Record foundRecord = Record.Find(newRecord.Id);
      Assert.AreEqual(newRecord, foundRecord);
    }

    [TestMethod]
    public void Save_SavesToDataBase_RecordList()
    {
      Record testRecord = new Record("Victim in Pain", "albumart.jpg");
      testRecord.Save();
      List<Record> result = Record.GetAll();
      List<Record> testList = new List<Record> { testRecord };
      CollectionAssert.AreEqual(testList, result);
    }
  }
}