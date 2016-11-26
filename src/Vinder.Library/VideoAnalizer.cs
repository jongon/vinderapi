using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Vinders.Library
{
    public class VideoAnalizer
    {
        private readonly string _id;

        private readonly string _key;

        private readonly string _url;

        public VideoAnalizer(string id, string key, string url)
        {
            _id = id;
            _key = key;
            _url = url;
        }

        public async Task Analize(string videoUrl)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("app_id", _id);
                client.DefaultRequestHeaders.Add("app_key", _key);

                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("source", videoUrl),
                });

                var response = await client.PostAsync(_url, formContent);
                //var bytesFiles = contentStream.ToBytes();
                //video.File = new CommonFile
                //{
                //    File = bytesFiles,
                //    Name = fileName
                //};
            }
        }
    }
}
