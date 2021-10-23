package crc6465a58e62806569dc;


public class Question_bulletin_board
	extends crc6465a58e62806569dc.CustomActivity
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"n_onDestroy:()V:GetOnDestroyHandler\n" +
			"n_onOptionsItemSelected:(Landroid/view/MenuItem;)Z:GetOnOptionsItemSelected_Landroid_view_MenuItem_Handler\n" +
			"n_onKeyDown:(ILandroid/view/KeyEvent;)Z:GetOnKeyDown_ILandroid_view_KeyEvent_Handler\n" +
			"";
		mono.android.Runtime.register ("WordLearning.Activities.Question_bulletin_board, wordlearning", Question_bulletin_board.class, __md_methods);
	}


	public Question_bulletin_board ()
	{
		super ();
		if (getClass () == Question_bulletin_board.class)
			mono.android.TypeManager.Activate ("WordLearning.Activities.Question_bulletin_board, wordlearning", "", this, new java.lang.Object[] {  });
	}


	public Question_bulletin_board (int p0)
	{
		super (p0);
		if (getClass () == Question_bulletin_board.class)
			mono.android.TypeManager.Activate ("WordLearning.Activities.Question_bulletin_board, wordlearning", "System.Int32, mscorlib", this, new java.lang.Object[] { p0 });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);


	public void onDestroy ()
	{
		n_onDestroy ();
	}

	private native void n_onDestroy ();


	public boolean onOptionsItemSelected (android.view.MenuItem p0)
	{
		return n_onOptionsItemSelected (p0);
	}

	private native boolean n_onOptionsItemSelected (android.view.MenuItem p0);


	public boolean onKeyDown (int p0, android.view.KeyEvent p1)
	{
		return n_onKeyDown (p0, p1);
	}

	private native boolean n_onKeyDown (int p0, android.view.KeyEvent p1);

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
