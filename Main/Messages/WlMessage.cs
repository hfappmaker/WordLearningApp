using System;
using System.Collections.Generic;
using WordLearning.Language;

namespace WordLearning.Messages
{
    public static class WlMessage
    {
        public static IReadOnlyDictionary<WlLanguage, string> DeleteWordConfirm { get; } = new Dictionary<WlLanguage, string>
            {
                {WlLanguage.日本語,$"選択した単語を削除します。{Environment.NewLine} 宜しいですか？"},
                {WlLanguage.English,$"Delete the selected word.{Environment.NewLine}Is it OK?"},
                {WlLanguage.繁體中文,$"刪除所選單詞。{Environment.NewLine}可以嗎？"},
                {WlLanguage.简体中文,$"删除所选单词。{Environment.NewLine}可以吗？"},
                {WlLanguage.Deutsch,$"Löschen Sie das ausgewählte Wort.{Environment.NewLine} Ist es o.k?"},
                {WlLanguage.Français,$"Supprimer le mot sélectionné.{Environment.NewLine}Est-ce que c'est bon?"},
                {WlLanguage.한국어,$"선택한 단어를 삭제하십시오.{Environment.NewLine}괜찮습니까?"},
                {WlLanguage.русский,$"Удалить выбранное слово.{Environment.NewLine}Это нормально?"}
            };


        public static IReadOnlyDictionary<WlLanguage, string> ChangeThemeColor { get; } = new Dictionary<WlLanguage, string>()
            {
                {WlLanguage.日本語,""},
                {WlLanguage.English,""},
                {WlLanguage.繁體中文,""},
                {WlLanguage.简体中文,""},
                {WlLanguage.Deutsch,""},
                {WlLanguage.Français,""},
                {WlLanguage.한국어,""},
                {WlLanguage.русский,""},
                {WlLanguage.इंडिया,""}
            };


        public static IReadOnlyDictionary<WlLanguage, string> MaxCountOfTag { get; } = new Dictionary<WlLanguage, string>
            {
                {WlLanguage.日本語,"タグは最大5つまでです"},
                {WlLanguage.English,"Tag is allowed 5 at the most."},
                {WlLanguage.繁體中文,"標籤最多允許5。"},
                {WlLanguage.简体中文,"标签最多允许5。"},
                {WlLanguage.Deutsch,"Tag ist maximal 5 erlaubt."},
                {WlLanguage.Français,"La balise est autorisée 5 au maximum."},
                {WlLanguage.한국어,"태그는 최대 5 개까지 허용됩니다."},
                {WlLanguage.русский,"Метка допускается максимум 5."}
            };


        public static IReadOnlyDictionary<WlLanguage, string> EditTag { get; } = new Dictionary<WlLanguage, string>
            {
                {WlLanguage.日本語,"タグの編集"},
                {WlLanguage.English,"Edit tag"},
                {WlLanguage.繁體中文,"編輯標籤"},
                {WlLanguage.简体中文,"编辑标签"},
                {WlLanguage.Deutsch,"Tag bearbeiten"},
                {WlLanguage.Français,"Modifier la balise"},
                {WlLanguage.한국어,"태그 수정"},
                {WlLanguage.русский,"Изменить тег"}
            };


        public static IReadOnlyDictionary<WlLanguage, string> InputMemo { get; } = new Dictionary<WlLanguage, string>
            {
                {WlLanguage.日本語,"メモを入力して下さい"},
                {WlLanguage.English,"Please Input memo"},
                {WlLanguage.繁體中文,"請輸入備忘錄"},
                {WlLanguage.简体中文,"请输入备忘录"},
                {WlLanguage.Deutsch,"Bitte Memo eingeben"},
                {WlLanguage.Français,"S'il vous plaît entrer un mémo"},
                {WlLanguage.한국어,"메모를 입력하십시오."},
                {WlLanguage.русский,"Пожалуйста, введите памятку"},
            };


        public static IReadOnlyDictionary<WlLanguage, string> AnotherTitle { get; } = new Dictionary<WlLanguage, string>()
            {
                {WlLanguage.日本語,"タイトルが重複しています。他のタイトル名に変更して下さい。"},
                {WlLanguage.English,"Title is duplicated.Please set another title."},
                {WlLanguage.繁體中文,"標題是重複的。請設置另一個標題。"},
                {WlLanguage.简体中文,"标题重复。请设置另一个标题。"},
                {WlLanguage.Deutsch,"Titel ist doppelt vorhanden. Bitte setzen Sie einen anderen Titel."},
                {WlLanguage.Français,"Le titre est dupliqué. Veuillez définir un autre titre."},
                {WlLanguage.한국어,"제목이 중복되었습니다. 다른 제목을 설정하십시오."},
                {WlLanguage.русский,"Название дублируется.Пожалуйста, установите другое название."},
                {WlLanguage.इंडिया,"शीर्षक डुप्लिकेट है। कृपया एक और शीर्षक सेट करें।"}
            };


