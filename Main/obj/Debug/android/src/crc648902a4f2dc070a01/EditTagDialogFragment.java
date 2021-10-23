package crc648902a4f2dc070a01;


public class EditTagDialogFragment
	extends crc648902a4f2dc070a01.WlAlartDialogFragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("WordLearning.Fragment.EditTagDialogFragment, wordlearning", EditTagDialogFragment.class, __md_methods);
	}


	public EditTagDialogFragment ()
	{
		super ();
		if (getClass () == EditTagDialogFragment.class)
			mono.android.TypeManager.Activate ("WordLearning.Fragment.EditTagDialogFragment, wordlearning", "", this, new java.lang.Object[] {  });
	}

	public EditTagDialogFragment (android.os.Bundle p0)
	{
		super ();
		if (getClass () == EditTagDialogFragment.class)
			mono.android.TypeManager.Activate ("WordLearning.Fragment.EditTagDialogFragment, wordlearning", "Android.OS.Bundle, Mono.Android", this, new java.lang.Object[] { p0 });
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
