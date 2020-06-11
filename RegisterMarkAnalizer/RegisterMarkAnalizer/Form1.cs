using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RegisterMarkAnalizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadImage(imgUpperLeft, txtCyanUpperLeftX, txtCyanUpperLeftY, txtMagentaUpperLeftX, txtMagentaUpperLeftY, txtYellowUpperLeftX, txtYellowUpperLeftY, txtBlackUpperLeftX, txtBlackUpperLeftY);
        }

        private string LoadImage(PictureBox imgPictureBox, TextBox txtCyanX, TextBox txtCyanY, TextBox txtMagentaX, TextBox txtMagentaY, TextBox txtYellowX, TextBox txtYellowY, TextBox txtBlackX, TextBox txtBlackY)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                Bitmap bmp = new Bitmap(open.FileName);
                imgPictureBox.Image = bmp;
                Aurigma.GraphicsMill.Bitmap bitmap = new Aurigma.GraphicsMill.Bitmap(open.FileName);
                Bitmap cyanBitmap = (Bitmap)bitmap.Channels[Aurigma.GraphicsMill.Channel.Cyan];
                Bitmap MagentaBitmap = (Bitmap)bitmap.Channels[Aurigma.GraphicsMill.Channel.Magenta];
                Bitmap yellowBitmap = (Bitmap)bitmap.Channels[Aurigma.GraphicsMill.Channel.Yellow];
                Bitmap blackBitmap = (Bitmap)bitmap.Channels[Aurigma.GraphicsMill.Channel.Black];


                int cyanXPosition = GetLenghtToTheFirstLine(cyanBitmap);
                int cyanYPosition = GetHeightToTheFirstLine(cyanBitmap);

                int magentaXPosition = GetLenghtToTheFirstLine(MagentaBitmap);
                int magentaYPosition = GetHeightToTheFirstLine(MagentaBitmap);

                int yellowXPosition = GetLenghtToTheFirstLine(yellowBitmap);
                int yellowYPosition = GetHeightToTheFirstLine(yellowBitmap);

                int blackXPosition = GetLenghtToTheFirstLine(blackBitmap);
                int blackYPosition = GetHeightToTheFirstLine(blackBitmap);

                int magentaErrorX = cyanXPosition - magentaXPosition;
                int magentaErrorY = cyanYPosition - magentaYPosition;

                int yellowErrorX = cyanXPosition - yellowXPosition;
                int yellowErrorY = cyanYPosition - yellowYPosition;

                int blackErrorX = cyanXPosition - blackXPosition;
                int blackErrorY = cyanYPosition - blackYPosition;

                txtCyanX.Text = cyanXPosition.ToString();
                txtCyanY.Text = cyanYPosition.ToString();

                txtMagentaX.Text = magentaErrorX.ToString();
                txtMagentaY.Text = magentaErrorY.ToString();

                txtYellowX.Text = yellowErrorX.ToString();
                txtYellowY.Text = yellowErrorY.ToString();

                txtBlackX.Text = blackErrorX.ToString();
                txtBlackY.Text = blackErrorY.ToString();
            }

            return "";
        }

        private int GetHeightToTheFirstLine(Bitmap processingBitmap)
        {
            bool isYBreak = false;
            int ImageYPosition = 0;

            for (int i = 0; i < processingBitmap.Width; i++)
            {
                for (int j = 0; j < processingBitmap.Height; j++)
                {
                    Color c = processingBitmap.GetPixel(i, j);
                    if (c.R >= 240 && c.G >= 240 && c.B >= 240 && !isYBreak)
                    {
                        ImageYPosition++;
                    }
                    else
                    {
                        isYBreak = true;
                    }
                }
                if (ImageYPosition == processingBitmap.Height)
                {
                    ImageYPosition = 0;
                }
                if (isYBreak)
                {
                    break;
                }
            }
            return ImageYPosition;
        }

        private int GetLenghtToTheFirstLine(Bitmap processingBitmap)
        {
            bool isXBreak = false;
            int ImageXPosition = 0;

            for (int i = 0; i < processingBitmap.Height; i++)
            {
                for (int j = 0; j < processingBitmap.Width; j++)
                {
                    Color c = processingBitmap.GetPixel(j, i);
                    if (c.R >= 240 && c.G >= 240 && c.B >= 240 && !isXBreak)
                    {
                        ImageXPosition++;
                    }
                    else
                    {
                        isXBreak = true;
                    }
                }
                if (ImageXPosition == processingBitmap.Width)
                {
                    ImageXPosition = 0;
                }
                if (isXBreak)
                {
                    break;
                }
            }
            return ImageXPosition;
        }

        #region Methode

        private void button2_Click(object sender, EventArgs e)
        {
            LoadImage(imgUpperCenter,txtCyanUpperCenterX, txtCyanUpperCenterY, txtMagentaUpperCenterX, txtMagentaUpperCenterY, txtYellowUpperCenterX, txtYellowUpperCenterY, txtBlackUpperCenterX, txtBlackUpperCenterY);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LoadImage(imgUpperRight, txtCyanUpperRightX, txtCyanUpperRightY, txtMagentaUpperRightX, txtMagentaUpperRightY, txtYellowUpperRightX, txtYellowUpperRightY, txtBlackUpperRightX, txtBlackUpperRightY);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadImage(imgMiddleLeft, txtCyanMiddleLeftX, txtCyanMiddleLeftY, txtMagentaMiddleLeftX, txtMagentaMiddleLeftY, txtYellowMiddleLeftX, txtYellowMiddleLeftY, txtBlackMiddleLeftX, txtBlackMiddleLeftY);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            LoadImage(imgMiddleRight, txtCyanMiddleRightX, txtCyanMiddleRightY, txtMagentaMiddleRightX, txtMagentaMiddleRightY, txtYellowMiddleRightX, txtYellowMiddleRightY, txtBlackMiddleRightX, txtBlackMiddleRightY);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            LoadImage(imgBottomLeft, txtCyanBottomLeftX, txtCyanBottomLeftY, txtMagentaBottomLeftX, txtMagentaBottomLeftY, txtYellowBottomLeftX, txtYellowBottomLeftY, txtBlackBottomLeftX, txtBlackBottomLeftY);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            LoadImage(imgBottomCenter, txtCyanBottomCenterX, txtCyanBottomCenterY, txtMagentaBottomCenterX, txtMagentaBottomCenterY, txtYellowBottomCenterX, txtYellowBottomCenterY, txtBlackBottomCenterX, txtBlackBottomCenterY);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            LoadImage(imgBottomRight, txtCyanBottomRightX, txtCyanBottomRightY, txtMagentaBottomRightX, txtMagentaBottomRightY, txtYellowBottomRightX, txtYellowBottomRightY, txtBlackBottomRightX, txtBlackBottomRightY);
        }

        #endregion

        private void button9_Click(object sender, EventArgs e)
        {
            if (rdbCyan.Checked)
            {

            }
            else if (rdbMagenta.Checked)
            {
                int GuiedPin = Convert.ToInt32(txtMagentaUpperLeftX.Text);
                int BottomPin = Convert.ToInt32(txtMagentaUpperLeftY.Text);

                string message = "Move bottom pin " + BottomPin + " units and Move guied pin " + GuiedPin + " units";
                txtDecision.Text = message;
            }
            else if (rdbYellow.Checked)
            {
                int GuiedPin = Convert.ToInt32(txtYellowUpperLeftX.Text);
                int BottomPin = Convert.ToInt32(txtYellowUpperLeftY.Text);

                string message = "Move bottom pin " + BottomPin + " units and Move guied pin " + GuiedPin + " units";
                txtDecision.Text = message;
            }
            else if (rdbBlack.Checked)
            {
                int GuiedPin = Convert.ToInt32(txtBlackUpperLeftX.Text);
                int BottomPin = Convert.ToInt32(txtBlackUpperLeftY.Text);

                string message = "Move bottom pin " + BottomPin + " units and Move guied pin " + GuiedPin + " units";
                txtDecision.Text = message;
            }
        }
    }
}
