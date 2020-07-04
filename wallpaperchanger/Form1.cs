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
        private UserPreferences Prefs;
        private int Picked = 0;
        private Boolean Rotate = true;
        private System.Threading.Timer TestTimer;

        public Form1()
        {
            InitializeComponent();
            ApiHelper.initializeClient();

            // ComboBox (In Minutes)
            rotationTime.Items.Add("1");
            rotationTime.Items.Add("5");
            rotationTime.Items.Add("15");
            rotationTime.Items.Add("30");
            rotationTime.Items.Add("60");

            this.Prefs = new UserPreferences();

            if (this.Prefs.Errors.Count() > 0)
            {
                string PrefErrors = "";

                foreach (string error in this.Prefs.Errors)
                {
                    PrefErrors += error + " ";
                }

                MessageBox.Show("Errors: \n " + PrefErrors + "\n Please open this software as administrator", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                Application.Exit();
            }

            wallpaperCategory.Text = Prefs.Category;
            saveFolder.Text = Prefs.Dir;
            ResolutionWidth.Text = Prefs.Width;
            ResolutionHeight.Text = Prefs.Height;
            rotationTime.SelectedItem = Prefs.Time;

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
            else if (!this.Prefs.Update("Category", this.Prefs.Category, wallpaperCategory.Text))
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
            else if (!this.Prefs.Update("Directory", this.Prefs.Dir, saveFolder.Text))
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
            else if (!this.Prefs.Update("Width", this.Prefs.Width, ResolutionWidth.Text) || !this.Prefs.Update("Height", this.Prefs.Height, ResolutionHeight.Text))
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

                WallpaperFetcher wf = new WallpaperFetcher(wallpaperCategory.Text, ResolutionWidth.Text, ResolutionHeight.Text);

                await wf.LoadWallpaper();


                if (wf.Wallpaper.meta.total <= 0)
                {
                    MessageBox.Show("No wallpapers found with that category", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (wf.Wallpaper.meta.total < 10)
                {
                    await wf.DownloadWallpapers(this.Prefs.Dir, wf.Wallpaper.meta.total);

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
                    await wf.DownloadWallpapers(this.Prefs.Dir, 10);

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


        // Incomplete | Please rename properly and complete it.
        private void Test(Object obj)
        {
            string[] fileEntries = Directory.GetFiles(this.Prefs.Dir);

            if (fileEntries.Length < 10)
            {
                //
            }

/*             if (this.Picked > fileEntries.Length - 1)
             {
                this.Picked = 0;
             }
*/
            this.Picked = (this.Picked > fileEntries.Length - 1) ? 0 : this.Picked;

             Console.WriteLine("Changing to: " + fileEntries[Picked]);
             Wallpaper.SetDesktopWallpaper(fileEntries[Picked]);
             this.Picked++;
        }

        private void ToggleRotation_Click(object sender, EventArgs e)
        {
            if (this.Rotate)
            {
                this.TestTimer.Change(Timeout.Infinite, Timeout.Infinite);
                this.Rotate = false;
                ToggleRotation.Text = "Start Rotation";
            } else
            {
                int CurrentRotationTime = Convert.ToInt32(this.rotationTime.Text) * 1000;
                this.TestTimer.Change(CurrentRotationTime, CurrentRotationTime);
                ToggleRotation.Text = "Stop Rotation";
                this.Rotate = true;
            }
            
        }
    }
}
