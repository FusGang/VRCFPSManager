using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

namespace VRCFPSManager
{
    internal class PauseDetector : MonoBehaviour
    {
        void OnApplicationFocus(bool hasFocus)
        {
            if (!(bool)VRCFPSManager.Config.LowFPSUnfocused)
                return;
            if (VRCTrackingManager.IsInVRMode())
                return;

            if (hasFocus)
            {
                if ((bool)VRCFPSManager.Config.UnlimitedFPS)
                    Application.targetFrameRate = 0;
                else
                    Application.targetFrameRate = VRCFPSManager.OriginalFrameRate;
            }
            else
                Application.targetFrameRate = 5;
        }
    }
}
