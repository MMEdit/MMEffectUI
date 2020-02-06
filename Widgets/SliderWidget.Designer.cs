namespace MMDUI.Widgets
{
    partial class SliderWidget
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.textA = new System.Windows.Forms.TextBox();
            this.textZ = new System.Windows.Forms.TextBox();
            this.textY = new System.Windows.Forms.TextBox();
            this.trackY = new System.Windows.Forms.TrackBar();
            this.trackZ = new System.Windows.Forms.TrackBar();
            this.trackX = new System.Windows.Forms.TrackBar();
            this.textX = new System.Windows.Forms.TextBox();
            this.trackA = new System.Windows.Forms.TrackBar();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.labelUIName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackA)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // textA
            // 
            this.textA.BackColor = System.Drawing.Color.White;
            this.textA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textA.Location = new System.Drawing.Point(1257, 101);
            this.textA.Name = "textA";
            this.textA.ReadOnly = true;
            this.textA.Size = new System.Drawing.Size(114, 21);
            this.textA.TabIndex = 8;
            this.textA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textZ
            // 
            this.textZ.BackColor = System.Drawing.Color.White;
            this.textZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textZ.Location = new System.Drawing.Point(1257, 75);
            this.textZ.Name = "textZ";
            this.textZ.ReadOnly = true;
            this.textZ.Size = new System.Drawing.Size(114, 21);
            this.textZ.TabIndex = 6;
            this.textZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textY
            // 
            this.textY.BackColor = System.Drawing.Color.White;
            this.textY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textY.Location = new System.Drawing.Point(1257, 49);
            this.textY.Name = "textY";
            this.textY.ReadOnly = true;
            this.textY.Size = new System.Drawing.Size(114, 21);
            this.textY.TabIndex = 4;
            this.textY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // trackY
            // 
            this.trackY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackY.Location = new System.Drawing.Point(3, 49);
            this.trackY.Name = "trackY";
            this.trackY.Size = new System.Drawing.Size(1248, 20);
            this.trackY.TabIndex = 3;
            this.trackY.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackY.Scroll += new System.EventHandler(this.trackY_Scroll);
            // 
            // trackZ
            // 
            this.trackZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackZ.Location = new System.Drawing.Point(3, 75);
            this.trackZ.Name = "trackZ";
            this.trackZ.Size = new System.Drawing.Size(1248, 20);
            this.trackZ.TabIndex = 5;
            this.trackZ.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackZ.Scroll += new System.EventHandler(this.trackZ_Scroll);
            // 
            // trackX
            // 
            this.trackX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackX.Location = new System.Drawing.Point(3, 23);
            this.trackX.Name = "trackX";
            this.trackX.Size = new System.Drawing.Size(1248, 20);
            this.trackX.TabIndex = 1;
            this.trackX.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackX.Scroll += new System.EventHandler(this.trackX_Scroll);
            // 
            // textX
            // 
            this.textX.BackColor = System.Drawing.Color.White;
            this.textX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textX.Location = new System.Drawing.Point(1257, 23);
            this.textX.Name = "textX";
            this.textX.ReadOnly = true;
            this.textX.Size = new System.Drawing.Size(114, 21);
            this.textX.TabIndex = 2;
            this.textX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // trackA
            // 
            this.trackA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trackA.Location = new System.Drawing.Point(3, 101);
            this.trackA.Name = "trackA";
            this.trackA.Size = new System.Drawing.Size(1248, 20);
            this.trackA.TabIndex = 7;
            this.trackA.TickStyle = System.Windows.Forms.TickStyle.None;
            this.trackA.Scroll += new System.EventHandler(this.trackA_Scroll);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.Controls.Add(this.textA, 1, 4);
            this.tableLayoutPanel.Controls.Add(this.trackA, 0, 4);
            this.tableLayoutPanel.Controls.Add(this.textZ, 1, 3);
            this.tableLayoutPanel.Controls.Add(this.trackZ, 0, 3);
            this.tableLayoutPanel.Controls.Add(this.textY, 1, 2);
            this.tableLayoutPanel.Controls.Add(this.trackY, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.textX, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.trackX, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.labelUIName, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 5;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1374, 124);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // labelUIName
            // 
            this.labelUIName.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tableLayoutPanel.SetColumnSpan(this.labelUIName, 2);
            this.labelUIName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelUIName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelUIName.Location = new System.Drawing.Point(3, 0);
            this.labelUIName.Name = "labelUIName";
            this.labelUIName.Size = new System.Drawing.Size(1368, 20);
            this.labelUIName.TabIndex = 0;
            this.labelUIName.Text = "UIName";
            this.labelUIName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelUIName.Click += new System.EventHandler(this.labelUIName_Click);
            // 
            // SliderWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "SliderWidget";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.Size = new System.Drawing.Size(1374, 130);
            ((System.ComponentModel.ISupportInitialize)(this.trackY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackA)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TrackBar trackX;
        private System.Windows.Forms.TextBox textX;
        private System.Windows.Forms.TextBox textA;
        private System.Windows.Forms.TextBox textZ;
        private System.Windows.Forms.TextBox textY;
        private System.Windows.Forms.TrackBar trackY;
        private System.Windows.Forms.TrackBar trackZ;
        private System.Windows.Forms.TrackBar trackA;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label labelUIName;
    }
}
