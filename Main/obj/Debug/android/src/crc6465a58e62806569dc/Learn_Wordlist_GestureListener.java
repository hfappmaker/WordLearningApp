package crc6465a58e62806569dc;


public class Learn_Wordlist_GestureListener
	extends android.view.GestureDetector.SimpleOnGestureListener
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onFling:(Landroid/view/MotionEvent;Landroid/view/MotionEvent;FF)Z:GetOnFling_Landroid_view_MotionEvent_Landroid_view_MotionEvent_FFHandler\n" +
			"";
		mono.android.Runtime.register ("WordLearning.Activities.Learn_Wordlist+GestureListener, wordlearning", Learn_Wordlist_GestureListener.class, __md_methods);
	}


	public Learn_Wordlist_GestureListener ()
	{
		super ();
		if (getClass () == Learn_Wordlist_GestureListener.class)
			mono.android.TypeManager.Activate ("WordLearning.Activities.Learn_Wordlist+GestureListener, wordlearning", "", this, new java.lang.Object[] {  });
	}

	public Learn_Wordlist_GestureListener (crc6465a58e62806569dc.Learn_Wordlist p0)
	{
		super ();
		if (getClass () == Learn_Wordlist_GestureListener.class)
			mono.android.TypeManager.Activate ("WordLearning.Activities.Learn_Wordlist+GestureListener, wordlearning", "WordLearning.Activities.Learn_Wordlist, wordlearning", this, new java.lang.Object[] { p0 });
	}


	public boolean onFling (android.view.MotionEvent p0, android.view.MotionEvent p1, float p2, float p3)
	{
		return n_onFling (p0, p1, p2, p3);
	}

	private native boolean n_onFling (android.view.MotionEvent p0, android.view.MotionEvent p1, float p2, float p3);

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
