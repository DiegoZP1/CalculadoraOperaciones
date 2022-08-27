using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CalculadoraOperaciones.Models;


namespace CalculadoraOperaciones.Controllers
{
 
    public class ProductosController : Controller
    {
         [HttpPost]
		public IActionResult Productos(
             Productos calculadora,String resultado)
		{
            
            if("KG".Equals(calculadora.unidad)){
                calculadora.unidad="KG";
            }else{
                calculadora.unidad="Gramos";
            }
           
            double result = 0.0;
             result = calculadora.peso * calculadora.precio;
             calculadora.Result= result+result*0.18;
            
            ViewData["Message"] = "Nombre:  "+calculadora.nombre + "Peso:  "+calculadora.peso +"Unidad:  "+calculadora.unidad +"Precio:  "+calculadora.precio+"Precio total:  "+calculadora.Result;
   


            return View("Index",calculadora);
		}


    public IActionResult Productos()
        {
            ViewData["Message"] = "Your Calculadora page.";

            return View();
        }


        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}