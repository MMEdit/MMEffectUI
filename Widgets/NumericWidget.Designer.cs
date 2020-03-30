namespace MMEffectUI.Widgets
{
    partial class NumericWidget
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
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.labelUIName = new System.Windows.Forms.Label();
            this.numericX = new System.Windows.Forms.NumericUpDown();
            this.numericY = new System.Windows.Forms.NumericUpDown();
            this.numericZ = new System.Windows.Forms.NumericUpDown();
            this.numericA = new System.Windows.Forms.NumericUpDown();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericA)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.AutoSize = true;
            this.tableLayoutPanel.ColumnCount = 4;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.Controls.Add(this.labelUIName, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.numericX, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.numericY, 1, 1);
            this.tableLayoutPanel.Controls.Add(this.numericZ, 2, 1);
            this.tableLayoutPanel.Controls.Add(this.numericA, 3, 1);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(1374, 46);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // labelUIName
            // 
            this.labelUIName.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tableLayoutPanel.SetColumnSpan(this.labelUIName, 4);
            this.labelUIName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelUIName.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelUIName.Location = new System.Drawing.Point(3, 0);
            this.labelUIName.Name = "labelUIName";
            this.labelUIName.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.labelUIName.Size = new System.Drawing.Size(1368, 20);
            this.labelUIName.TabIndex = 1;
            this.labelUIName.Text = "UIName";
            this.labelUIName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelUIName.Click += new System.EventHandler(this.labelUIName_Click);
            // 
            // numericX
            // 
            this.numericX.DecimalPlaces = 2;
            this.numericX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericX.Location = new System.Drawing.Point(3, 23);
            this.numericX.Name = "numericX";
            this.numericX.Size = new System.Drawing.Size(337, 21);
            this.numericX.TabIndex = 2;
            this.numericX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericX.ValueChanged += new System.EventHandler(this.numericX_ValueChanged);
            // 
            // numericY
            // 
            this.numericY.DecimalPlaces = 2;
            this.numericY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericY.Location = new System.Drawing.Point(346, 23);
            this.numericY.Name = "numericY";
            this.numericY.Size = new System.Drawing.Size(337, 21);
            this.numericY.TabIndex = 3;
            this.numericY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericY.ValueChanged += new System.EventHandler(this.numericY_ValueChanged);
            // 
            // numericZ
            // 
            this.numericZ.DecimalPlaces = 2;
            this.numericZ.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericZ.Location = new System.Drawing.Point(689, 23);
            this.numericZ.Name = "numericZ";
            this.numericZ.Size = new System.Drawing.Size(337, 21);
            this.numericZ.TabIndex = 4;
            this.numericZ.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericZ.ValueChanged += new System.EventHandler(this.numericZ_ValueChanged);
            // 
            // numericA
            // 
            this.numericA.DecimalPlaces = 2;
            this.numericA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericA.Location = new System.Drawing.Point(1032, 23);
            this.numericA.Name = "numericA";
            this.numericA.Size = new System.Drawing.Size(339, 21);
            this.numericA.TabIndex = 5;
            this.numericA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericA.ValueChanged += new System.EventHandler(this.numericA_ValueChanged);
            // 
            // NumericWidget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.tableLayoutPanel);
            this.Name = "NumericWidget";
            this.Padding = new System.Windows.Forms.Padding(0, 0, 0, 6);
            this.Size = new System.Drawing.Size(1374, 52);
            this.tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Label labelUIName;
        private System.Windows.Forms.NumericUpDown numericX;
        private System.Windows.Forms.NumericUpDown numericY;
        private System.Windows.Forms.NumericUpDown numericZ;
        private System.Windows.Forms.NumericUpDown numericA;
        private System.Windows.Forms.ToolTip toolTip;
    }
}
