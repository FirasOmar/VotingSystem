using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VotingSystem.Models;

namespace VotingSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly VotingDBContext _context;
        public HomeController(VotingDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var votingDBContext = _context.CandidatePosition.Include(v => v.Candidate).Include(v => v.Position);
            return View(await votingDBContext.ToListAsync());
            //return View();
        }
        [HttpPost]
        public bool Vote(List<VoteResult> resultList)
        {
         
            return true;
        }

        [HttpPost]
        public bool checkValidVoter(int mobileNo)
        {
            var voter = _context.Voter.Where(m => m.mobileMo == mobileNo).FirstOrDefault();
            if (voter == null)
            {
                return false;
            }
            else
            {
                if (voter.voted == true)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
