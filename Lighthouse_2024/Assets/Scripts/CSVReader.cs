using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

/// <summary>
/// Reads data from a Comma-Seperated Value (.csv) representation of a Excel Spreadsheet.
/// Sourced from https://pastebin.com/7XCA2UDD.
/// </summary>
public class CSVReader
{
    static string SPLIT_RE = @",(?=(?:[^""]*""[^""]*"")*(?![^""]*""))";
    static string LINE_SPLIT_RE = @"\r\n|\n\r|\n|\r";
    static char[] TRIM_CHARS = { '\"' };
 
    /// <summary>
    /// Reads a .csv file given the fileName, and returns a List representation of the data.
    /// </summary>
    /// <param name="fileName">the name of the file in \Resources</param>
    /// <returns> A list of a length equal to the number of .csv's rows - 1, 
    /// with a Dictionary relating the String in the header row of the .csv's to the data within that column</returns>
    public static List<Dictionary<string, object>> Read(string fileName)
    {
        var list = new List<Dictionary<string, object>>();
        TextAsset data = Resources.Load(fileName) as TextAsset;
 
        var lines = Regex.Split(data.text, LINE_SPLIT_RE);
 
        if (lines.Length <= 1) return list;
 
        var header = Regex.Split(lines[0], SPLIT_RE);
        for (var i = 1; i < lines.Length; i++)
        {
 
            var values = Regex.Split(lines[i], SPLIT_RE);
            if (values.Length == 0 || values[0] == "") continue;
 
            var entry = new Dictionary<string, object>();
            for (var j = 0; j < header.Length && j < values.Length; j++)
            {
                string value = values[j];
                value = value.TrimStart(TRIM_CHARS).TrimEnd(TRIM_CHARS).Replace("\\", "");
                object finalvalue = value;
                int n;
                float f;
                if (int.TryParse(value, out n))
                {
                    finalvalue = n;
                }
                else if (float.TryParse(value, out f))
                {
                    finalvalue = f;
                }
                entry[header[j]] = finalvalue;
            }
            list.Add(entry);
        }
        return list;
    }

}