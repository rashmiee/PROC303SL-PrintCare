using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Drawing;
using PrintCareThirdTry.Classes;
using System.Data;
using PrintCareThirdTry.Database;
using System.IO;
using System.Linq;

namespace Print_Care
{
	/// <summary>
	/// Interaction logic for NewJobDetails.xaml
	/// </summary>
	public partial class NewJobDetails : Window
	{
        MachineClass machineClass = new MachineClass();
        JobClass jobClass = new JobClass();

		public NewJobDetails()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}

        string imagePath;

        private void btnOpen_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog open = new Microsoft.Win32.OpenFileDialog();
            open.DefaultExt = ".jpg";

            Nullable<bool> value = open.ShowDialog();

            if (value == true)
            {
                BitmapImage imgSource = new BitmapImage(new Uri(open.FileName));
                imgSample.Source = imgSource;
                imagePath = open.FileName;
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            DataTable dt = machineClass.getMachineIDs();

            cmbMachineID.DisplayMemberPath = "Name";
            cmbMachineID.SelectedValuePath = "Value";
            cmbMachineID.ItemsSource = dt.DefaultView;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Printing_Job job = new Printing_Job
                {
                    MachineID = Convert.ToInt32(cmbMachineID.SelectedValue),
                    colours = Convert.ToInt32(txtNoOfColours.Text),
                    StartingPosition = Convert.ToDouble(txtStartingPosition.Text),
                    Width = Convert.ToDouble(txtWidthOfJob.Text),
                    Height = Convert.ToDouble(txtHeightOfJob.Text),
                    EndTime = Convert.ToDateTime(dtpExpectedDeadLine.SelectedDate.Value),
                    Note = txtNote.Text,
                    Sample = imagePath
                };

                int jobID = jobClass.insertJobDetails(job);
                if (jobID != 0)
                {
                    MessageBox.Show("Information successfully saved.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtJobID.Text = jobID.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occuered while processing. Error Code : "+ex.Message,"Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
	}
}