        public static IReadOnlyDictionary<WlLanguage, string> ToolbarTitle_Wordlist { get; } = new Dictionary<WlLanguage, string>()
            {
                {WlLanguage.日本語,"単語帳"},
                {WlLanguage.English,"Word book"},
                {WlLanguage.简体中文,"单词书"},
                {WlLanguage.繁體中文,"單詞書"},
                {WlLanguage.Deutsch,"Wortbuch"},
                {WlLanguage.Français,"Livre de mots"},
                {WlLanguage.한국어,"단어장"},
                {WlLanguage.русский,"Слово книга"},
                {WlLanguage.इंडिया,""}
            };
        public static IReadOnlyDictionary<WlLanguage, string> ToolbarTitle_RegisterWord { get; } = new Dictionary<WlLanguage, string>()
            {
                {WlLanguage.日本語,"単語の登録"},
                {WlLanguage.English,"Register words"},
                {WlLanguage.简体中文,"注册单词"},
                {WlLanguage.繁體中文,"註冊單詞"},
                {WlLanguage.Deutsch,"Wörter registrieren"},
                {WlLanguage.Français,"Enregistrer les mots"},
                {WlLanguage.한국어,"단어 등록"},
                {WlLanguage.русский,"Регистрировать слова"},
                {WlLanguage.इंडिया,""}
            };
        public static IReadOnlyDictionary<WlLanguage, string> ToolbarTitle_Editword { get; } = new Dictionary<WlLanguage, string>()
            {
                {WlLanguage.日本語,"単語の編集"},
                {WlLanguage.English,"Edit words"},
                {WlLanguage.简体中文,"编辑单词"},
                {WlLanguage.繁體中文,"編輯單詞"},
                {WlLanguage.Deutsch,"Wörter bearbeiten"},
                {WlLanguage.Français,"Modifier les mots"},
                {WlLanguage.한국어,"단어 수정"},
                {WlLanguage.русский,"Изменить слова"},
                {WlLanguage.इंडिया,""}
            };
        public static IReadOnlyDictionary<WlLanguage, string> ToolbarTitle_Settings { get; } = new Dictionary<WlLanguage, string>()
            {
                {WlLanguage.日本語,"設定"},
                {WlLanguage.English,"Settings"},
                {WlLanguage.简体中文,"设置"},
                {WlLanguage.繁體中文,"設置"},
                {WlLanguage.Deutsch,"die Einstellungen"},
                {WlLanguage.Français,"Réglages"},
                {WlLanguage.한국어,"설정"},
                {WlLanguage.русский,"настройки"},
                {WlLanguage.इंडिया,""}
            };
        public static IReadOnlyDictionary<WlLanguage, string> ToolbarTitle_Question_bulletin_board { get; } = new Dictionary<WlLanguage, string>()
            {
                {WlLanguage.日本語,"質問掲示板"},
                {WlLanguage.English,"Question_bulletin_board"},
                {WlLanguage.简体中文,"Question_bulletin_board"},
                {WlLanguage.繁體中文,"Question_bulletin_board"},
                {WlLanguage.Deutsch,"Question_bulletin_board"},
                {WlLanguage.Français,"Question_bulletin_board"},
                {WlLanguage.한국어,"Question_bulletin_board"},
                {WlLanguage.русский,"Question_bulletin_board"},
                {WlLanguage.इंडिया,"Question_bulletin_board"}
            };

