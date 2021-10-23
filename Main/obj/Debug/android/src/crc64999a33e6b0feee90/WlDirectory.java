package crc64999a33e6b0feee90;


public abstract class WlDirectory
	extends crc64999a33e6b0feee90.WlEntry
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Common.Entry.WlDirectory, Common", WlDirectory.class, __md_methods);
	}


	public WlDirectory ()
	{
		super ();
		if (getClass () == WlDirectory.class)
			mono.android.TypeManager.Activate ("Common.Entry.WlDirectory, Common", "", this, new java.lang.Object[] {  });
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
