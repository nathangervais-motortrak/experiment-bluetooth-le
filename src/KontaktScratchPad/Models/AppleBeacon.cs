using System;
using Android.OS;
using Android.Runtime;
using Com.Kontakt.Sdk.Android.Common.Profile;
using Java.Util;
using KontaktScratchPad.Models;

namespace KontaktScratchPad
{
    public class AppleBeacon : BaseBeacon
    {
        public int Major { get; set; }
        public int Minor { get; set; }
        public UUID ProximityUUID { get; set; }

        public override string TypeName => "AppleBeacon";
    }
}