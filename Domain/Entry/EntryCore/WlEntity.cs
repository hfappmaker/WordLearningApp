using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordLearning.Domain.Entry.EntryCore
{
    public abstract class WlEntity : Java.Lang.Object
    {
        /// <summary>
        /// エンティティの識別ID
        /// </summary>
        public Guid EntityID { get; } = Guid.NewGuid();
    }
}