using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Vinder.DAL;
using Vinder.DAL.Configuration;
using Vinder.DAL.Interfaces;
using VinderApi.Configuration;
using VinderApi.Factories.Interfaces;
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

        private readonly IUnitOfWork _unitOfWork;

        private readonly IUserFactory _userFactory;

        /// <summary>
        /// Kairos analizer controller constructor
        /// passing dependencies through DI
        /// </summary>
        /// <param name="kairosSettings">Kairos Settings</param>
        public AnalyzerController(
            IOptions<KairosSettings> kairosSettings,
            IUserFactory userFactory,
            ApplicationDbContext context)
        {
            _kairosSettings = kairosSettings.Value;
            _videoAnalizer = new VideoAnalizer(
                _kairosSettings.Id,
                _kairosSettings.Key,
                _kairosSettings.MediaUrl,
                _kairosSettings.AnalyticsUrl);
            _unitOfWork = new UnitOfWork(context);
            _userFactory = userFactory;
        }

        [HttpGet]
        public async Task<ActionResult> Get(Guid userId, string videoId)
        {
            var videoMedia = await _videoAnalizer.GetAnalytics(videoId);

            if (videoMedia.StatusCode != 4)
            {
                return Json(new
                {
                    statusCode = videoMedia.StatusCode,
                    statusMessage = videoMedia.StatusMessage
                });
            }

            #region Set Emotions To User
            var user = _unitOfWork.Users.Get(userId);
            user = _userFactory.GetWithEmotions(user, videoMedia);
            _unitOfWork.Users.Update(user);
            #endregion

            return Json(await _videoAnalizer.GetAnalytics(videoId));
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult> Post(string url)
        {
            return Json(await _videoAnalizer.PostVideo(url));
        }
    }
}