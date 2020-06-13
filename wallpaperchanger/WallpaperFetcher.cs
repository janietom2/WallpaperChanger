using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Remoting;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace wallpaperchanger
{
    class WallpaperFetcher
    {

        public string Category { private get; set; }
        public string Width { private get; set; }
        public string Height { private get; set; }
        public int MetaTotal { private get; set; }
        public RootObject Wallpapers { get; private set; }
        public List<string> Errors { get; private set; }


        WallpaperFetcher(string category, string width, string height)
        {
            this.Category = category;
            this.Width = width;
            this.Height = Height;
        }

        private async Task LoadWallpaper(string category, string width, string height)
        {

            if (category == null || category.Length < 1)
            {
                this.Errors.Add("Invalid Category");
            }

            string url = $"https://wallhaven.cc/api/v1/search?q={ category }&categories=111&purity=100&atleast={ width }x{ height }&sorting=random&order=asc";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {

                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    this.Wallpapers = JsonConvert.DeserializeObject<RootObject>(jsonString);
                }
                else 
                {
                    this.Errors.Add(response.ReasonPhrase);
                }
            }
        }


        public void CleanWallpapers(string dir)
        {
            string[] fileEntries = Directory.GetFiles(dir);

            foreach(string file in fileEntries)
            {
                try
                {
                    File.Delete(file);
                }
                catch (DirectoryNotFoundException dirEx)
                {
                    this.Errors.Add(dirEx.Message);
                }
            }
        }

        public async Task DownloadWallpapers(string dir, string category, string width, string height, int ArrayLenght)
        {
            RootObject wallpapers = await LoadWallpaper(category, width, height);

            for(int i = 0; i < ArrayLenght; i++)
            {
                string[] filename = new Uri(wallpapers.data[i].path).Segments;
                Image.DownloadFromWeb(wallpapers.data[i].path, dir, filename[filename.Length - 1]);
            }

        }
    }
}
