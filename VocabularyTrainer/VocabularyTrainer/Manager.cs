using System;

namespace VocabularyTrainer
{
    /// <summary>
    /// Common manager class for future operations
    /// </summary>
    class Manager
    {
        /// <summary>
        /// Entry point for vocabulary learning exercise
        /// </summary>
        /// <param name="args">default</param>
        static void Main(string[] args)
        {
            try
            {
                //Invoke LessonController for vocabulary learning
                LessonController lessonTest = new LessonController();
                if (lessonTest != null)
                {
                    lessonTest.LearnLesson();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
