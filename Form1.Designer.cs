namespace NeuralNetworkRecognitionNumbers
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxPath = new System.Windows.Forms.TextBox();
            this.labelPath = new System.Windows.Forms.Label();
            this.buttonLoad = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelTrainSize = new System.Windows.Forms.Label();
            this.labelTestSize = new System.Windows.Forms.Label();
            this.labelRecognizableNumbers = new System.Windows.Forms.Label();
            this.labelBitLen = new System.Windows.Forms.Label();
            this.labelTraningResult = new System.Windows.Forms.Label();
            this.buttonTrain = new System.Windows.Forms.Button();
            this.labelTestResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxPath
            // 
            this.textBoxPath.Location = new System.Drawing.Point(107, 13);
            this.textBoxPath.Name = "textBoxPath";
            this.textBoxPath.Size = new System.Drawing.Size(617, 20);
            this.textBoxPath.TabIndex = 0;
            this.textBoxPath.Text = "E:\\Datasets\\AppleAndBanana\\MNIST\\";
            // 
            // labelPath
            // 
            this.labelPath.AutoSize = true;
            this.labelPath.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelPath.Location = new System.Drawing.Point(12, 14);
            this.labelPath.Name = "labelPath";
            this.labelPath.Size = new System.Drawing.Size(89, 17);
            this.labelPath.TabIndex = 1;
            this.labelPath.Text = "Path to data:";
            // 
            // buttonLoad
            // 
            this.buttonLoad.Location = new System.Drawing.Point(107, 39);
            this.buttonLoad.Name = "buttonLoad";
            this.buttonLoad.Size = new System.Drawing.Size(113, 50);
            this.buttonLoad.TabIndex = 2;
            this.buttonLoad.Text = "Load";
            this.buttonLoad.UseVisualStyleBackColor = true;
            this.buttonLoad.Click += new System.EventHandler(this.buttonLoad_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(15, 474);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(709, 23);
            this.progressBar.TabIndex = 3;
            // 
            // labelTrainSize
            // 
            this.labelTrainSize.AutoSize = true;
            this.labelTrainSize.Location = new System.Drawing.Point(400, 39);
            this.labelTrainSize.Name = "labelTrainSize";
            this.labelTrainSize.Size = new System.Drawing.Size(58, 13);
            this.labelTrainSize.TabIndex = 4;
            this.labelTrainSize.Text = "Train size: ";
            // 
            // labelTestSize
            // 
            this.labelTestSize.AutoSize = true;
            this.labelTestSize.Location = new System.Drawing.Point(403, 76);
            this.labelTestSize.Name = "labelTestSize";
            this.labelTestSize.Size = new System.Drawing.Size(55, 13);
            this.labelTestSize.TabIndex = 5;
            this.labelTestSize.Text = "Test size: ";
            // 
            // labelRecognizableNumbers
            // 
            this.labelRecognizableNumbers.AutoSize = true;
            this.labelRecognizableNumbers.Location = new System.Drawing.Point(226, 39);
            this.labelRecognizableNumbers.Name = "labelRecognizableNumbers";
            this.labelRecognizableNumbers.Size = new System.Drawing.Size(121, 13);
            this.labelRecognizableNumbers.TabIndex = 6;
            this.labelRecognizableNumbers.Text = "Recognizable numbers: ";
            // 
            // labelBitLen
            // 
            this.labelBitLen.AutoSize = true;
            this.labelBitLen.Location = new System.Drawing.Point(226, 76);
            this.labelBitLen.Name = "labelBitLen";
            this.labelBitLen.Size = new System.Drawing.Size(57, 13);
            this.labelBitLen.TabIndex = 6;
            this.labelBitLen.Text = "Bit lenght: ";
            // 
            // labelTraningResult
            // 
            this.labelTraningResult.AutoSize = true;
            this.labelTraningResult.Location = new System.Drawing.Point(13, 100);
            this.labelTraningResult.Name = "labelTraningResult";
            this.labelTraningResult.Size = new System.Drawing.Size(62, 13);
            this.labelTraningResult.TabIndex = 7;
            this.labelTraningResult.Text = "Train result:";
            // 
            // buttonTrain
            // 
            this.buttonTrain.Enabled = false;
            this.buttonTrain.Location = new System.Drawing.Point(611, 39);
            this.buttonTrain.Name = "buttonTrain";
            this.buttonTrain.Size = new System.Drawing.Size(113, 49);
            this.buttonTrain.TabIndex = 8;
            this.buttonTrain.Text = "Train";
            this.buttonTrain.UseVisualStyleBackColor = true;
            this.buttonTrain.Click += new System.EventHandler(this.buttonTrain_Click);
            // 
            // labelTestResult
            // 
            this.labelTestResult.AutoSize = true;
            this.labelTestResult.Location = new System.Drawing.Point(156, 100);
            this.labelTestResult.Name = "labelTestResult";
            this.labelTestResult.Size = new System.Drawing.Size(59, 13);
            this.labelTestResult.TabIndex = 9;
            this.labelTestResult.Text = "Test result:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 509);
            this.Controls.Add(this.labelTestResult);
            this.Controls.Add(this.buttonTrain);
            this.Controls.Add(this.labelTraningResult);
            this.Controls.Add(this.labelBitLen);
            this.Controls.Add(this.labelRecognizableNumbers);
            this.Controls.Add(this.labelTestSize);
            this.Controls.Add(this.labelTrainSize);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.buttonLoad);
            this.Controls.Add(this.labelPath);
            this.Controls.Add(this.textBoxPath);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxPath;
        private System.Windows.Forms.Label labelPath;
        private System.Windows.Forms.Button buttonLoad;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelTrainSize;
        private System.Windows.Forms.Label labelTestSize;
        private System.Windows.Forms.Label labelRecognizableNumbers;
        private System.Windows.Forms.Label labelBitLen;
        private System.Windows.Forms.Label labelTraningResult;
        private System.Windows.Forms.Button buttonTrain;
        private System.Windows.Forms.Label labelTestResult;
    }
}

