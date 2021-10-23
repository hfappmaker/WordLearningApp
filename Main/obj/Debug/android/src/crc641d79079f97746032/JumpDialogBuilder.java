package crc641d79079f97746032;


public class JumpDialogBuilder
	extends crc641d79079f97746032.WlAlartDialogBuilder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_show:()Landroidx/appcompat/app/AlertDialog;:GetShowHandler\n" +
			"";
		mono.android.Runtime.register ("WordLearning.Dialog.JumpDialogBuilder, wordlearning", JumpDialogBuilder.class, __md_methods);
	}


	public JumpDialogBuilder (android.content.Context p0)
	{
		super (p0);
		if (getClass () == JumpDialogBuilder.class)
			mono.android.TypeManager.Activate ("WordLearning.Dialog.JumpDialogBuilder, wordlearning", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public JumpDialogBuilder (android.content.Context p0, int p1)
	{
		super (p0, p1);
		if (getClass () == JumpDialogBuilder.class)
			mono.android.TypeManager.Activate ("WordLearning.Dialog.JumpDialogBuilder, wordlearning", "Android.Content.Context, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1 });
	}


	public androidx.appcompat.app.AlertDialog show ()
	{
		return n_show ();
	}

	private native androidx.appcompat.app.AlertDialog n_show ();

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
