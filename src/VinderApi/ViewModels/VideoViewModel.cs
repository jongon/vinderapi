using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VinderApi.ViewModels
{
    public class CreateUserViewModel
    {
        public string Name { get; set; }

        public string ThumbnailUrl { get; set; }

        public string VideoUrl { get; set; }

        public string AzureVideoUrl { get; set; }

        public string FileName { get; set; }
    }
}
