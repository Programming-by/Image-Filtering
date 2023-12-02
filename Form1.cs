using System;
using System.Windows.Forms;

namespace Image_Filtering_Project
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cbSize.SelectedIndex = 0;



            //for (int i = 1; i <= 5;i++)
            //{
            //    ListViewItem item = new ListViewItem(i.ToString());

            //    listView1.Items.Add(i.ToString());
            //}



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
        
            if (!clsUtil.CreateFolderIfDoesNotExist("c:\\ImageFilters"))
            {
                return;
            }
            _HandleImage();


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
    }
}
