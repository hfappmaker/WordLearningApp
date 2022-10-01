using Android.App;
using Android.Content;
using System;
using System.Reflection;
using System.Xml.Linq;
using WordLearning.Domain.Entry;
using WordLearning.Domain.Entry.EntryCore;
using WordLearning.Domain.Colors;
using WordLearning.CoreLibrary.Utility;

namespace WordLearning.Domain.Utility
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


        private static XDocument GetDefaultDocument()
        {
            return new(
                new XDeclaration("1.0", "utf-8", "true"),
                new XElement("Root",
                new XElement(nameof(WlFolder), new XAttribute(nameof(WlDirectory.Name), Application.Context.GetString(Resource.String.Wordlist))),
                ThemeColor.GetDefaultThemeColorElement(),
                new XElement(nameof(TagColorCollection),
                   TagColor.GetDefaultTagColorElement(),
                   TagColor.GetDefaultTagColorElement(),
                   TagColor.GetDefaultTagColorElement(),
                   TagColor.GetDefaultTagColorElement(),
                   TagColor.GetDefaultTagColorElement())
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
