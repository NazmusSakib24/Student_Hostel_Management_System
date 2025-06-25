namespace Student_Hostel_Management_System.View
{
    partial class StudentDashboardForm
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblRoomNum = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.grpRoomInfo = new System.Windows.Forms.GroupBox();
            this.btnRequest = new System.Windows.Forms.Button();
            this.btnMyRequests = new System.Windows.Forms.Button();
            this.btnMyBills = new System.Windows.Forms.Button();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.grpRoomInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(20, 20);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(68, 16);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome,";
            // 
            // lblRoomNum
            // 
            this.lblRoomNum.AutoSize = true;
            this.lblRoomNum.Location = new System.Drawing.Point(6, 30);
            this.lblRoomNum.Name = "lblRoomNum";
            this.lblRoomNum.Size = new System.Drawing.Size(101, 16);
            this.lblRoomNum.TabIndex = 1;
            this.lblRoomNum.Text = "Room Number: ";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(6, 93);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(47, 16);
            this.lblStatus.TabIndex = 2;
            this.lblStatus.Text = "Status:";
            // 
            // lblCapacity
            // 
            this.lblCapacity.AutoSize = true;
            this.lblCapacity.Location = new System.Drawing.Point(6, 61);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(66, 16);
            this.lblCapacity.TabIndex = 3;
            this.lblCapacity.Text = "Capacity: ";
            // 
            // grpRoomInfo
            // 
            this.grpRoomInfo.Controls.Add(this.lblRoomNum);
            this.grpRoomInfo.Controls.Add(this.lblStatus);
            this.grpRoomInfo.Controls.Add(this.lblCapacity);
            this.grpRoomInfo.Location = new System.Drawing.Point(40, 60);
            this.grpRoomInfo.Name = "grpRoomInfo";
            this.grpRoomInfo.Size = new System.Drawing.Size(400, 150);
            this.grpRoomInfo.TabIndex = 4;
            this.grpRoomInfo.TabStop = false;
            this.grpRoomInfo.Text = "Assigned Room info";
            // 
            // btnRequest
            // 
            this.btnRequest.Location = new System.Drawing.Point(150, 230);
            this.btnRequest.Name = "btnRequest";
            this.btnRequest.Size = new System.Drawing.Size(180, 35);
            this.btnRequest.TabIndex = 5;
            this.btnRequest.Text = "Submit Service Request";
            this.btnRequest.UseVisualStyleBackColor = true;
            this.btnRequest.Click += new System.EventHandler(this.btnRequest_Click_1);
            // 
            // btnMyRequests
            // 
            this.btnMyRequests.Location = new System.Drawing.Point(150, 270);
            this.btnMyRequests.Name = "btnMyRequests";
            this.btnMyRequests.Size = new System.Drawing.Size(180, 35);
            this.btnMyRequests.TabIndex = 6;
            this.btnMyRequests.Text = "View My Request";
            this.btnMyRequests.UseVisualStyleBackColor = true;
            this.btnMyRequests.Click += new System.EventHandler(this.btnMyRequests_Click);
            // 
            // btnMyBills
            // 
            this.btnMyBills.Location = new System.Drawing.Point(150, 310);
            this.btnMyBills.Name = "btnMyBills";
            this.btnMyBills.Size = new System.Drawing.Size(180, 40);
            this.btnMyBills.TabIndex = 7;
            this.btnMyBills.Text = "View Utility Bills";
            this.btnMyBills.UseVisualStyleBackColor = true;
            this.btnMyBills.Click += new System.EventHandler(this.btnMyBills_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(150, 350);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(180, 40);
            this.btnLogout.TabIndex = 8;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnBack
            // 
            this.btnBack.Location = new System.Drawing.Point(150, 390);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(180, 40);
            this.btnBack.TabIndex = 9;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // StudentDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 485);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.btnMyBills);
            this.Controls.Add(this.btnMyRequests);
            this.Controls.Add(this.btnRequest);
            this.Controls.Add(this.grpRoomInfo);
            this.Controls.Add(this.lblWelcome);
            this.Name = "StudentDashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Student Dashboard";
            this.Load += new System.EventHandler(this.StudentDashboardForm_Load);
            this.grpRoomInfo.ResumeLayout(false);
            this.grpRoomInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblRoomNum;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.GroupBox grpRoomInfo;
        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.Button btnMyRequests;
        private System.Windows.Forms.Button btnMyBills;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.Button btnBack;
    }
}