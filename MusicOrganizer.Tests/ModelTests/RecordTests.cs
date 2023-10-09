using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MusicOrganizer.Models;
using System;

namespace MusicOrganizer.Tests
{
  [TestClass]
  public class RecordTests : IDisposable
  {

    public void Dispose()
    {
      Record.ClearAll();
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
    public void GetAll_ReturnsEmptyList_RecordList()
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
      Record newRecord02 = new Record(title02, artworkUrl02);
      Record newRecord03 = new Record(title03, artworkUrl03);
      List<Record> newList = new List<Record> { newRecord01, newRecord02, newRecord03 };
      List<Record> result = Record.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetId_RecordsInstantiateWithAnIdAndGetterReturns_Int()
    {
      string title = "Victim in Pain";
      Record newRecord = new Record(title, "test URL");
      int result = newRecord.Id;
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectRecord_Record()
    {
      string title01 = "Up the Bracket";
      string title02 = "The Libertines";
      string title03 = "Is This It";
      string artworkUrl01 = "test URL one";
      string artworkUrl02 = "test URL two";
      string artworkUrl03 = "test URL three";
      Record newRecord01 = new Record(title01, artworkUrl01);
      Record newRecord02 = new Record(title02, artworkUrl02);
      Record newRecord03 = new Record(title03, artworkUrl03);
      Record result = Record.Find(2);
      Assert.AreEqual(newRecord02, result);
    }
  }
}