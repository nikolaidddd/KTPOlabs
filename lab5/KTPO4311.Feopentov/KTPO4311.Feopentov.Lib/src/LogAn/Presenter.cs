using System;
using System.Collections.Generic;
using System.Text;

namespace KTPO4311.Feopentov.Lib.src.LogAn
{
    public class Presenter
    {
        ILogAnalyze logAnalyzer = null;
        IView view = null;
        
        public Presenter(ILogAnalyze logAnalyzer,IView view)
        {
            this.logAnalyzer = logAnalyzer;
            this.view = view;
            logAnalyzer.Analyzed += OnLogAnalyzed;
        }
        private void OnLogAnalyzed()
        {
            view.Render("Обработка завершена");
        }
    }

}
