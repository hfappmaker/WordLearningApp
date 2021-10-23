package crc6465a58e62806569dc;


public class Question_bulletin_board_listtitleevent
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
		mono.android.Runtime.register ("WordLearning.Activities.Question_bulletin_board+listtitleevent, wordlearning", Question_bulletin_board_listtitleevent.class, __md_methods);
	}


	public Question_bulletin_board_listtitleevent ()
	{
		super ();
		if (getClass () == Question_bulletin_board_listtitleevent.class)
			mono.android.TypeManager.Activate ("WordLearning.Activities.Question_bulletin_board+listtitleevent, wordlearning", "", this, new java.lang.Object[] {  });
	}

	public Question_bulletin_board_listtitleevent (crc6465a58e62806569dc.Question_bulletin_board p0)
	{
		super ();
		if (getClass () == Question_bulletin_board_listtitleevent.class)
			mono.android.TypeManager.Activate ("WordLearning.Activities.Question_bulletin_board+listtitleevent, wordlearning", "WordLearning.Activities.Question_bulletin_board, wordlearning", this, new java.lang.Object[] { p0 });
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
