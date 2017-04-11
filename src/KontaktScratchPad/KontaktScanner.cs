using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Android.App;
using Android.Content;
using Android.Database;
using Android.Util;
using Com.Kontakt.Sdk.Android.Ble.Configuration;
using Com.Kontakt.Sdk.Android.Ble.Connection;
using Com.Kontakt.Sdk.Android.Ble.Manager;
using Com.Kontakt.Sdk.Android.Ble.Manager.Listeners;
using Com.Kontakt.Sdk.Android.Common;
using Com.Kontakt.Sdk.Android.Common.Profile;

namespace KontaktScratchPad
{
    public class KontaktScanner : Java.Lang.Object, IOnServiceReadyListener
    {
        IProximityManager proximityManager;

        public KontaktScanner(Context context, 
            System.Action<ObservableCollection<IdentifiedBeacon>> doOnBeaconsUpdated)
        {
            // Initialize Kontakt SDK with your API key
            KontaktSDK.Initialize("put_your_api_key_here");

            // Initialize Proximity Manager
            proximityManager = ProximityManagerFactory.Create(context);

            // Configure Proximity Manager
            proximityManager.Configuration()
                .ScanMode(ScanMode.LowPower)
                .ScanPeriod(ScanPeriod.Ranging)
                .ActivityCheckConfiguration(ActivityCheckConfiguration.Default)
                .DeviceUpdateCallbackInterval(2000);

            // Set Device listeners

            var beaconListener = new KontaktBeaconListener(doOnBeaconsUpdated);
            proximityManager.SetIBeaconListener(beaconListener);

        }

        public void Start()
        {
            proximityManager.Connect(this);
        }

        public void Stop()
        {
            proximityManager.Disconnect();
        }

        public void OnServiceReady()
        {
            proximityManager.StartScanning();
        }
    }
}