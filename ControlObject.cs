using MMEdit;
using System.Collections.Generic;

namespace MMEffectUI
{
    public class ControlObject : Annotation
    {
        #region Fields
        List<ControlObject> controlObjects = new List<ControlObject>();
        #endregion

        #region Constructor
        /// <summary>
        /// 初始化 <see cref="ControlObject"/> 类的新实例。
        /// </summary>
        public ControlObject()
        {
        }

        /// <summary>
        /// 初始化 <see cref="ControlObject"/> 类的新实例。
        /// </summary>
        /// <param name="type"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public ControlObject(string type, string name, string value) : base(type, name, value)
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// 获取 <see cref="ControlObject"/> 中包含的注解列表。
        /// </summary>
        public List<ControlObject> ControlObjects
        {
            get
            {
                return controlObjects;
            }
        }

        /// <summary>
        /// <inheritdoc cref="Annotation.Value"/>
        /// </summary>
        new public string Value
        {
            get
            {
                return base.Value.ToString();
            }

            set
            {
                base.Value = value;
            }
        }

        /// <summary>
        /// 获取或设置 <see cref="ControlObject"/> 是静态。
        /// </summary>
        public bool IsStatic
        {
            get;set;
        }

        /// <summary>
        /// 获取或设置 <see cref="ControlObject"/> 是常量。
        /// </summary>
        public bool IsConst
        {
            get;set;
        }

        /// <summary>
        /// 获取或设置 <see cref="ControlObject"/> 在源文件中从零开始的位置。！此属性由导入程序指定。！
        /// </summary>
        public int _Index
        {
            get;set;
        }

        /// <summary>
        /// 获取或设置 <see cref="ControlObject"/> 在源文件中的长度。！此属性由导入程序指定。！
        /// </summary>
        public int _Length
        {
            get;set;
        }

        /// <summary>
        /// 获取或设置用于编辑 <see cref="ObjectFX"/> 的小部件 WidgetID。<para>= GetAnnotation("UIWidget");</para>
        /// </summary>
        public override string WidgetID
        {
            get
            {
                return GetControlObject("UIWidget")?.Value.ToString();
            }
        }
        #endregion

        #region Methods
        /// <summary>
        /// 搜索与指定名称相匹配的 <see cref="ControlObject"/>, 并返回整个 <see cref="ControlObject.ControlObjects"/> 中的第一个匹配元素。
        /// </summary>
        /// <param name="controlObject"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public ControlObject GetControlObject(string name)
        {
            return ControlObjects.Find(a => a.Name == name);
        }
        #endregion
    }
}
