
using Android.Content;
using Android.Support.V7.Widget;
using Android.Views;
using KontaktScratchPad;
using KontaktScratchPad.Models;
using System.Collections.Generic;
using Android.Content.Res;
using Android.Widget;

public class MainActivityAdapter : RecyclerView.Adapter
{
    List<BaseBeacon> _items = new List<BaseBeacon>();
    Context _context;

    public MainActivityAdapter(Context context, List<BaseBeacon> items)
    {
        _context = context;
        _items = items ?? new List<BaseBeacon>();
    }
    public override long GetItemId(int position)
    {
        return position;
    }

    public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
    {
        try
        {
            var viewHolder = holder as BeaconViewHolder;

            viewHolder.TypeName.Text = "TypeName: " + _items[position].TypeName;
            viewHolder.Address.Text = "Address: " + _items[position].Address;
            viewHolder.Distance.Text = "Distance: " + _items[position].Distance.ToString();
            viewHolder.BatteryPower.Text = "BatteryPower: " + _items[position].BatteryPower.ToString();

            var appleBeacon = _items[position] as AppleBeacon;
            if (appleBeacon != null)
            {
                viewHolder.Major.Text = "Major: " + appleBeacon.Major.ToString();
                viewHolder.Minor.Text = "Minor: " + appleBeacon.Minor.ToString();
                viewHolder.ProximityUuid.Text = "ProximityUUID: " + appleBeacon.ProximityUUID.ToString();
            }
            viewHolder.Name.Text = "Name: " + _items[position].Name;
            viewHolder.Rssi.Text = "Rssi: " + _items[position].Rssi;
            viewHolder.UniqueId.Text = "UniqueId: " + _items[position].UniqueId;

            var eddyBeacon = _items[position] as EddyBeacon;
            if (eddyBeacon != null)
            {
                viewHolder.Eid.Text = "Eid: " + eddyBeacon.Eid;
                viewHolder.EncryptedTelemetry.Text = "EncryptedTelemetry: " + eddyBeacon.EncryptedTelemetry;
                viewHolder.InstanceId.Text = "InstanceId: " + eddyBeacon.InstanceId;
                viewHolder.Namespace.Text = "Namespace: " + eddyBeacon.Namespace;
                viewHolder.Telemetry.Text = "Temperature: " + eddyBeacon.Telemetry.Temperature.ToString();
                viewHolder.Url.Text = "Url: " + eddyBeacon.Url;
            }
        }
        catch
        {

        }

    }

    public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
    {
        View view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.ListItem, parent, false);
        return new BeaconViewHolder(view);
    }

    public override int ItemCount => _items.Count;
}
