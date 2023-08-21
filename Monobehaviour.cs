using UnityEngine;
using MelonLoader;
using ZXing.QrCode;
using ZXing;
using System;

namespace QRScannerBL
{
    [RegisterTypeInIl2Cpp]
    class Scanner : MonoBehaviour
    {
        public Scanner(IntPtr ptr) : base(ptr) {}
        public RenderTexture CamText;
        private int W;
        private int H;
        private Color32[] pixels;
        private Camera cam;

        public void Awake()
        {
            cam = gameObject.GetComponent<Camera>();
            if (CamText == null)
            {
                MelonLogger.Msg("CamText is NulL");
                CamText = cam.targetTexture;
            }
            W = CamText.width;
            H = CamText.height;
        }

        public void ScanOpen()
        {
            Application.OpenURL(ScanReturn());
        }

        public string ScanReturn()
        {
            string result = "";
            Texture2D tex = new Texture2D(W, H);
            RenderTexture.active = CamText;
            tex.ReadPixels(new Rect(0, 0, W, H), 0, 0);
            tex.Apply();
            pixels = tex.GetPixels32();
            var barcodeReader = new BarcodeReader { AutoRotate = true, Options = new ZXing.Common.DecodingOptions { TryHarder = false} };
            var qrresult = barcodeReader.Decode(pixels, W, H);
            result = qrresult.Text;
            MelonLogger.Msg(result);
            return result;
        }
    }
}