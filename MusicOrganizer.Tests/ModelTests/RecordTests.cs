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
      Record newRecord = new Record("test");
      Assert.AreEqual(typeof(Record), newRecord.GetType());
    }

    [TestMethod]
    public void GetTitle_ReturnsTitle_String()
    {
      string title = "Definitely Maybe";
      Record newRecord = new Record(title);
      string result = newRecord.Title;
      Assert.AreEqual(title, result);
    }

    [TestMethod]
    public void SetTitle_SetTitle_String()
    {
      string title = "Definitely Maybe";
      Record newRecord = new Record(title);
      string updatedTitle = "What's the Story, Morning Glory?";
      newRecord.Title = updatedTitle;
      string result = newRecord.Title;
      Assert.AreEqual(updatedTitle, result);
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
      Record newRecord01 = new Record(title01);
      Record newRecord02 = new Record(title02);
      Record newRecord03 = new Record(title03);
      List<Record> newList = new List<Record> { newRecord01, newRecord02, newRecord03 };
      List<Record> result = Record.GetAll();
      CollectionAssert.AreEqual(newList, result);
    }

    [TestMethod]
    public void GetId_RecordsInstantiateWithAnIdAndGetterReturns_Int()
    {
      string title = "Victim in Pain";
      Record newRecord = new Record(title);
      int result = newRecord.Id;
      Assert.AreEqual(1, result);
    }
  }
}