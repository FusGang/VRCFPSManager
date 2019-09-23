using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using VRCUnlocked.Config;

namespace VRCFPSManager
{
    internal class FPSConfig
    {
        [ConfigItem("Unlimited FPS", true)]
        public bool? UnlimitedFPS { get; set; }

        [ConfigItem("Low unfocused FPS", true)]
        public bool? LowFPSUnfocused { get; set; }
    }
}
