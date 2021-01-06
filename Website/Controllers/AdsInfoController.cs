using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ImotiWebsite.Models;
using ImotiWebsite.Database;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ImotiWebsite.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdsInfoController : Controller
    {
        private readonly ILogger<AdsInfoController> _logger;
        private readonly IRealEstateContext context;

        public AdsInfoController(ILogger<AdsInfoController> logger, IRealEstateContext context)
        {
            _logger = logger;
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<Ad> Get()
        {
            return context.Ads.Select(x => x);
        }
    }
}
