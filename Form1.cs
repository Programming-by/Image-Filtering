using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Image_Filtering_Project
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        // on set image refresh list view
        // Filter List View by  Image Size
        private void Form1_Load(object sender, EventArgs e)
        {
            cbSize.SelectedIndex = 0;
            rbDetails.Checked = true;


            GetFilesAndFillImageList();


            // float fileLength;
            // fileLength = new FileInfo(pic).Length;

        }

        private void GetFilesAndFillImageList(string Extension = "*")
        {
        

            DirectoryInfo ImageDirectory = new DirectoryInfo(@"C:\ImageFilters\");

            string[] pics = Directory.GetFiles(ImageDirectory.ToString(), $"*.{Extension}");
            listView1.SmallImageList = imageList1;
            imageList1.ImageSize = new Size(40, 40);

            foreach (var pic in pics)
            {
                imageList1.Images.Add(Image.FromFile(pic));
            }

            _FillImagesToListView();
        }    
        private void _FillImagesToListView()
        {

            for (int j = 0; j < imageList1.Images.Count; j++)
            {
                ListViewItem item = new ListViewItem();

                item.ImageIndex = j;

                listView1.Items.Add(item);
            }
        }
        
        private void _FillImageToListView()
        {
            imageList1.Images.Add(Image.FromFile(pbImage.ImageLocation));

            int j = (imageList1.Images.Count - 1);
            ListViewItem item = new ListViewItem();

            item.ImageIndex = j;

            listView1.Items.Add(item);
        }
        private void _FilterImageInListViewByExtension(string Extension)
        {
            listView1.Clear();
            imageList1.Images.Clear();

            GetFilesAndFillImageList(Extension);
        }
        private bool _HandleImage()
        {
            if (pbImage.ImageLocation != null)
            {
                string sourceFile = pbImage.ImageLocation.ToString();

            if (clsUtil.CopyImageToProjectImagesFolder(ref sourceFile))
            {
                pbImage.ImageLocation = sourceFile;
                return true;
            } else
                {
                MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                 return false;
                }
            }
            return true;
        }
        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedPath = openFileDialog1.FileName;
                pbImage.Load(selectedPath);
             }
            _HandleImage();

            _FillImageToListView();
        }
        private void rbDetails_CheckedChanged(object sender, EventArgs e)
        {
            listView1.View = View.Details;
        }
        private void rbSmallIcon_CheckedChanged(object sender, EventArgs e)
        {
            listView1.View = View.SmallIcon;

        }
        private void rbLargeIcon_CheckedChanged(object sender, EventArgs e)
        {
            listView1.View = View.LargeIcon;
        }
        private void rbList_CheckedChanged(object sender, EventArgs e)
        {
            listView1.View = View.List;
        }
        private void rbTile_CheckedChanged(object sender, EventArgs e)
        {
            listView1.View= View.Tile;
        }
        private void cbSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbSize.Text)
            {

                case "500 KB":
                    break;
                case "300 KB":

                    break;

                case "200 KB":

                    break;

                case "90 KB":

                    break;


            }
        }
        private void cbExtension_SelectedIndexChanged(object sender, EventArgs e)
        {
            _FilterImageInListViewByExtension(cbExtension.Text);
        }
    }
}