        public static IReadOnlyDictionary<WlLanguage, string[]> ActionSelectedTag { get; } = new Dictionary<WlLanguage, string[]>
            {
                {WlLanguage.日本語,new string[] { "選択したタグを編集する", "選択したタグを削除する" }},
                {WlLanguage.English,new string[]{"Edit the selected tag.", "Delete the selected tag." } },
                {WlLanguage.繁體中文,new string[]{ "編輯選定的標籤。", "刪除所選標籤。" } },
                {WlLanguage.简体中文,new string[]{ "编辑选定的标签。", "删除所选标签。" } },
                {WlLanguage.Deutsch,new string[]{ "Bearbeiten Sie das ausgewählte Tag.", "Löschen Sie das ausgewählte Tag." } },
                {WlLanguage.Français,new string[]{ "Modifier la balise sélectionnée.", "Supprimer la balise sélectionnée." } },
                {WlLanguage.한국어,new string[]{ "선택한 태그를 편집하십시오.", "선택한 태그를 삭제하십시오." } },
                {WlLanguage.русский,new string[]{ "Редактировать выбранный тег.", "Удалить выбранный тег." } }
            };
        public static IReadOnlyDictionary<WlLanguage, string> NotImplement { get; } = new Dictionary<WlLanguage, string>
            {
                {WlLanguage.日本語,"すみません、まだ未実装です。m(_ _)m"},
                {WlLanguage.English,"Sorry, not implemented yet."},
                {WlLanguage.繁體中文,"對不起，還沒有實現。"},
                {WlLanguage.简体中文,"对不起，还没有实现。"},
                {WlLanguage.Deutsch,"Sorry, noch nicht implementiert."},
                {WlLanguage.Français,"Désolé, pas encore implémenté."},
                {WlLanguage.한국어,"죄송합니다. 아직 구현되지 않았습니다."},
                {WlLanguage.русский,"Извините, пока не реализовано."}
            };
        public static IReadOnlyDictionary<WlLanguage, string> NoTag { get; } = new Dictionary<WlLanguage, string>
            {
                {WlLanguage.日本語,"タグなし"},
                {WlLanguage.English,"No tag"},
                {WlLanguage.繁體中文,"沒有標籤"},
                {WlLanguage.简体中文,"没有标签"},
                {WlLanguage.Deutsch,"Keine Markierung"},
                {WlLanguage.Français,"Aucun tag"},
                {WlLanguage.한국어,"태그 없음"},
                {WlLanguage.русский,"Нет тега"},
            };
        public static IReadOnlyDictionary<WlLanguage, string> NoRegisteredWord { get; } = new Dictionary<WlLanguage, string>
            {
                {WlLanguage.日本語,"単語が登録されていません"},
                {WlLanguage.English,"Word is not registered."},
                {WlLanguage.繁體中文,"單詞未註冊"},
                {WlLanguage.简体中文,"单词未注册"},
                {WlLanguage.Deutsch,"Wörter sind nicht registriert"},
                {WlLanguage.Français,"Les mots ne sont pas enregistrés"},
                {WlLanguage.한국어,"단어가 등록되지 않았습니다."},
                {WlLanguage.русский,"Слова не зарегистрированы"},
            };
        public static IReadOnlyDictionary<WlLanguage, string> NoMatchWord { get; } = new Dictionary<WlLanguage, string>
            {
                {WlLanguage.日本語,"条件を満たす単語が存在しません"},
                {WlLanguage.English,"matched word is not registered."},
                {WlLanguage.繁體中文,"匹配的單詞未註冊"},
                {WlLanguage.简体中文,"匹配的单词未注册"},
                {WlLanguage.Deutsch,"übereinstimmendes Wort ist nicht registriert"},
                {WlLanguage.Français,"le mot correspondant n'est pas enregistré"},
                {WlLanguage.한국어,"일치하는 단어가 등록되지 않았습니다."},
                {WlLanguage.русский,"подходящее слово не зарегистрировано"},
            };
        public static IReadOnlyDictionary<WlLanguage, string> Deleted { get; } = new Dictionary<WlLanguage, string>
            {
                {WlLanguage.日本語,"削除されました"},
                {WlLanguage.English,"Delete is done"},
                {WlLanguage.繁體中文,"刪除完成"},
                {WlLanguage.简体中文,"删除完成"},
                {WlLanguage.Deutsch,"Löschen ist fertig"},
                {WlLanguage.Français,"Supprimer est terminé"},
                {WlLanguage.한국어,"삭제가 완료되었습니다."},
                {WlLanguage.русский,"Удаление сделано"},
            };
        public static IReadOnlyDictionary<WlLanguage, string> DeleteWord { get; } = new Dictionary<WlLanguage, string>
            {
                {WlLanguage.日本語,"単語の削除"},
                {WlLanguage.English,"Delete word"},
                {WlLanguage.繁體中文,"刪除單詞"},
                {WlLanguage.简体中文,"删除单词"},
                {WlLanguage.Deutsch,"Wort löschen"},
                {WlLanguage.Français,"Supprimer le mot"},
                {WlLanguage.한국어,"단어 삭제"},
                {WlLanguage.русский,"Удалить слово"},
            };

