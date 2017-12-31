namespace PesterchumFormatter
{
    partial class PesterchumFormatter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PesterchumFormatter));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.input = new System.Windows.Forms.TextBox();
            this.output = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.quirksEnabled = new System.Windows.Forms.CheckBox();
            this.changeOutputFont = new System.Windows.Forms.Button();
            this.changeOutputCommandFont = new System.Windows.Forms.Button();
            this.coloringEnabled = new System.Windows.Forms.CheckBox();
            this.fontEnabled = new System.Windows.Forms.CheckBox();
            this.fontPicker = new System.Windows.Forms.FontDialog();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.splitContainer1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 513);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.input);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.output);
            this.splitContainer1.Size = new System.Drawing.Size(978, 447);
            this.splitContainer1.SplitterDistance = 489;
            this.splitContainer1.TabIndex = 0;
            // 
            // input
            // 
            this.input.AcceptsReturn = true;
            this.input.AcceptsTab = true;
            this.input.Dock = System.Windows.Forms.DockStyle.Fill;
            this.input.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.input.Location = new System.Drawing.Point(0, 0);
            this.input.Multiline = true;
            this.input.Name = "input";
            this.input.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.input.Size = new System.Drawing.Size(489, 447);
            this.input.TabIndex = 0;
            this.input.TabStop = false;
            this.input.Text = resources.GetString("input.Text");
            this.input.TextChanged += new System.EventHandler(this.input_TextChanged);
            // 
            // output
            // 
            this.output.Dock = System.Windows.Forms.DockStyle.Fill;
            this.output.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.output.Location = new System.Drawing.Point(0, 0);
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.output.Size = new System.Drawing.Size(485, 447);
            this.output.TabIndex = 0;
            this.output.Text = "";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.quirksEnabled, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.changeOutputFont, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.changeOutputCommandFont, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.coloringEnabled, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.fontEnabled, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 456);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(978, 54);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // quirksEnabled
            // 
            this.quirksEnabled.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.quirksEnabled.AutoSize = true;
            this.quirksEnabled.Checked = true;
            this.quirksEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.quirksEnabled.Location = new System.Drawing.Point(51, 5);
            this.quirksEnabled.Name = "quirksEnabled";
            this.quirksEnabled.Size = new System.Drawing.Size(92, 17);
            this.quirksEnabled.TabIndex = 0;
            this.quirksEnabled.Text = "Enable Quirks";
            this.quirksEnabled.UseVisualStyleBackColor = true;
            this.quirksEnabled.CheckedChanged += new System.EventHandler(this.input_TextChanged);
            // 
            // changeOutputFont
            // 
            this.changeOutputFont.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.changeOutputFont.Location = new System.Drawing.Point(783, 3);
            this.changeOutputFont.Name = "changeOutputFont";
            this.changeOutputFont.Size = new System.Drawing.Size(192, 21);
            this.changeOutputFont.TabIndex = 2;
            this.changeOutputFont.Text = "Change Output Font";
            this.changeOutputFont.UseVisualStyleBackColor = true;
            this.changeOutputFont.Click += new System.EventHandler(this.changeOutputFont_Click);
            // 
            // changeOutputCommandFont
            // 
            this.changeOutputCommandFont.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.changeOutputCommandFont.Location = new System.Drawing.Point(783, 30);
            this.changeOutputCommandFont.Name = "changeOutputCommandFont";
            this.changeOutputCommandFont.Size = new System.Drawing.Size(192, 21);
            this.changeOutputCommandFont.TabIndex = 4;
            this.changeOutputCommandFont.Text = "Change ==>Command Font";
            this.changeOutputCommandFont.UseVisualStyleBackColor = true;
            this.changeOutputCommandFont.Click += new System.EventHandler(this.changeOutputCommandFont_Click);
            // 
            // coloringEnabled
            // 
            this.coloringEnabled.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.coloringEnabled.AutoSize = true;
            this.coloringEnabled.Checked = true;
            this.coloringEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.coloringEnabled.Location = new System.Drawing.Point(230, 5);
            this.coloringEnabled.Name = "coloringEnabled";
            this.coloringEnabled.Size = new System.Drawing.Size(124, 17);
            this.coloringEnabled.TabIndex = 1;
            this.coloringEnabled.Text = "Enable Text Coloring";
            this.coloringEnabled.UseVisualStyleBackColor = true;
            this.coloringEnabled.CheckedChanged += new System.EventHandler(this.input_TextChanged);
            // 
            // fontEnabled
            // 
            this.fontEnabled.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.fontEnabled.AutoSize = true;
            this.fontEnabled.Checked = true;
            this.fontEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.fontEnabled.Location = new System.Drawing.Point(435, 5);
            this.fontEnabled.Name = "fontEnabled";
            this.fontEnabled.Size = new System.Drawing.Size(105, 17);
            this.fontEnabled.TabIndex = 9;
            this.fontEnabled.Text = "Allow Chum Font";
            this.fontEnabled.UseVisualStyleBackColor = true;
            // 
            // PesterchumFormatter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 537);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "PesterchumFormatter";
            this.Text = "PesterchumFormatter";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TextBox input;
        private System.Windows.Forms.RichTextBox output;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.CheckBox quirksEnabled;
        private System.Windows.Forms.CheckBox coloringEnabled;
        private System.Windows.Forms.Button changeOutputFont;
        private System.Windows.Forms.FontDialog fontPicker;
        private System.Windows.Forms.Button changeOutputCommandFont;
        private System.Windows.Forms.CheckBox fontEnabled;
    }
}

