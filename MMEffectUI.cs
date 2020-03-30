using MMEffectUI.Properties;
using MMEffectUI.Widgets;
using MMEdit;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MMEffectUI
{
    public class MMEffectUI : PluginBase, IImportPlugin, IExportPlugin
    {
        #region Fields
        public Encoding Encoding;
        private Regex regex = new Regex(@"(?<static>static\s+)?(?<const>const\s+)?(?<type>string|float|float2|float3|float4|int)\s+(?<name>\w+)\s*<\s*(?<annotation>(?<a_type>\w+)\s+(?<a_name>\w+)\s*=\s*(?<a_value>[^;]+)\s*;\s*)+\s*>\s*=\s*(?<value>[^;]+);", RegexOptions.Multiline);
        #endregion

        #region Constructor
        public MMEffectUI()
        {
            Encoding = Encoding.GetEncoding(Settings.Default.Encoding);
            Settings.Default.PropertyChanged += (s, e) =>
            {
                if (e.PropertyName == "Encoding")
                {
                    Encoding = Encoding.GetEncoding(Settings.Default.Encoding);
                }
            };
        }
        #endregion

        #region Properties
        public override Guid Guid
        {
            get
            {
                return new Guid("{2461F59A-09EA-49B5-9A8E-37588AABDC9B}");
            }
        }

        public override string Name
        {
            get
            {
                return Resources.MMEffectUI_Name;
            }
        }

        public override string Version
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString(2);
            }
        }

        public string Caption
        {
            get
            {
                return Resources.MMEffectUI_Caption;
            }
        }

        public string Pattern
        {
            get
            {
                return "*.fx";
            }
        }

        public Image Image
        {
            get
            {
                return Resources.mme;
            }
        }
        #endregion

        #region Methods
        public override void Initialize(IHost host)
        {
            base.Initialize(host);
            Host.RegisterWidgets(new IWidget[]
            {
                new WidgetClass("MMEffectUI", obj => new WidgetProxy(obj, Host)),
                new WidgetClass("Color", obj => new SliderWidget(true) { ObjectFX = obj }),
                new WidgetClass("Slider", obj => new SliderWidget { ObjectFX = obj }),
                new WidgetClass("Numeric", obj => new NumericWidget { ObjectFX = obj }),
                new WidgetClass("Spinner", obj => new NumericWidget { ObjectFX = obj }),
            });
        }

        public bool IsExportable(ObjectFX obj)
        {
            return obj is UIObjectFX;
        }

        public void Export(ObjectFX obj, string path)
        {
            UIObjectFX fx = (UIObjectFX)obj;
            string originalText = fx.OriginalText;
            List<int> indexList = new List<int>();

            foreach (ControlObject controlObject in fx.ControlObjects)
            {
                indexList.Add(controlObject._Index);
            }
            indexList.Sort();
            indexList.Reverse();

            foreach (int index in indexList)
            {
                foreach (ControlObject controlObject in fx.ControlObjects)
                {
                    int startIndex = controlObject._Index;

                    if (startIndex == index)
                    {
                        int length = controlObject._Length;

                        originalText = originalText.Remove(startIndex, length);
                        originalText = originalText.Insert(startIndex, Format(controlObject));

                        break;
                    }
                }
            }
            File.WriteAllText(path, originalText, Encoding);
        }

        private string Format(ControlObject controlObject)
        {
            string data =
                $"{(controlObject.IsStatic ? "static " : "")}" +
                $"{(controlObject.IsConst ? "const " : "")}" +
                $"{controlObject.Type} {controlObject.Name} <";

            foreach (Annotation annotation in controlObject.ControlObjects)
            {
                data += Environment.NewLine + $"\t{annotation.Type} {annotation.Name} = {(annotation.Type == "string" ? $"\"{annotation.Value}\"" : annotation.Value)};";
            }
            data += $"{Environment.NewLine}> = {controlObject.Value};";
            return data;
        }

        public bool IsImportable(string path)
        {
            if (Path.GetExtension(path) == ".fx")
            {
                string data = File.ReadAllText(path, Encoding);
                return regex.IsMatch(data);
            }
            return false;
        }

        public ObjectFX Import(string path)
        {
            if (!IsImportable(path))
                throw new Exception(Resources.Msg_FormatException);

            UIObjectFX obj = new UIObjectFX("MMEffectUI")
            {
                OriginalText = File.ReadAllText(path, Encoding),
            };

            obj.Data.Add("IMPORTPLUGIN", Name);
            obj.Data.Add("IMPORTPLUGIN_VERSION", Version);
            obj.Data.Add("IMPORTPLUGIN_GUID", Guid);

            foreach (Match match in regex.Matches(obj.OriginalText))
            {
                ControlObject controlObject = new ControlObject()
                {
                    Type = match.Groups["type"].Value,
                    Name = match.Groups["name"].Value,
                    Value = match.Groups["value"].Value
                };

                for (int i = 0; i < match.Groups["a_type"].Captures.Count; i++)
                {
                    ControlObject co = new ControlObject()
                    {
                        Type = match.Groups["a_type"].Captures[i].Value,
                        Name = match.Groups["a_name"].Captures[i].Value,
                        Value = match.Groups["a_value"].Captures[i].Value.Replace("\"", ""),
                    };

                    controlObject.ControlObjects.Add(co);
                }

                controlObject.IsStatic = match.Groups["static"].Success;
                controlObject.IsConst = match.Groups["const"].Success;
                controlObject._Index = match.Index;
                controlObject._Length = match.Length;

                obj.ControlObjects.Add(controlObject);
            }

            return obj;
        }
        #endregion
    }
}
