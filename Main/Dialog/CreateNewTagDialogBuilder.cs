using System;
using System.Collections.Generic;
using Android.Content;
using Android.Content.Res;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using WordLearning.Colors;
using WordLearning.Language;
using WordLearning.Messages;
using WordLearning.Shape;
using static Android.Widget.RadioGroup;
using static Android.Widget.SeekBar;

namespace WordLearning.Dialog
{
    internal class CreateNewTagDialogBulder : WlAlartDialogBuilder
    {
        public CreateNewTagDialogBulder(Context context) : base(context)
        {
            Initialize(context);
        }

        private void Initialize(Context context)
        {
            var inflater = LayoutInflater.From(context);
            var view = inflater.Inflate(Resource.Layout.Dialog_CreateNewTag, null);
            SetMessage(WlMessage.MaxCountOfTag[WlLanguageUtil.CurrentLanguage]);
            SetView(view);
        }

        public void rdogSelectshape_CheckedChange(object sender, CheckedChangeEventArgs e)
        {
            var position = 0;
            var view = (sender as RadioGroup).RootView;
            var tagColor = TagColorCollection.Instance[position].WlColor;
            var shape = TagColorCollection.Instance[position].Shape;
            IReadOnlyDictionary<int, WlShape> drawableDictionary = new Dictionary<int, WlShape>()
                                        {
                                            {Resource.Id.rdorect,WlShape.Square},
                                            {Resource.Id.rdostar,WlShape.Star},
                                            {Resource.Id.rdoheart,WlShape.Heart},
                                        };

            var drawable = Context.GetDrawable((int)drawableDictionary[e.CheckedId]) as VectorDrawable;
            drawable.Mutate();
            drawable.SetColorFilter(new BlendModeColorFilter(tagColor, BlendMode.Multiply));
            shape = drawableDictionary[e.CheckedId];
        }


        public void Sb_Red_Dialog_CreateNewTag_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            SetSeekBar(sender, e);
        }

        public void Sb_Green_Dialog_CreateNewTag_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            SetSeekBar(sender, e);
        }

        // attribute
        public void Sb_Blue_Dialog_CreateNewTag_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            SetSeekBar(sender, e);
        }

        private void SetSeekBar(object sender, ProgressChangedEventArgs e)
        {
            var view = (sender as SeekBar).RootView;
            var seekBars = new SeekBar[]
            {
                view.FindViewById<SeekBar>(Resource.Id.Sb_Red_Dialog_CreateNewTag),
                view.FindViewById<SeekBar>(Resource.Id.Sb_Green_Dialog_CreateNewTag),
                view.FindViewById<SeekBar>(Resource.Id.Sb_Blue_Dialog_CreateNewTag)
            };

            const int colorValue = 255;
            int[] progressTintColor = new int[]
            {
                Convert.ToInt32(sender == seekBars[0]) * colorValue,
                Convert.ToInt32(sender == seekBars[1]) * colorValue,
                Convert.ToInt32(sender == seekBars[2]) * colorValue,
            };

            e.SeekBar.ProgressTintList = ColorStateList.ValueOf(Android.Graphics.Color.Argb(e.Progress, progressTintColor[0], progressTintColor[1], progressTintColor[2]));
            var tagColor = Android.Graphics.Color.Rgb(seekBars[0].Progress, seekBars[1].Progress, seekBars[2].Progress);
            var imageView = view.FindViewById<ImageView>(Resource.Id.ivDialog_CreateNewTag);
            var drawable = imageView.Drawable as VectorDrawable;
            drawable.Mutate();
            drawable.SetColorFilter(new BlendModeColorFilter(tagColor, BlendMode.Multiply));
        }
    }
}
