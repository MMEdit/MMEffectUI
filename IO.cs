using MMDUI.Properties;
using MMEdit;
using MMEdit.Fx;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MMDUI
{
    public class IO : PluginClass, IImportPlugin, IExportPlugin
    {
        #region Fields
        public Encoding Encoding;
        private Regex regex = new Regex(@"(?<static>static\s+)?(?<const>const\s+)?(?<type>string|float|float2|float3|float4|int)\s+(?<name>\w+)\s*<\s*(?<annotation>(?<a_type>\w+)\s+(?<a_name>\w+)\s*=\s*(?<a_value>[^;]+)\s*;\s*)+\s*>\s*=\s*(?<value>[^;]+);", RegexOptions.Multiline);
        #endregion

        #region Constructor
        public IO()
        {
            Encoding = Encoding.GetEncoding(Settings.Default.Encoding);
            Settings.Default.PropertyChanged += Default_PropertyChanged;
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
                return Resources.IO_Name;
            }
        }

        public override string Version
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public override string Description
        {
            get
            {
                return Resources.IO_Description;
            }
        }

        public string Caption
        {
            get
            {
                return Resources.IO_Caption;
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
                return Resources.function;
            }
        }
        #endregion

        #region Methods
        public bool IsExportable(ObjectFX obj)
        {
            return obj is MMDUIObjectFX;
        }

        public void Export(ObjectFX obj, string path)
        {
            MMDUIObjectFX fx = (MMDUIObjectFX)obj;

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

            foreach (Annotation annotation in controlObject.Annotations)
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
                throw new Exception(Resources.IO_FormatException);

            MMDUIObjectFX fx = new MMDUIObjectFX
            {
                WidgetID = "MMDUI.Widgets.WidgetProxy",
                OriginalText = File.ReadAllText(path, Encoding),
            };

            foreach (Match match in regex.Matches(fx.OriginalText))
            {
                ControlObject controlObject = new ControlObject()
                {
                    Type = match.Groups["type"].Value,
                    Name = match.Groups["name"].Value,
                    Value = match.Groups["value"].Value
                };

                for (int i = 0; i < match.Groups["a_type"].Captures.Count; i++)
                {
                    Annotation annotation = new Annotation()
                    {
                        Type = match.Groups["a_type"].Captures[i].Value,
                        Name = match.Groups["a_name"].Captures[i].Value,
                        Value = match.Groups["a_value"].Captures[i].Value.Replace("\"", ""),
                    };

                    controlObject.Annotations.Add(annotation);
                }

                controlObject.IsStatic = match.Groups["static"].Success;
                controlObject.IsConst = match.Groups["const"].Success;
                controlObject._Index = match.Index;
                controlObject._Length = match.Length;

                fx.ControlObjects.Add(controlObject);
            }

            return fx;
        }

        private void Default_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Encoding")
            {
                Encoding = Encoding.GetEncoding(Settings.Default.Encoding);
            }
        }
        #endregion
    }
}
