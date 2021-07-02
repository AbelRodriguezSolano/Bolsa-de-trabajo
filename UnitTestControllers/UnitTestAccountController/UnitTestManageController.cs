using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ITLA_Jobs.Controllers;
using ITLA_Jobs.Models;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Linq;

namespace UnitTestAccountController
{
    [TestClass]
    public class UnitTestManageController
    {

        [TestMethod]
        public void AddPhoneNumbertest()
        {
            //PREPARACION
            var Manage_controller = new ManageController();

            //PRUEBA
            ViewResult result = Manage_controller.AddPhoneNumber() as ViewResult;

            //VERIFICACION
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void ChangePassword()
        {
            //PREPARACION
            var Manage_controller = new ManageController();

            //PRUEBA
            ViewResult result2 = Manage_controller.ChangePassword() as ViewResult;

            //VERIFICACION
            Assert.IsNotNull(result2);
        }

        [TestMethod]
        public void SetPassword()
        {
            //PREPARACION
            var Manage_controller = new ManageController();

            //PRUEBA
            ViewResult result3 = Manage_controller.SetPassword() as ViewResult;

            //VERIFICACION
            Assert.IsNotNull(result3);
        }
    }
}
