using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Print_Care;
using PrintCareThirdTry.GUI;
using ShapeChecker;
using RegisterMarkAnalizer;


namespace PrintCareThirdTry
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEnterMachineDetails_Click(object sender, RoutedEventArgs e)
        {
            EnterMachineDetails frm = new EnterMachineDetails();
            frm.ShowDialog();
        }

        private void btnEnterNewJobDetails_Click(object sender, RoutedEventArgs e)
        {
            NewJobDetails frm = new NewJobDetails();
            frm.ShowDialog();
        }

        private void btnJobControlPanel_Click(object sender, RoutedEventArgs e)
        {
            JobControlPanel frm = new JobControlPanel();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            RegisterMarkAnalizer.Form1 frm = new RegisterMarkAnalizer.Form1();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            ShapeChecker.MainForm frm = new ShapeChecker.MainForm();
            frm.ShowDialog();
        }
    }
}
