using MMEdit;
using MMEdit.Fx;
using System.Collections.Generic;

namespace MMDUI
{
    public class MMDUIObjectFX : ObjectFX
    {
        #region Constructor
        public MMDUIObjectFX()
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
