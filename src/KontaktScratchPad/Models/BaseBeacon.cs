using Android.OS;
using Android.Runtime;
using Com.Kontakt.Sdk.Android.Common;
using Com.Kontakt.Sdk.Android.Common.Profile;

namespace KontaktScratchPad.Models
{
    public abstract class BaseBeacon : Java.Lang.Object, IBeaconBase
    {
        public abstract string TypeName { get;  }
        public string Address { get; set; }

        public int BatteryPower { get; set; }

        public double Distance { get; set; }

        public string FirmwareVersion { get; set; }

        public bool IsShuffled { get; set; }

        public string Name { get; set; }

        public DeviceProfile Profile { get; set; }

        public Proximity Proximity { get; set; }

        public int Rssi { get; set; }

        public long Timestamp { get; set; }

        public int TxPower { get; set; }

        public string UniqueId { get; set; }
    }
}