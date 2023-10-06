using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MusicOrganizer.Models;
using System;
using System.Collections.ObjectModel;

namespace MusicOrganizer.Tests
{
  [TestClass]
  public class ArtistTests
  {
    [TestMethod]
    public void ArtistConstructor_CreatesInstanceOfArtist_Artist()
    {
      Artist newArtist = new Artist("test artist");
      Assert.AreEqual(typeof(Artist), newArtist.GetType());
    }
  }
}