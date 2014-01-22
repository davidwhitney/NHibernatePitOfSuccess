﻿using System.Web.Mvc;
using NHibernate;
using WebApplication1.Code.Model;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISession _session;

        public HomeController(ISession session)
        {
            _session = session;
        }

        public ActionResult Index()
        {
            // We've switched to a Get rather than a load here
            // To steal this excellent StackOverflow explaination

            /* Load should be used when you know for sure that an entity with a certain ID exists.
             * The call does not result in a database hit (and thus can be optimized away by NHibernate in certain cases).
             * Beware of the exception that may be raised when the object is accessed if the entity instance
             * doesn't exist in the DB.
             * 
             * Get instantly hits the database to retrieve the entity data. 
             * If the entity exists it is returned, otherwise null will be returned.
             * This is the safest way to determine whether an entity with a certain ID exists or not. 
             * If you're not sure what to use, use Get.             
             */

            // Before we changes the class map to support our enum, the call to .Load
            // appeared as though it was working - beware this in conjunction with mapping errors
            // as you'll end up with strange bugs where your entities appear to load, but they haven't.

            var customer = _session.Get<Customer>(1);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}