        public static Dictionary<WlLanguage, string> SpecifyDestination = new Dictionary<WlLanguage, string>()
            {
                {WlLanguage.日本語,"移動先のページ番号を指定して下さい"},
                {WlLanguage.English,"Please specify the page number of the destination."},
                {WlLanguage.繁體中文,"請指定目的地的頁碼。"},
                {WlLanguage.简体中文,"请指定目的地的页码。"},
                {WlLanguage.Deutsch,"Bitte geben Sie die Seitennummer des Ziels an."},
                {WlLanguage.Français,"Veuillez spécifier le numéro de page de la destination."},
                {WlLanguage.한국어,"대상 페이지 번호를 지정하십시오."},
                {WlLanguage.русский,"Пожалуйста, укажите номер страницы назначения."}
            };
        public static IReadOnlyDictionary<WlLanguage, string> AutoPlayConfirm = new Dictionary<WlLanguage, string>()
            {
                {WlLanguage.日本語,"自動再生を開始します。宜しいですか？"},
                {WlLanguage.English,"Start auto playing.Are you sure?"},
                {WlLanguage.繁體中文,"開始自動播放。你確定嗎？"},
                {WlLanguage.简体中文,"开始自动播放。你确定吗？"},
                {WlLanguage.Deutsch,"Starten Sie die automatische Wiedergabe. Sind Sie sicher?"},
                {WlLanguage.Français,"Commencez la lecture automatique. Êtes-vous sûr?"},
                {WlLanguage.한국어,"자동 연주 시작. 정말이야?"},
                {WlLanguage.русский,"Запустите автоматическое воспроизведение. Вы уверены?"}
            };

        public static string GetWarningPageSelect(WlLanguage language)
        {
            switch (language)
            {
                //case WlLanguage.English:
                //    return "The page must be an integer from 1 to " + (WlUtility.CurrentEntry.Parent as WordList).Entries.Count;
                //case WlLanguage.日本語:
                //    return "ページは1から" + (WlUtility.CurrentEntry.Parent as WordList).Entries.Count + "までの整数で指定して下さい。";
                //case WlLanguage.简体中文:
                //    return "页面必须是1到" + (WlUtility.CurrentEntry.Parent as WordList).Entries.Count + "之间的整数。";
                //case WlLanguage.繁體中文:
                //    return "頁面必須是1到" + (WlUtility.CurrentEntry.Parent as WordList).Entries.Count + "之間的整數。";
                //case WlLanguage.Deutsch:
                //    return "Die Seite muss eine ganze Zahl von 1 bis " + (WlUtility.CurrentEntry.Parent as WordList).Entries.Count + " sein.";
                //case WlLanguage.Français:
                //    return "La page doit être un entier compris entre 1 et " + (WlUtility.CurrentEntry.Parent as WordList).Entries.Count;
                //case WlLanguage.한국어:
                //    return "페이지는 1에서 " + (WlUtility.CurrentEntry.Parent as WordList).Entries.Count + " 사이의 정수 여야합니다.";
                //case WlLanguage.русский:
                //    return "Страница должна быть целым числом от 1 до " + (WlUtility.CurrentEntry.Parent as WordList).Entries.Count;
                //case WlLanguage.इंडिया:
                //    return string.Empty;
                //case WlLanguage.None:
                //    return string.Empty;
                default:
                    return string.Empty;
            }
        }


        public static IReadOnlyDictionary<WlLanguage, string> Memo { get; } = new Dictionary<WlLanguage, string>()
            {
                {WlLanguage.日本語,"メモ"},
                {WlLanguage.English,"Memo"},
                {WlLanguage.繁體中文,"備忘錄"},
                {WlLanguage.简体中文,"备忘录"},
                {WlLanguage.Deutsch,"Memo"},
                {WlLanguage.Français,"Note"},
                {WlLanguage.한국어,"메모"},
                {WlLanguage.русский,"напоминание"}
            };


        public static IReadOnlyDictionary<WlLanguage, string[]> BackUp { get; } = new Dictionary<WlLanguage, string[]>()
            {
                {WlLanguage.日本語,new string[]{"バックアップの作成","バックアップから復元" + System.Environment.NewLine + "場所:" + System.Environment.NewLine } },
                {WlLanguage.English,new string[]{"Create backup","Recover from backup" + System.Environment.NewLine + "locate:" + System.Environment.NewLine } },
                {WlLanguage.繁體中文,new string[]{ "創建備份", "從備份中恢復" + System.Environment.NewLine + "定位:" + System.Environment.NewLine } },
                {WlLanguage.简体中文,new string[]{ "创建备份", "从备份中恢复" + System.Environment.NewLine + "定位:" + System.Environment.NewLine } },
                {WlLanguage.Deutsch,new string[]{ "Ein Backup erstellen", "Vom Backup wiederherstellen" + System.Environment.NewLine + "Lokalisieren:" + System.Environment.NewLine } },
                {WlLanguage.Français,new string[]{"Create backup","バックアップから復元" + System.Environment.NewLine + "場所:" + System.Environment.NewLine } },
                {WlLanguage.한국어,new string[]{"Create backup","バックアップから復元" + System.Environment.NewLine + "場所:" + System.Environment.NewLine } },
                {WlLanguage.русский,new string[]{"Create backup","バックアップから復元" + System.Environment.NewLine + "場所:" + System.Environment.NewLine } },
                {WlLanguage.इंडिया,new string[]{ }}
            };

