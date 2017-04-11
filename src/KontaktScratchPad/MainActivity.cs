using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Widget;

namespace KontaktScratchPad
{
    [Activity(Label = "KontaktScratchPad", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        // Component with encapsulated scanning functionality.
        // More details below.
        KontaktScanner scanner;

        private bool scannerStarted;
        private ListView identifiedBeacons;
        private MainActivityAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            // Initialize Scanner
            scanner = new KontaktScanner(this, b => DoOnBeaconsUpdated(b.ToList()));
            identifiedBeacons = FindViewById<ListView>(Resource.Id.IdentifiedBeacons);

        }

        protected override void OnStart()
        {
            base.OnStart();
            if (!scannerStarted)
            {
                scanner.Start();
            }
        }

        protected override void OnResume()
        {
            base.OnStart();
            if (!scannerStarted)
            {
                scanner.Start();
            }
        }

        protected override void OnStop()
        {
            if (scannerStarted)
            {
                scanner.Stop();
            }
            base.OnStop();
        }

        protected override void OnPause()
        {
            if (scannerStarted)
            {
                scanner.Stop();
            }
            base.OnPause();
        }

        void DoOnBeaconsUpdated(List<IdentifiedBeacon> items)
        {
            if (adapter == null)
            {
                adapter = new MainActivityAdapter(this, items);
                identifiedBeacons.Adapter = adapter;
            }
            else
            {
                adapter.NotifyItemsChanged(items);
            }
        }
        //void DoOnEddyBeaconsUpdated(List<IdentifiedBeacon> items)
        //{
        //    var adapter = new MainActivityAdapter(this, items);
        //    identifiedBeacons.Adapter = adapter;
        //}
    }
}

