using Android.Graphics;
using Android.Views;
using Android.Widget;
using WordLearning.Domain;
using WordLearning.Domain.Adapters.AdapterCore;
using WordLearning.Domain.Entry;
using WordLearning.Domain.Entry.EntryCore;
using WordLearning.Domain.ViewHolders;
using System;
using System.Collections.Generic;
using static AndroidX.RecyclerView.Widget.RecyclerView;

namespace WordLearning.Domain.Adapters
{
    /// <summary>
    /// Array adapter start move.
    /// </summary>
    public class Start_MoveAdapter : RecyclerAdapter<WlFolder, WlRecyclerViewHolder>
    {
        public Start_MoveAdapter()
            : base(new WlStartMoveCollection())
        {
        }
    }
}