        public static IReadOnlyDictionary<WlLanguage, string[]> BU_And_RC { get; } = new Dictionary<WlLanguage, string[]>()
            {
                {WlLanguage.日本語,new string[]{"現在登録されている単語帳から" +System.Environment.NewLine + "バックアップを作成します。" + System.Environment.NewLine + "宜しいですか？","バックアップから単語帳を復元し、"+ System.Environment.NewLine + "現在の単語帳に統合します。" + System.Environment.NewLine + "宜しいですか？"}},
                {WlLanguage.English,new string[]{"Create a backup from" +System.Environment.NewLine + "the currently registered word book." + System.Environment.NewLine + "Are you sure？", "Restore word book from backup," + System.Environment.NewLine + "And merge into the current word book." + System.Environment.NewLine + "Are you sure？"}},
                {WlLanguage.繁體中文,new string[]{ "從當前註冊的單詞簿創建備份。" + System.Environment.NewLine + "你確定嗎？", "從備份中恢復單詞簿，" + System.Environment.NewLine + "並合併到當前的單詞簿。" + System.Environment.NewLine + "你確定嗎？"}},
                {WlLanguage.简体中文,new string[]{ "从当前注册的单词簿创建备份。" + System.Environment.NewLine + "你确定吗？", "从备份中恢复单词簿，" + System.Environment.NewLine + "并合并到当前的单词簿。" + System.Environment.NewLine + "你确定吗？"}},
                {WlLanguage.Deutsch,new string[]{ "Erstellen Sie eine Sicherung"  + System.Environment.NewLine + "aus dem aktuell registrierten Word-Buch." + System.Environment.NewLine + "Bist du sicher?", "Wordbook aus einem Backup wiederherstellen," + System.Environment.NewLine + "und verschmelzen mit dem aktuellen Wortbuch." + System.Environment.NewLine + "Bist du sicher?"}},
                {WlLanguage.Français,new string[]{ "Créez une sauvegarde à partir " + System.Environment.NewLine + "du livre de mots actuellement enregistré." + System.Environment.NewLine + "Êtes-vous sûr?", "Restaurer le livre de mots à partir d'une sauvegarde," + System.Environment.NewLine + "et fusionner dans le dictionnaire de mots actuel." + System.Environment.NewLine + "Êtes-vous sûr?"}},
                {WlLanguage.한국어,new string[]{ "현재 등록 된 단어장에서 백업을 만듭니다." + System.Environment.NewLine + "확실해?", "백업에서 단어장 복원," + System.Environment.NewLine + "현재 단어장에 병합합니다." + System.Environment.NewLine + "확실해?"}},
                {WlLanguage.русский,new string[]{ "Создайте резервную копию из " + System.Environment.NewLine + "текущей зарегистрированной книги слов." + System.Environment.NewLine + "Уверены ли вы?", "Восстановить книгу слов из резервной копии," + System.Environment.NewLine + "и влиться в текущую книгу слов." + System.Environment.NewLine + "Уверены ли вы?"}},
                {WlLanguage.इंडिया,new string[]{ }}
            };

        public static IReadOnlyDictionary<WlLanguage, string> RegisterWordListConfirm { get; } = new Dictionary<WlLanguage, string>()
            {
                {WlLanguage.日本語,"以下の単語帳を追加します。宜しいですか？"},
                {WlLanguage.English,"Add these word books. Are you sure?"},
                {WlLanguage.繁體中文,"添加這些單詞書。你確定嗎？"},
                {WlLanguage.简体中文,"添加这些单词书。你确定吗？"},
                {WlLanguage.Deutsch,"Fügen Sie diese Wortbücher hinzu. Bist du sicher?"},
                {WlLanguage.Français,"Ajoutez ces livres de mots. Êtes-vous sûr?"},
                {WlLanguage.한국어,"이 단어장을 추가하십시오. 확실해?"},
                {WlLanguage.русский,"Добавьте эти слова книги. Уверены ли вы?"},
                {WlLanguage.इंडिया,""}
            };

