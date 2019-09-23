using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using UnityEngine;

using VRCModLoader;

using VRCUnlocked;

namespace VRCFPSManager
{
    [VRCModInfo("VRCFPSManager", "0.1.1", "AtiLion")]
    internal class VRCFPSManager : VRCMod
    {
        #region Config Variables
        private static UnlockedConfig<FPSConfig> _config;
        #endregion
        #region Config Properties
        public static FPSConfig Config
        {
            get
            {
                if (_config == null)
                    _config = new UnlockedConfig<FPSConfig>("VRCFPSManager.json", "FPS Manager");
                return _config?.Config;
            }
        }
        #endregion

        void OnApplicationStart()
        {
            if (Config == null)
                VRCModLogger.LogError("Failed to get config!");
            ModManager.StartCoroutine(Setup());
        }

        #region FPSManager Properties
        public static int OriginalFrameRate { get; private set; } = 90;
        #endregion
        #region VRCFPSManager Coroutines
        private IEnumerator Setup()
        {
            // Wait for load
            yield return VRCUManager.WaitForVRChatLoad();

            // Save original values
            OriginalFrameRate = Application.targetFrameRate;

            // Set unlimited FPS
            if ((bool)Config.UnlimitedFPS)
                Application.targetFrameRate = 0;

            // Add Unity scripts
            VRCUManager.ScriptContainer.AddComponent<PauseDetector>();

            // Add unlimited FPS watcher
            _config.WatchForUpdate("UnlimitedFPS", () =>
            {
                if ((bool)Config.UnlimitedFPS)
                    Application.targetFrameRate = 0;
                else
                    Application.targetFrameRate = OriginalFrameRate;
            });
        }
        #endregion
    }
}
