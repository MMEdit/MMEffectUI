using MMDUI.Properties;
using MMEdit;
using System;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace MMDUI
{
    public class Menu : PluginClass
    {
        #region Properties
        public override Guid Guid
        {
            get
            {
                return new Guid("{75C84522-71B3-4006-8F21-1E965484622B}");
            }
        }

        public override string Name
        {
            get
            {
                return "MMDUI Menu";
            }
        }

        public override string Version
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }
        #endregion

        #region Methods
        private bool flag;
        protected override void Initialize(IHost host)
        {
            if (!flag)
            {
                MenuStrip menuStrip = (host.MainForm as Form).MainMenuStrip;
                ToolStripMenuItem menuItem_MMDUI = new ToolStripMenuItem();
                ToolStripMenuItem menuItem_Encoding = new ToolStripMenuItem();
                ToolStripMenuItem menuItem_Encoding_ANSI = new ToolStripMenuItem();
                ToolStripMenuItem menuItem_Encoding_UTF_8 = new ToolStripMenuItem();
                ToolStripMenuItem menuItem_Encoding_Shift_JIS = new ToolStripMenuItem();
                ToolStripSeparator separator_1 = new ToolStripSeparator();
                ToolStripMenuItem menuItem_MMDUI_About = new ToolStripMenuItem();

                menuStrip.SuspendLayout();
                menuStrip.Items.Insert(menuStrip.Items.Count - 1, menuItem_MMDUI);

                menuItem_MMDUI.DropDownItems.AddRange(new ToolStripItem[]
                {
                    menuItem_Encoding,
                    separator_1,
                    menuItem_MMDUI_About,
                });
                menuItem_MMDUI.Name = "menuItem_MMDUI";
                menuItem_MMDUI.Text = "MMDUI(&M)";
                menuItem_MMDUI.Visible = false;

                menuItem_Encoding.DropDownItems.AddRange(new ToolStripItem[]
                {
                    menuItem_Encoding_ANSI,
                    menuItem_Encoding_UTF_8,
                    menuItem_Encoding_Shift_JIS,
                });
                menuItem_Encoding.Name = "menuItem_Encoding";
                menuItem_Encoding.Text = "编码";

                menuItem_Encoding_ANSI.Name = "menuItem_Encoding_ANSI";
                menuItem_Encoding_ANSI.Text = "使用 ANSI 编码";
                menuItem_Encoding_ANSI.Tag = Encoding.Default.WebName;
                menuItem_Encoding_ANSI.Click += MenuItem_Encoding_DropDownItems_Click;

                menuItem_Encoding_UTF_8.Name = "menuItem_Encoding_UTF_8";
                menuItem_Encoding_UTF_8.Text = "使用 UTF-8 编码";
                menuItem_Encoding_UTF_8.Tag = Encoding.UTF8.WebName;
                menuItem_Encoding_UTF_8.Click += MenuItem_Encoding_DropDownItems_Click;

                menuItem_Encoding_Shift_JIS.Name = "menuItem_Encoding_Shift_JIS";
                menuItem_Encoding_Shift_JIS.Text = "使用 Shift-JIS 编码";
                menuItem_Encoding_Shift_JIS.Tag = Encoding.GetEncoding("shift-jis").WebName;
                menuItem_Encoding_Shift_JIS.Click += MenuItem_Encoding_DropDownItems_Click;

                menuItem_MMDUI_About.Name = "menuItem_MMDUI_About";
                menuItem_MMDUI_About.Text = "关于 MMDUI(&A)";
                menuItem_MMDUI_About.Click += MenuItem_MMDUI_About_Click;

                foreach (ToolStripMenuItem item in menuItem_Encoding.DropDownItems)
                {
                    if (item.Tag.ToString() == Settings.Default.Encoding)
                    {
                        item.Checked = true;
                    }
                }

                menuStrip.ResumeLayout();

                void MenuItem_Encoding_DropDownItems_Click(object sender, EventArgs e)
                {
                    foreach (ToolStripMenuItem item in menuItem_Encoding.DropDownItems)
                    {
                        item.Checked = false;
                    }

                    ToolStripMenuItem menuItem = sender as ToolStripMenuItem;
                    menuItem.Checked = true;

                    Settings.Default.Encoding = menuItem.Tag.ToString();
                    Settings.Default.Save();

                    host.MainForm.RefreshFX();
                }

                host.FileStatusChanged += (sender, e) =>
                {
                    if (e.Status == FileStatus.Opened)
                        menuItem_MMDUI.Visible = host.MainForm.Importer.Guid == new Guid("{2461F59A-09EA-49B5-9A8E-37588AABDC9B}");
                };

                flag = true;
            }
        }

        private void MenuItem_MMDUI_About_Click(object sender, EventArgs e)
        {
            string text = $"{AssemblyProduct}\n{string.Format("版本 {0}", AssemblyVersion)}\n{AssemblyCopyright}\n\n{AssemblyDescription}";
            MessageBox.Show(text, "关于 MMDUI", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region 程序集特性访问器

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion
    }
}