        public static IReadOnlyDictionary<WlLanguage, string> SelectPlace { get; } = new Dictionary<WlLanguage, string>()
            {
                {WlLanguage.日本語,"追加先を選択して下さい。" },
                {WlLanguage.English,"Please select a destination folder." },
                {WlLanguage.繁體中文,"請選擇目標文件夾。" },
                {WlLanguage.简体中文,"请选择目标文件夹。" },
                {WlLanguage.Deutsch,"Bitte wählen Sie einen Zielordner." },
                {WlLanguage.Français,"Veuillez sélectionner un dossier de destination." },
                {WlLanguage.한국어,"대상 폴더를 선택하십시오." },
                {WlLanguage.русский,"Пожалуйста, выберите папку назначения." },
                {WlLanguage.इंडिया,""}
            };
        public static IReadOnlyDictionary<WlLanguage, string> Add { get; } = new Dictionary<WlLanguage, string>()
            {
                {WlLanguage.日本語,"追加"},
                {WlLanguage.English,"Add"},
                {WlLanguage.繁體中文,"加"},
                {WlLanguage.简体中文,"加"},
                {WlLanguage.Deutsch,"hinzufügen"},
                {WlLanguage.Français,"ajouter"},
                {WlLanguage.한국어,"더하다"},
                {WlLanguage.русский,"добавлять"},
                {WlLanguage.इंडिया,""}
            };
        public static IReadOnlyDictionary<WlLanguage, string> AddComplete { get; } = new Dictionary<WlLanguage, string>()
            {
                {WlLanguage.日本語,"追加されました。"},
                {WlLanguage.English,"Addition was completed."},
                {WlLanguage.繁體中文,"增加完成了"},
                {WlLanguage.简体中文,"增加完成了"},
                {WlLanguage.Deutsch,"Die Zugabe wurde abgeschlossen"},
                {WlLanguage.Français,"L'addition a été complétée"},
                {WlLanguage.한국어,"추가가 완료되었습니다."},
                {WlLanguage.русский,"Дополнение было завершено"},
                {WlLanguage.इंडिया,""}
            };
        public static IReadOnlyDictionary<WlLanguage, string> CreateBackupComplete { get; } = new Dictionary<WlLanguage, string>()
            {
                {WlLanguage.日本語,"バックアップの作成に成功しました。"},
                {WlLanguage.English,"Creating a backup was completed."},
                {WlLanguage.繁體中文,"創建備份已完成。"},
                {WlLanguage.简体中文,"创建备份已完成。"},
                {WlLanguage.Deutsch,"Das Erstellen eines Backups wurde abgeschlossen."},
                {WlLanguage.Français,"la création d'une sauvegarde était terminée."},
                {WlLanguage.한국어,"백업 작성이 완료되었습니다."},
                {WlLanguage.русский,"создание резервной копии было завершено."},
                {WlLanguage.इंडिया,""}
            };
        public static IReadOnlyDictionary<WlLanguage, string> Error { get; } = new Dictionary<WlLanguage, string>()
            {
                {WlLanguage.日本語,"エラー"},
                {WlLanguage.English,"Error"},
                {WlLanguage.繁體中文,"錯誤"},
                {WlLanguage.简体中文,"错误"},
                {WlLanguage.Deutsch,"Error"},
                {WlLanguage.Français,"Erreur"},
                {WlLanguage.한국어,"오류"},
                {WlLanguage.русский,"ошибка"},
                {WlLanguage.इंडिया,""}
            };
        public static IReadOnlyDictionary<WlLanguage, string> RequireStorageAccess { get; } = new Dictionary<WlLanguage, string>()
            {
                {WlLanguage.日本語,"復元に失敗しました。\nストレージへのアクセスを許可して下さい。"},
                {WlLanguage.English,"Failed to restore.\nPlease Allow access to storage."},
                {WlLanguage.繁體中文,"無法恢復。\n請允許訪問存儲空間。"},
                {WlLanguage.简体中文,"无法恢复。\n请允许访问存储空间。"},
                {WlLanguage.Deutsch,"Wiederherstellung fehlgeschlagen\nBitte erlauben Sie den Zugriff auf Speicher."},
                {WlLanguage.Français,"Échec de la restauration.\nVeuillez autoriser l'accès au stockage."},
                {WlLanguage.한국어,"복원하지 못했습니다.\n저장소에 대한 액세스를 허용하십시오."},
                {WlLanguage.русский,"Не удалось восстановить.\nПожалуйста, разрешите доступ к хранилищу."},
                {WlLanguage.इंडिया,""}
            };
        public static IReadOnlyDictionary<WlLanguage, string> CreateBackupFailure { get; } = new Dictionary<WlLanguage, string>()
            {
                {WlLanguage.日本語,"バックアップの作成に失敗しました。"},
                {WlLanguage.English,"Failed to create backup."},
                {WlLanguage.繁體中文,"無法創建備份。"},
                {WlLanguage.简体中文,"无法创建备份。"},
                {WlLanguage.Deutsch,"Sicherung konnte nicht erstellt werden"},
                {WlLanguage.Français,"Échec de la création de la sauvegarde."},
                {WlLanguage.한국어,"백업을 만들지 못했습니다."},
                {WlLanguage.русский,"Не удалось создать резервную копию."},
                {WlLanguage.इंडिया,""}
            };
        public static IReadOnlyDictionary<WlLanguage, string> RestoreCompletedTooManyFolder { get; } = new Dictionary<WlLanguage, string>()
            {
                {WlLanguage.日本語,"復元に成功しました。(フォルダ数が多いため、一部のみ復元しました。)"},
                {WlLanguage.English,"Restoration was successful. (Since there were many folders, only a part was restored.)"},
                {WlLanguage.繁體中文,"恢復成功。 （由於存在許多文件夾，因此只恢復了一部分。）"},
                {WlLanguage.简体中文,"恢复成功。 （由于存在许多文件夹，因此只恢复了一部分。）"},
                {WlLanguage.Deutsch,"Wiederherstellen war erfolgreich. (Nur ein Teil wurde wiederhergestellt, da viele Ordner vorhanden sind.)"},
                {WlLanguage.Français,"la restauration a réussi. (Seule une partie a été restaurée car il y a beaucoup de dossiers.)"},
                {WlLanguage.한국어,"복원이 성공했습니다. 폴더가 많기 때문에 부품 만 복원되었습니다."},
                {WlLanguage.русский,"восстановление прошло успешно. (Только часть была восстановлена, потому что есть много папок.)"},
                {WlLanguage.इंडिया,""}
            };
        public static IReadOnlyDictionary<WlLanguage, string> RestoreCompleted { get; } = new Dictionary<WlLanguage, string>()
            {
                {WlLanguage.日本語,"復元に成功しました。"},
                {WlLanguage.English,"Restoration was successful."},
                {WlLanguage.繁體中文,"恢復成功。"},
                {WlLanguage.简体中文,"恢复成功。"},
                {WlLanguage.Deutsch,"Wiederherstellen war erfolgreich."},
                {WlLanguage.Français,"la restauration a réussi."},
                {WlLanguage.한국어,"복원이 성공했습니다."},
                {WlLanguage.русский,"восстановление прошло успешно."},
                {WlLanguage.इंडिया,""}

            };
        public static IReadOnlyDictionary<WlLanguage, string> RestoreFaliure { get; } = new Dictionary<WlLanguage, string>()
            {
                {WlLanguage.日本語,"復元中にエラーが発生しました。バックアップが壊れています。"},
                {WlLanguage.English,"An error occurred during restore. Backup is broken."},
                {WlLanguage.繁體中文,"還原期間發生錯誤。備份被破壞了。"},
                {WlLanguage.简体中文,"还原期间发生错误。备份被破坏了。"},
                {WlLanguage.Deutsch,"Bei der Wiederherstellung ist ein Fehler aufgetreten. Sicherung ist defekt"},
                {WlLanguage.Français,"Une erreur s'est produite lors de la restauration. La sauvegarde est cassée."},
                {WlLanguage.한국어,"복원 중 오류가 발생했습니다. 백업이 끊어졌습니다."},
                {WlLanguage.русский,"Произошла ошибка во время восстановления. Бэкап сломан."},
                {WlLanguage.इंडिया,""}
            };
        public static IReadOnlyDictionary<WlLanguage, string> NoneOfBackup { get; } = new Dictionary<WlLanguage, string>()
            {
                {WlLanguage.日本語,"バックアップが存在しません。"},
                {WlLanguage.English,"Backup does not exist."},
                {WlLanguage.繁體中文,"備份不存在。"},
                {WlLanguage.简体中文,"备份不存在。"},
                {WlLanguage.Deutsch,"Backup existiert nicht."},
                {WlLanguage.Français,"La sauvegarde n'existe pas."},
                {WlLanguage.한국어,"백업이 존재하지 않습니다."},
                {WlLanguage.русский,"Резервная копия не существует."},
                {WlLanguage.इंडिया,""}
            };


