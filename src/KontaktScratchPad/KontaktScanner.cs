using System.Collections.ObjectModel;
using Android.Content;
using Com.Kontakt.Sdk.Android.Ble.Configuration;
using Com.Kontakt.Sdk.Android.Ble.Connection;
using Com.Kontakt.Sdk.Android.Ble.Manager;
using Com.Kontakt.Sdk.Android.Common;
using KontaktScratchPad.Models;

namespace KontaktScratchPad
{
    public class KontaktScanner : Java.Lang.Object, IOnServiceReadyListener
    {
        IProximityManager proximityManager;

        public KontaktScanner(Context context, 
            System.Action<ObservableCollection<BaseBeacon>> doOnBeaconsUpdated)
        {
            // Initialize Kontakt SDK with your API key
            KontaktSDK.Initialize("gUAUcsxrCiBdVGYQiSHMFRKvhghfzTyM");

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
            proximityManager.SetEddystoneListener(beaconListener);

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