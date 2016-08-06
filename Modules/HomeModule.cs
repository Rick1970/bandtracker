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
      Get["/"] = _ => {
        List<Venue> AllVenues = Venue.GetAll();
        return View["index.cshtml", AllVenues];
      };

      Get["/bands"] = _ => {
        List<Band> AllBands = Band.GetAll();
        return View["bands.cshtml", AllBands];
      };

      Get["/venues"] = _ => {
        List<Venue> AllVenues = Venue.GetAll();
        return View["venues.cshtml", AllVenues];
      };

      Get["/venues/new"] = _ => {
        return View["venues_form.cshtml"];
      };

      Post["/venues/new"] = _ => {
        Venue newVenue = new Venue(Request.Form["venue-name"]);
        newVenue.Save();
        return View["success.cshtml"];
      };

      Get["/bands/new"] = _ => {
        return View["bands_form.cshtml"];
      };

      Post["/bands/new"] = _ => {
        Band newBand = new Band(Request.Form["band-name"]);
        newBand.Save();
        return View["success.cshtml"];
      };

      Post["/bands/delete"] = _ => {
        Band.DeleteAll();
        return View["cleared.cshtml"];
      };

      Get["/venues/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        var SelectedVenue = Venue.Find(parameters.id);
        var VenueBands = SelectedVenue.GetBands();
        model.Add("venue", SelectedVenue);
        model.Add("bands", VenueBands);
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

      Get["bands/{id}"]=parameters=>{
        Dictionary<string, object> model = new Dictionary<string, object>();
        Band selectedBand = Band.Find(parameters.id);
        List<Venue> bandVenues = selectedBand.GetVenues();
        List<Venue> allVenues = Venue.GetAll();
        model.Add("band",selectedBand);
        model.Add("bandVenues",bandVenues);
        model.Add("allVenues",allVenues);
        return View["band.cshtml",model];
      };

      Get["venues/{id}"] = parameters => {
        Dictionary<string, object> model = new Dictionary<string, object>();
        Venue selectedVenue = Venue.Find(parameters.id);
        List<Band> venueBands = selectedVenue.GetBands();
        List<Band> allBands = Band.GetAll();
        model.Add("venue", selectedVenue);
        model.Add("venueBands", venueBands);
        model.Add("allBands", allBands);
        return View["venue.cshtml", model];
      };

      Post["band/add_venue"] = _ =>{
        Venue venue= Venue.Find(Request.Form["venue-id"]);
        Band band = Band.Find(Request.Form["band-id"]);
        band.AddVenues(venue);
        return View["success.cshtml"];
      };
      
      Post["venue/add_band"] = _ => {
        Venue venue = Venue.Find(Request.Form["venue-id"]);
        Band band = Band.Find(Request.Form["band-id"]);
        venue.AddBands(band);
        return View["success.cshtml"];
      };
    }
  }
}
