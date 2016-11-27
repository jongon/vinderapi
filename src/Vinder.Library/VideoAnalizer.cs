using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Vinder.Common;
using Vinders.Library.VideoAnalysis;

namespace Vinders.Library
{
    public class VideoAnalizer
    {
        private readonly string _id;

        private readonly string _key;

        private readonly string _mediaUrl;

        private readonly string _analyticsUrl;

        public VideoAnalizer(string id, string key, string mediaUrl, string analyticsUrl)
        {
            _id = id;
            _key = key;
            _mediaUrl = mediaUrl;
            _analyticsUrl = analyticsUrl;
        }

        public async Task<VideoMedia> PostVideo(string videoUrl)
        {
            var formUrl = $"{_mediaUrl}?source={videoUrl}";
            return await FetchData(formUrl);
        }

        public async Task<VideoMedia> GetAnalytics(string id)
        {
            var formUrl = $"{_mediaUrl}/{id}";
            return await FetchData(formUrl);
        }

        private async Task<VideoMedia> FetchData(string url)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("app_id", _id);
                client.DefaultRequestHeaders.Add("app_key", _key);

                var stringContent = new StringContent("");
                var response = await client.PostAsync(url, stringContent);
                var responseString = response.Content.ReadAsStringAsync().Result;
                var responseJson = JsonConvert.DeserializeObject<VideoMedia>(
                    responseString,
                    new JsonSerializerSettings()
                    {
                        ContractResolver = new UnderscorePropertyNamesContractResolver()
                    });

                return responseJson;
            }
        }
    }
}
