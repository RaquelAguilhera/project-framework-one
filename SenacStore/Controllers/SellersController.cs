using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SenacStore.Data;
using SenacStore.Models;
using SenacStore.Models.ViewModels;
using System.Linq;

namespace SenacStore.Controllers
{
    public class SellersController : Controller
    {
        public readonly SenacStoreContext _context;

        public SellersController (SenacStoreContext context)
        {
            _context = context;
        }

        public IActionResult Index ()
        {
            var sellers = _context.Seller.Include("Department").ToList();

            var trainee = sellers.Where (s => s.Slary<10000);

            var sellersAscendente = sellers.OrderBy(s => s.Name).ThenBy(s => s.Slary);

            return View (trainee);
        }

        public  IActionResult Create()
        {
            //cria uma instancia de sellers
            //essa instancia vai ter duas propriedades
            //um vendedor e uma lista de departamentos
            var viewModel = new SellerFormViewModel();
            viewModel.Departments = _context.Department.ToList();
            return View(viewModel);
        }
        [HttpPost]
        public IActionResult Create (Seller Seller)
        {
            /* testa se foi passado um obj vendedor */ 

            if (Seller == null)
            {
                return NotFound();
            }
           // Seller.Department = _context.Department.FirstOrDefault();
           // Seller.DepartmentId = Seller.Department.Id;

            _context.Add(Seller);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details (int id)
        {
            var seller = _context.Seller.Include("Department").FirstOrDefault(s => s.Id == id);

            if (seller == null)
            {
                return NotFound();
            }

            return View(seller);
        }

        public IActionResult Edit(int id)
        {
            Seller seller = _context.Seller.FirstOrDefault(s => s.Id == id);

            if (seller == null)
            {
                return NotFound();

            }

            List<Department> departments = _context.Department.ToList();

            SellerFormViewModel viewModel = new SellerFormViewModel();
            viewModel.Departments = departments;
            viewModel.Seller = seller;

            return View(viewModel);
        }

        [HttpPost]

        public IActionResult Edit(Seller Seller)
        {
            if(Seller == null)
            { return NotFound(); }

            _context.Update(Seller);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int? id)
        {
            //Busca no banco de dados o vendedor com o id informado
            Seller seller = _context.Seller.Include("Department").FirstOrDefault(s => s.Id == id);

            if (seller == null)
            {
                return NotFound();
            }

            return View(seller);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            Seller seller = _context.Seller.FirstOrDefault(s => s.Id == id);

            if (seller == null)
            {
                return NotFound();
            }

            _context.Remove(seller);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Report ()
        {
            var sellers = _context.Seller.Include("Department").ToList();
            ViewData["totalfoladepagamento"] = sellers.Sum(s => s.Slary);

            ViewData["MAIOR"] = sellers.Max(s => s.Slary);

            ViewData["MENOR"] = sellers.Min(s => s.Slary);

            ViewData["MEDIA"] = sellers.Average(s => s.Slary);

            ViewData["RICOS"] = sellers.Count(s => s.Slary >= 10000);

            return View();
        }
    }
}
