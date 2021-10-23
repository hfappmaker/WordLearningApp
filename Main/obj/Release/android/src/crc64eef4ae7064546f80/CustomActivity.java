package crc64eef4ae7064546f80;


public abstract class CustomActivity
	extends androidx.appcompat.app.AppCompatActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_setContentView:(I)V:GetSetContentView_IHandler\n" +
			"n_onCreateOptionsMenu:(Landroid/view/Menu;)Z:GetOnCreateOptionsMenu_Landroid_view_Menu_Handler\n" +
			"";
		mono.android.Runtime.register ("WordLearning.CustomActivity, wordlearning", CustomActivity.class, __md_methods);
	}


	public CustomActivity ()
	{
		super ();
		if (getClass () == CustomActivity.class)
			mono.android.TypeManager.Activate ("WordLearning.CustomActivity, wordlearning", "", this, new java.lang.Object[] {  });
	}


	public CustomActivity (int p0)
	{
		super (p0);
		if (getClass () == CustomActivity.class)
			mono.android.TypeManager.Activate ("WordLearning.CustomActivity, wordlearning", "System.Int32, mscorlib", this, new java.lang.Object[] { p0 });
	}


	public void setContentView (int p0)
	{
		n_setContentView (p0);
	}

	private native void n_setContentView (int p0);


	public boolean onCreateOptionsMenu (android.view.Menu p0)
	{
		return n_onCreateOptionsMenu (p0);
	}

	private native boolean n_onCreateOptionsMenu (android.view.Menu p0);

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
