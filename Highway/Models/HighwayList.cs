using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Win32;
using System.Windows;

namespace Highway.Models
{
    public class HighwayList
    {
        private List<HighWay> _highwaysList;
        public HighwayList()
        {
            _highwaysList = new List<HighWay>();
        }
        public int GetCurrentLength()
        { return _highwaysList.Count; }
        public bool ReadFile()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Filter = "Text files|*.txt*.*";
            fileDialog.DefaultExt = ".txt";
            Nullable<bool> dialogOk = fileDialog.ShowDialog();
            if (dialogOk == false) return false;
            
            if (new FileInfo(fileDialog.FileNames[0]).Length == 0)
                throw new IOException("Wrong file format, a file is empty");

            string line = "";
            string[] lineSplit;
            List<HighWay> beforeHighwayList = new List<HighWay>();
            string nameHighway = "";
            RoadType roadType = RoadType.state;
            uint roadLength;
            uint numberLanes;
            Availability banquette = Availability.unavailable;
            Availability roadSeparator = Availability.unavailable;
            uint currLine = 0;

            using (StreamReader reader = new StreamReader(fileDialog.FileNames[0]))
            {
                while (reader.Peek() >= 0)
                {
                    currLine++;
                    line = reader.ReadLine();
                    lineSplit = line.Split();
                    if(lineSplit.Length != 6)
                        throw new FormatException(String.Format($"Wrong file format, an error has occurred in line {currLine}"));
                    for (int i = 0; i < lineSplit.Length; ++i)
                        lineSplit[i] = String.Concat(lineSplit[i].Where(c => !Char.IsWhiteSpace(c)));
                    nameHighway = lineSplit[0];
                    if (!Enum.IsDefined(typeof(RoadType), lineSplit[1]))
                        throw new FormatException(String.Format($"Wrong file format, an error has occurred in line {currLine}"));
                    roadType = (RoadType)Enum.Parse(typeof(RoadType), lineSplit[1], true);
                    if (!uint.TryParse(lineSplit[2], out roadLength))
                        throw new FormatException(String.Format($"Wrong file format, an error has occurred in line {currLine}"));
                    if (!uint.TryParse(lineSplit[3], out numberLanes))
                        throw new FormatException(String.Format($"Wrong file format, an error has occurred in line {currLine}"));
                    if (!Enum.IsDefined(typeof(Availability), lineSplit[4]))
                        throw new FormatException(String.Format($"Wrong file format, an error has occurred in line {currLine}"));
                    banquette = (Availability)Enum.Parse(typeof(Availability), lineSplit[4], true);
                    if (!Enum.IsDefined(typeof(Availability), lineSplit[5]))
                        throw new FormatException(String.Format($"Wrong file format, an error has occurred in line {currLine}"));
                    roadSeparator = (Availability)Enum.Parse(typeof(Availability), lineSplit[5], true);
                    if(roadLength <= 0 || numberLanes <= 0 )
                        throw new FormatException(String.Format($"Wrong file format, an error has occurred in line {currLine}"));

                    beforeHighwayList.Add(new HighWay(nameHighway, roadType.ToString(), roadLength, numberLanes, banquette.ToString(), roadSeparator.ToString()));
                }
                _highwaysList = beforeHighwayList;
            }
            return true;
        }

