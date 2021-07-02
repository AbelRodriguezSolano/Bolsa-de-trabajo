using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ITLA_Jobs.Controllers;
using ITLA_Jobs.Models;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace UnitTestAccountController
{

    [TestClass]
    public class UnitTestAccountController
    {
        [TestMethod]
        public void Logintest()
        {
            //PREPARACION
            AccountController AC_Controller = new AccountController();
            var lgn = new ExternalLoginConfirmationViewModel() { Email = string.Empty };

            //PRUEBA
            ViewResult vr = AC_Controller.Login("") as ViewResult;
            var resultado = lgn.Email;

            //VERIFICACION
            Assert.IsNotNull(AC_Controller);
            Assert.IsNotNull(resultado);
        }
        [TestMethod]
        public async Task Registertest2()
        {
            //PREPARACION
            AccountController registro = new AccountController();

            //PRUEBA
            ViewResult vr = registro.Register() as ViewResult;

            //VERIFICACION
            Assert.IsNotNull(registro);
        }
        [TestMethod]
        public void ForgotPasswordConfirmationTest()
        {

            //PREPARACION
            AccountController pass = new AccountController();

            //PRUEBA
            var result1 = pass.ForgotPasswordConfirmation();

            //VERIFICACION
            Assert.IsNotNull(result1);
        }
        [TestMethod]
        public void ResetPasswordConfirmationtest()
        {
            //PREPARACION
            AccountController pass_reset = new AccountController();

            //PRUEBA
            var result2 = pass_reset.ResetPasswordConfirmation();

            //VERIFICACION
            Assert.IsNotNull(result2);
        }
        [TestMethod]
        public void ExternalLoginFailure()
        {
            AccountController pass_setting = new AccountController();

            var result4 = pass_setting.ExternalLoginFailure();

            Assert.IsNotNull(result4);
        }
        [TestMethod]
        public void Indextest()
        {
            HomeController pass_setting = new HomeController();

            var resultado = pass_setting.Index();

            Assert.IsNotNull(resultado);
        }
    }
}
