using System;
using QRScannerBL;
using MelonLoader;
[assembly: MelonInfo(typeof(Mod), "QRScannerBL", "1.0.0", "Void Vapor Inc")]
namespace QRScannerBL
{
    public class Mod : MelonMod
    {
        public override void OnInitializeMelon()
        {
            LoggerInstance.Msg("QRScannerBL initialized");
        }
    }
}
