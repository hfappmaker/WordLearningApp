package crc64eef4ae7064546f80;


public class Question_bulletin_board_listboardevent
	extends java.lang.Object
	implements
		mono.android.IGCUserPeer,
		com.google.firebase.database.ValueEventListener
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onCancelled:(Lcom/google/firebase/database/DatabaseError;)V:GetOnCancelled_Lcom_google_firebase_database_DatabaseError_Handler:Firebase.Database.IValueEventListenerInvoker, Xamarin.Firebase.Database\n" +
			"n_onDataChange:(Lcom/google/firebase/database/DataSnapshot;)V:GetOnDataChange_Lcom_google_firebase_database_DataSnapshot_Handler:Firebase.Database.IValueEventListenerInvoker, Xamarin.Firebase.Database\n" +
			"";
		mono.android.Runtime.register ("WordLearning.Question_bulletin_board+listboardevent, wordlearning", Question_bulletin_board_listboardevent.class, __md_methods);
	}


	public Question_bulletin_board_listboardevent ()
	{
		super ();
		if (getClass () == Question_bulletin_board_listboardevent.class)
			mono.android.TypeManager.Activate ("WordLearning.Question_bulletin_board+listboardevent, wordlearning", "", this, new java.lang.Object[] {  });
	}

	public Question_bulletin_board_listboardevent (crc64eef4ae7064546f80.Question_bulletin_board p0)
	{
		super ();
		if (getClass () == Question_bulletin_board_listboardevent.class)
			mono.android.TypeManager.Activate ("WordLearning.Question_bulletin_board+listboardevent, wordlearning", "WordLearning.Question_bulletin_board, wordlearning", this, new java.lang.Object[] { p0 });
	}


	public void onCancelled (com.google.firebase.database.DatabaseError p0)
	{
		n_onCancelled (p0);
	}

	private native void n_onCancelled (com.google.firebase.database.DatabaseError p0);


	public void onDataChange (com.google.firebase.database.DataSnapshot p0)
	{
		n_onDataChange (p0);
	}

	private native void n_onDataChange (com.google.firebase.database.DataSnapshot p0);

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
