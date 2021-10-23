package crc641d79079f97746032;


public abstract class WlAlartDialogBuilder
	extends androidx.appcompat.app.AlertDialog.Builder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_create:()Landroidx/appcompat/app/AlertDialog;:GetCreateHandler\n" +
			"";
		mono.android.Runtime.register ("WordLearning.Dialog.WlAlartDialogBuilder, wordlearning", WlAlartDialogBuilder.class, __md_methods);
	}


	public WlAlartDialogBuilder (android.content.Context p0)
	{
		super (p0);
		if (getClass () == WlAlartDialogBuilder.class)
			mono.android.TypeManager.Activate ("WordLearning.Dialog.WlAlartDialogBuilder, wordlearning", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public WlAlartDialogBuilder (android.content.Context p0, int p1)
	{
		super (p0, p1);
		if (getClass () == WlAlartDialogBuilder.class)
			mono.android.TypeManager.Activate ("WordLearning.Dialog.WlAlartDialogBuilder, wordlearning", "Android.Content.Context, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1 });
	}


	public androidx.appcompat.app.AlertDialog create ()
	{
		return n_create ();
	}

	private native androidx.appcompat.app.AlertDialog n_create ();

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
