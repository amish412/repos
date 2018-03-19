using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace VocabularyTrainer
{
    /// <summary>
    /// Perform lesson file I/O operations
    /// </summary>
    static class LessonIO
    {
        static string[] fileHeader;

        /// <summary>
        /// Read contents of lesson file as List
        /// </summary>
        /// <returns>List of Type - LessonModel</returns>
        static internal List<LessonModel> ReadLessonFile()
        {
            try
            {
                    //Read single line header
                    fileHeader = File.ReadLines(Constants.LessonFile)
                                                    .Where(emptyLine => emptyLine != "")//Skip Blank lines
                                                    .Take(1)//Take first row
                                                    .ToArray();
                    //Read rest of the lines excluding header as List<LessonModel>
                    return File.ReadAllLines(Constants.LessonFile)
                                                   .Where(emptyLine => emptyLine != "")
                                                   .Skip(1)//Skip Header
                                                   .Select(line => new LessonModel(line))
                                                   .ToList();               
            }
            //Specific exception
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }            
            //Generic exception
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        /// <summary>
        /// Write contents of List to Lesson file
        /// </summary>
        /// <param name="statements">List of Type - LessonModel</param>
        static internal void WriteLessonFile(List<LessonModel> statements)
        {
            StringBuilder fileContent = new StringBuilder();
            try
            {
                foreach (string data in fileHeader)
                {
                    //Append header data items converted from array to string
                    fileContent.Append(data.Trim().Replace("\t",""));
                }
                foreach (LessonModel lessonLine in statements)
                {
                    //Append rest of the lines data items
                    fileContent.AppendLine();
                    fileContent.Append(string.Concat(lessonLine.AnswerLangWord.Trim(), ";"));
                    fileContent.Append(string.Concat(lessonLine.QuestionLangWord.Trim(), ";"));
                    fileContent.Append(lessonLine.Counter);
                }
                //Update the lesson file with counts of correct/wrong answers 
                File.WriteAllText(Constants.LessonFile, fileContent.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
