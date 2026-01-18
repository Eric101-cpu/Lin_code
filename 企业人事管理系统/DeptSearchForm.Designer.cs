namespace HomeWorke
{
    partial class DeptSearchForm
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tbDeptName = new System.Windows.Forms.Label();
            this.DeptName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(116, 179);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(126, 32);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "查询";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(484, 179);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(126, 32);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // tbDeptName
            // 
            this.tbDeptName.AutoSize = true;
            this.tbDeptName.Location = new System.Drawing.Point(207, 93);
            this.tbDeptName.Name = "tbDeptName";
            this.tbDeptName.Size = new System.Drawing.Size(80, 18);
            this.tbDeptName.TabIndex = 3;
            this.tbDeptName.Text = "部门名称";
            // 
            // DeptName
            // 
            this.DeptName.Location = new System.Drawing.Point(319, 90);
            this.DeptName.Name = "DeptName";
            this.DeptName.Size = new System.Drawing.Size(158, 28);
            this.DeptName.TabIndex = 5;
            this.DeptName.TextChanged += new System.EventHandler(this.DeptName_TextChanged);
            // 
            // DeptSearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 266);
            this.Controls.Add(this.DeptName);
            this.Controls.Add(this.tbDeptName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSearch);
            this.Name = "DeptSearchForm";
            this.Text = "DeptSearchForm";
            this.Load += new System.EventHandler(this.DeptSearchForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label tbDeptName;
        private System.Windows.Forms.TextBox DeptName;
    }
}