        public bool WriteToFile()
        {
            if (ToString() == "")
                if (MessageBox.Show(
                    "The table is empty, are you sure to save it?",
                    "Saving the HigwayTable",
                    MessageBoxButton.OKCancel,
                    MessageBoxImage.Question) != MessageBoxResult.OK) return false;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files|*.txt";
            saveFileDialog.FileName = "HighwayTable";
            saveFileDialog.Title = "Save Road Table";
            if (saveFileDialog.ShowDialog() == true)
            {
                string path = saveFileDialog.FileName;
                using (FileStream fs = File.Create(path))
                {
                    Byte[] title = new System.Text.UTF8Encoding(true).GetBytes(ToString());
                    fs.Write(title, 0, title.Length);
                    return true;
                }
            }
            return false;
        }
        public HighWay this[int index]
        {
            get
            {
                if (index < 0 || index >= _highwaysList.Count)
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }
                return _highwaysList[index];
            }
        }
        public void Sort()
        {
            _highwaysList.Sort();
        }
        public HighwayList FindShortestRoadWithMostLanes()
        {
            if (GetCurrentLength() == 0) return null;
            HighwayList minHighways = new HighwayList();
            minHighways._highwaysList.Add(_highwaysList[0]);
            int countHighWays = _highwaysList.Count;
            if (countHighWays == 1) return minHighways;
            for (int i = 1; i < _highwaysList.Count; ++i)
            {
                if (minHighways[0].NumberLanes < _highwaysList[i].NumberLanes ||
                    (minHighways[0].NumberLanes == _highwaysList[i].NumberLanes &&
                    minHighways[0].RoadLength > _highwaysList[i].RoadLength))
                {
                    minHighways._highwaysList.Clear();
                    minHighways._highwaysList.Add(_highwaysList[i]);
                }
                if(minHighways[0].NumberLanes == _highwaysList[i].NumberLanes &&
                   minHighways[0].RoadLength == _highwaysList[i].RoadLength)
                {
                    minHighways._highwaysList.Add(_highwaysList[i]);
                }
            }
            return minHighways;
        }
        public Dictionary<RoadType, HighwayList> FindGroupedSeparatedRoadsMoreTwoLines()
        {
            Dictionary<RoadType, HighwayList> GroupedHighwayLists = new Dictionary<RoadType, HighwayList>();
            for (RoadType i = 0; i <= RoadType.local; ++i)
            {
                GroupedHighwayLists.Add(i, new HighwayList());
                for (int j = 0; j < _highwaysList.Count; ++j)
                    if (_highwaysList[j].RoadType == i &&
                        _highwaysList[j].RoadSeparator == Availability.available &&
                        _highwaysList[j].NumberLanes > 2)
                        GroupedHighwayLists[i]._highwaysList.Add(_highwaysList[j]);
            }
            return GroupedHighwayLists;
        }

        public HighwayList FindRegionalRoadsMostLanesCrosswalkAvailable()
        {
            HighwayList regionalRoadsList = new HighwayList();
            uint maxLanesCount = 0;
            for (int i = 0; i < _highwaysList.Count; ++i)
            {
                if (_highwaysList[i].RoadType == RoadType.regional &&
                    _highwaysList[i].Banquette == Availability.available)
                {
                    if (maxLanesCount < _highwaysList[i].NumberLanes)
                    {
                        maxLanesCount = _highwaysList[i].NumberLanes;
                        regionalRoadsList._highwaysList.Clear();
                    }
                    if (maxLanesCount == _highwaysList[i].NumberLanes)
                        regionalRoadsList._highwaysList.Add(_highwaysList[i]);
                }
            }
            return regionalRoadsList;
        }
        public override string ToString()
        {
            string print = "";
            for (int i = 0; i < _highwaysList.Count; ++i)
                print += String.Format($"{_highwaysList[i]}\n");
            return print;
        }

        public Dictionary<RoadType, HighwayList> FindAllRoadTypesWithFootpathsMaxLength()
        {
            Dictionary<RoadType, HighwayList> roadTypes = new Dictionary<RoadType, HighwayList>()
            {
                { RoadType.state, new HighwayList() },
                { RoadType.regional, new HighwayList() },
                { RoadType.areal, new HighwayList() },
                { RoadType.local, new HighwayList() }
            };
            uint maxLength = 0;
            for (int i = 0; i < _highwaysList.Count; ++i)
                if (_highwaysList[i].RoadSeparator == Availability.available)
                {
                    if (maxLength < _highwaysList[i].RoadLength)
                    {
                        maxLength = _highwaysList[i].RoadLength;
                        for (RoadType j = 0; j < RoadType.local; ++j)
                            if (_highwaysList[i].RoadType == j)
                                roadTypes[j]._highwaysList.Clear();
                    }
                    if (maxLength == _highwaysList[i].RoadLength)
                        for (RoadType j = 0; j < RoadType.local; ++j)
                            if (_highwaysList[i].RoadType == j)
                                roadTypes[j]._highwaysList.Add(_highwaysList[i]);
                }
            return roadTypes;
        }
        public void ClearList()
        {
            _highwaysList.Clear();
        }
    }
}
