using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Android.Util;
using Com.Kontakt.Sdk.Android.Ble.Manager.Listeners;
using Com.Kontakt.Sdk.Android.Common.Profile;

public class KontaktBeaconListener : Java.Lang.Object, IBeaconListener, IEddystoneListener
{
    const string TAG = nameof(KontaktBeaconListener);
    public ObservableCollection<IdentifiedBeacon> Beacons { get; }

    public KontaktBeaconListener(System.Action<ObservableCollection<IdentifiedBeacon>> doOnBeaconsUpdated)
    {
        Beacons = new ObservableCollection<IdentifiedBeacon>();
        Beacons.CollectionChanged += (sender, args) => doOnBeaconsUpdated.Invoke(Beacons);
    }

    public void OnIBeaconDiscovered(IBeaconDevice iBeacon, IBeaconRegion region)
    {
        Log.Info(TAG, "iBeacon " + iBeacon + " discovered in region " + region);
        Beacons.Add(new IdentifiedBeacon{Identifier = iBeacon.Address});

    }

    public void OnIBeaconLost(IBeaconDevice iBeacon, IBeaconRegion region)
    {
        Log.Info(TAG, "iBeacon " + iBeacon + " abandoned region " + region);
        var beaconToRemove = Beacons.FirstOrDefault(b => b.Identifier == iBeacon.Address);
        if (beaconToRemove != null)
        {
            Beacons.Remove(beaconToRemove);
        }
    }

    public void OnIBeaconsUpdated(IList<IBeaconDevice> iBeacons, IBeaconRegion region)
    {
        Log.Info(TAG, "Updated " + iBeacons.Count + " iBeacons in region " + region);
    }

    public void OnEddystoneDiscovered(IEddystoneDevice eddystone, IEddystoneNamespace region)
    {
        Log.Info(TAG, "Eddystone " + eddystone + " discovered in region " + region);
        Beacons.Add(new IdentifiedBeacon { Identifier = eddystone.Address });
    }

    public void OnEddystoneLost(IEddystoneDevice eddystone, IEddystoneNamespace region)
    {
        Log.Info(TAG, "Eddystone " + eddystone + " abandoned region " + region);
        var beaconToRemove = Beacons.FirstOrDefault(b => b.Identifier == eddystone.Address);
        if (beaconToRemove != null)
        {
            Beacons.Remove(beaconToRemove);
        }
    }

    public void OnEddystonesUpdated(IList<IEddystoneDevice> eddystones, IEddystoneNamespace region)
    {
        Log.Info(TAG, "Updated " + eddystones.Count + " eddystones in region " + region);
    }
}