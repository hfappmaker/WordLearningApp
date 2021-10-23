package crc64eef4ae7064546f80;


public abstract class RecyclerAdapter
	extends androidx.recyclerview.widget.RecyclerView.Adapter
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("WordLearning.RecyclerAdapter, wordlearning", RecyclerAdapter.class, __md_methods);
	}


	public RecyclerAdapter ()
	{
		super ();
		if (getClass () == RecyclerAdapter.class)
			mono.android.TypeManager.Activate ("WordLearning.RecyclerAdapter, wordlearning", "", this, new java.lang.Object[] {  });
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
