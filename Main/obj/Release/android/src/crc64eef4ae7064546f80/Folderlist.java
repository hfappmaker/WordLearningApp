package crc64eef4ae7064546f80;


public class Folderlist
	extends androidx.recyclerview.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("WordLearning.Folderlist, wordlearning", Folderlist.class, __md_methods);
	}


	public Folderlist (android.view.View p0)
	{
		super (p0);
		if (getClass () == Folderlist.class)
			mono.android.TypeManager.Activate ("WordLearning.Folderlist, wordlearning", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
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
