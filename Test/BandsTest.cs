using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MusicBusiness
{
  public class BandTest : IDisposable
  {
    public BandTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }
    public void Dispose()
    {
      Band.DeleteAll();
    }

    [Fact]
       public void T1_BandsEmptyAtFirst()
       {
         //arrange, act
         int result = Band.GetAll().Count;
         //assert
         Assert.Equal(0, result);
       }

       [Fact]
    public void T2_Equal_ReturnsTrueIfNamesAreTheSame()
    {
      //arrange, act
      Band firstBand = new Band("GNR");
      Band secondBand = new Band("GNR");
      //Assert
      Assert.Equal(firstBand, secondBand);
    }

    [Fact]
    public void T3_Test_Save_SavesToDatabase()
    {
      //arrange
      Band testBand = new Band("GNR");
      //act
      testBand.Save();
      List<Band> result = Band.GetAll();
      List<Band> testList = new List<Band>{testBand};
      //Assert
      Assert.Equal(testList, result);
    }
    [Fact]
    public void T4_Save_AsignsIdToObject()
    {
      //arrange
      Band newBand = new Band("GNR");
      //action
      newBand.Save();
      Band savedBand = Band.GetAll()[0];

      int result = savedBand.GetId();
      int testId = newBand.GetId();
      //assert
      Assert.Equal(testId, result);
    }

    [Fact]
    public void T5_Find_FindNameInDatabase()
    {
      //arrange
      Band testBand = new Band("Pheonix");
      testBand.Save();
      //act
      Band foundBand = Band.Find(testBand.GetId());
      //Assert
      Assert.Equal(testBand, foundBand);
    }

  }
}
