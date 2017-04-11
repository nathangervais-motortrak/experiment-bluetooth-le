
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Views;
using Android.Widget;
using KontaktScratchPad;

public class MainActivityAdapter : BaseAdapter<IdentifiedBeacon>
{
    List<IdentifiedBeacon> _items = new List<IdentifiedBeacon>();
    Context _context;

    public MainActivityAdapter(Context context, List<IdentifiedBeacon> items)
    {
        _context = context;
        _items = items ?? new List<IdentifiedBeacon>();
    }
    public override long GetItemId(int position)
    {
        return position;
    }

    public override View GetView(int position, View convertView, ViewGroup parent)
    {
        LayoutInflater inflater = (LayoutInflater)_context.GetSystemService(Context.LayoutInflaterService);

        View view = convertView ?? inflater.Inflate(Resource.Layout.ListItem, null); // re-use an existing view, if one is available
        view.FindViewById<TextView>(Resource.Id.tv_caption).Text = _items[position].Identifier;

        return view;
    }

    public override int Count => _items.Count;

    public void NotifyItemsChanged(List<IdentifiedBeacon> items)
    {
        _items = items;
        NotifyDataSetChanged();
    }

    public override IdentifiedBeacon this[int position] => _items[position];
}
