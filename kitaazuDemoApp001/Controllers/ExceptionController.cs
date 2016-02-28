using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace kitaazuDemoApp001.Controllers
{
    public class ExceptionController : Controller
    {
        // GET: Exception
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ThrowNull()
        {
            throw new NullReferenceException("そんなものはない");
        }

        public ActionResult ThrowIndexOutOfRange()
        {
            throw new IndexOutOfRangeException("そんなものはない");
        }

        public ActionResult ThrowNotImplements()
        {
            throw new NotImplementedException("そんなものはない");
        }


    }
}