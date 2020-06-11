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
using System.Windows.Shapes;
using PrintCareThirdTry.Classes;
using PrintCareThirdTry.Database;
using System.Data;
using Aurigma.GraphicsMill;
using System.IO;

using AForge;
using AForge.Math;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Imaging.Textures;

using Point = System.Drawing.Point;

namespace PrintCareThirdTry.GUI
{
    /// <summary>
    /// Interaction logic for JobControlPanel.xaml
    /// </summary>
    public partial class JobControlPanel : Window
    {
        JobClass jobClass = new JobClass();

        public JobControlPanel()
        {
            InitializeComponent();
        }

        private void frmJobControlPanel_Loaded(object sender, RoutedEventArgs e)
        {
            FillJobIDs();
            fillCmbColours();
        }

        private void FillJobIDs()
        {
            DataTable dt = jobClass.getJobIDs();

            cmbJobID.DisplayMemberPath = "Name";
            cmbJobID.SelectedValuePath = "Value";
            cmbJobID.ItemsSource = dt.DefaultView;
        }

        private void cmbJobID_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int jobID = Convert.ToInt32(cmbJobID.SelectedValue);

            BitmapImage sampleImage = jobClass.getSampleImage(jobID);
            imgSampleImage.Source = sampleImage;

            Printing_Job job = jobClass.getPrintingJobDetails(jobID);

            txtNoOfColours.Text = job.colours.ToString();

            fillCmbColours();
        }

        private void fillCmbColours()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Value", typeof(string));

            dt.Rows.Add("Cyan", "Cyan");
            dt.Rows.Add("Magenta", "Magenta");
            dt.Rows.Add("Yellow", "Yellow");
            dt.Rows.Add("Black", "Black");

