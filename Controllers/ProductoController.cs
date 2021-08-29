using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prog1LabPC1.Models;
using Prog1LabPC1.Data;

namespace Prog1LabPC1.Controllers
{

    
    public class ProductoController : Controller
    {
         private readonly ApplicationDbContext _context;
        
        public ProductoController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
             return View(_context.DataProductos.ToList());
        }

           public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Producto objProducto)
        {
            _context.Add(objProducto);
            _context.SaveChanges();
            ViewData["Message"] = "Producto Registrado Correctamente";
            //return RedirectToAction(nameof(Index));
            return View();
        }

         public IActionResult Edit(int id)
        {
            Producto objProducto = _context.DataProductos.Find(id);
            if(objProducto == null){
                return NotFound();
            }
            return View(objProducto);
        }

        [HttpPost]
        public IActionResult Edit(int id,[Bind("Id,name,categoria,precio,descuento")] Producto objProducto)
        {
             _context.Update(objProducto);
             _context.SaveChanges();
              ViewData["Message"] = "El Video ya esta actualizado";
             return View(objProducto);
        }

        public IActionResult Delete(int id)
        {
            Producto objProducto = _context.DataProductos.Find(id);
            _context.DataProductos.Remove(objProducto);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}