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
    public class UnitTestVacantesController
    {
        [TestMethod]
        public void Indextest()
        {
            //PREPARACION
            var vc_controller = new VacantesController();

            //PRUEBA
            ViewResult resultadoesperado = vc_controller.Index() as ViewResult;

            //VERIFICACION
            Assert.IsNotNull(resultadoesperado);
        }

        [TestMethod]
        public void Createtest()
        {
            //PREPARACION
            VacantesController indx = new VacantesController();

            //PRUEBA
            ViewResult view_r = indx.Create() as ViewResult;

            //VERIFICACION
            Assert.IsNotNull(view_r);
        }
        [TestMethod]
        public void EditTest()
        {
            //PREPARACION
            VacantesController indx = new VacantesController();

            //PRUEBA
            ViewResult view_r = indx.Edit(1) as ViewResult;

            //VERIFICACION
            Assert.IsNull(view_r);

        }

        [TestMethod]
         public void Details()
         {
            //PREPARACION
            VacantesController indx = new VacantesController();

            //PRUEBA
            ViewResult view_r = indx.Details(1) as ViewResult;

            //VERIFICACION
            Assert.IsNull(view_r);
        }

         [TestMethod]
         public void Delete()
         {
            //PREPARACION
            VacantesController indx = new VacantesController();

            //PRUEBA
            ViewResult view_r = indx.Delete(1) as ViewResult;

            //VERIFICACION
            Assert.IsNull(view_r);
        }
        
        [TestMethod]
         public void MisVacantesTest()
         {
            //PREPARACION
            VacantesController indx = new VacantesController();

            //PRUEBA
            ViewResult view_r = indx.MisVacantes() as ViewResult;

            //VERIFICACION
            Assert.IsNotNull(view_r);
        }
    }
}
