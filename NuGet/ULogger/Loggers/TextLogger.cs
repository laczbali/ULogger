using System;
using System.Collections.Generic;
using ULogger.Types;
using System.IO;
using Newtonsoft.Json;

namespace ULogger.Loggers
{
    /// <summary>
    /// Log to TXT or JSON
    /// </summary>
    public class TextLogger : ILogger
    {
        private readonly List<string> _outputFiles = new List<string>();

        /// <summary>
        /// Set up a new TextLogger
        /// 
        /// Select where should it create a log.
        /// It can be an existing or a new file.
        /// The format can be .txt or .json
        /// </summary>
        /// <param name="outputFile"></param>
        public TextLogger(string outputFile)
        {
            InsertOutputFiles(new string[] { outputFile });
        }

        /// <summary>
        /// Set up a new TextLogger
        /// 
        /// Select where should it create a log.
        /// It can be an existing or a new file.
        /// The format can be .txt or .json
        /// 
        /// If multiple files are provided, the logs will get created in each.
        /// </summary>
        /// <param name="outputFiles"></param>
        /// <exception cref="ArgumentException"></exception>
        public TextLogger(string[] outputFiles)
        {
            if (outputFiles.Length == 0) { throw new ArgumentException("Must provide at least one output file"); }
            InsertOutputFiles(outputFiles);
        }

        /// <summary>
        /// Valiadtes each output file, before registering it
        /// </summary>
        /// <param name="outputFiles"></param>
        /// <exception cref="ArgumentException"></exception>
        private void InsertOutputFiles(string[] outputFiles)
        {
            foreach (var filePath in outputFiles)
            {
                try
                {
                    if (!File.Exists(filePath))
                    {
                        // if the file does not exists, check that we can create it
                        var fileInfo = new FileInfo(filePath);
                        var dirPath = fileInfo.DirectoryName;
                        if (!Directory.Exists(dirPath))
                        {
                            Directory.CreateDirectory(dirPath);
                        }
                    }

                    // check if we can write to it
                    using (StreamWriter writer = new StreamWriter(filePath, true)) { }

                    // file path is valid
                    _outputFiles.Add(filePath);
                }
                catch (Exception)
                {
                    throw new ArgumentException($"Failed to validate [ {filePath} ]");
                }
            }
        }

        /// <summary>
        /// Logs the message to each file
        /// </summary>
        /// <param name="message"></param>
        /// <param name="level"></param>
        void ILogger.Log(string message, LogLevel level)
        {
            foreach (var of in _outputFiles)
            {
                LogToFile(of, message, level);
            }
        }

        /// <summary>
        /// Creates a log in a file
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="message"></param>
        /// <param name="level"></param>
        private void LogToFile(string filePath, string message, LogLevel level)
        {
            var fileInf = new FileInfo(filePath);
            var logObject = new LogObject { creationDate = DateTime.Now, message = message, level = level };
            switch (fileInf.Extension.ToLower())
            {
                case ".json":
                    LogToJson(filePath, logObject);
                    break;

                default:
                    // treat as TXT
                    LogToText(filePath, logObject);
                    break;
            }
        }

        /// <summary>
        /// Creates a JSON log: [ {..}, {..}, .. ]
        /// 
        /// As it needs to load the whole log to append it, this is less performant then the TXT log.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="logObject"></param>
        private void LogToJson(string filePath, LogObject logObject)
        {
            var rawFileData = File.ReadAllText(filePath);
            if (rawFileData == "") { rawFileData = "[]"; }
            var fileData = JsonConvert.DeserializeObject<List<LogObject>>(rawFileData);

            fileData.Add(logObject);
            var outText = JsonConvert.SerializeObject(fileData);

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(outText);
            }
        }

        /// <summary>
        /// Creates a TXT log
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="logObject"></param>
        private void LogToText(string filePath, LogObject logObject)
        {
            var outtext = "----------------------------------";
            outtext += $"\nCreated at: {logObject.creationDate.ToString()}";
            outtext += $"\nLevel:      {logObject.level.ToString()}";
            outtext += $"\n\n{logObject.message}\n";

            using (StreamWriter writer = new StreamWriter(filePath, append: true))
            {
                writer.WriteLine(outtext);
            }
        }
    }
}
