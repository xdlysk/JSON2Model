namespace JSON2Model
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Cbx_InnerClass = new System.Windows.Forms.CheckBox();
            this.richTextBox2 = new System.Windows.Forms.RichTextBox();
            this.Btn_Generate = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(13, 37);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1129, 114);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "JSON";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Btn_Generate);
            this.groupBox1.Controls.Add(this.richTextBox2);
            this.groupBox1.Controls.Add(this.Cbx_InnerClass);
            this.groupBox1.Location = new System.Drawing.Point(13, 158);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1129, 482);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // Cbx_InnerClass
            // 
            this.Cbx_InnerClass.AutoSize = true;
            this.Cbx_InnerClass.Location = new System.Drawing.Point(6, 20);
            this.Cbx_InnerClass.Name = "Cbx_InnerClass";
            this.Cbx_InnerClass.Size = new System.Drawing.Size(60, 16);
            this.Cbx_InnerClass.TabIndex = 0;
            this.Cbx_InnerClass.Text = "内部类";
            this.Cbx_InnerClass.UseVisualStyleBackColor = true;
            // 
            // richTextBox2
            // 
            this.richTextBox2.Location = new System.Drawing.Point(6, 43);
            this.richTextBox2.Name = "richTextBox2";
            this.richTextBox2.Size = new System.Drawing.Size(1117, 433);
            this.richTextBox2.TabIndex = 1;
            this.richTextBox2.Text = "";
            // 
            // Btn_Generate
            // 
            this.Btn_Generate.Location = new System.Drawing.Point(1048, 13);
            this.Btn_Generate.Name = "Btn_Generate";
            this.Btn_Generate.Size = new System.Drawing.Size(75, 23);
            this.Btn_Generate.TabIndex = 2;
            this.Btn_Generate.Text = "生成";
            this.Btn_Generate.UseVisualStyleBackColor = true;
            this.Btn_Generate.Click += new System.EventHandler(this.Btn_Generate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 652);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Btn_Generate;
        private System.Windows.Forms.RichTextBox richTextBox2;
        private System.Windows.Forms.CheckBox Cbx_InnerClass;
    }
}

