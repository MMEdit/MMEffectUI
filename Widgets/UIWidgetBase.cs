using MMEdit;
using System;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;

namespace MMEffectUI.Widgets
{
    public class UIWidgetBase : WidgetControl
    {
        #region Constructor
        public UIWidgetBase()
        {
            Dock = DockStyle.Top;
        }
        #endregion

        #region Properties
        public override ObjectFX ObjectFX
        {
            get
            {
                return base.ObjectFX;
            }

            set
            {
                base.ObjectFX = value;

                if (!(ObjectFX is ControlObject))
                    throw new Exception(string.Format(Properties.Resources.Msg_IsNotControlObject, Name));

                ControlObject = (ControlObject)ObjectFX;

                string UIVisible = ControlObject.GetControlObject("UIVisible")?.Value;
                switch (UIVisible)
                {
                    default:
                    case "true":
                        Visible = true;
                        break;
                    case "false":
                        Visible = false;
                        break;
                }

                UpdateControlObject();
            }
        }

        public virtual ControlObject ControlObject { get; protected set; }
        #endregion

        #region Events
        /// <summary>
        /// 在 <see cref="UIWidgetBase.ControlObject"/>.Value 属性的值被改变时发生。
        /// </summary>
        public event EventHandler ValueChanged;

        /// <summary>
        /// 引发 <see cref="ValueChanged"/> 事件。
        /// </summary>
        protected virtual void OnValueChanged()
        {
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }
        #endregion

        #region Methods
        /// <summary>
        /// 此方法在 <see cref="ControlObject"/> 的值改变时被调用。
        /// </summary>
        protected virtual void UpdateControlObject() { }
        #endregion
    }

    /// <summary>
    /// 提供编辑值类型（int，float，float2，float3，float4）的小部件基类。
    /// </summary>
    public class UIWidgetBaseV : UIWidgetBase
    {
        #region Fields
        private string _ValueX = "0";
        private string _ValueY = "0";
        private string _ValueZ = "0";
        private string _ValueA = "0";
        private string _UIMaxX = "10000";
        private string _UIMaxY = "10000";
        private string _UIMaxZ = "10000";
        private string _UIMaxA = "10000";
        private string _UIMinX = "0";
        private string _UIMinY = "0";
        private string _UIMinZ = "0";
        private string _UIMinA = "0";
        private System.Threading.Timer timer;
        #endregion

        #region Constructor
        public UIWidgetBaseV()
        {
            timer = new System.Threading.Timer(new TimerCallback(OnUpdateValue), null, Timeout.Infinite, Timeout.Infinite);
        }
        #endregion

        #region Properties
        public string ValueX
        {
            get
            {
                return _ValueX;
            }

            set
            {
                _ValueX = value;
                UpdateValue();
            }
        }

        public string ValueY
        {
            get
            {
                return _ValueY;
            }

            set
            {
                _ValueY = value;
                UpdateValue();
            }
        }

        public string ValueZ
        {
            get
            {
                return _ValueZ;
            }

            set
            {
                _ValueZ = value;
                UpdateValue();
            }
        }

        public string ValueA
        {
            get
            {
                return _ValueA;
            }

            set
            {
                _ValueA = value;
                UpdateValue();
            }
        }

        public string UIMaxX
        {
            get
            {
                return _UIMaxX;
            }
        }

        public string UIMaxY
        {
            get
            {
                return _UIMaxY;
            }
        }

        public string UIMaxZ
        {
            get
            {
                return _UIMaxZ;
            }
        }

        public string UIMaxA
        {
            get
            {
                return _UIMaxA;
            }
        }

        public string UIMinX
        {
            get
            {
                return _UIMinX;
            }
        }

        public string UIMinY
        {
            get
            {
                return _UIMinY;
            }
        }

        public string UIMinZ
        {
            get
            {
                return _UIMinZ;
            }
        }

        public string UIMinA
        {
            get
            {
                return _UIMinA;
            }
        }
        #endregion

