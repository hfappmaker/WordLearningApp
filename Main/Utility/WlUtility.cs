using Android.App;
using Android.Content;
using Common.Entry;
using Common.Utility;
using System;
using System.Reflection;
using System.Xml.Linq;
using WordLearning.Colors;
using WordLearning.Entry;
using WordLearning.Language;
using WordLearning.Messages;

namespace WordLearning.Utility
{
    public static class WlUtility
    {
        public static Assembly CurrentAssembly { get; } = Assembly.GetExecutingAssembly();


        static WlUtility()
        {
            RootFolder.Save(WordListPath);
        }

        private const string FileName = "Wordlist.xml";


        public static readonly string WordListPath =
            System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), FileName);


        public static WlFolder RootFolder { get; } = new WlFolder(RootElement.Element(nameof(WlFolder)));


        private static XElement GetDefaultTagColorElement()
        {
            return new(nameof(TagColor),
                new XElement(nameof(TagColor.Red), TagColor.DefaultTagColor.R),
                new XElement(nameof(TagColor.Green), TagColor.DefaultTagColor.G),
                new XElement(nameof(TagColor.Blue), TagColor.DefaultTagColor.B),
                new XElement(nameof(TagColor.Meaning), string.Empty),
                new XElement(nameof(TagColor.Shape), TagColor.DefaultShape)
         );
        }

        private static XElement GetDefaultThemeColorElement()
        {
            return new(nameof(ThemeColor),
                new XElement(nameof(ThemeColor.Red), ThemeColor.DefaultRed),
                new XElement(nameof(ThemeColor.Green), ThemeColor.DefaultGreen),
                new XElement(nameof(ThemeColor.Blue), ThemeColor.DefaultBlue)
    );
        }

        private static XDocument GetDefaultDocument()
        {
            return new(
                new XDeclaration("1.0", "utf-8", "true"),
                new XElement("Root",
                new XElement(nameof(WlFolder), new XAttribute(nameof(WlDirectory.Name), WlMessage.ToolbarTitle_Wordlist[WlLanguageUtil.CurrentLanguage])),
                GetDefaultThemeColorElement(),
                new XElement(nameof(TagColorCollection),
                   GetDefaultTagColorElement(),
                   GetDefaultTagColorElement(),
                   GetDefaultTagColorElement(),
                   GetDefaultTagColorElement(),
                   GetDefaultTagColorElement())
         )
);
        }

        private static XDocument document;
        public static XElement RootElement
        {
            get
            {
#if DEBUG
                if (document == null)
                {
                    document = GetDefaultDocument();
                    document.Save(WordListPath);
                }

                return document.Root;
#else
                if (document == null)
                {
                    if (File.Exists(WordListPath))
                    {
                        document = XDocument.Load(WordListPath);
                    }
                    else
                    {
                        document = GetDefaultDocument();
                        document.Save(WordListPath);
                    }
                }

                return document.Root;
#endif
            }
        }
        /// <summary>
        /// Check name
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static bool FileNameCheck(string fileName, Context context)
        {
            AlertDialog.Builder dialog = new AlertDialog.Builder(context);
            if (string.IsNullOrEmpty(fileName))
            {
                dialog.SetMessage(Resource.String.SetName);
                dialog.SetNeutralButton("OK", (_, _) => { });
                dialog.Show();
                return false;
            }
            return true;
        }


        public static void AddEventToEachView(dynamic root, object target = null)
        {
            CommonUtility.AddEventToEachView(root, typeof(Resource.Id).GetFields(), target);
        }
    }
}
