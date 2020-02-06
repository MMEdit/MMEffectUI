using System;

namespace MMDUI.Widgets
{
    public partial class NumericWidget : MMDUIWidgetBaseN
    {
        #region Fields
        private bool folded;
        #endregion

        #region Constructor
        public NumericWidget()
        {
            InitializeComponent();
        }
        #endregion

        #region Methods
        protected override void UpdateControlObject()
        {
            base.UpdateControlObject();

            Fold();

            numericY.Visible = ControlObject.Type == "float2" || ControlObject.Type == "float3" || ControlObject.Type == "float4";
            numericZ.Visible = ControlObject.Type == "float3" || ControlObject.Type == "float4";
            numericA.Visible = ControlObject.Type == "float4";
            
            labelUIName.Text = ControlObject.GetAnnotation("UIName")?.Value ?? ControlObject.Name;
            toolTip.SetToolTip(labelUIName, ControlObject.GetAnnotation("UIHelp")?.Value);

            numericX.Maximum = Convert.ToDecimal(UIMaxX);
            numericY.Maximum = Convert.ToDecimal(UIMaxY);
            numericZ.Maximum = Convert.ToDecimal(UIMaxZ);
            numericA.Maximum = Convert.ToDecimal(UIMaxA);

            numericX.Minimum = Convert.ToDecimal(UIMinX);
            numericY.Minimum = Convert.ToDecimal(UIMinY);
            numericZ.Minimum = Convert.ToDecimal(UIMinZ);
            numericA.Minimum = Convert.ToDecimal(UIMinA);

            numericX.Increment = numericX.Maximum * 0.005m >= 0.01m ? numericX.Maximum * 0.005m : 0.01m;
            numericY.Increment = numericY.Maximum * 0.005m >= 0.01m ? numericY.Maximum * 0.005m : 0.01m;
            numericZ.Increment = numericZ.Maximum * 0.005m >= 0.01m ? numericZ.Maximum * 0.005m : 0.01m;
            numericA.Increment = numericA.Maximum * 0.005m >= 0.01m ? numericA.Maximum * 0.005m : 0.01m;

            numericX.Value = Convert.ToDecimal(ValueX);
            numericY.Value = Convert.ToDecimal(ValueY);
            numericZ.Value = Convert.ToDecimal(ValueZ);
            numericA.Value = Convert.ToDecimal(ValueA);
        }

        private void Fold()
        {
            SuspendLayout();
            if (folded)
            {
                tableLayoutPanel.RowStyles[1].Height = Font.Height * 2;
                folded = false;
            }
            else
            {
                tableLayoutPanel.RowStyles[1].Height = 0;
                folded = true;
            }
            ResumeLayout();
        }

        private void numericX_ValueChanged(object sender, EventArgs e)
        {
            ValueX = numericX.Value.ToString();
        }

        private void numericY_ValueChanged(object sender, EventArgs e)
        {
            ValueY = numericY.Value.ToString();
        }

        private void numericZ_ValueChanged(object sender, EventArgs e)
        {
            ValueZ = numericZ.Value.ToString();
        }

        private void numericA_ValueChanged(object sender, EventArgs e)
        {
            ValueA = numericA.Value.ToString();
        }

        private void labelUIName_Click(object sender, EventArgs e)
        {
            Fold();
        }
        #endregion
    }
}
