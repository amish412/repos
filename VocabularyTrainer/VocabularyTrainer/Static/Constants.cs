using System;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Resources;

namespace VocabularyTrainer
{
    /// <summary>
    /// Fetch readonly values from config, resource file
    /// </summary>
    static class Constants
    {
        /// <summary>
        /// Config file constants
        /// </summary>
        internal static readonly char Delimiter = ConfigurationManager.AppSettings["Delimiter"].First();
        internal static readonly int Threshold = Convert.ToInt32(ConfigurationManager.AppSettings["Threshold"]);        
        internal static readonly string InputColor =  ConfigurationManager.AppSettings["InputColor"];
        internal static readonly string LessonFile = ConfigurationManager.AppSettings["LessonFile"];
        internal static readonly string ResourceFileName = ConfigurationManager.AppSettings["ResourceFileName"];
        
        static readonly String[] assName = Assembly.GetExecutingAssembly().FullName.Split(',');
        static ResourceManager rm = new ResourceManager(assName[0] + "." + ResourceFileName, Assembly.GetExecutingAssembly());
    
        /// <summary>
        /// Resource file literals
        /// </summary>
        internal static readonly String strQuestionLang = rm.GetString("QuestionLang");
        internal static readonly String strAnswerLang = rm.GetString("AnswerLang");
        internal static readonly String strCorrect = rm.GetString("Correct");
        internal static readonly String strWrong = rm.GetString("Wrong");
        internal static readonly String strTotal = rm.GetString("Total");
        internal static readonly String strColon = rm.GetString("Colon");
        internal static readonly String strComma = rm.GetString("Comma");
        internal static readonly String strPeriod = rm.GetString("Period");
        internal static readonly String strIs = rm.GetString("Is");
        internal static readonly String strTrngText = rm.GetString("TrainingText");
        internal static readonly String strSuccessText = rm.GetString("SuccessfulText");
        internal static readonly String strTransText = rm.GetString("TranslationText");
    }
}
