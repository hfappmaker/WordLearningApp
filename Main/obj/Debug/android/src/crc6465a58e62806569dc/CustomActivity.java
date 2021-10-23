package crc6465a58e62806569dc;


public abstract class CustomActivity
	extends androidx.appcompat.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreateOptionsMenu:(Landroid/view/Menu;)Z:GetOnCreateOptionsMenu_Landroid_view_Menu_Handler\n" +
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("WordLearning.Activities.CustomActivity, wordlearning", CustomActivity.class, __md_methods);
	}


	public CustomActivity ()
	{
		super ();
		if (getClass () == CustomActivity.class)
			mono.android.TypeManager.Activate ("WordLearning.Activities.CustomActivity, wordlearning", "", this, new java.lang.Object[] {  });
	}


	public CustomActivity (int p0)
	{
		super (p0);
		if (getClass () == CustomActivity.class)
			mono.android.TypeManager.Activate ("WordLearning.Activities.CustomActivity, wordlearning", "System.Int32, mscorlib", this, new java.lang.Object[] { p0 });
	}


	public boolean onCreateOptionsMenu (android.view.Menu p0)
	{
		return n_onCreateOptionsMenu (p0);
	}

	private native boolean n_onCreateOptionsMenu (android.view.Menu p0);


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
