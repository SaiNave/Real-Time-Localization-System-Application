namespace UWB_RTLS_6Tags_Visualization
{
    partial class UWB_RTLS_6tags
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UWB_RTLS_6tags));
            this.Datetime = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.z2 = new System.Windows.Forms.Label();
            this.z1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tags_tracking = new System.Windows.Forms.CheckBox();
            this.show_anchors = new System.Windows.Forms.CheckBox();
            this.xy_values = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // Datetime
            // 
            this.Datetime.AutoSize = true;
            this.Datetime.BackColor = System.Drawing.SystemColors.Info;
            this.Datetime.Font = new System.Drawing.Font("Cambria", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Datetime.Location = new System.Drawing.Point(14, 20);
            this.Datetime.Name = "Datetime";
            this.Datetime.Size = new System.Drawing.Size(99, 22);
            this.Datetime.TabIndex = 5;
            this.Datetime.Text = "Date Time";
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.z2);
            this.panel1.Controls.Add(this.z1);
            this.panel1.Location = new System.Drawing.Point(176, 30);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(715, 453);
            this.panel1.TabIndex = 6;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_paint);
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_mousedown);
            this.panel1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_mousemove);
            // 
            // z2
            // 
            this.z2.AutoSize = true;
            this.z2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.z2.Location = new System.Drawing.Point(1, 264);
            this.z2.Name = "z2";
            this.z2.Size = new System.Drawing.Size(0, 13);
            this.z2.TabIndex = 1;
            // 
            // z1
            // 
            this.z1.AutoSize = true;
            this.z1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.z1.Location = new System.Drawing.Point(1, 169);
            this.z1.Name = "z1";
            this.z1.Size = new System.Drawing.Size(0, 13);
            this.z1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Gainsboro;
            this.groupBox3.Controls.Add(this.tags_tracking);
            this.groupBox3.Controls.Add(this.show_anchors);
            this.groupBox3.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(248, 512);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(604, 49);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Visualization Panel";
            // 
            // tags_tracking
            // 
            this.tags_tracking.AutoSize = true;
            this.tags_tracking.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tags_tracking.Location = new System.Drawing.Point(388, 28);
            this.tags_tracking.Name = "tags_tracking";
            this.tags_tracking.Size = new System.Drawing.Size(113, 19);
            this.tags_tracking.TabIndex = 7;
            this.tags_tracking.Text = "Tag\'s Tracking";
            this.tags_tracking.UseVisualStyleBackColor = true;
            this.tags_tracking.CheckedChanged += new System.EventHandler(this.tags_tracking_CheckedChanged);
            // 
            // show_anchors
            // 
            this.show_anchors.AutoSize = true;
            this.show_anchors.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.show_anchors.Location = new System.Drawing.Point(13, 28);
            this.show_anchors.Name = "show_anchors";
            this.show_anchors.Size = new System.Drawing.Size(110, 19);
            this.show_anchors.TabIndex = 5;
            this.show_anchors.Text = "Show Anchors";
            this.show_anchors.UseVisualStyleBackColor = true;
            this.show_anchors.CheckedChanged += new System.EventHandler(this.show_anchors_check);
            // 
            // xy_values
            // 
            this.xy_values.AutoSize = true;
            this.xy_values.Font = new System.Drawing.Font("Cambria", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xy_values.Location = new System.Drawing.Point(940, 30);
            this.xy_values.Name = "xy_values";
            this.xy_values.Size = new System.Drawing.Size(61, 15);
            this.xy_values.TabIndex = 10;
            this.xy_values.Text = "xy_values";
            // 
            // UWB_RTLS_6tags
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(1051, 608);
            this.Controls.Add(this.xy_values);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.Datetime);
            this.Name = "UWB_RTLS_6tags";
            this.Text = "UWB_RTLS_6Tags";
            this.Load += new System.EventHandler(this.UWB_RTLS_6tags_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Datetime;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label z2;
        private System.Windows.Forms.Label z1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox tags_tracking;
        private System.Windows.Forms.CheckBox show_anchors;
        private System.Windows.Forms.Label xy_values;
    }
}

