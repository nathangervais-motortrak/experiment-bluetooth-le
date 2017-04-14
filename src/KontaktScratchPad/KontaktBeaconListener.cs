using Android.Util;
using Com.Kontakt.Sdk.Android.Ble.Manager.Listeners;
using Com.Kontakt.Sdk.Android.Common.Profile;
using KontaktScratchPad;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using KontaktScratchPad.Models;

public class KontaktBeaconListener : Java.Lang.Object, IBeaconListener, IEddystoneListener
{
    const string TAG = nameof(KontaktBeaconListener);
    public ObservableCollection<BaseBeacon> Beacons { get; }

    public KontaktBeaconListener(System.Action<ObservableCollection<BaseBeacon>> doOnBeaconsUpdated)
    {
        Beacons = new ObservableCollection<BaseBeacon>();
        Beacons.CollectionChanged += (sender, args) => doOnBeaconsUpdated.Invoke(Beacons);
    }

    public void OnIBeaconDiscovered(IBeaconDevice iBeacon, IBeaconRegion region)
    {
        var beacon = Beacons?.FirstOrDefault(b => b.UniqueId == iBeacon.UniqueId);
        if (beacon != null)
        {
            Beacons.Remove(beacon);
        }

        Beacons.Add(new AppleBeacon()
        {
            Profile = iBeacon.Profile,
            Address = iBeacon.Address,
            BatteryPower = iBeacon.BatteryPower,
            Distance = iBeacon.Distance,
            UniqueId = iBeacon.UniqueId,
            Name = iBeacon.Name,
            Major = iBeacon.Major,
            Minor = iBeacon.Minor,
            ProximityUUID = iBeacon.ProximityUUID
        });
    }

    public void OnIBeaconLost(IBeaconDevice p0, IBeaconRegion p1)
    {
        var beacon = Beacons?.FirstOrDefault(b => b.UniqueId == p0.UniqueId);
        if (beacon != null)
        {
            Beacons.Remove(beacon);
        }
    }


    public void OnIBeaconsUpdated(IList<IBeaconDevice> iBeacons, IBeaconRegion region)
    {
        Log.Info(TAG, "Updated " + iBeacons.Count + " iBeacons in region " + region);
    }

    public void OnEddystoneDiscovered(IEddystoneDevice eddystone, IEddystoneNamespace region)
    {
        var beacon = Beacons?.FirstOrDefault(b => b.UniqueId == eddystone.UniqueId);
        if (beacon != null)
        {
            Beacons.Remove(beacon);
        }

        Beacons.Add(new EddyBeacon()
        {
            Profile = eddystone.Profile,
            Address = eddystone.Address,
            BatteryPower = eddystone.BatteryPower,
            Distance = eddystone.Distance,
            UniqueId = eddystone.UniqueId,
            Name = eddystone.Name,
            Eid = eddystone.Eid,
            Url = eddystone.Url,
            Telemetry = eddystone.Telemetry
        });
    }

    public void OnEddystoneLost(IEddystoneDevice p0, IEddystoneNamespace p1)
    {
        var beacon = Beacons?.FirstOrDefault(b => b.UniqueId == p0.UniqueId);
        if (beacon != null)
        {
            Beacons.Remove(beacon);
        }
    }

    public void OnEddystonesUpdated(IList<IEddystoneDevice> eddystones, IEddystoneNamespace region)
    {
        Log.Info(TAG, "Updated " + eddystones.Count + " eddystones in region " + region);
    }
}