        public static IReadOnlyDictionary<WlLanguage, string> IntegrationConfirm { get; } = new Dictionary<WlLanguage, string>()
            {
                {WlLanguage.日本語,"選択した単語帳を一つの単語帳に統合します。" + System.Environment.NewLine + "宜しいですか？" },
                {WlLanguage.English,"Merge selected wordlists into one wordlist." + System.Environment.NewLine + "Is it OK?"},
                {WlLanguage.繁體中文,"將選定的單詞列表合併為一個單詞表。" + System.Environment.NewLine + "可以嗎？"},
                {WlLanguage.简体中文,"将选定的单词列表合并为一个单词表。" + System.Environment.NewLine + "可以吗？"},
                {WlLanguage.Deutsch,"Ausgewählte Wortlisten in einer Wortliste zusammenführen." + System.Environment.NewLine + "Ist es o.k?"},
                {WlLanguage.Français,"Fusionnez les listes de mots sélectionnées en une seule." + System.Environment.NewLine + "Est-ce que c'est bon?"},
                {WlLanguage.한국어,"선택한 단어 목록을 하나의 단어 목록으로 병합합니다." + System.Environment.NewLine + "괜찮습니까?"},
                {WlLanguage.русский,"Объединить выбранные списки слов в один список слов." + System.Environment.NewLine + "Это нормально?"},
                {WlLanguage.इंडिया,""}
            };
        public static IReadOnlyDictionary<WlLanguage, string> SetWordListName { get; } = new Dictionary<WlLanguage, string>()
            {
                {WlLanguage.日本語,"単語帳名を入力して下さい。" },
                {WlLanguage.English,"Please set name of wordlist." },
                {WlLanguage.繁體中文,"請設置詞彙書的名稱。" },
                {WlLanguage.简体中文,"请设置词汇书的名称。" },
                {WlLanguage.Deutsch,"Bitte geben Sie den Namen des Vokabulars an." },
                {WlLanguage.Français,"Veuillez indiquer le nom du vocabulaire." },
                {WlLanguage.한국어,"어휘집의 이름을 정하십시오." },
                {WlLanguage.русский,"Пожалуйста, укажите название словарного запаса." },
                {WlLanguage.इंडिया,""}
             };

