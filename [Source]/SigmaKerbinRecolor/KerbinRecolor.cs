using System.Linq;
using UnityEngine;


namespace SigmaKerbinRecolorPlugin
{
    [KSPAddon(KSPAddon.Startup.SpaceCentre, true)]
    class AtmoFixer : MonoBehaviour
    {
        static CelestialBody currentBody = null;

        void Awake()
        {
            if (AssemblyLoader.loadedAssemblies.FirstOrDefault(a => a.name == "GalacticNeighborhood") != null) return;

            ConfigNode settings = GameDatabase.Instance.GetConfigNodes("SigmaKerbinRecolor").FirstOrDefault();
            string[] colors = new string[] { "4", "5", "9", "10" };

            if (colors.Contains(settings?.GetValue("KerbinColor")))
                DontDestroyOnLoad(this);
            else
                DestroyImmediate(this);
        }

        void Update()
        {
            if (currentBody != FlightGlobals.getMainBody())
            {
                currentBody = FlightGlobals.getMainBody();
                if (currentBody == FlightGlobals.GetHomeBody())
                    GalaxyCubeControl.Instance.daytimeFadeLimit = 0;
                else
                    GalaxyCubeControl.Instance.daytimeFadeLimit = 500;
            }
        }
    }

    [KSPAddon(KSPAddon.Startup.SpaceCentre, false)]
    class AmbientFixer : MonoBehaviour
    {
        void Awake()
        {
            if (FlightGlobals.GetHomeBody()?.atmosphericAmbientColor != null)
                RenderSettings.ambientLight = FlightGlobals.GetHomeBody().atmosphericAmbientColor;
        }
    }
}
