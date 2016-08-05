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
       public void T7_Update_UpdatesVenueInDatabase()
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
  }
}
