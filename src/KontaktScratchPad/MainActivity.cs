using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Android.App;
using Android.OS;
using Android.Support.V7.Widget;
using Android.Widget;
using KontaktScratchPad.Models;

namespace KontaktScratchPad
{
    [Activity(Label = "KontaktScratchPad", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        // Component with encapsulated scanning functionality.
        // More details below.
        KontaktScanner scanner;

        private bool scannerStarted;
        private RecyclerView rv_identifiedBeacons;
        private TextView tv_Count;
        private MainActivityAdapter adapter;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            // Initialize Scanner
            rv_identifiedBeacons = FindViewById<RecyclerView>(Resource.Id.rv_IdentifiedBeacons);
            rv_identifiedBeacons.SetLayoutManager(new LinearLayoutManager(this, LinearLayoutManager.Vertical, false));
            tv_Count = FindViewById<TextView>(Resource.Id.tv_count);
            scanner = new KontaktScanner(this, DoOnBeaconsUpdated);
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

        void DoOnBeaconsUpdated(ObservableCollection<BaseBeacon> items)
        {
            tv_Count.Text = "Beacons in range: " + items.Count;
            adapter = new MainActivityAdapter(this, items.ToList());
            rv_identifiedBeacons.SetAdapter(adapter);
        }
    }
}

