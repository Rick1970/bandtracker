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


  }
}
