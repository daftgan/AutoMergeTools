﻿using Microsoft.Build.Construction;
using Microsoft.Build.Evaluation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AutoMergeTools
{
    class AutoMergeUtilities
    {
        private static readonly List<string> SourceFilesToIgnore = new List<string>
        {
            "AssemblyInfo.cs"
        };

        static public void MergeSourceFile(string projectFilePath, string outputFilePath)
        {
            var filesToParse = GetSourceFileNames(projectFilePath);
            var namespaces = GetUniqueNamespaces(filesToParse);

            string outputSource = GenerateCombinedSource(namespaces, filesToParse);
            File.WriteAllText(outputFilePath, outputSource);
        }

        private static string GenerateCombinedSource(List<string> namespaces, List<string> files)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(@"/*");
            sb.AppendLine($" * File generated by SourceCombiner.exe using {files.Count} source files.");
            sb.AppendLine($" * Created On: {DateTime.Now}");
            sb.AppendLine(@"*/");

            foreach (var ns in namespaces.OrderBy(s => s))
            {
                sb.AppendLine("using " + ns + ";");
            }

            foreach (var file in files)
            {
                IEnumerable<string> sourceLines = File.ReadAllLines(file);
                sb.AppendLine(@"//*** SourceCombiner -> original file " + Path.GetFileName(file) + " ***");
                var openingTag = "using ";
                foreach (var sourceLine in sourceLines)
                {
                    var trimmedLine = sourceLine.Trim().Replace("  ", " ");
                    var isUsingDir = trimmedLine.StartsWith(openingTag) && trimmedLine.EndsWith(";");
                    if (!string.IsNullOrWhiteSpace(sourceLine) && !isUsingDir)
                    {
                        sb.AppendLine(sourceLine);
                    }
                }
            }

            return sb.ToString();
        }

        static private List<Project> projects;

        private static List<string> GetSourceFileNames(string solutionFilePath)
        {
            //List<string> files = new List<string>();
            //SolutionFile solutionFile = SolutionFile.Parse(solutionFilePath);
            //if (projects == null)
            //{
            //    projects = solutionFile.ProjectsInOrder.Select(p => new Project(p.AbsolutePath)).ToList();
            //}
            //foreach (Project project in projects)
            //{
            //    foreach (ProjectItem item in project.AllEvaluatedItems.Where(item => item.ItemType == "Compile"))
            //    {
            //        if (!SourceFilesToIgnore.Contains(Path.GetFileName(item.EvaluatedInclude)))
            //        {
            //            string projectFolder = Path.GetDirectoryName(project.FullPath);
            //            string fullpath = Path.Combine(projectFolder, item.EvaluatedInclude);
            //            files.Add(fullpath);
            //        }
            //    }
            //}
            
            string[] files = Directory.GetFiles(Path.GetDirectoryName(solutionFilePath), "*.cs", SearchOption.AllDirectories).Where(x => !x.Contains("\\obj\\")).ToArray();

            return files.ToList();
        }


        private static List<string> GetUniqueNamespaces(List<string> files)
        {
            var names = new List<string>();
            const string openingTag = "using ";
            const int namespaceStartIndex = 6;

            foreach (var file in files)
            {
                IEnumerable<string> sourceLines = null;
                bool bSucess = false;
                while (!bSucess)
                {
                    try
                    {
                        sourceLines = File.ReadAllLines(file);
                        bSucess = true;
                    }
                    catch (Exception exp)
                    {
                        Console.Error.WriteLine(exp.Message);
                        Thread.Sleep(500);
                    }
                }



                foreach (var sourceLine in sourceLines)
                {
                    var trimmedLine = sourceLine.Trim().Replace("  ", " ");
                    if (trimmedLine.StartsWith(openingTag) && trimmedLine.EndsWith(";"))
                    {
                        var name = trimmedLine.Substring(namespaceStartIndex, trimmedLine.Length - namespaceStartIndex - 1);

                        if (!names.Contains(name))
                        {
                            names.Add(name);
                        }
                    }
                }
            }

            return names;
        }
    }

}

