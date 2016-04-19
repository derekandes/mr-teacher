using UnityEngine;
using System.Collections;

namespace UnityStandardAssets.ImageEffects
{
    public class CamOverlay : MonoBehaviour
    {
        public ScreenOverlay screenOverlay;
        public bool overlayEnabled = false;

        void Awake()
        {
            screenOverlay = GetComponent<ScreenOverlay>();
        }

        void Update()
        {
            if (GameManager.instance.levelEnded && !overlayEnabled)
            {
                overlayEnabled = true;
                screenOverlay.enabled = true;
            }
        }
    }
}
