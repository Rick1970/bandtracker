using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MusicBusiness
{
  public class VenueTest : IDisposable
  {
    public VenueTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }
    public void Dispose()
    {
      Venue.DeleteAll();
    }

    [Fact]
    public void T1_VenuesEmptyAtFirst()
    {
      //arrange, act
      int result = Venue.GetAll().Count;
      //assert
      Assert.Equal(0, result);
    }

    [Fact]
    public void T2_Equal_ReturnsTrueIfNamesAreTheSame()
    {
      //arrange, act
      Venue firstVenue = new Venue("Pheonix");
      Venue secondVenue = new Venue("Pheonix");
      //Assert
      Assert.Equal(firstVenue, secondVenue);
    }
    [Fact]
    public void T3_Test_Save_SavesToDatabase()
    {
      //arrange
      Venue testVenue = new Venue("Pheonix");
      //act
      testVenue.Save();
      List<Venue> result = Venue.GetAll();
      List<Venue> testList = new List<Venue>{testVenue};
      //Assert
      Assert.Equal(testList, result);
    }

    [Fact]
    public void T4_Save_AsignsIdToObject()
    {
      //arrange
      Venue newVenue = new Venue("Pheonix");
      //action
      newVenue.Save();
      Venue savedVenue = Venue.GetAll()[0];

      int result = savedVenue.GetId();
      int testId = newVenue.GetId();
      //assert
      Assert.Equal(testId, result);
    }

    [Fact]
    public void T5_Find_FindNameInDatabase()
    {
      //arrange
      Venue testVenue = new Venue("Pheonix");
      testVenue.Save();
      //act
      Venue foundVenue = Venue.Find(testVenue.GetId());
      //Assert
      Assert.Equal(testVenue, foundVenue);
    }
    [Fact]
    public void T6_Update_UpdatesVenueInDatabase()
    {
      //Arrange
      string name = "Pheonix";
      Venue testVenue = new Venue(name);
      testVenue.Save();
      string newName = "Rock Candy";
      //Act
      testVenue.Update(newName);
      string result = testVenue.GetName();
      //Assert
      Assert.Equal(newName, result);
    }

    // [Fact]
    // public void T6_GetBands_RetrievesAllBandsWithVenue()
    // {
    //   Venue testVenue = new Venue("Paramont");
    //   testVenue.Save();
    //
    //   Band firstBand = new Band("GNR", testVenue.GetId());
    //   firstBand.Save();
    //   Band secondBand = new Band("Slayer", testVenue.GetId());
    //   secondBand.Save();
    //
    //
    //   List<Band> testBandList = new List<Band> {firstBand, secondBand};
    //   List<Band> resultBandList = testVenue.GetBands();
    //
    //   Assert.Equal(testBandList, resultBandList);
    // }

    // [Fact]
    // public void T7_Delete_DeletesVenueFromDatabase()
    // {
    //   //Arrange
    //   string name1 = "Pheonix";
    //   Venue testVenue1 = new Venue(name1);
    //   testVenue1.Save();
    //
    //   string name2 = "Rock Candy";
    //   Venue testVenue2 = new Venue(name2);
    //   testVenue2.Save();
    //
    //   Band testBand1 = new Band("Metallica", testVenue1.GetId());
    //   testBand1.Save();
    //   Band testBand2 = new Band("Guns and Roses", testVenue2.GetId());
    //   testBand2.Save();
    //
    //   //Act
    //   testVenue1.Delete();
    //   List<Venue> resultVenue = Venue.GetAll();
    //   List<Venue> testVenueList = new List<Venue> {testVenue2};
    //
    //   List<Band> resultBands = Band.GetAll();
    //   List<Band> testBandList = new List<Band> {testBand2};
    //
    //   //Assert
    //   Assert.Equal(testVenueList, resultVenue);
    //   Assert.Equal(testBandList, resultBands);
    // }
  }
}
