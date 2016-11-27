using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Vinder.Common;
using Vinder.Services.AzureStorage.Interfaces;
using VinderApi.Configuration;
using VinderApi.Models;

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

        /// <summary>
        /// Images controller constructor
        /// passing dependencies through DI
        /// </summary>
        /// <param name="azureFileHandlerFactory">Azure File Handler Factory</param>
        /// <param name="azureSettings">Azure Settings</param>
        public VideosController(
            IAzureFileHandlerFactory azureFileHandlerFactory,
            IOptions<AzureStorageSettings> azureSettings)
        {
            _azureFileHandlerFactory = azureFileHandlerFactory;
            _azureSettings = azureSettings.Value;
        }

        /// <summary>
        /// Uploads a video to Azure Blob Storage
        /// </summary>
        /// <param name="url">Url</param>
        /// <param name="fileName">FileName</param>
        /// <returns>Video's Uri on Azure Storage blob</returns>
        [HttpPost]
        public async Task<IActionResult> Post(string url, string fileName)
        {
            try
            {
                var video = new Video();
                using (var client = new HttpClient())
                using (var request = new HttpRequestMessage(HttpMethod.Get, url))
                {
                    var contentStream = await (await client.SendAsync(request)).Content.ReadAsStreamAsync();
                    var bytesFiles = contentStream.ToBytes();
                    video.File = new CommonFile
                    {
                        File = bytesFiles,
                        Name = fileName
                    };
                }

                var azureFileService = _azureFileHandlerFactory.GetService(
                    _azureSettings.ConnectionString,
                    _azureSettings.VideoContainer
                );

                var imageUri = await azureFileService.SaveFileAsync(video.File);

                return Json(new { url = imageUri });
            }
            catch (Exception e)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, e);
            }
        }
    }
}