        public static IReadOnlyDictionary<WlLanguage, string> NoMatchedWord { get; } = new Dictionary<WlLanguage, string>()
            {
                {WlLanguage.日本語,"条件を満たす単語が存在しません。"},
                {WlLanguage.English,"Matched words does not exist."},
                {WlLanguage.繁體中文,"匹配的單詞不存在。"},
                {WlLanguage.简体中文,"匹配的单词不存在。"},
                {WlLanguage.Deutsch,"passende Wörter gibt es nicht."},
                {WlLanguage.Français,"les mots correspondants n'existent pas."},
                {WlLanguage.한국어,"일치하는 단어가 존재하지 않습니다." },
                {WlLanguage.русский,"совпавших слов не существует." },
                {WlLanguage.इंडिया,""}
            };

        public static IReadOnlyDictionary<WlLanguage, string> MoveValidate { get; } = new Dictionary<WlLanguage, string>()
            {
                {WlLanguage.日本語,"移動先が現在位置と同じです。"},
                {WlLanguage.English,"The destination is the same as the current position"},
                {WlLanguage.繁體中文,"目的地與當前位置相同"},
                {WlLanguage.简体中文,"目的地与当前位置相同"},
                {WlLanguage.Deutsch,"Das Ziel entspricht der aktuellen Position"},
                {WlLanguage.Français,"La destination est la même que la position actuelle."},
                {WlLanguage.한국어,"목적지는 현재 위치와 같습니다." },
                {WlLanguage.русский,"Пункт назначения совпадает с текущей позицией." },
                {WlLanguage.इंडिया,""}
            };
        public static IReadOnlyDictionary<WlLanguage, string> Move { get; } = new Dictionary<WlLanguage, string>()
            {
                {WlLanguage.日本語,"移動されました。"},
                {WlLanguage.English,"Move is completed."},
                {WlLanguage.繁體中文,"移動完成。"},
                {WlLanguage.简体中文,"移动完成。"},
                {WlLanguage.Deutsch,"Der Umzug ist abgeschlossen."},
                {WlLanguage.Français,"Le déménagement est terminé."},
                {WlLanguage.한국어,"이동이 완료되었습니다." },
                {WlLanguage.русский,"Перемещение завершено." },
                {WlLanguage.इंडिया,""}
            };

        public static IReadOnlyDictionary<WlLanguage, string> EnterWord { get; } = new Dictionary<WlLanguage, string>()
            {
                {WlLanguage.日本語,"単語を入力してください"},
                {WlLanguage.English,"Please Enter words."},
                {WlLanguage.繁體中文,"請輸入單詞"},
                {WlLanguage.简体中文,"请输入单词"},
                {WlLanguage.Deutsch,"Bitte geben Sie Wörter ein"},
                {WlLanguage.Français,"S'il vous plaît entrer des mots"},
                {WlLanguage.한국어,"단어를 입력하십시오."},
                {WlLanguage.русский,"Пожалуйста, введите слова"},
                {WlLanguage.इंडिया,"कृपया शब्द दर्ज करें"}
            };
    }
}
