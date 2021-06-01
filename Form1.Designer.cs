namespace doc_Identify
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.mark_btn = new System.Windows.Forms.Button();
            this.deducts_tb = new System.Windows.Forms.TextBox();
            this.ColorList = new System.Windows.Forms.CheckedListBox();
            this.answers_tb = new System.Windows.Forms.TextBox();
            this.path_tb = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.select_btn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Folder_rb = new System.Windows.Forms.RadioButton();
            this.File_rb = new System.Windows.Forms.RadioButton();
            this.score_tb = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mark_btn
            // 
            this.mark_btn.Enabled = false;
            this.mark_btn.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.mark_btn.Location = new System.Drawing.Point(335, 179);
            this.mark_btn.Name = "mark_btn";
            this.mark_btn.Size = new System.Drawing.Size(172, 29);
            this.mark_btn.TabIndex = 1;
            this.mark_btn.Text = "批改";
            this.mark_btn.UseVisualStyleBackColor = true;
            this.mark_btn.Click += new System.EventHandler(this.Mark_Click);
            // 
            // deducts_tb
            // 
            this.deducts_tb.Font = new System.Drawing.Font("新細明體", 12F);
            this.deducts_tb.Location = new System.Drawing.Point(142, 179);
            this.deducts_tb.Multiline = true;
            this.deducts_tb.Name = "deducts_tb";
            this.deducts_tb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.deducts_tb.Size = new System.Drawing.Size(167, 40);
            this.deducts_tb.TabIndex = 2;
            // 
            // ColorList
            // 
            this.ColorList.CheckOnClick = true;
            this.ColorList.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.ColorList.FormattingEnabled = true;
            this.ColorList.Items.AddRange(new object[] {
            "Red",
            "Green",
            "Blue"});
            this.ColorList.Location = new System.Drawing.Point(142, 57);
            this.ColorList.Name = "ColorList";
            this.ColorList.Size = new System.Drawing.Size(167, 70);
            this.ColorList.TabIndex = 3;
            // 
            // answers_tb
            // 
            this.answers_tb.Font = new System.Drawing.Font("新細明體", 12F);
            this.answers_tb.Location = new System.Drawing.Point(142, 133);
            this.answers_tb.Multiline = true;
            this.answers_tb.Name = "answers_tb";
            this.answers_tb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.answers_tb.Size = new System.Drawing.Size(167, 40);
         
            this.answers_tb.TabIndex = 4;
            // 
            // path_tb
            // 
            this.path_tb.Location = new System.Drawing.Point(142, 29);
            this.path_tb.Name = "path_tb";
            this.path_tb.ReadOnly = true;
            this.path_tb.Size = new System.Drawing.Size(120, 22);
            this.path_tb.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("標楷體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(24, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "讀取位置：";
            // 
            // select_btn
            // 
            this.select_btn.Font = new System.Drawing.Font("標楷體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.select_btn.Location = new System.Drawing.Point(268, 28);
            this.select_btn.Name = "select_btn";
            this.select_btn.Size = new System.Drawing.Size(41, 23);
            this.select_btn.TabIndex = 1;
            this.select_btn.Text = "選取";
            this.select_btn.UseVisualStyleBackColor = true;
            this.select_btn.Click += new System.EventHandler(this.Select_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Folder_rb);
            this.groupBox1.Controls.Add(this.File_rb);
            this.groupBox1.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.groupBox1.Location = new System.Drawing.Point(335, 29);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(141, 73);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "讀取方式";
            // 
            // Folder_rb
            // 
            this.Folder_rb.AutoSize = true;
            this.Folder_rb.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Folder_rb.Location = new System.Drawing.Point(14, 44);
            this.Folder_rb.Name = "Folder_rb";
            this.Folder_rb.Size = new System.Drawing.Size(74, 20);
            this.Folder_rb.TabIndex = 10;
            this.Folder_rb.Text = "Folder";
            this.Folder_rb.UseVisualStyleBackColor = true;
            // 
            // File_rb
            // 
            this.File_rb.AutoSize = true;
            this.File_rb.Checked = true;
            this.File_rb.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.File_rb.Location = new System.Drawing.Point(14, 24);
            this.File_rb.Name = "File_rb";
            this.File_rb.Size = new System.Drawing.Size(58, 20);
            this.File_rb.TabIndex = 9;
            this.File_rb.TabStop = true;
            this.File_rb.Text = "File";
            this.File_rb.UseVisualStyleBackColor = true;
            // 
            // score_tb
            // 
            this.score_tb.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.score_tb.Font = new System.Drawing.Font("標楷體", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.score_tb.Location = new System.Drawing.Point(413, 128);
            this.score_tb.Name = "score_tb";
            this.score_tb.ReadOnly = true;
            this.score_tb.Size = new System.Drawing.Size(94, 27);
            this.score_tb.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("標楷體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(24, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 19);
            this.label2.TabIndex = 10;
            this.label2.Text = "顏色選取：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("標楷體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(24, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 19);
            this.label3.TabIndex = 11;
            this.label3.Text = "答案配置：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("標楷體", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label4.Location = new System.Drawing.Point(24, 189);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 19);
            this.label4.TabIndex = 12;
            this.label4.Text = "分數加權：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("標楷體", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label5.Location = new System.Drawing.Point(331, 132);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 21);
            this.label5.TabIndex = 13;
            this.label5.Text = "分數：";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(546, 250);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.score_tb);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.select_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.path_tb);
            this.Controls.Add(this.answers_tb);
            this.Controls.Add(this.ColorList);
            this.Controls.Add(this.deducts_tb);
            this.Controls.Add(this.mark_btn);
            this.Name = "Form1";
            this.Text = "作業批改";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button mark_btn;
        private System.Windows.Forms.TextBox deducts_tb;
        private System.Windows.Forms.CheckedListBox ColorList;
        private System.Windows.Forms.TextBox answers_tb;
        private System.Windows.Forms.TextBox path_tb;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button select_btn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton Folder_rb;
        private System.Windows.Forms.RadioButton File_rb;
        private System.Windows.Forms.TextBox score_tb;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}

