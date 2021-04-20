using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WAD_BookLibrary_8574.Models;
using WAD_BookLibrary_8574.Data.Interfaces;
using WAD_BookLibrary_8574.ViewModel;

namespace WAD_BookLibrary_8574.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly ICustomerRepository _customerRepository;

        public HomeController(IBookRepository bookRepository,
                              IAuthorRepository authorRepository,
                              ICustomerRepository customerRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _customerRepository = customerRepository;
        }
        public IActionResult Index()
        {
            // create home view model
            var homeVM = new HomeViewModel()
            {
                AuthorCount = _authorRepository.Count(x => true),
                CustomerCount = _customerRepository.Count(x=>true),
                BookCount = _bookRepository.Count(x => true),
                LendBookCount= _bookRepository.Count(x => x.Borrower != null)
            };
            // call view
            return View(homeVM);
        }
    }
}
