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
        private List<HighWay> _highwaysList; // current list of roads
        const int ROADDATACOUNT = 6; // amount of input data for each road
        public HighwayList() // create empty list
        {
            _highwaysList = new List<HighWay>();
        }
        public HighwayList(params HighWay[] highWay)
        {
            for (int i = 0; i < highWay.Length; ++i)
                _highwaysList.Add(highWay[i]);
        }
        public HighwayList(HighwayList highwayList) // create list and initialize it with given
        {
            if (highwayList._highwaysList != null) // if given list is not null
                _highwaysList = highwayList._highwaysList;
            else throw new NullReferenceException("Initialize with empty list"); // else exceptional situation
        }
        public int GetCurrentLength() // get current length of the list of roads
        { return _highwaysList.Count; }
        public bool ReadFile() // read all roads from file and create list of roads
        {
            OpenFileDialog fileDialog = new OpenFileDialog(); // create opening dialog to choose what file to read
            fileDialog.Multiselect = false; // disallow multiple files to be selected
            fileDialog.Filter = "Text files|*.txt*.*"; // filter to be able to choose only .txt files
            fileDialog.DefaultExt = ".txt"; // default format value
            Nullable<bool> dialogOk = fileDialog.ShowDialog(); // open file dialog to read
            if (dialogOk == false) return false; // if close the window, then exit
            
            if (new FileInfo(fileDialog.FileNames[0]).Length == 0) // if file is empty
                throw new IOException("Wrong file format, a file is empty"); // then exceptional situation

            string line = ""; // for reading each line of the file
            string[] lineSplit; // fore splitting current line to get information about road
            List<HighWay> beforeHighwayList = new List<HighWay>(); // create new list to save all roads
            string nameHighway = ""; // variables to keep all data
            RoadType roadType = RoadType.state;
            int roadLength;
            int numberLanes;
            Availability banquette = Availability.unavailable;
            Availability roadSeparator = Availability.unavailable;
            uint currLine = 0;

            using (StreamReader reader = new StreamReader(fileDialog.FileNames[0])) // open .txt file to read
            {
                while (reader.Peek() >= 0) // if there are characters to read
                {
                    currLine++;
                    line = reader.ReadLine(); // reading line
                    lineSplit = line.Split(); // splitting line
                    if(lineSplit.Length != ROADDATACOUNT)  // if amount of data input is less or more than expected
                        throw new FormatException(String.Format($"Wrong file format, an error has occurred in line {currLine}")); // then exceptional situation
                    for (int i = 0; i < lineSplit.Length; ++i) // if 
                        lineSplit[i] = String.Concat(lineSplit[i].Where(c => !Char.IsWhiteSpace(c)));
                    nameHighway = lineSplit[0];
                    if (!Enum.IsDefined(typeof(RoadType), lineSplit[1])) // if cannot convert string to enum value
                        throw new FormatException(String.Format($"Wrong file format, an error has occurred in line {currLine}"));
                    roadType = (RoadType)Enum.Parse(typeof(RoadType), lineSplit[1], true);
                    if (!int.TryParse(lineSplit[2], out roadLength)) // if cannot convert string to uint
                        throw new FormatException(String.Format($"Wrong file format, an error has occurred in line {currLine}"));
                    if (!int.TryParse(lineSplit[3], out numberLanes)) // if cannot convert string to uint
                        throw new FormatException(String.Format($"Wrong file format, an error has occurred in line {currLine}"));
                    if (!Enum.IsDefined(typeof(Availability), lineSplit[4]))  // if cannot convert string to enum value
                        throw new FormatException(String.Format($"Wrong file format, an error has occurred in line {currLine}"));
                    banquette = (Availability)Enum.Parse(typeof(Availability), lineSplit[4], true);
                    if (!Enum.IsDefined(typeof(Availability), lineSplit[5]))  // if cannot convert string to enum value
                        throw new FormatException(String.Format($"Wrong file format, an error has occurred in line {currLine}"));
                    roadSeparator = (Availability)Enum.Parse(typeof(Availability), lineSplit[5], true);
                    if(roadLength <= 0 || numberLanes <= 0) // if converted number are length or equal 0
                        throw new FormatException(String.Format($"Wrong file format, an error has occurred in line {currLine}"));

                    beforeHighwayList.Add(new HighWay(nameHighway, 
                                                    roadType.ToString(), 
                                                    roadLength, 
                                                    numberLanes, 
                                                    banquette.ToString(), 
                                                    roadSeparator.ToString())); // add current road to new list
                }
                _highwaysList = beforeHighwayList; // if everything is done than copy new list to current list
            }
            return true;
        }

        public bool WriteToFile()
        {
            if (GetCurrentLength() == 0) // if table is empty
                if (MessageBox.Show( // ask user about saving it to file
                    "The table is empty, are you sure to save it?",
                    "Saving the HigwayTable",
                    MessageBoxButton.OKCancel,
                    MessageBoxImage.Question) != MessageBoxResult.OK) return false; // leave function
            SaveFileDialog saveFileDialog = new SaveFileDialog(); // open saving window
            saveFileDialog.Filter = "Text Files|*.txt"; // format file allowed
            saveFileDialog.FileName = "HighwayTable"; // default filename
            saveFileDialog.Title = "Save Road Table"; // title of the saving window
            if (saveFileDialog.ShowDialog() == true) // if saving is approved
            {
                using (FileStream fs = File.Create(saveFileDialog.FileName)) // create file and open it
                {
                    Byte[] title = new System.Text.UTF8Encoding(true).GetBytes(ToString()); // get text to print
                    fs.Write(title, 0, title.Length); // print to file
                    return true;
                }
            }
            return false; // if saving is not approved
        }
        public HighWay this[int index] // to be able to get some road using object of the HighwayList class
        {
            get
            {
                if (index < 0 || index >= _highwaysList.Count) // if index is out of range
                {
                    throw new IndexOutOfRangeException("Index is out of range."); // then exceptional situation
                }
                return _highwaysList[index]; // else return current road
            }
        }
        public void Sort() // sorting roads
        {
            _highwaysList.Sort(); // override sort, where type of sort is mentioned in HighWay.cs
        }
        public HighwayList FindShortestRoadWithMostLanes() // finding shortest road with most lanes 
        {
            if (GetCurrentLength() == 0) return null; // if table is empty leave
            HighwayList minHighways = new HighwayList(); // create new list that contains shortest road
            minHighways._highwaysList.Add(_highwaysList[0]); // add to new list first road from list
            int countHighWays = GetCurrentLength(); // get current length of highwaysList
            if (countHighWays == 1) return minHighways; // if count is 1, then return list
            for (int i = 1; i < countHighWays; ++i) // move through other roads in the list
            {
                if (minHighways[0].NumberLanes < _highwaysList[i].NumberLanes || // if road has more lanes than previous or
                    (minHighways[0].NumberLanes == _highwaysList[i].NumberLanes && // if they have same count of lanes and
                    minHighways[0].RoadLength > _highwaysList[i].RoadLength)) // if current road has shorter length than previous
                {
                    minHighways._highwaysList.Clear(); // then clear current list
                    minHighways._highwaysList.Add(_highwaysList[i]); // and add current road to the list
                }
                if(minHighways[0].NumberLanes == _highwaysList[i].NumberLanes &&
                   minHighways[0].RoadLength == _highwaysList[i].RoadLength) // situation when roads have same data
                {
                    minHighways._highwaysList.Add(_highwaysList[i]); // then add current road to the list
                }
            }
            return minHighways; // return current road list
        }
        public Dictionary<RoadType, HighwayList> FindGroupedSeparatedRoadsMoreTwoLanes() // find grouped roads with
                                                                                         // separator and more than 2 lanes
        {
            if (GetCurrentLength() == 0) return null; // if table is empty leave
            // create road dictionary that has all roads with separator and more than 2 lanes where key is RoadType 
            Dictionary<RoadType, HighwayList> GroupedHighwayLists = new Dictionary<RoadType, HighwayList>();
            int countHighWays = GetCurrentLength();
            for (RoadType i = 0; i <= RoadType.local; ++i) // moving through all RoadType (enum)
            {
                GroupedHighwayLists.Add(i, new HighwayList()); // add current key
                for (int j = 0; j < countHighWays; ++j) // moving through all roads
                    if (_highwaysList[j].RoadType == i &&
                        _highwaysList[j].RoadSeparator == Availability.available &&
                        _highwaysList[j].NumberLanes > 2) // if road is with separator and more than 2 lanes
                        GroupedHighwayLists[i]._highwaysList.Add(_highwaysList[j]); // then add to list with current key
            }
            return GroupedHighwayLists; // return current road dictionary
        }

        public HighwayList FindRegionalRoadsMostLanesCrosswalkAvailable() // find regional roads with most lanes and crosswalks
        {
            if (GetCurrentLength() == 0) return null; // if table is empty leave
            // create HighwayList to keep current roads
            HighwayList regionalRoadsList = new HighwayList();
            int maxLanesCount = 0; // value to keep max lanes count
            int countHighWays = GetCurrentLength(); // get current length of highwaysList
            for (int i = 0; i < countHighWays; ++i) // moving through all roads
            {
                if (_highwaysList[i].RoadType == RoadType.regional && // if road type is regional and 
                    _highwaysList[i].Banquette == Availability.available) // it has banquette
                {
                    if (maxLanesCount < _highwaysList[i].NumberLanes) // if number of lanes is bigger than previous
                    {
                        maxLanesCount = _highwaysList[i].NumberLanes; // then change max lanes count
                        regionalRoadsList._highwaysList.Clear(); // clear current list
                    }
                    if (maxLanesCount == _highwaysList[i].NumberLanes) // if max lanes count is same as current road number lanes 
                        regionalRoadsList._highwaysList.Add(_highwaysList[i]); // then add it to the list
                }
            }
            return regionalRoadsList; // return this list
        }
        public override string ToString() // parse road to the string
        {
            if (GetCurrentLength() == 0) return null; // if table is empty leave
            string print = ""; // value to keep all roads in text format
            int countHighWays = GetCurrentLength(); // get current length of highwaysList
            for (int i = 0; i < countHighWays; ++i) // moving through all roads
                print += String.Format($"{_highwaysList[i]}\n"); // add current road to the print value
            return print; // return text with all roads
        }

        public Dictionary<RoadType, HighwayList> FindAllRoadTypesWithFootpathsMaxLength() // find road types with
                                                                                          // banquette and road is longest 
        {
            if (GetCurrentLength() == 0) return null; // if table is empty leave
            // create road dictionary that has all road types with banquette and road is longest
            Dictionary<RoadType, HighwayList> roadTypes = new Dictionary<RoadType, HighwayList>()
            {
                { RoadType.state, new HighwayList() },
                { RoadType.regional, new HighwayList() },
                { RoadType.areal, new HighwayList() },
                { RoadType.local, new HighwayList() }
            };
            int maxLength = 0; // to keep max length of road
            int countHighWays = GetCurrentLength(); // get current length of highwaysList
            for (int i = 0; i < countHighWays; ++i) // moving through all roads
                if (_highwaysList[i].Banquette == Availability.available) // if road has banquette
                {
                    if (maxLength < _highwaysList[i].RoadLength) // if current road length is bigger than maxLength
                    {
                        maxLength = _highwaysList[i].RoadLength; // then set new maxLength
                        for (RoadType j = 0; j < RoadType.local; ++j) // moving through all road types
                            if (_highwaysList[i].RoadType == j) // if current road type is equal to j
                                roadTypes[j]._highwaysList.Clear(); // then clear list
                    }
                    if (maxLength == _highwaysList[i].RoadLength) // if maxLength is equal to current road length
                        for (RoadType j = 0; j < RoadType.local; ++j) // moving through all road types
                            if (_highwaysList[i].RoadType == j) // if current road type is equal to j
                                roadTypes[j]._highwaysList.Add(_highwaysList[i]); // than add it to the list
                }
            return roadTypes; // return dictionary with roads
        }
        public void ClearList() // clear road list
        {
            _highwaysList.Clear();
            HighWay.countRoads = 0; // static value that contains count of roads is equal to 0 now
        }
        public void Add(HighWay highWay) // add road to the list
        {
            _highwaysList.Add(highWay);
        }
    }
}
