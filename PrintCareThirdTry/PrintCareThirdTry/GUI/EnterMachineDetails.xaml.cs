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
using PrintCareThirdTry.Classes;
using PrintCareThirdTry.Database;

namespace Print_Care
{
	/// <summary>
	/// Interaction logic for EnterMachineDetails.xaml
	/// </summary>
	public partial class EnterMachineDetails : Window
	{
        MachineClass machineClass = new MachineClass();

		public EnterMachineDetails()
		{
			this.InitializeComponent();
			
			// Insert code required on object creation below this point.
		}

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Machine mac = new Machine
                    {
                        Manufacture = txtManufacturer.Text,
                        Model = txtModel.Text,
                        ColourUnits = Convert.ToInt32(txtNoOfColourUnits.Text),
                        PrintingWidth = Convert.ToDouble(txtMaxWidth.Text),
                        PrintingHeight = Convert.ToDouble(txtMaxHeight.Text),
                        DampingMethod = txtDampingMethode.Text,
                        InkControlingValve = Convert.ToInt32(txtNoOfInkControlingValue.Text),
                        Note = txtNote.Text,
                    };

                int machineID = machineClass.inserMachineDetails(mac);
                if (machineID != 0)
                {
                    MessageBox.Show("Information successfully saved.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    txtMachineID.Text = machineID.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occuered while processing. Error Code : "+ex.Message,"Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {

        }

        
	}
}