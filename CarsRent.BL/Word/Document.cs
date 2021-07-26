using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;

namespace CarsRent.BL.Word
{
    public class Document
    {
        private FileInfo _documentInfo;

        public Document(FileMode mode, string path)
        {
            if (mode == FileMode.Open && File.Exists(path) == false)
                throw new Exception("Не удалось открыть файл. Файла не существует.");

            _documentInfo = new FileInfo(path);
        }

        public void Replace(Dictionary<string, string> replaceWords)
        {
            var app = new Application();
            object file = _documentInfo.FullName;

            app.Documents.Open(file);

            foreach (var word in replaceWords)
            {
                app.Selection.Find.ClearFormatting();
                app.Selection.Find.Replacement.ClearFormatting();

                app.Selection.Find.Execute(FindText: word.Key,
                    MatchCase: false,
                    MatchWholeWord: false,
                    MatchWildcards: false,
                    MatchSoundsLike: Type.Missing,
                    MatchAllWordForms: false,
                    Forward: true,
                    Wrap: WdFindWrap.wdFindContinue,
                    Format: false,
                    ReplaceWith: word.Value,
                    Replace: WdReplace.wdReplaceAll); 
            }

            app.ActiveDocument.Save();
            app.ActiveDocument.Close();
            app.Quit();
        }
    }
}