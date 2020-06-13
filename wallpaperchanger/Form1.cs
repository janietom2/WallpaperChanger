using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace wallpaperchanger
{
    public partial class Form1 : Form
    {
        private UserPreferences prefs;
        private int picked = 0;
        private Boolean rotate = true;
        private System.Threading.Timer TestTimer;

        public Form1()
        {
            InitializeComponent();
            ApiHelper.initializeClient();

            // ComboBox
            rotationTime.Items.Add("1");
            rotationTime.Items.Add("5");
            rotationTime.Items.Add("15");
            rotationTime.Items.Add("30");
            rotationTime.Items.Add("60");

            this.prefs = new UserPreferences();

            if (this.prefs.Errors.Count() > 0)
            {
                string prefErrors = "";

                foreach (string error in this.prefs.Errors)
                {
                    prefErrors += error + " ";
                }

                MessageBox.Show("Errors: \n " + prefErrors + "\n Please open this software as administrator", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Application.Exit();
            }

            wallpaperCategory.Text = prefs.Category;
            saveFolder.Text = prefs.Dir;
            ResolutionWidth.Text = prefs.Width;
            ResolutionHeight.Text = prefs.Height;
            rotationTime.SelectedItem = prefs.Time;

        }

        private void Form1_Load(object sender, EventArgs ev)
        {
            TimerCallback timerDelegate = new TimerCallback(Test);
            this.TestTimer = new System.Threading.Timer(timerDelegate, null, 5000, 5000);
        }

        //  This maybe needs its own class (Modularity)
        [DllImport("gdi32.dll")]
        static extern int GetDeviceCaps(IntPtr hdc, int nIndex);
        public enum DeviceCap
        {
            VERTRES = 10,
            DESKTOPVERTRES = 117,
        }

        private void updateCategory_Click(object sender, EventArgs e)
        {
            if (wallpaperCategory.Text == "")
            {
                MessageBox.Show("Please type a category", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!this.prefs.Update("Category", this.prefs.Category, wallpaperCategory.Text))
            {
                MessageBox.Show("Error saving your data", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }else
            {
                MessageBox.Show(wallpaperCategory.Text + " has been set", "Update",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void updateSaveFolder_Click(object sender, EventArgs e)
        {
            if (saveFolder.Text == "")
            {
                MessageBox.Show("Please type a category", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!this.prefs.Update("Directory", this.prefs.Dir, saveFolder.Text))
            {
                MessageBox.Show("Error saving your data", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            { 
                MessageBox.Show("Save Folder Updated to "+saveFolder.Text, "Update",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void UpdateResolution_Click(object sender, EventArgs e)
        {
            if (ResolutionWidth.Text == "" || ResolutionHeight.Text == "")
            {
                MessageBox.Show("Please type a resolution", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!this.prefs.Update("Width", this.prefs.Width, ResolutionWidth.Text) || !this.prefs.Update("Height", this.prefs.Height, ResolutionHeight.Text))
            {
                MessageBox.Show("Error saving your data", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Resolution updated to " + ResolutionWidth.Text + " x "+ ResolutionHeight.Text, "Update",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void manualChangeWallpaper_Click(object sender, EventArgs e)
        {
            if (wallpaperCategory.Text.Length < 1 || ResolutionWidth.Text == "" || ResolutionHeight.Text == "")
            {
                MessageBox.Show("Please type a category and set a resolution", "Error",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Console.WriteLine(wallpaperCategory.Text);
                RootObject wallpaper = await WallpaperFetcher.LoadWallpaper(wallpaperCategory.Text, ResolutionWidth.Text, ResolutionHeight.Text);


                if (wallpaper.meta.total <= 0)
                {
                    MessageBox.Show("No wallpapers found with that category", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (wallpaper.meta.total < 10)
                {
                    await WallpaperFetcher.DownloadWallpapers(this.prefs.Dir, this.prefs.Category, this.prefs.Width, this.prefs.Height,);

                    /*                    for (int i = 0; i < wallpaper.meta.total; i++)
                                        {
                                            Console.WriteLine("id " + i + ": " + wallpaper.data[i].path);
                                        }*/

                    // Add this to the loop
                    /*                    string[] filename = new Uri(wallpaper.data[0].path).Segments;
                                        Image.DownloadFromWeb(wallpaper.data[0].path, saveFolder.Text, filename[filename.Length-1]);*/

                }
                else 
                {
                    await WallpaperFetcher.DownloadWallpapers(this.prefs.Dir, this.prefs.Category, this.prefs.Width, this.prefs.Height, 10);

/*                    for (int i = 0; i < 10; i++)
                    {
                        Console.WriteLine("id " + i + ": " + wallpaper.data[i].path);
                    }*/

                    // Add this to the loop
/*                    string[] filename = new Uri(wallpaper.data[0].path).Segments;
                    Image.DownloadFromWeb(wallpaper.data[0].path, saveFolder.Text, filename[filename.Length - 1]);
*/
                }
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Automatic(object sender, EventArgs e)
        {
            Graphics g = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr desktop = g.GetHdc();
            int LogicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.VERTRES);
            int PhysicalScreenHeight = GetDeviceCaps(desktop, (int)DeviceCap.DESKTOPVERTRES);

            float ScreenScalingFactor = (float)PhysicalScreenHeight / (float)LogicalScreenHeight;

            ResolutionHeight.Text = (int.Parse(Screen.PrimaryScreen.Bounds.Height.ToString()) * ScreenScalingFactor).ToString();
            ResolutionWidth.Text = (int.Parse(Screen.PrimaryScreen.Bounds.Width.ToString()) * ScreenScalingFactor).ToString();
        }

        private void ChooseFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog FolderDialog = new FolderBrowserDialog();
            FolderDialog.RootFolder = Environment.SpecialFolder.Desktop;
            FolderDialog.Description = "Select Store Folder";
            FolderDialog.ShowNewFolderButton = false;

            if (FolderDialog.ShowDialog() == DialogResult.OK)
            {
                saveFolder.Text = FolderDialog.SelectedPath + "\\";
            }
        }

        private void Test(Object obj)
        {
            string[] fileEntries = Directory.GetFiles(this.prefs.Dir);

            if (fileEntries.Length < 10)
            {
                //
            }

/*             if (this.picked > fileEntries.Length - 1)
             {
                this.picked = 0;
             }
*/
            this.picked = (this.picked > fileEntries.Length - 1) ? 0 : this.picked;

             Console.WriteLine("Changing to: " + fileEntries[picked]);
             Wallpaper.SetDesktopWallpaper(fileEntries[picked]);
             this.picked++;
        }

        private void ToggleRotation_Click(object sender, EventArgs e)
        {
            if (this.rotate)
            {
                this.TestTimer.Change(Timeout.Infinite, Timeout.Infinite);
                this.rotate = false;
                ToggleRotation.Text = "Start Rotation";
            } else
            {
                this.TestTimer.Change(5000, 5000);
                ToggleRotation.Text = "Stop Rotation";
                this.rotate = true;
            }
            
        }
    }
}
