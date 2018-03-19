using System;
using System.Collections.Generic;

namespace VocabularyTrainer
{
    /// <summary>
    /// Process the lesson file, validate the answers, store back results
    /// </summary>
    class LessonController
    {
        /// <summary>
        /// Class variables
        /// </summary>
        List<LessonModel> statements;
        int totalCount = 0, correctCount = 0;

        /// <summary>
        /// Check the count of word pairs pending to be marked as passed
        /// </summary>
        private void PreLesson()
        {
            foreach (LessonModel lessonLine in statements)
            {
                //Count=4 for a word pair means passed
                if (lessonLine.Counter < Constants.Threshold)
                    totalCount++;
            }
            if (totalCount != 0)
            {
                Console.WriteLine(Constants.strTrngText);
                Console.WriteLine(String.Format(Constants.strTransText, Constants.strAnswerLang));
            }
        }

        /// <summary>
        /// Input values from user and compare with actual answers
        /// </summary>
        private void ProcessLesson()
        {
            String userInput;
            try
            {
                foreach (LessonModel lessonLine in statements)
                {
                    //Fetch word pairs which are not passed yet
                    if (lessonLine.Counter < Constants.Threshold)
                    {
                        Console.WriteLine(Constants.strQuestionLang + Constants.strColon + " " + lessonLine.QuestionLangWord.Trim());
                        Console.Write(Constants.strAnswerLang + Constants.strColon + " ");
                        Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), Constants.InputColor);
                        userInput = Console.ReadLine();
                        Console.ResetColor();
                        //Input comparison
                        if (userInput.Trim().Equals(lessonLine.AnswerLangWord.Trim(), StringComparison.OrdinalIgnoreCase))
                        {
                            //Increement counter
                            lessonLine.Counter++;
                            correctCount++;
                            Console.WriteLine(Constants.strCorrect);
                        }
                        else
                        {
                            //Decreement counter
                            lessonLine.Counter--;
                            Console.WriteLine(Constants.strWrong + Constants.strPeriod + " " +
                                Constants.strCorrect + " " + Constants.strIs + Constants.strColon + " " +
                                lessonLine.AnswerLangWord.Trim());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Check the total, correct and wrong answers
        /// </summary>
        private void PostLesson()
        {
            if (totalCount == 0)
            {
                //All word pairs passed and lesson is complete
                Console.WriteLine(Constants.strSuccessText);
            }
            else
            {
                Console.WriteLine(Constants.strTotal + Constants.strColon + " " + totalCount +
                    Constants.strComma + " " + Constants.strCorrect + Constants.strColon + " " + correctCount +
                    Constants.strComma + " " + Constants.strWrong + Constants.strColon + " " + (totalCount - correctCount));
            }
        }

        /// <summary>
        /// Calls read, validate and write operations for lesson
        /// </summary>
        internal void LearnLesson()
        {
            try
            {
                statements = LessonIO.ReadLessonFile();
                PreLesson();
                //If word pairs are pending to be passed
                if (totalCount != 0 && statements != null)
                {
                    ProcessLesson();
                }
                PostLesson();
                if (totalCount != 0 && statements != null)
                {
                    LessonIO.WriteLessonFile(statements);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
