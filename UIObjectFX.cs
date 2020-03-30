using MMEdit;
using System.Collections.Generic;

namespace MMEffectUI
{
    public class UIObjectFX : ObjectFX
    {
        #region Constructor
        public UIObjectFX() : this(null)
        {

        }

        public UIObjectFX(string widgetID) : base(widgetID)
        {
            ControlObjects = new List<ControlObject>();
        }
        #endregion

        #region Properties
        public List<ControlObject> ControlObjects { get; }
        public string OriginalText { get; set; }
        #endregion
    }
}
