using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Vinder.Services.AzureStorage.Interfaces;
using VinderApi.Configuration;
using Vinders.Library;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace VinderApi.Controllers
{
    [Route("api/[controller]")]
    public class AnalyzerController : Controller
    {
        /// <summary>
        /// Kairos Settings
        /// </summary>
        private readonly KairosSettings _kairosSettings;

        private readonly VideoAnalizer _videoAnalizer;

        /// <summary>
        /// Kairos analizer controller constructor
        /// passing dependencies through DI
        /// </summary>
        /// <param name="kairosSettings">Kairos Settings</param>
        public AnalyzerController(
            IOptions<KairosSettings> kairosSettings)
        {
            _kairosSettings = kairosSettings.Value;
        }
        // POST api/values
        [HttpPost]
        public void Post([FromBody]string url)
        {

        }
    }
}
