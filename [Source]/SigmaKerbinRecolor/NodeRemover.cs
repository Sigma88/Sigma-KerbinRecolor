using UnityEngine;
using System.Linq;


namespace SigmaKerbinRecolorPlugin
{
    [KSPAddon(KSPAddon.Startup.Instantly, true)]
    class ConfigNodeRemover : MonoBehaviour
    {
        void Start()
        {
            foreach (UrlDir.UrlConfig node in GameDatabase.Instance.GetConfigs("SigmaKerbinRecolor").Where(c => c.url != "Sigma/KerbinRecolor/Settings/SigmaKerbinRecolor"))
            {
                node.parent.configs.Remove(node);
            }
        }
    }
}
