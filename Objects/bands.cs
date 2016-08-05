using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MusicBusiness
{
  public class Band
  {
    private int _id;
    private string _name;

    public Band (string Name, int Id = 0)
    {
      _id = Id;
      _name = Name;
    }

    public static void DeleteAll()
   {
     SqlConnection connection = DB.Connection();
     connection.Open();
     SqlCommand command = new SqlCommand("DELETE FROM bands;", connection);
     command.ExecuteNonQuery();
     connection.Close();
   }

  }
}
