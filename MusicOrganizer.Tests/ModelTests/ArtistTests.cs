using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MusicOrganizer.Models;
using System;

namespace MusicOrganizer.Tests
{
  [TestClass]
  public class ArtistTests : IDisposable
  {

    public void Dispose()
    {
      Artist.ClearAll();
    }
    [TestMethod]
    public void ArtistConstructor_CreatesInstanceOfArtist_Artist()
    {
      Artist newArtist = new Artist("test artist");
      Assert.AreEqual(typeof(Artist), newArtist.GetType());
    }

    [TestMethod]
    public void GetName_ReturnsName_String()
    {
      string name = "Agnostic Front";
      Artist newArtist = new Artist(name);
      string result = newArtist.Name;
      Assert.AreEqual(name, result);
    }

    [TestMethod]
    public void SetName_SetNameValue_String()
    {
      string name = "Agnostic Front";
      Artist newArtist = new Artist(name);
      string updatedName = "Melvins";
      newArtist.Name = updatedName;
      string result = newArtist.Name;
      Assert.AreEqual(updatedName, result);
    }

    [TestMethod]
    public void GetAll_ReturnsAllArtistObjects_ArtistList()
    {
      string name01 = "Agnostic Front";
      string name02 = "Dead Moon";
      string name03 = "Sonic Youth";
      Artist newArtist01 = new Artist(name01);
      Artist newArtist02 = new Artist(name02);
      Artist newArtist03 = new Artist(name03);
      List<Artist> newList = new List<Artist> { newArtist01, newArtist02, newArtist03 };
      List<Artist> result = Artist.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetId_ReturnsArtistId_Int()
    {
      string name = "Agent Orange";
      Artist newArtist = new Artist(name);
      int result = newArtist.Id;
      Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void Find_ReturnsCorrectArtist_Artist()
    {
      string name01 = "Dwarves";
      string name02 = "The Brian Jonestown Massacre";
      Artist newArtist01 = new Artist(name01);
      Artist newArtist02 = new Artist(name02);
      Artist result = Artist.Find(2);
      Assert.AreEqual(newArtist02, result);
    }

    [TestMethod]
    public void AddRecord_AssociatesRecordWithArtist_RecordList()
    {
      string title = "Methodrone";
      string artworkUrl = "Methodrone URL";
      Record newRecord = new Record(title, artworkUrl);
      List<Record> newList = new List<Record> { newRecord };
      string name = "The Brian Jonestown Massacre";
      Artist newArtist = new Artist(name);
      newArtist.AddRecord(newRecord);
      List<Record> result = newArtist.Records;
      CollectionAssert.AreEqual(newList, result);
    }
  }
}