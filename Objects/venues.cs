using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MusicBusiness
{
  public class Venues
  {
    private int _id;
    private string _name;

    public Book (string Name, int Id = 0)
    {
      _id = Id;
      _title = Name;
    }

    public static void DeleteAll()
   {
     SqlConnection connection = DB.Connection();
     connection.Open();
     SqlCommand command = new SqlCommand("DELETE FROM venues;", connection);
     command.ExecuteNonQuery();
     connection.Close();
   }

  }
}