        #region Methods
        protected override void UpdateControlObject()
        {
            ControlObject UIMax = ControlObject.GetControlObject("UIMax");
            if (UIMax != null)
            {
                switch (UIMax.Type)
                {
                    case "int":
                    case "float":
                        string[] value = parse(UIMax.Value);
                        if (value.Length >= 1)
                        {
                            _UIMaxX = value[0];
                            _UIMaxY = value[0];
                            _UIMaxZ = value[0];
                            _UIMaxA = value[0];
                        }
                        break;
                    case "float2":
                        string[] float2 = parse(UIMax.Value);
                        if (float2.Length >= 2)
                        {
                            _UIMaxX = float2[0];
                            _UIMaxY = float2[1];
                        }
                        break;
                    case "float3":
                        string[] float3 = parse(UIMax.Value);
                        if (float3.Length >= 3)
                        {
                            _UIMaxX = float3[0];
                            _UIMaxY = float3[1];
                            _UIMaxZ = float3[2];
                        }
                        break;
                    case "float4":
                        string[] float4 = parse(UIMax.Value);
                        if (float4.Length >= 4)
                        {
                            _UIMaxX = float4[0];
                            _UIMaxY = float4[1];
                            _UIMaxZ = float4[2];
                            _UIMaxA = float4[3];
                        }
                        break;
                }
            }

            ControlObject UIMin = ControlObject.GetControlObject("UIMin");
            if (UIMin != null)
            {
                switch (UIMin.Type)
                {
                    case "int":
                    case "float":
                        string[] value = parse(UIMin.Value);
                        if (value.Length >= 1)
                        {
                            _UIMinX = value[0];
                            _UIMinY = value[0];
                            _UIMinZ = value[0];
                            _UIMinA = value[0];
                        }
                        break;
                    case "float2":
                        string[] float2 = parse(UIMin.Value);
                        if (float2.Length >= 2)
                        {
                            _UIMinX = float2[0];
                            _UIMinY = float2[1];
                        }
                        break;
                    case "float3":
                        string[] float3 = parse(UIMin.Value);
                        if (float3.Length >= 3)
                        {
                            _UIMinX = float3[0];
                            _UIMinY = float3[1];
                            _UIMinZ = float3[2];
                        }
                        break;
                    case "float4":
                        string[] float4 = parse(UIMin.Value);
                        if (float4.Length >= 4)
                        {
                            _UIMinX = float4[0];
                            _UIMinY = float4[1];
                            _UIMinZ = float4[2];
                            _UIMinA = float4[3];
                        }
                        break;
                }
            }

            switch (ControlObject.Type)
            {
                case "int":
                case "float":
                    string[] value = parse(ControlObject.Value);
                    if (value.Length >= 1)
                    {
                        _ValueX = value[0];
                        _ValueY = UIMinY;
                        _ValueZ = UIMinZ;
                        _ValueA = UIMinA;
                    }
                    break;
                case "float2":
                    string[] float2 = parse(ControlObject.Value);
                    if (float2.Length >= 2)
                    {
                        _ValueX = float2[0];
                        _ValueY = float2[1];
                        _ValueZ = UIMinZ;
                        _ValueA = UIMinA;
                    }
                    break;
                case "float3":
                    string[] float3 = parse(ControlObject.Value);
                    if (float3.Length >= 3)
                    {
                        _ValueX = float3[0];
                        _ValueY = float3[1];
                        _ValueZ = float3[2];
                        _ValueA = UIMinA;
                    }
                    break;
                case "float4":
                    string[] float4 = parse(ControlObject.Value);
                    if (float4.Length >= 4)
                    {
                        _ValueX = float4[0];
                        _ValueY = float4[1];
                        _ValueZ = float4[2];
                        _ValueA = float4[3];
                    }
                    break;
            }

            string[] parse(string str)
            {
                Regex regex = new Regex(@"(float|float2|float3|float4|int)\((?<value>.*?)\)");
                if (regex.IsMatch(str))
                {
                    return Regex.Replace(regex.Match(str).Groups["value"].Value, @"\s", "").Split(',');
                }

                return new string[] { str, str, str, str }; //Length >= 4
            }
        }

        /// <summary>
        /// 更新 <see cref="UIWidgetBase.ControlObject"/>.Value 属性的值，并引发 <see cref="UIWidgetBase.ValueChanged"/> 事件。
        /// </summary>
        protected void UpdateValue()
        {
            timer.Change(75, Timeout.Infinite);
            OnValueChanged();
        }

        private void OnUpdateValue(object state)
        {
            switch (ControlObject.Type)
            {
                default:
                case "int":
                case "float":
                    ControlObject.Value = ValueX;
                    break;
                case "float2":
                    ControlObject.Value = $"float2({ValueX}, {ValueY})";
                    break;
                case "float3":
                    ControlObject.Value = $"float3({ValueX}, {ValueY}, {ValueZ})";
                    break;
                case "float4":
                    ControlObject.Value = $"float4({ValueX}, {ValueY}, {ValueZ}, {ValueA})";
                    break;
            }
        }
        #endregion
    }
}
