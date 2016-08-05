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

  }
}
