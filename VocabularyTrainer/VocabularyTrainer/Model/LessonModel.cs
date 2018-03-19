using System;

namespace VocabularyTrainer
{
    /// <summary>
    /// Model defning the fields of lesson files
    /// </summary>
    class LessonModel
    {
        /// <summary>
        /// Properties for inividual fields in lesson file
        /// </summary>
        internal string QuestionLangWord { get; }//Read-only
        internal string AnswerLangWord { get; }//Read-only
        internal int Counter { get; set; }

        /// <summary>
        /// Constructor initialization 
        /// </summary>
        /// <param name="line">Every single line in file</param>
        internal LessonModel(string line)
        {
                var words = line.Split(Constants.Delimiter);
                AnswerLangWord = words[0];
                QuestionLangWord = words[1];
                Counter = Convert.ToInt32(words[2]);
        }
    }
}
