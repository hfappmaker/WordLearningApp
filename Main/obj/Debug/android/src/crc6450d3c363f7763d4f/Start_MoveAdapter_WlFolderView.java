package crc6450d3c363f7763d4f;


public class Start_MoveAdapter_WlFolderView
	extends androidx.recyclerview.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("WordLearning.Adapter.Start_MoveAdapter+WlFolderView, wordlearning", Start_MoveAdapter_WlFolderView.class, __md_methods);
	}


	public Start_MoveAdapter_WlFolderView (android.view.View p0)
	{
		super (p0);
		if (getClass () == Start_MoveAdapter_WlFolderView.class)
			mono.android.TypeManager.Activate ("WordLearning.Adapter.Start_MoveAdapter+WlFolderView, wordlearning", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
