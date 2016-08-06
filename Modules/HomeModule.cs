using System.Collections.Generic;
using Nancy;
using Nancy.ViewEngines.Razor;
using System;

namespace MusicBusiness
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
       Get ["/"] = _ => {
         List<Venue> AllVenues = Venue.GetAll();
         return View["index.cshtml"];
       };
       Get["/venues"] = _ => {
       List<Venue> AllVenues = Venue.GetAll();
       return View["venues.cshtml", AllVenues];
     };
      Get["/bands"] = _ => {
       List<Band> AllBands = Band.GetAll();
       return View["bands.cshtml", AllBands];
     };
     Get["/venues/new"] = _ => {
       return View["venues_form.cshtml"];
     };
     Post["/venues/new"] = _ =>{
       Venue newVenue = new Venue(Request.Form["venue-name"]);
       newVenue.Save();
       return View["success.cshtml"];
     };
     Get["/bands/new"] = _ => {
       List<Venue> AllVenue = Venue.GetAll();
       return View["bands_form.cshtml", AllVenue];
     };
     Post["/bands/new"] = _ => {
       Band newBand = new Band(Request.Form["band-name"], Request.Form["venue-id"]);
       newBand.Save();
       return View["success.cshtml"];
     };
    
    }
  }
}
