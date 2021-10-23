package crc641d79079f97746032;


public class RenameDirectoryDialogFragment
	extends crc648902a4f2dc070a01.WlAlartDialogFragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreateDialog:(Landroid/os/Bundle;)Landroid/app/Dialog;:GetOnCreateDialog_Landroid_os_Bundle_Handler\n" +
			"n_onSaveInstanceState:(Landroid/os/Bundle;)V:GetOnSaveInstanceState_Landroid_os_Bundle_Handler\n" +
			"n_onDestroy:()V:GetOnDestroyHandler\n" +
			"";
		mono.android.Runtime.register ("WordLearning.Dialog.RenameDirectoryDialogFragment, wordlearning", RenameDirectoryDialogFragment.class, __md_methods);
	}


	public RenameDirectoryDialogFragment ()
	{
		super ();
		if (getClass () == RenameDirectoryDialogFragment.class)
			mono.android.TypeManager.Activate ("WordLearning.Dialog.RenameDirectoryDialogFragment, wordlearning", "", this, new java.lang.Object[] {  });
	}

	public RenameDirectoryDialogFragment (android.os.Bundle p0)
	{
		super ();
		if (getClass () == RenameDirectoryDialogFragment.class)
			mono.android.TypeManager.Activate ("WordLearning.Dialog.RenameDirectoryDialogFragment, wordlearning", "Android.OS.Bundle, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public android.app.Dialog onCreateDialog (android.os.Bundle p0)
	{
		return n_onCreateDialog (p0);
	}

	private native android.app.Dialog n_onCreateDialog (android.os.Bundle p0);


	public void onSaveInstanceState (android.os.Bundle p0)
	{
		n_onSaveInstanceState (p0);
	}

	private native void n_onSaveInstanceState (android.os.Bundle p0);


	public void onDestroy ()
	{
		n_onDestroy ();
	}

	private native void n_onDestroy ();

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
