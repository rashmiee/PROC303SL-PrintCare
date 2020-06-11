namespace ShapeChecker
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if ( disposing && ( components != null ) )
            {
                components.Dispose( );
            }
            base.Dispose( disposing );
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent( )
        {
            this.components = new System.ComponentModel.Container();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDecision = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(12, 13);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1147, 525);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "Image files (*.jpg,*.png,*.tif,*.bmp,*.gif)|*.jpg;*.png;*.tif;*.bmp;*.gif|JPG fil" +
    "es (*.jpg)|*.jpg|PNG files (*.png)|*.png|TIF files (*.tif)|*.tif|BMP files (*.bm" +
    "p)|*.bmp|GIF files (*.gif)|*.gif";
            this.openFileDialog.Title = "Open image file";
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            this.splitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.button2);
            this.splitContainer.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer.Panel1.Controls.Add(this.button1);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.AutoScroll = true;
            this.splitContainer.Panel2.Controls.Add(this.pictureBox);
            this.splitContainer.Panel2.Resize += new System.EventHandler(this.splitContainer_Panel2_Resize);
            this.splitContainer.Size = new System.Drawing.Size(1171, 646);
            this.splitContainer.SplitterDistance = 92;
            this.splitContainer.TabIndex = 1;
            this.splitContainer.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Load Image";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDecision);
            this.groupBox1.Location = new System.Drawing.Point(94, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1065, 81);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Decision";
            // 
            // txtDecision
            // 
            this.txtDecision.Location = new System.Drawing.Point(7, 20);
            this.txtDecision.Multiline = true;
            this.txtDecision.Name = "txtDecision";
            this.txtDecision.Size = new System.Drawing.Size(1052, 55);
            this.txtDecision.TabIndex = 0;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 43);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Analyze";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1171, 646);
            this.Controls.Add(this.splitContainer);
            this.MinimumSize = new System.Drawing.Size(540, 420);
            this.Name = "MainForm";
            this.Text = "Dot Analyzer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            this.splitContainer.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDecision;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

