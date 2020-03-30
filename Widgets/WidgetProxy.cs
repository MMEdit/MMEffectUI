using MMEdit;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace MMEffectUI.Widgets
{
    public class WidgetProxy : WidgetControl
    {
        #region Constructor
        public WidgetProxy()
        {
            AutoScroll = true;
            Dock = DockStyle.Fill;
            Padding = new Padding(10);
            DoubleBuffered = true;
        }
        public WidgetProxy(ObjectFX obj, IHost host) : this()
        {
            Host = host;
            ObjectFX = obj;
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

                if (!(ObjectFX is UIObjectFX))
                    throw new Exception(Properties.Resources.Msg_IsNotUIObjectFX);

                List<ControlObject> controlObjects = new List<ControlObject>((ObjectFX as UIObjectFX).ControlObjects);
                controlObjects.Reverse();

                new Thread(() =>
                {
                    while (!IsHandleCreated) { }
                    Invoke(new Action(() =>
                    {
                        SuspendLayout();
                        foreach (ControlObject controlObject in controlObjects)
                        {
                            ControlObject UIWidget = controlObject.GetControlObject("UIWidget");

                            if (UIWidget != null)
                            {
                                Control widget;
                                try
                                {
                                    widget = Host.CreateWidget<Control>(UIWidget.Value,controlObject) ?? new MessageWidget(string.Format(Properties.Resources.Msg_WidgetNotFound, UIWidget.Value));
                                }
                                catch (Exception e)
                                {
                                    widget = new MessageWidget($"{controlObject.Name}: {e.Message}", MessageBoxIcon.Warning);
                                }

                                if (widget is UIWidgetBase widgetBase)
                                {
                                    widgetBase.ValueChanged += Widget_ValueChanged;
                                }
                                Controls.Add(widget);
                            }
                        }
                        ResumeLayout();
                    }));
                }).Start();
            }
        }
        protected IHost Host { get; }
        #endregion

        #region Methods
        private void Widget_ValueChanged(object sender, EventArgs e)
        {
           ObjectFX.OnStatusChanged(FileStatus.Changed);
        }
        #endregion
    }
}
