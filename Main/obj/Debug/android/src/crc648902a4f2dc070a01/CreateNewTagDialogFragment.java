package crc648902a4f2dc070a01;


public class CreateNewTagDialogFragment
	extends crc648902a4f2dc070a01.WlAlartDialogFragment
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreateDialog:(Landroid/os/Bundle;)Landroid/app/Dialog;:GetOnCreateDialog_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("WordLearning.Fragment.CreateNewTagDialogFragment, wordlearning", CreateNewTagDialogFragment.class, __md_methods);
	}


	public CreateNewTagDialogFragment ()
	{
		super ();
		if (getClass () == CreateNewTagDialogFragment.class)
			mono.android.TypeManager.Activate ("WordLearning.Fragment.CreateNewTagDialogFragment, wordlearning", "", this, new java.lang.Object[] {  });
	}

	public CreateNewTagDialogFragment (android.os.Bundle p0)
	{
		super ();
		if (getClass () == CreateNewTagDialogFragment.class)
			mono.android.TypeManager.Activate ("WordLearning.Fragment.CreateNewTagDialogFragment, wordlearning", "Android.OS.Bundle, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public android.app.Dialog onCreateDialog (android.os.Bundle p0)
	{
		return n_onCreateDialog (p0);
	}

	private native android.app.Dialog n_onCreateDialog (android.os.Bundle p0);

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
