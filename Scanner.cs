using UnityEngine;

namespace QRScannerBL
{
    class Scanner : MonoBehaviour
    {
        public RenderTexture CamText;
        private int W;
        private int H;
        private Color32[] pixels;

        public void Awake()
        {
            if (CamText == null)
            {
                CamText = gameObject.GetComponent<Camera>().targetTexture;
                W = CamText.width;
                H = CamText.height;
            }
        }

        public void ScanOpen()
        {
            Application.OpenURL(ScanReturn());
        }

        public string ScanReturn()
        {
            string result = "";
            return result;
        }
    }
}