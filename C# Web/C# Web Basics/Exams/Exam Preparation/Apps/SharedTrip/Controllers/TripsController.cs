﻿using SharedTrip.Services;
using SharedTrip.ViewModels.Trips;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace SharedTrip.Controllers
{
    public class TripsController : Controller
    {
        private readonly ITripsService tripsService;

        public TripsController(ITripsService tripsService)
        {
            this.tripsService = tripsService;
        }

        public HttpResponse Add()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("Users/Login");
            }

            return this.View();
        }

        public HttpResponse All()
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("Users/Login");
            }

            var trips = this.tripsService.GetAll();
            return this.View(trips);
        }

        [HttpPost]
        public HttpResponse Add(AddTripInputModel input)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("Users/Login");
            }

            if (string.IsNullOrEmpty(input.StartPoint))
            {
                return this.Error("Start point is required.");
            }

            if (string.IsNullOrEmpty(input.EndPoint))
            {
                return this.Error("End point is required.");
            }

            if (input.Seats < 2 || input.Seats > 6)
            {
                return this.Error("Seats should be between 2 and 6.");
            }

            if (string.IsNullOrEmpty(input.Description) || input.Description.Length > 80)
            {
                return this.Error("Invalid description.");
            }

            if (!DateTime.TryParseExact(input.DepartureTime, "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
            {
                return this.Error("Invalid departure time. Please use : (dd.MM.yyyy HH: mm) format.");
            }

            this.tripsService.Create(input);

            return this.Redirect("/Trips/All");
        }

        public HttpResponse Details(string tripId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("Users/Login");
            }

            var trip = this.tripsService.GetDetails(tripId);

            return this.View(trip);
        }

        public HttpResponse AddUserToTrip(string tripId)
        {
            if (!this.IsUserSignedIn())
            {
                return this.Redirect("Users/Login");
            }

            if (!this.IsUserSignedIn())
            {
                return this.Redirect("/Users/Login");
            }

            if (!this.tripsService.HasAvailableSeats(tripId))
            {
                return this.Error("There is no available seats.");
            }

            var userId = this.GetUserId();

            if (!this.tripsService.AddUserToTrip(userId, tripId))
            {
                return this.Redirect("/Trips/Details?tripId=" + tripId);
            }

            return this.Redirect("/Trips/All");
        }
    }
}
