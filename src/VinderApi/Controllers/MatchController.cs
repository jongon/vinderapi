using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vinder.DAL;
using Vinder.DAL.Configuration;
using Vinder.DAL.Interfaces;
using VinderApi.Configuration;
using VinderApi.Factories.Interfaces;
using Vinders.Library;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace VinderApi.Controllers
{
    public class MatchController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly ApplicationDbContext _context;

        public MatchController(IUnitOfWork unitOfWork, ApplicationDbContext context)
        {
            _unitOfWork = new UnitOfWork(context);
        }

        [HttpGet]
        public IActionResult Get(Guid userId)
        {
            return Json(_unitOfWork.Match.Get(userId));
        }
    }
}
