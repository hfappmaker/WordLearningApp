package crc64999a33e6b0feee90;


public abstract class WlEntry
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Common.Entry.WlEntry, Common", WlEntry.class, __md_methods);
	}


	public WlEntry ()
	{
		super ();
		if (getClass () == WlEntry.class)
			mono.android.TypeManager.Activate ("Common.Entry.WlEntry, Common", "", this, new java.lang.Object[] {  });
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
