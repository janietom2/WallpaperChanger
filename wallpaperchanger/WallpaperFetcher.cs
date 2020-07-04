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
        public RootObject Wallpaper { get; private set; }
        public List<string> Errors { get; private set; }


        public WallpaperFetcher(string category, string width, string height)
        {
            this.Category = category;
            this.Width = width;
            this.Height = height;
            
        }

        public async Task<Boolean> LoadWallpaper()
        {

            if (this.Category == null || this.Category.Length < 1)
            {
                this.Errors.Add("Invalid Category");
                return false;
            }

            string url = $"https://wallhaven.cc/api/v1/search?q={ this.Category }&categories=111&purity=100&atleast={ this.Width }x{ this.Height }&sorting=random&order=asc";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {

                if (response.IsSuccessStatusCode)
                {
                    string jsonString = await response.Content.ReadAsStringAsync();
                    this.Wallpaper = JsonConvert.DeserializeObject<RootObject>(jsonString);
                    return true;
                }
                else
                {
                    return false;
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

        public async Task DownloadWallpapers(string dir,  int ArrayLenght)
        {
            for(int i = 0; i < ArrayLenght; i++)
            {
                string[] filename = new Uri(this.Wallpaper.data[i].path).Segments;
                Image.DownloadFromWeb(this.Wallpaper.data[i].path, dir, filename[filename.Length - 1]);
            }

        }
    }
}
