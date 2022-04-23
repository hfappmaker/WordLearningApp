namespace WordLearning.Colors
{
    public static class WlColorUtil
    {
        public static Android.Graphics.Color GetSelectColor(bool isSelect)
        {
            if (isSelect)
            {
                return Android.Graphics.Color.Argb(127, 255, 87, 34);
            }
            else
            {
                return Android.Graphics.Color.Transparent;
            }
        }
    }
}