            cmbCurrentColour.DisplayMemberPath = "Name";
            cmbCurrentColour.SelectedValuePath = "Value";
            cmbCurrentColour.ItemsSource = dt.DefaultView;

        }

        private void cmbCurrentColour_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            generateInitiateValveValues();
        }

        private void btnPredictInkValveValues_Click(object sender, RoutedEventArgs e)
        {
            generateInitiateValveValues();
        }

        private void generateInitiateValveValues()
        {
            int jobID = Convert.ToInt32(cmbJobID.SelectedValue);
            string imagePath = jobClass.getSampleImagePath(jobID);

            Aurigma.GraphicsMill.Bitmap bitmap = new Bitmap(imagePath);

            if (bitmap.PixelFormat.IsRgb)
            {
                bitmap.ColorProfile = Aurigma.GraphicsMill.ColorProfile.FromSrgb();
                bitmap.ColorManagement.ColorManagementEngine = Aurigma.GraphicsMill.Transforms.ColorManagementEngine.LittleCms;
                bitmap.ColorManagement.DestinationProfile = new Aurigma.GraphicsMill.ColorProfile(@"C:\windows\system32\spool\drivers\color\EuroscaleCoated.icc");
                bitmap.ColorManagement.Convert(Aurigma.GraphicsMill.ColorSpace.Cmyk, bitmap.HasAlpha, bitmap.PixelFormat.IsExtended);
            }
            string selectedChannel = cmbCurrentColour.SelectedValue.ToString();

            Aurigma.GraphicsMill.Bitmap selectedChannelBitmap = new Aurigma.GraphicsMill.Bitmap(bitmap);

            if (selectedChannel == "Cyan")
            {
                selectedChannelBitmap = bitmap.Channels[Aurigma.GraphicsMill.Channel.Cyan];
            }
            else if (selectedChannel == "Magenta")
            {
                selectedChannelBitmap = bitmap.Channels[Aurigma.GraphicsMill.Channel.Magenta];
            }
            else if (selectedChannel == "Yellow")
            {
                selectedChannelBitmap = bitmap.Channels[Aurigma.GraphicsMill.Channel.Yellow];
            }
            else if (selectedChannel == "Black")
            {
                selectedChannelBitmap = bitmap.Channels[Aurigma.GraphicsMill.Channel.Black];
            }

            BitmapImage bmpimg = ConvertAurigmaImageToBitmapImage(selectedChannelBitmap);

            imgSelectedChannel.Source = bmpimg;

            int WidthOfTheImage = selectedChannelBitmap.Width;

            int partWidth = WidthOfTheImage / 12;
            int partHeight = selectedChannelBitmap.Height;

            System.Windows.Controls.Image[] imgArr = new System.Windows.Controls.Image[12];
            imgArr[0] = image3;
            imgArr[1] = image4;
            imgArr[2] = image5;
            imgArr[3] = image6;
            imgArr[4] = image7;
            imgArr[5] = image8;
            imgArr[6] = image9;
            imgArr[7] = image10;
            imgArr[8] = image11;
            imgArr[9] = image12;
            imgArr[10] = image13;
            imgArr[11] = image14;

            Label[] lblValveArr = new Label[12];
            lblValveArr[0] = lblValve01;
            lblValveArr[1] = lblValve02;
            lblValveArr[2] = lblValve03;
            lblValveArr[3] = lblValve04;
            lblValveArr[4] = lblValve05;
            lblValveArr[5] = lblValve06;
            lblValveArr[6] = lblValve07;
            lblValveArr[7] = lblValve08;
            lblValveArr[8] = lblValve09;
            lblValveArr[9] = lblValve10;
            lblValveArr[10] = lblValve11;
            lblValveArr[11] = lblValve12;

            Aurigma.GraphicsMill.Histogram histogram;

            int startingPoint = 0;
            for (int i = 0; i < 12; i++)
            {
                System.Drawing.Rectangle rect = new System.Drawing.Rectangle(startingPoint, 0, partWidth, partHeight);
                Aurigma.GraphicsMill.Bitmap croppingBmp = new Aurigma.GraphicsMill.Bitmap(selectedChannelBitmap);
                croppingBmp.Transforms.Crop(rect);
                BitmapImage croppedBitmap = ConvertAurigmaImageToBitmapImage(croppingBmp);
                imgArr[i].Source = croppedBitmap;
                startingPoint += partWidth;

                histogram = croppingBmp.Statistics.GetSumHistogram();

                double histoValue = Convert.ToDouble(histogram.Mean);

                double calcValue = (255 - histoValue) / (255);

                double precentageValue = calcValue * 100;

                lblValveArr[i].Content = precentageValue.ToString("0.00") + " %";
            }
        }

        private static BitmapImage ConvertAurigmaImageToBitmapImage(Aurigma.GraphicsMill.Bitmap selectedChannelBitmap)
        {
            System.Drawing.Bitmap bmp = (System.Drawing.Bitmap)selectedChannelBitmap;
            BitmapImage bmpimg = new BitmapImage();

            using (MemoryStream memstr = new MemoryStream())
            {
                bmp.Save(memstr, System.Drawing.Imaging.ImageFormat.Jpeg);
                memstr.Position = 0;
                bmpimg.BeginInit();
                bmpimg.StreamSource = memstr;
                bmpimg.CacheOption = BitmapCacheOption.OnLoad;
                bmpimg.EndInit();
            }
            return bmpimg;
        }

        private void btnUploadPrint_Click(object sender, RoutedEventArgs e)
        {
            int jobID = Convert.ToInt32(cmbJobID.SelectedValue);
            string SampleFilePath = jobClass.getSampleImagePath(jobID);
            Microsoft.Win32.OpenFileDialog open = new Microsoft.Win32.OpenFileDialog();
            if (open.ShowDialog() == true)
            {
                Aurigma.GraphicsMill.Bitmap SampleBitmap = new Bitmap(SampleFilePath);
                Aurigma.GraphicsMill.Bitmap PrintedOutCome = new Bitmap(open.FileName);

                if (SampleBitmap.PixelFormat.IsRgb)
                {
                    SampleBitmap.ColorProfile = Aurigma.GraphicsMill.ColorProfile.FromSrgb();
                    SampleBitmap.ColorManagement.ColorManagementEngine = Aurigma.GraphicsMill.Transforms.ColorManagementEngine.LittleCms;
                    SampleBitmap.ColorManagement.DestinationProfile = new Aurigma.GraphicsMill.ColorProfile(@"C:\windows\system32\spool\drivers\color\EuroscaleCoated.icc");
                    SampleBitmap.ColorManagement.Convert(Aurigma.GraphicsMill.ColorSpace.Cmyk, SampleBitmap.HasAlpha, SampleBitmap.PixelFormat.IsExtended);
                }
                if (PrintedOutCome.PixelFormat.IsRgb)
                {
                    PrintedOutCome.ColorProfile = Aurigma.GraphicsMill.ColorProfile.FromSrgb();
                    PrintedOutCome.ColorManagement.ColorManagementEngine = Aurigma.GraphicsMill.Transforms.ColorManagementEngine.LittleCms;
                    PrintedOutCome.ColorManagement.DestinationProfile = new Aurigma.GraphicsMill.ColorProfile(@"C:\windows\system32\spool\drivers\color\EuroscaleCoated.icc");
                    PrintedOutCome.ColorManagement.Convert(Aurigma.GraphicsMill.ColorSpace.Cmyk, PrintedOutCome.HasAlpha, PrintedOutCome.PixelFormat.IsExtended);
                }

                string selectedChannel = cmbCurrentColour.SelectedValue.ToString();

                Aurigma.GraphicsMill.Bitmap selectedColourSampleBitmap = new Bitmap(SampleBitmap);
                Aurigma.GraphicsMill.Bitmap selectedColourPrintedOutCome = new Bitmap(PrintedOutCome);

                if (selectedChannel == "Cyan")
                {
                    selectedColourSampleBitmap = SampleBitmap.Channels[Aurigma.GraphicsMill.Channel.Cyan];
                    selectedColourPrintedOutCome = PrintedOutCome.Channels[Aurigma.GraphicsMill.Channel.Cyan];
                }
                else if (selectedChannel == "Magenta")
                {
                    selectedColourSampleBitmap = SampleBitmap.Channels[Aurigma.GraphicsMill.Channel.Magenta];
                    selectedColourPrintedOutCome = PrintedOutCome.Channels[Aurigma.GraphicsMill.Channel.Magenta];
                }
                else if (selectedChannel == "Yellow")
                {
                    selectedColourSampleBitmap = SampleBitmap.Channels[Aurigma.GraphicsMill.Channel.Yellow];
                    selectedColourPrintedOutCome = PrintedOutCome.Channels[Aurigma.GraphicsMill.Channel.Yellow];
                }
                else if (selectedChannel == "Black")
                {
                    selectedColourSampleBitmap = SampleBitmap.Channels[Aurigma.GraphicsMill.Channel.Black];
                    selectedColourPrintedOutCome = PrintedOutCome.Channels[Aurigma.GraphicsMill.Channel.Black];
                }

                //Ink valve values

                System.Drawing.Bitmap bmpSelectedColourFromSample = new System.Drawing.Bitmap((System.Drawing.Bitmap)selectedColourSampleBitmap);
                System.Drawing.Bitmap bmpSelectedColourFromPrintedOutCome = new System.Drawing.Bitmap((System.Drawing.Bitmap)selectedColourPrintedOutCome);

                System.Drawing.Bitmap bmpResultAfterDifferentiate = new Difference(bmpSelectedColourFromSample).Apply(bmpSelectedColourFromPrintedOutCome);

                bmpResultAfterDifferentiate.Save("bmpResultAfterDifferentiate.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                System.Drawing.Bitmap bmpInvertedResult = new Invert().Apply(new System.Drawing.Bitmap("bmpResultAfterDifferentiate.jpg"));

                bmpInvertedResult.Save("bmpInvertedResult.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);

                Bitmap bmpForCropping = new Bitmap(bmpInvertedResult);

                int partWidth = bmpForCropping.Width / 12;
                int partHeight = bmpForCropping.Height;

                System.Windows.Controls.Image[] imgArr = new System.Windows.Controls.Image[12];
                imgArr[0] = image15;
                imgArr[1] = image16;
                imgArr[2] = image17;
                imgArr[3] = image18;
                imgArr[4] = image19;
                imgArr[5] = image20;
                imgArr[6] = image21;
                imgArr[7] = image22;
                imgArr[8] = image23;
                imgArr[9] = image24;
                imgArr[10] = image25;
                imgArr[11] = image26;

                Label[] lblArr = new Label[12];
                lblArr[0] = lblValve101;
                lblArr[1] = lblValve102;
                lblArr[2] = lblValve103;
                lblArr[3] = lblValve104;
                lblArr[4] = lblValve105;
                lblArr[5] = lblValve106;
                lblArr[6] = lblValve107;
                lblArr[7] = lblValve108;
                lblArr[8] = lblValve109;
                lblArr[9] = lblValve110;
                lblArr[10] = lblValve111;
                lblArr[11] = lblValve112;

                int startingPoint = 0;
                Aurigma.GraphicsMill.Histogram histogram;
                for (int i = 0; i < 12; i++)
                {
                    System.Drawing.Rectangle rect = new System.Drawing.Rectangle(startingPoint, 0, partWidth, partHeight);
                    Bitmap croppedPart = new Bitmap(bmpForCropping);
                    croppedPart.Transforms.Crop(rect);
                    BitmapImage croppedBitmap = ConvertAurigmaImageToBitmapImage(croppedPart);
                    imgArr[i].Source = croppedBitmap;
                    startingPoint += partWidth;

                    histogram = croppedPart.Statistics.GetSumHistogram();

                    double histoValue = Convert.ToDouble(histogram.Mean);

                    double calcValue = (255 - histoValue) / (255);

                    double precentageValue = calcValue * 100;

                    lblArr[i].Content = precentageValue.ToString("0.00") + " %";
                }
            }
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
