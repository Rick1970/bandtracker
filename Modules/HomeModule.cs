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
     Get["/venue/{id}"] = parameters => {
         Dictionary<string, object> model = new Dictionary<string, object>();
         var SelectedVenue = Venue.Find(parameters.id);
         var VenuesBands = SelectedVenue.GetBands();
         model.Add("bands", VenuesBands);
         model.Add("venues", SelectedVenue);
         return View["venue.cshtml", model];
       };
       Get["venue/edit/{id}"] = parameters => {
        Venue SelectedVenue = Venue.Find(parameters.id);
        return View["venue_edit.cshtml", SelectedVenue];
      };
     Patch["venue/edit/{id}"] = parameters => {
         Venue SelectedVenue = Venue.Find(parameters.id);
         SelectedVenue.Update(Request.Form["venue-name"]);
         return View["success.cshtml"];
       };
     Get["venue/delete/{id}"] = parameters => {
        Venue SelectedVenue = Venue.Find(parameters.id);
        return View["venue_delete.cshtml", SelectedVenue];
      };
     Delete["venue/delete/{id}"] = parameters => {
        Venue SelectedVenue = Venue.Find(parameters.id);
        SelectedVenue.Delete();
        return View["success.cshtml"];
      };
    }
  }
}
