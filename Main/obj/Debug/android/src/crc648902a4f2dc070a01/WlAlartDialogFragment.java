package crc648902a4f2dc070a01;


public class WlAlartDialogFragment
	extends androidx.appcompat.app.AppCompatDialogFragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("WordLearning.Fragment.WlAlartDialogFragment, wordlearning", WlAlartDialogFragment.class, __md_methods);
	}


	public WlAlartDialogFragment ()
	{
		super ();
		if (getClass () == WlAlartDialogFragment.class)
			mono.android.TypeManager.Activate ("WordLearning.Fragment.WlAlartDialogFragment, wordlearning", "", this, new java.lang.Object[] {  });
	}

	public WlAlartDialogFragment (android.os.Bundle p0)
	{
		super ();
		if (getClass () == WlAlartDialogFragment.class)
			mono.android.TypeManager.Activate ("WordLearning.Fragment.WlAlartDialogFragment, wordlearning", "Android.OS.Bundle, Mono.Android", this, new java.lang.Object[] { p0 });
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
