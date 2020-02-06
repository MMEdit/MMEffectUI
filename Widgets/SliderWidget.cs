using MMDUI.Properties;
using MMEdit.Fx;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MMDUI.Widgets
{
    public partial class SliderWidget : MMDUIWidgetBaseN
    {
        #region Fields
        private bool folded;
        private List<RowStyle> enabledRows = new List<RowStyle>();
        #endregion

        #region Constructor
        public SliderWidget()
        {
            InitializeComponent();
        }

        public SliderWidget(bool isColor) : this()
        {
            IsColor = isColor;
        }

        #endregion

        #region Properties
        public bool IsColor { get; }
        #endregion

        #region Methods
        protected override void UpdateControlObject()
        {
            base.UpdateControlObject();

            if (ControlObject.Type == "float4")
            {
                enabledRows.Add(tableLayoutPanel.RowStyles[4]);
                enabledRows.Add(tableLayoutPanel.RowStyles[3]);
                enabledRows.Add(tableLayoutPanel.RowStyles[2]);
                enabledRows.Add(tableLayoutPanel.RowStyles[1]);
            }
            else if (ControlObject.Type == "float3")
            {
                tableLayoutPanel.RowStyles[4].Height = 0;

                enabledRows.Add(tableLayoutPanel.RowStyles[3]);
                enabledRows.Add(tableLayoutPanel.RowStyles[2]);
                enabledRows.Add(tableLayoutPanel.RowStyles[1]);
            }
            else if (ControlObject.Type == "float2")
            {
                tableLayoutPanel.RowStyles[4].Height = 0;
                tableLayoutPanel.RowStyles[3].Height = 0;

                enabledRows.Add(tableLayoutPanel.RowStyles[2]);
                enabledRows.Add(tableLayoutPanel.RowStyles[1]);

            }
            else if (ControlObject.Type == "float" || ControlObject.Type == "int")
            {
                tableLayoutPanel.RowStyles[4].Height = 0;
                tableLayoutPanel.RowStyles[3].Height = 0;
                tableLayoutPanel.RowStyles[2].Height = 0;

                enabledRows.Add(tableLayoutPanel.RowStyles[1]);
            }

            Fold();

            labelUIName.Image = IsColor ? Resources.color_swatches : Resources.ui_slider_050;
            labelUIName.Text = $"{ControlObject.GetAnnotation("UIName")?.Value ?? ControlObject.Name}";
            labelUIName.Update();
            toolTip.SetToolTip(labelUIName, ControlObject.GetAnnotation("UIHelp")?.Value);

            trackX.Maximum = IsColor ? 100 : (int)(Convert.ToSingle(UIMaxX) * 100f);
            trackY.Maximum = IsColor ? 100 : (int)(Convert.ToSingle(UIMaxY) * 100f);
            trackZ.Maximum = IsColor ? 100 : (int)(Convert.ToSingle(UIMaxZ) * 100f);
            trackA.Maximum = IsColor ? 100 : (int)(Convert.ToSingle(UIMaxA) * 100f);

            trackX.Minimum = IsColor ? 0 : (int)(Convert.ToSingle(UIMinX) * 100f);
            trackY.Minimum = IsColor ? 0 : (int)(Convert.ToSingle(UIMinY) * 100f);
            trackZ.Minimum = IsColor ? 0 : (int)(Convert.ToSingle(UIMinZ) * 100f);
            trackA.Minimum = IsColor ? 0 : (int)(Convert.ToSingle(UIMinA) * 100f);

            trackX.LargeChange = ControlObject.Type == "int" ? 100 : (int)(trackX.Maximum * 0.05f);
            trackY.LargeChange = ControlObject.Type == "int" ? 100 : (int)(trackX.Maximum * 0.05f);
            trackZ.LargeChange = ControlObject.Type == "int" ? 100 : (int)(trackX.Maximum * 0.05f);
            trackA.LargeChange = ControlObject.Type == "int" ? 100 : (int)(trackX.Maximum * 0.05f);

            trackX.Value = (int)(Convert.ToSingle(ValueX) * 100f);
            trackY.Value = (int)(Convert.ToSingle(ValueY) * 100f);
            trackZ.Value = (int)(Convert.ToSingle(ValueZ) * 100f);
            trackA.Value = (int)(Convert.ToSingle(ValueA) * 100f);

            textX.Text = ValueX;
            textY.Text = ValueY;
            textZ.Text = ValueZ;
            textA.Text = ValueA;
        }

        private void Fold()
        {
            SuspendLayout();
            if (folded)
            {
                foreach (var rowStyle in enabledRows)
                {
                    rowStyle.Height = Font.Height * 2;
                }
                folded = false;
            }
            else
            {
                foreach (var rowStyle in enabledRows)
                {
                    rowStyle.Height = 0;
                }
                folded = true;
            }
            ResumeLayout();
        }

        private void trackX_Scroll(object sender, EventArgs e)
        {
            ValueX =
            textX.Text = (trackX.Value / 100f).ToString();
        }

        private void trackY_Scroll(object sender, EventArgs e)
        {
            ValueY =
            textY.Text = (trackY.Value / 100f).ToString();
        }

        private void trackZ_Scroll(object sender, EventArgs e)
        {
            ValueZ =
            textZ.Text = (trackZ.Value / 100f).ToString();
        }

        private void trackA_Scroll(object sender, EventArgs e)
        {
            ValueA =
            textA.Text = (trackA.Value / 100f).ToString();
        }

        private void labelUIName_Click(object sender, EventArgs e)
        {
            Fold();
        }
        #endregion
    }
}
