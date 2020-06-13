using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace wallpaperchanger
{
    class UserPreferences
    {

        // Private
        private const string FileDirectory = @"C:\Program Files (x86)\WallpaperChanger\";
        private const string DownloadDefaultDir = @"images\";
        private const string FileName = @"userPrefs.xml";
        private XDocument xdoc;
        private Boolean FileExists = (File.Exists(FileDirectory + FileName)) ? true : false;

        // Public
        public List<string> Errors { get; private set; }
        public String Category { get; private set; }
        public String Dir { get; private set; }
        public String Width { get; private set; }
        public String Height { get; private set; }
        public String Time { get; private set; }

        public UserPreferences()
        {
            this.Errors = new List<string>();

            if (!this.FileExists)
            {
                Console.WriteLine("DOES NOT EXISTS");
                this.CreateFile();
                this.GenerateNewXML();
            }
            this.xdoc = XDocument.Load(FileDirectory + FileName);
            this.Load();
        }

        private void CreateFile()
        {
            try
            {
                Directory.CreateDirectory(FileDirectory);
                Directory.CreateDirectory(FileDirectory + DownloadDefaultDir);
            }
            catch (UnauthorizedAccessException ex) 
            {
                this.Errors.Add("Error: "+ex);
            }
        }

        private void GenerateNewXML()
        {
            XmlTextWriter writer = new XmlTextWriter(FileDirectory+FileName, System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;
            writer.WriteStartElement("Preferences");

            writer.WriteStartElement("Category");
            writer.WriteString("cats");
            writer.WriteEndElement();

            writer.WriteStartElement("Directory");
            writer.WriteString(FileDirectory+DownloadDefaultDir);
            writer.WriteEndElement();

            writer.WriteStartElement("Width");
            writer.WriteString("1920");
            writer.WriteEndElement();

            writer.WriteStartElement("Height");
            writer.WriteString("1080");
            writer.WriteEndElement();

            writer.WriteStartElement("Time");
            writer.WriteString("5");
            writer.WriteEndElement();

            writer.WriteEndElement();
            writer.Close();
        }

        private void Load()
        {
            try
            {
                IEnumerable<XElement> result = xdoc.Descendants("Preferences");

                foreach(XElement pref in result)
                {
                    this.Category = pref.Descendants("Category").FirstOrDefault().Value;
                    this.Dir = pref.Descendants("Directory").FirstOrDefault().Value;
                    this.Width = pref.Descendants("Width").FirstOrDefault().Value;
                    this.Height = pref.Descendants("Height").FirstOrDefault().Value;
                    this.Time = pref.Descendants("Time").FirstOrDefault().Value;
                }
            }
            catch (FileLoadException ex)
            {
                this.Errors.Add("Error: " + ex);
            }
        }

        public Boolean Update(string Element, string OldValue, string NewValue)
        {
            IEnumerable<XElement> preferences = from pref in xdoc.Descendants("Preferences")
                          where pref.Element(Element).Value == OldValue
                          select pref;

            if (preferences.Count() == 0)
            {
                return false;
            }

            foreach (XElement pref in preferences)
            {
                pref.SetElementValue(Element, NewValue);
            }
            xdoc.Save(FileDirectory + FileName);
            this.Load(); // Reload

            return true;
        }
    }
}
