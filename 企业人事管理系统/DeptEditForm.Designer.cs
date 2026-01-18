namespace HomeWorke
{
    partial class DeptEditForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.tbDeptName = new System.Windows.Forms.TextBox();
            this.btEdit = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "部门名称";
            // 
            // tbDeptName
            // 
            this.tbDeptName.Location = new System.Drawing.Point(289, 135);
            this.tbDeptName.Name = "tbDeptName";
            this.tbDeptName.Size = new System.Drawing.Size(204, 28);
            this.tbDeptName.TabIndex = 3;
            // 
            // btEdit
            // 
            this.btEdit.Location = new System.Drawing.Point(149, 324);
            this.btEdit.Name = "btEdit";
            this.btEdit.Size = new System.Drawing.Size(149, 33);
            this.btEdit.TabIndex = 4;
            this.btEdit.Text = "修改";
            this.btEdit.UseVisualStyleBackColor = true;
            this.btEdit.Click += new System.EventHandler(this.btEdit_Click);
            // 
            // btCancel
            // 
            this.btCancel.Location = new System.Drawing.Point(344, 324);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(149, 33);
            this.btCancel.TabIndex = 5;
            this.btCancel.Text = "取消";
            this.btCancel.UseVisualStyleBackColor = true;
            // 
            // DeptEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 450);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btEdit);
            this.Controls.Add(this.tbDeptName);
            this.Controls.Add(this.label2);
            this.Name = "DeptEditForm";
            this.Text = "DeptEditForm";
            this.Load += new System.EventHandler(this.DeptEditForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbDeptName;
        private System.Windows.Forms.Button btEdit;
        private System.Windows.Forms.Button btCancel;
    }
}