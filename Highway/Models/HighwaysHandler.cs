using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Windows;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Highway.Models
{
    public class HighwaysHandler
    {
        private List<HighWay> _highways;

        public HighWay this[int index]
        {
            get
            {
                if (index < 0 || index >= _highways.Count)
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }
                return _highways[index];
            }
        }
        public HighwaysHandler()
        {
            _highways = new List<HighWay>();
        }
        public HighwaysHandler(string filePath)
        {
            _highways = new List<HighWay>();
            ReadFromFile(filePath);
        }
        public HighwaysHandler(HighwaysHandler handler)
        {
            _highways = handler._highways.ToList();
        }
        public void ReadFromFile(string filePath)
        {
            if (String.IsNullOrWhiteSpace(filePath))
            {
                throw new ArgumentException("String is null or whitespace.", nameof(filePath));
            }
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File not found.", filePath);
            }

            FileInfo fileInfo = new FileInfo(filePath);
            if (String.CompareOrdinal(fileInfo.Extension, ".txt") != 0 &&
                String.CompareOrdinal(fileInfo.Extension, ".json") != 0)
            {
                throw new NotSupportedException("Only *.txt and *.json files are supported.");
            }

            string file;
            using (StreamReader reader = new StreamReader(filePath))
            {
                file = reader.ReadToEnd();
            }
            if (String.CompareOrdinal(fileInfo.Extension, ".json") == 0)
            {
                ReadJson(file);
                return;
            }
            /*string[] lines = null;
            using (StreamReader reader = new(filePath))
            {
                lines = reader.ReadToEnd().Split("\n", StringSplitOptions.RemoveEmptyEntries);
            }*/
            throw new NotImplementedException();

        }
        private void ReadJson(string json)
        {
            JObject jObject = JObject.Parse(json);
            JToken shapesJToken = jObject["Highways"] ?? throw new FormatException("Json file must contain attribute \"Highways\"");
            foreach (JToken shapeJToken in shapesJToken)
            {
                JToken typeJT = shapeJToken["Type"] ?? throw new FormatException("Each token must contain attribute \"Type\".");
                HighWay highway = shapeJToken.ToObject<HighWay>();
                _highways.Add(highway ?? throw new Exception("Failed to parse shape from JSON."));
            }
        }

        public void AddHighway(HighWay highway)
        {
            if (highway == null)
            {
                throw new ArgumentNullException(nameof(highway), "Parameter is null.");
            }
            _highways.Add(highway);
        }
    }
}
