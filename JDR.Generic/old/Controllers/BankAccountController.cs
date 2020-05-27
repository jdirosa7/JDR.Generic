using JDR.Generic.Domain;
using JDR.Generic.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JDR.Generic.UI.Web.Controllers
{
    public class BankAccountController : Controller
    {
        BankProcess dbBank = new BankProcess();
        AccountProcess dbCA = new AccountProcess();

        // GET: BankAccount
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetData()
        {
            List<IAccount> data = dbBank.GetAccounts();
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Deposit()
        {
            return View();
        }

        public ActionResult Extract()
        {
            return View();
        }

        public ActionResult Transfer()
        {
            return View();
        }

        //public JsonResult Deposit(BankOperation operation)
        //{
        //    try
        //    {
        //        dbCA.Deposit(operation);
        //        return Json("success", JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception)
        //    {
        //        return Json("error", JsonRequestBehavior.DenyGet);
        //    }
        //}

        //public ActionResult Extract(BankOperation operation)
        //{
        //    try
        //    {
        //        dbCA.Extract(operation);
        //        return Json("success", JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception)
        //    {
        //        return Json("error", JsonRequestBehavior.DenyGet);
        //    }
        //}

        //public ActionResult Transfer(BankOperation operation)
        //{
        //    try
        //    {
        //        dbCA.Transfer(operation);
        //        return Json("success", JsonRequestBehavior.AllowGet);
        //    }
        //    catch (Exception)
        //    {
        //        return Json("error", JsonRequestBehavior.DenyGet);
        //    }
        //}

        // GET: BankAccount/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BankAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BankAccount/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BankAccount/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BankAccount/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: BankAccount/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BankAccount/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
