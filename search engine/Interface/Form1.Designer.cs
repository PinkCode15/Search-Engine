namespace Interface
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
            this.label1 = new System.Windows.Forms.Label();
            this.searchBtn = new System.Windows.Forms.Button();
            this.suggestTxtBox = new System.Windows.Forms.ComboBox();
            this.resultBox = new System.Windows.Forms.ListBox();
            this.resultLbl = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Goudy Old Style", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(222, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Beyond The Search";
            // 
            // searchBtn
            // 
            this.searchBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.searchBtn.BackColor = System.Drawing.Color.CornflowerBlue;
            this.searchBtn.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBtn.Location = new System.Drawing.Point(566, 83);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(105, 38);
            this.searchBtn.TabIndex = 1;
            this.searchBtn.Text = "Search";
            this.searchBtn.UseVisualStyleBackColor = false;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // suggestTxtBox
            // 
            this.suggestTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.suggestTxtBox.AutoCompleteCustomSource.AddRange(new string[] {
            "the",
            "all",
            "have",
            "search",
            "list",
            "close",
            "because",
            "she ",
            "I ",
            "have",
            "big",
            "hair"});
            this.suggestTxtBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.suggestTxtBox.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.suggestTxtBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.suggestTxtBox.FormattingEnabled = true;
            this.suggestTxtBox.Location = new System.Drawing.Point(35, 90);
            this.suggestTxtBox.Name = "suggestTxtBox";
            this.suggestTxtBox.Size = new System.Drawing.Size(492, 27);
            this.suggestTxtBox.Sorted = true;
            this.suggestTxtBox.TabIndex = 4;
            this.suggestTxtBox.Text = "Type here...";
            this.suggestTxtBox.SelectedIndexChanged += new System.EventHandler(this.suggestTxtBox_SelectedIndexChanged);
            this.suggestTxtBox.Click += new System.EventHandler(this.suggestTxtBox_Click);
            // 
            // resultBox
            // 
            this.resultBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultBox.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.resultBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.resultBox.Font = new System.Drawing.Font("Cambria", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultBox.FormattingEnabled = true;
            this.resultBox.HorizontalScrollbar = true;
            this.resultBox.ItemHeight = 19;
            this.resultBox.Items.AddRange(new object[] {
            "chiamaka.html",
            "read.css",
            "clarette.doc",
            "automata.pdf",
            "friedrecipe.coo",
            "pda.html",
            "weekQueek.pdf",
            "chiamaka.html",
            "read.css",
            "clarette.doc",
            "automata.pdf",
            "friedrecipe.coo",
            "pda.html",
            "weekQueek.pdf",
            "chiamaka.html",
            "read.css",
            "clarette.doc",
            "automata.pdf"});
            this.resultBox.Location = new System.Drawing.Point(35, 207);
            this.resultBox.Name = "resultBox";
            this.resultBox.Size = new System.Drawing.Size(637, 287);
            this.resultBox.TabIndex = 5;
            this.resultBox.Visible = false;
            this.resultBox.SelectedIndexChanged += new System.EventHandler(this.resultBox_SelectedIndexChanged);
            // 
            // resultLbl
            // 
            this.resultLbl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.resultLbl.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.resultLbl.Font = new System.Drawing.Font("Goudy Old Style", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultLbl.Location = new System.Drawing.Point(35, 156);
            this.resultLbl.Name = "resultLbl";
            this.resultLbl.Size = new System.Drawing.Size(637, 60);
            this.resultLbl.TabIndex = 6;
            this.resultLbl.Text = "Results";
            this.resultLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.resultLbl.Visible = false;
            this.resultLbl.Click += new System.EventHandler(this.resultLbl_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(574, 141);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(707, 508);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.resultLbl);
            this.Controls.Add(this.resultBox);
            this.Controls.Add(this.suggestTxtBox);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Corbel", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "Search Engine";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.ComboBox suggestTxtBox;
        private System.Windows.Forms.ListBox resultBox;
        private System.Windows.Forms.Label resultLbl;
        private System.Windows.Forms.Label label2;
    }
}

