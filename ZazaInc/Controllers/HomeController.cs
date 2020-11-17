using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using ZazaInc.Models;

namespace ZazaInc.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public ActionResult Login(String correo_usuario, String contraseña_usuario)
        {

            if (!string.IsNullOrEmpty(correo_usuario) && !string.IsNullOrEmpty(contraseña_usuario))
            {

                DBZazaIncEntities2 dB = new DBZazaIncEntities2();
                var user = dB.Usuarios.FirstOrDefault(e => e.correo_usuario == correo_usuario && e.contraseña_usuario == contraseña_usuario);

                if (user != null)
                {
                    FormsAuthentication.SetAuthCookie(user.correo_usuario, true);


                    var myCookie = new HttpCookie("myCookie");//instantiate an new cookie and give it a name
                    myCookie.Values.Add("Rol",  user.rol_usuario);//populate it with key, value pairs
                    Response.Cookies.Add(myCookie);//add it to the client




                    return RedirectToAction("Index", "Home");
                    


                }
                else
                {
                    return RedirectToAction("Index", new { Message = "no se encontro" });
                }
            }

            else
            {
                return RedirectToAction("Index", new { Message = "LLene los cuadros" });
            }


        }

        [Authorize]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index");
        }
    
}

}