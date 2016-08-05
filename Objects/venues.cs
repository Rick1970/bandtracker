using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace MusicBusiness
{
  public class Venue
  {
    private int _id;
    private string _name;
    //Constructor
    public Venue (string Name, int Id = 0)
    {
      _id = Id;
      _name = Name;
    }
    //Getter and Setters
    public int GetId()
    {
      return _id;
    }
    public string GetName()
    {
      return _name;
    }
    public void SetName(string newName)
    {
      _name = newName;
    }
    //Functions
    public static List<Venue> GetAll()
    {
      List<Venue> allVenues = new List<Venue>{};

      SqlConnection conn = DB.Connection();
      conn.Open();

      SqlCommand cmd = new SqlCommand("SELECT * FROM venues;", conn);
      SqlDataReader rdr = cmd.ExecuteReader();

      while (rdr.Read())
      {
        int venueId = rdr.GetInt32(0);
        string venueName = rdr.GetString(1);
        Venue newVenue = new Venue(venueName, venueId);
        allVenues.Add(newVenue);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return allVenues;
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
