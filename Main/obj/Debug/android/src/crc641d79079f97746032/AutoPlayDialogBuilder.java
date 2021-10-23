package crc641d79079f97746032;


public class AutoPlayDialogBuilder
	extends crc641d79079f97746032.WlAlartDialogBuilder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("WordLearning.Dialog.AutoPlayDialogBuilder, wordlearning", AutoPlayDialogBuilder.class, __md_methods);
	}


	public AutoPlayDialogBuilder (android.content.Context p0)
	{
		super (p0);
		if (getClass () == AutoPlayDialogBuilder.class)
			mono.android.TypeManager.Activate ("WordLearning.Dialog.AutoPlayDialogBuilder, wordlearning", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public AutoPlayDialogBuilder (android.content.Context p0, int p1)
	{
		super (p0, p1);
		if (getClass () == AutoPlayDialogBuilder.class)
			mono.android.TypeManager.Activate ("WordLearning.Dialog.AutoPlayDialogBuilder, wordlearning", "Android.Content.Context, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1 });
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
