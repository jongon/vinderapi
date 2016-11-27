﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
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
            _videoAnalizer = new VideoAnalizer(
                _kairosSettings.Id,
                _kairosSettings.Key,
                _kairosSettings.MediaUrl,
                _kairosSettings.AnalyticsUrl);
        }

        [HttpGet]
        public async Task<ActionResult> Get(string id)
        {
            return Json(await _videoAnalizer.GetAnalytics(id));
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post(string url)
        {
            return Json(await _videoAnalizer.PostVideo(url));
        }
    }
}