namespace EDDWinForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtFistName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtLastName = new TextBox();
            label3 = new Label();
            btnShow = new Button();
            SuspendLayout();
            // 
            // txtFistName
            // 
            txtFistName.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtFistName.Location = new Point(336, 86);
            txtFistName.Name = "txtFistName";
            txtFistName.Size = new Size(187, 35);
            txtFistName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(38, 15);
            label1.TabIndex = 1;
            label1.Text = "label1";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(213, 89);
            label2.Name = "label2";
            label2.Size = new Size(106, 30);
            label2.TabIndex = 2;
            label2.Text = "Fist Name";
            // 
            // txtLastName
            // 
            txtLastName.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            txtLastName.Location = new Point(336, 138);
            txtLastName.Name = "txtLastName";
            txtLastName.Size = new Size(187, 35);
            txtLastName.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(213, 141);
            label3.Name = "label3";
            label3.Size = new Size(118, 30);
            label3.TabIndex = 2;
            label3.Text = "Last  Name";
            // 
            // btnShow
            // 
            btnShow.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnShow.Location = new Point(336, 193);
            btnShow.Name = "btnShow";
            btnShow.Size = new Size(159, 64);
            btnShow.TabIndex = 3;
            btnShow.Text = "Show Data";
            btnShow.UseVisualStyleBackColor = true;
            btnShow.Click += btnShow_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnShow);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtLastName);
            Controls.Add(txtFistName);
            Name = "Form1";
            Text = "Form1";
            Click += Form1_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtFistName;
        private Label label1;
        private Label label2;
        private TextBox txtLastName;
        private Label label3;
        private Button btnShow;
    }
}