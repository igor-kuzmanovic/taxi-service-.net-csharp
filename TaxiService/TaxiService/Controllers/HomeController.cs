using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using TaxiService.Models;
using TaxiService.ViewModels;

namespace TaxiService.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext db = new AppDbContext();

        public ActionResult Index()
        {
            return RedirectToAction("Home");
        }

        [HttpGet]
        public ActionResult Home()
        {
            var user = (AppUser)Session["User"];
            if (user == null)
            {
                return RedirectToAction("SignIn", "Login");
            }

            if (user.Role == UserRole.Dispatcher)
            {
                return RedirectToAction("Dispatcher");
            }
            else
            {
                return RedirectToAction("Driver");
            }
        }

        [HttpGet]
        public ActionResult Search()
        {
            var user = (AppUser)Session["User"];
            if (user == null)
            {
                return RedirectToAction("SignIn", "Login");
            }

            return View();
        }

        [HttpGet]
        public ActionResult Dispatcher()
        {
            var user = (AppUser)Session["User"];
            if (user == null)
            {
                return RedirectToAction("SignIn", "Login");
            }

            if (user.Role != UserRole.Dispatcher)
            {
                return new HttpUnauthorizedResult();
            }

            var rides = db.Rides.Include(r => r.Dispatcher)
                .Include(r => r.Driver)
                .Include(r => r.Source)
                .Include(r => r.Destination)
                .Include(r => r.Comment);

            var rideTableRows = GenerateQuery(rides).ToList().Select(r => new RideTableRow(r));

            return View("Index", rideTableRows);
        }

        [HttpGet]
        public ActionResult Driver()
        {
            var user = (AppUser)Session["User"];
            if (user == null)
            {
                return RedirectToAction("SignIn", "Login");
            }

            if (user.Role != UserRole.Driver)
            {
                return new HttpUnauthorizedResult();
            }

            var rides = db.Rides.Include(r => r.Dispatcher)
                .Include(r => r.Driver)
                .Include(r => r.Source)
                .Include(r => r.Destination)
                .Include(r => r.Comment)
                .Where(r => r.Driver.Id == user.Id);

            var rideTableRows = GenerateQuery(rides).ToList().Select(r => new RideTableRow(r));

            return View("Index", rideTableRows);
        }

        private IQueryable<Ride> GenerateQuery(IQueryable<Ride> rides)
        {
            if (Request.QueryString["status"] != null)
            {
                var status = Request.QueryString["status"];

                switch (status)
                {
                    case "1":
                        rides = rides.Where(r => r.Status == RideStatus.Formed);
                        break;
                    case "2":
                        rides = rides.Where(r => r.Status == RideStatus.Failed);
                        break;
                    case "3":
                        rides = rides.Where(r => r.Status == RideStatus.Successful);
                        break;
                    case "0":
                    default:
                        break;
                }
            }

            if (Request.QueryString["sortBy"] != null)
            {
                var sortBy = Request.QueryString["sortBy"];

                switch (sortBy)
                {
                    case "1":
                        rides = rides.OrderByDescending(r => r.OrderDateTime);
                        break;
                    case "2":
                        rides = rides.OrderByDescending(r => r.Comment.Rating);
                        break;
                    case "0":
                    default:
                        break;
                }
            }

            if (Request.QueryString["orderDateMin"] != null)
            {
                var orderDateMin = Request.QueryString["orderDateMin"];

                if (DateTime.TryParse(orderDateMin, out DateTime result))
                {
                    rides = rides.Where(r => r.OrderDateTime >= result);
                }
            }

            if (Request.QueryString["orderDateMax"] != null)
            {
                var orderDateMax = Request.QueryString["orderDateMax"];

                if (DateTime.TryParse(orderDateMax, out DateTime result))
                {
                    rides = rides.Where(r => r.OrderDateTime <= result);
                }
            }

            if (Request.QueryString["ratingMin"] != null)
            {
                var ratingMin = Request.QueryString["ratingMin"];

                if (int.TryParse(ratingMin, out int result) && result > 0)
                {
                    rides = rides.Where(r => r.Status == RideStatus.Failed && (int)r.Comment.Rating >= result);
                }
            }

            if (Request.QueryString["ratingMax"] != null)
            {
                var ratingMax = Request.QueryString["ratingMax"];

                if (int.TryParse(ratingMax, out int result) && result > 0)
                {
                    rides = rides.Where(r => r.Status == RideStatus.Failed && (int)r.Comment.Rating <= result);
                }
            }

            if (Request.QueryString["priceMin"] != null)
            {
                var priceMin = Request.QueryString["priceMin"];

                if (int.TryParse(priceMin, out int result))
                {
                    rides = rides.Where(r => r.Status == RideStatus.Successful && r.Price.Value >= result);
                }
            }

            if (Request.QueryString["priceMax"] != null)
            {
                var priceMax = Request.QueryString["priceMax"];

                if (int.TryParse(priceMax, out int result))
                {
                    rides = rides.Where(r => r.Status == RideStatus.Successful && r.Price.Value <= result);
                }
            }

            if (Request.QueryString["firstName"] != null)
            {
                var firstName = Request.QueryString["firstName"];

                if (!string.IsNullOrWhiteSpace(firstName))
                {
                    rides = rides.Where(r => r.Driver.FirstName.ToLower().Contains(firstName.ToLower()));
                }
            }

            if (Request.QueryString["lastName"] != null)
            {
                var lastName = Request.QueryString["lastName"];

                if (!string.IsNullOrWhiteSpace(lastName))
                {
                    rides = rides.Where(r => r.Driver.LastName.ToLower().Contains(lastName.ToLower()));
                }
            }

            return rides;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}