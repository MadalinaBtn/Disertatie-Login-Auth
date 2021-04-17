using LucrareDeDisertatie.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace LucrareDeDisertatie.Controllers
{

    
    public class HomeController : Controller
    {
        private EntitatiDB _db = new EntitatiDB();

        // GET: Home
        public ActionResult Index()
        {
            if (Session["idUtilizator"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
            
        }


        // register
        public ActionResult Inregistrare()
        {

            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Inregistrare(Utilizator _utilizator)
        {
            if (ModelState.IsValid)
            {
                var check = _db.Utilizatori.FirstOrDefault(s => s.Email == _utilizator.Email);
                if (check == null)
                {
                    _utilizator.Parola = GetMD5(_utilizator.Parola);
                    _db.Configuration.ValidateOnSaveEnabled = false;
                    _db.Utilizatori.Add(_utilizator);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Email deja folosit.";
                    return View();
                }


            }
            return View();


        }


        //creare string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

        //login
        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginUtilizator _utilizatorLogin)
        {
            if (ModelState.IsValid)
            {


                var f_parola = GetMD5(_utilizatorLogin.Parola);
                var data = _db.Utilizatori.Where(s => s.Email.Equals(_utilizatorLogin.Email) && s.Parola.Equals(f_parola)).ToList();
                if (data.Count() > 0)
                {
                    //adauga sesiune
                    Session["NumeComplet"] = data.FirstOrDefault().Nume + " " + data.FirstOrDefault().Prenume;
                    Session["Email"] = data.FirstOrDefault().Email;
                    Session["idUtilizator"] = data.FirstOrDefault().idUtilizator;
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.error = "Incercarea de autentificare a esuat. ";
                    return RedirectToAction("Login");
                }
            }
            return View();
        }


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//sterge sesiune
            return RedirectToAction("Login");
        }


    }
}