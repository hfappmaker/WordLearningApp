using System;
using System.Collections.Generic;
using WordLearning.Language;

namespace WordLearning.Messages
{
    public static class WlMessage
    {
        public static IReadOnlyDictionary<WlLanguage, string> ChangeThemeColor { get; } = new Dictionary<WlLanguage, string>()
            {
                {WlLanguage.日本語,"テーマからの変更"},
                {WlLanguage.English,"Change theme color"},
                {WlLanguage.繁體中文,""},
                {WlLanguage.简体中文,""},
                {WlLanguage.Deutsch,""},
                {WlLanguage.Français,""},
                {WlLanguage.한국어,""},
                {WlLanguage.русский,""},
                {WlLanguage.इंडिया,""}
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
