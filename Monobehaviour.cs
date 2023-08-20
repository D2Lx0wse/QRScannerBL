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
            Texture2D tex = new Texture2D(W, H);
            tex.ReadPixels(gameObject.GetComponent<Camera>().rect, W, H);
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