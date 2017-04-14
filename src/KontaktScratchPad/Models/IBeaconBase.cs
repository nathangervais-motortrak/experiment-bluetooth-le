using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Com.Kontakt.Sdk.Android.Common;
using Com.Kontakt.Sdk.Android.Common.Profile;

namespace KontaktScratchPad
{
    public interface IBeaconBase
    {
        string Address { get; }
        int BatteryPower { get; }
        double Distance { get; }
        string FirmwareVersion { get; }
        bool IsShuffled { get; }
        string Name { get; }
        DeviceProfile Profile { get; }
        Proximity Proximity { get; }
        int Rssi { get; }
        long Timestamp { get; }
        int TxPower { get; }
        string UniqueId { get; }
    }
}