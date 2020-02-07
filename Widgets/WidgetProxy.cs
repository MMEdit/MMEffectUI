using MMEdit;
using MMEdit.Fx;
using MMEdit.Widgets;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MMDUI.Widgets
{
    public class WidgetProxy : WidgetControl
    {
        #region Constructor
        public WidgetProxy()
        {
            AutoScroll = true;
            Dock = System.Windows.Forms.DockStyle.Fill;
            Padding = new System.Windows.Forms.Padding(10);
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

                if (!(ObjectFX is MMDUIObjectFX))
                    throw new Exception(Properties.Resources.WidgetProxy_IsNotMMDUIObjectFX);

                List<ControlObject> controlObjects = new List<ControlObject>((ObjectFX as MMDUIObjectFX).ControlObjects);
                controlObjects.Reverse();

                new Thread(() =>
                {
                    Invoke(new Action(() =>
                    {
                        SuspendLayout();
                        foreach (ControlObject controlObject in controlObjects)
                        {
                            Annotation ann = controlObject.GetAnnotation("UIWidget");

                            if (ann != null)
                            {
                                WidgetControl widget;
                                try
                                {
                                    widget = Host.CreateWidget(ann.Value, controlObject) ?? new MessageWidget($"{controlObject.Name}: 没有找到小部件“{ann.Value}”。");
                                }
                                catch (Exception e)
                                {
                                    widget = new MessageWidget($"{controlObject.Name}: {e.Message}");
                                }

                                if (widget is MMDUIWidgetBase widgetBase)
                                    widgetBase.ValueChanged += Widget_ValueChanged;

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
            Host.OnFileStatusChanged(new FileStatusEventArgs(FileStatus.Changed));
        }
        #endregion
    }
}
