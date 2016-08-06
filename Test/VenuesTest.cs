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
      Band.DeleteAll();
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

    [Fact]
    public void T7_AddVenueToBand_True()
    {
      Band testBand = new Band("GNR");
      testBand.Save();


      Venue testVenue = new Venue("Paramont");
      testVenue.Save();

      Venue testVenue2 = new Venue("Rock Candy");
      testVenue2.Save();

      testBand.AddVenues(testVenue);
      testBand.AddVenues(testVenue2);
      List<Venue> allVenue = Venue.GetAll();
      List<Venue> result = testBand.GetVenues();
      List<Venue> testList = new List<Venue>{testVenue,testVenue2};

      Assert.Equal(testList, result);
    }

    [Fact]
    public void T8_GetVenues_ReturnsAllVenueBand()
    {
      Band testBand = new Band("GNR");
      testBand.Save();

      Venue testVenue1 = new Venue("Paramont");
      testVenue1.Save();

      Venue testVenue2 = new Venue("Rock Candy");
      testVenue2.Save();

      Venue testVenue3 = new Venue("Cafe Arizona");
      testVenue3.Save();

      Venue testVenue4 = new Venue("Joes Bar and Grill");
      testVenue4.Save();

      testBand.AddVenues(testVenue1);

      List<Venue> result = testBand.GetVenues();
      List<Venue> testList= new List<Venue>{testVenue1};

      Assert.Equal(testList,result);
    }

    [Fact]
    public void T9_Delete_DeletesVenueFromDB()
    {
      Venue testVenue1 = new Venue("Paramont");
      testVenue1.Save();
      Venue testVenue2 = new Venue("HD Hotspurs");
      testVenue2.Save();

      testVenue1.Delete();

      List<Venue> result = Venue.GetAll();
      List<Venue> testVenues = new List<Venue> {testVenue2};

      Assert.Equal(testVenues, result);
    }
  }
}
