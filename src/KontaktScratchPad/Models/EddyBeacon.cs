using Android.OS;
using Android.Runtime;
using Com.Kontakt.Sdk.Android.Ble.Spec;
using Com.Kontakt.Sdk.Android.Common.Profile;
using KontaktScratchPad.Models;

namespace KontaktScratchPad
{
    public class EddyBeacon : BaseBeacon
    {
        public string Eid { get; set;}
        public string EncryptedTelemetry { get; set;}
        public string InstanceId { get; set;}
        public string Namespace { get; set;}
        public Telemetry Telemetry { get; set;}
        public string Url { get; set; }

        public override string TypeName => "EddyBeacon";
    }

   
}