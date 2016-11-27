using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Vinder.Common;
using Vinder.DAL;
using Vinder.DAL.Configuration;
using Vinder.DAL.Interfaces;
using Vinder.Services.AzureStorage.Interfaces;
using VinderApi.Configuration;
using VinderApi.Factories.Interfaces;
using VinderApi.Models;
using VinderApi.ViewModels;
using Vinders.Library;

namespace VinderApi.Controllers
{
    /// <summary>
    /// Images controller
    /// </summary>
    [Route("api/[controller]")]
    public class VideosController : Controller
    {
        /// <summary>
        /// Azure File Handler
        /// </summary>
        private readonly IAzureFileHandlerFactory _azureFileHandlerFactory;

        /// <summary>
        /// Azure Settings
        /// </summary>
        private readonly AzureStorageSettings _azureSettings;

        private readonly IUnitOfWork _unitOfWork;

        private readonly IUserFactory _userFactory;

        private readonly KairosSettings _kairosSettings;

        private readonly VideoAnalizer _videoAnalizer;

        /// <summary>
        /// Images controller constructor
        /// passing dependencies through DI
        /// </summary>
        /// <param name="azureFileHandlerFactory">Azure File Handler Factory</param>
        /// <param name="azureSettings">Azure Settings</param>
        public VideosController(
            IAzureFileHandlerFactory azureFileHandlerFactory,
            IUserFactory userFactory,
            ApplicationDbContext context,
            IOptions<KairosSettings> kairosSettings,
            IOptions<AzureStorageSettings> azureSettings)
        {
            _azureFileHandlerFactory = azureFileHandlerFactory;
            _azureSettings = azureSettings.Value;
            _unitOfWork = new UnitOfWork(context);
            _kairosSettings = kairosSettings.Value;
            _userFactory = userFactory;
            _videoAnalizer = new VideoAnalizer(
                _kairosSettings.Id,
                _kairosSettings.Key,
                _kairosSettings.MediaUrl,
                _kairosSettings.AnalyticsUrl);
        }

        /// <summary>
        /// Uploads a video to Azure Blob Storage
        /// </summary>
        /// <param name="user">User</param>
        /// <returns>Video's Uri on Azure Storage blob</returns>
        [HttpPost]
        public async Task<IActionResult> Post(CreateUserViewModel user)
        {
            try
            {
                #region Get File From Ziggeo
                var video = new Video();
                using (var client = new HttpClient())
                using (var request = new HttpRequestMessage(HttpMethod.Get, user.VideoUrl))
                {
                    var contentStream = await (await client.SendAsync(request)).Content.ReadAsStreamAsync();
                    var bytesFiles = contentStream.ToBytes();
                    video.File = new CommonFile
                    {
                        File = bytesFiles,
                        Name = user.FileName
                    };
                }
                #endregion

                #region Save File At azure
                var azureFileService = _azureFileHandlerFactory.GetService(
                    _azureSettings.ConnectionString,
                    _azureSettings.VideoContainer
                );
                user.AzureVideoUrl = await azureFileService.SaveFileAsync(video.File);
                #endregion

                #region Save User
                var userDal = _userFactory.Get(user);

                _unitOfWork.Users.Add(userDal);
                _unitOfWork.SaveChanges();
                #endregion

                #region Get VideoID
                var videoMedia = await _videoAnalizer.PostVideo(user.AzureVideoUrl);
                #endregion

                return Json(new { userId = userDal.Id, videoId = videoMedia.Id });
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }
        }
    }
}