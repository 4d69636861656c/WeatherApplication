namespace WeatherApplication
{
    partial class MainView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.getWeatherDataButton = new System.Windows.Forms.Button();
            this.cityTextBox = new System.Windows.Forms.TextBox();
            this.weatherNowLabel = new System.Windows.Forms.Label();
            this.temperatureNowLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.currentlySelectedCityLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.forecastDataGridView = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.forecastDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // getWeatherDataButton
            // 
            this.getWeatherDataButton.Location = new System.Drawing.Point(335, 12);
            this.getWeatherDataButton.Name = "getWeatherDataButton";
            this.getWeatherDataButton.Size = new System.Drawing.Size(163, 23);
            this.getWeatherDataButton.TabIndex = 0;
            this.getWeatherDataButton.Text = "Get Data";
            this.getWeatherDataButton.UseVisualStyleBackColor = true;
            this.getWeatherDataButton.Click += new System.EventHandler(this.GetWeatherDataButton_Click);
            // 
            // cityTextBox
            // 
            this.cityTextBox.Location = new System.Drawing.Point(12, 12);
            this.cityTextBox.Name = "cityTextBox";
            this.cityTextBox.Size = new System.Drawing.Size(317, 20);
            this.cityTextBox.TabIndex = 1;
            // 
            // weatherNowLabel
            // 
            this.weatherNowLabel.AutoSize = true;
            this.weatherNowLabel.Location = new System.Drawing.Point(531, 12);
            this.weatherNowLabel.Name = "weatherNowLabel";
            this.weatherNowLabel.Size = new System.Drawing.Size(100, 13);
            this.weatherNowLabel.TabIndex = 3;
            this.weatherNowLabel.Text = "Right now there are";
            // 
            // temperatureNowLabel
            // 
            this.temperatureNowLabel.AutoSize = true;
            this.temperatureNowLabel.Location = new System.Drawing.Point(626, 12);
            this.temperatureNowLabel.Name = "temperatureNowLabel";
            this.temperatureNowLabel.Size = new System.Drawing.Size(25, 13);
            this.temperatureNowLabel.TabIndex = 4;
            this.temperatureNowLabel.Text = "___";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(533, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "degrees Celcius in";
            // 
            // currentlySelectedCityLabel
            // 
            this.currentlySelectedCityLabel.AutoSize = true;
            this.currentlySelectedCityLabel.Location = new System.Drawing.Point(626, 28);
            this.currentlySelectedCityLabel.Name = "currentlySelectedCityLabel";
            this.currentlySelectedCityLabel.Size = new System.Drawing.Size(25, 13);
            this.currentlySelectedCityLabel.TabIndex = 6;
            this.currentlySelectedCityLabel.Text = "___";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(533, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "See more info below ... ";
            // 
            // forecastDataGridView
            // 
            this.forecastDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.forecastDataGridView.Location = new System.Drawing.Point(12, 68);
            this.forecastDataGridView.Name = "forecastDataGridView";
            this.forecastDataGridView.ReadOnly = true;
            this.forecastDataGridView.Size = new System.Drawing.Size(710, 231);
            this.forecastDataGridView.TabIndex = 9;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 311);
            this.Controls.Add(this.forecastDataGridView);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.currentlySelectedCityLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.temperatureNowLabel);
            this.Controls.Add(this.weatherNowLabel);
            this.Controls.Add(this.cityTextBox);
            this.Controls.Add(this.getWeatherDataButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainView";
            this.Text = "Weather Application";
            ((System.ComponentModel.ISupportInitialize)(this.forecastDataGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button getWeatherDataButton;
        private System.Windows.Forms.TextBox cityTextBox;
        private System.Windows.Forms.Label weatherNowLabel;
        private System.Windows.Forms.Label temperatureNowLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label currentlySelectedCityLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView forecastDataGridView;
    }
}

