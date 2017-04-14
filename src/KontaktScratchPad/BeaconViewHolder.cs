using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Com.Kontakt.Sdk.Android.Common.Profile;

namespace KontaktScratchPad
{
    public class BeaconViewHolder : RecyclerView.ViewHolder
    {
        public TextView TypeName { get; set; }
        public TextView Address { get; set; }
        public TextView BatteryPower { get; set; }
        public TextView Distance { get; set; }
        public TextView Name { get; set; }
        public TextView Rssi { get; set; }
        public TextView UniqueId { get; set; }
        public TextView Major { get; set; }
        public TextView Minor { get; set; }
        public TextView ProximityUuid { get; set; }
        public TextView Eid { get; set; }
        public TextView EncryptedTelemetry { get; set; }
        public TextView InstanceId { get; set; }
        public TextView Namespace { get; set; }
        public TextView Telemetry { get; set; }
        public TextView Url { get; set; }

        public BeaconViewHolder(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public BeaconViewHolder(View itemView) : base(itemView)
        {
            TypeName = ItemView.FindViewById<TextView>(Resource.Id.tv_type);
            Address = ItemView.FindViewById<TextView>(Resource.Id.tv_Address);
            BatteryPower = ItemView.FindViewById<TextView>(Resource.Id.tv_BatteryPower);
            Distance = ItemView.FindViewById<TextView>(Resource.Id.tv_Distance);
            Name = ItemView.FindViewById<TextView>(Resource.Id.tv_Name);
            Rssi = ItemView.FindViewById<TextView>(Resource.Id.tv_Rssi);
            UniqueId = ItemView.FindViewById<TextView>(Resource.Id.tv_UniqueId);
            Major = ItemView.FindViewById<TextView>(Resource.Id.tv_Major);
            Minor = ItemView.FindViewById<TextView>(Resource.Id.tv_Minor);
            ProximityUuid = ItemView.FindViewById<TextView>(Resource.Id.tv_ProximityUuid);
        }
    }
}