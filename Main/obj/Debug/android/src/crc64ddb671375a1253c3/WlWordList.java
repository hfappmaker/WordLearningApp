package crc64ddb671375a1253c3;


public class WlWordList
	extends crc64999a33e6b0feee90.WlDirectory
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("WordLearning.Entry.WlWordList, wordlearning", WlWordList.class, __md_methods);
	}


	public WlWordList ()
	{
		super ();
		if (getClass () == WlWordList.class)
			mono.android.TypeManager.Activate ("WordLearning.Entry.WlWordList, wordlearning", "", this, new java.lang.Object[] {  });
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
