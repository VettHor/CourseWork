using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Win32;

namespace Highway.Models
{
    public class HighwayList
    {
        private List<HighWay> highwaysList;
        private const int roadTypesCount = 4;
        public HighwayList()
        {
            highwaysList = new List<HighWay>();
        }
        public int GetCurrentLength()
        { return highwaysList.Count; }
        public void ReadFile()
        {
            try
            {
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Multiselect = false;
                fileDialog.Filter = "Text files|*.txt*.*";
                fileDialog.DefaultExt = ".txt";
                Nullable<bool> dialogOk = fileDialog.ShowDialog();
                if(dialogOk == true)
                {
                    string filePath = fileDialog.FileNames[0];
                    string line = "";
                    string[] lineSplit;

                    string nameHighway = "";
                    RoadType roadType = RoadType.state;
                    uint roadLength;
                    uint numberLanes;
                    Availability banquette = Availability.unavailable;
                    Availability roadDivider = Availability.unavailable;

                    using (StreamReader reader = new StreamReader(filePath))
                    {
                        while(reader.Peek() >= 0)
                        {
                            line = reader.ReadLine();
                            lineSplit = line.Split();
                            for(int i = 0; i < lineSplit.Length; ++i)
                            {
                                lineSplit[i] = String.Concat(lineSplit[i].Where(c => !Char.IsWhiteSpace(c)));
                            }
                            nameHighway = lineSplit[0];
                            if (!Enum.IsDefined(typeof(RoadType), lineSplit[1]))
                                throw new FormatException("Wrong file format");
                            roadType = (RoadType)Enum.Parse(typeof(RoadType), lineSplit[1], true);
                            if (!uint.TryParse(lineSplit[2], out roadLength))
                                throw new FormatException("Wrong file format");
                            if (!uint.TryParse(lineSplit[3], out numberLanes))
                                throw new FormatException("Wrong file format");
                            if (!Enum.IsDefined(typeof(Availability), lineSplit[4]))
                                throw new FormatException("Wrong file format");
                            banquette = (Availability)Enum.Parse(typeof(Availability), lineSplit[4], true);
                            if (!Enum.IsDefined(typeof(Availability), lineSplit[5]))
                                throw new FormatException("Wrong file format");
                            roadDivider = (Availability)Enum.Parse(typeof(Availability), lineSplit[5], true);

                            highwaysList.Add(new HighWay(nameHighway, roadType.ToString(), roadLength, numberLanes, banquette.ToString(), roadDivider.ToString()));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void WriteToFile()
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files|*.txt";
            saveFileDialog.FileName = "Table";
            saveFileDialog.Title = "Save Road Table";
            if(saveFileDialog.ShowDialog() == true)
            {
                string path = saveFileDialog.FileName;
                using (FileStream fs = File.Create(path))
                {
                    Byte[] title = new System.Text.UTF8Encoding(true).GetBytes(ToString());
                    fs.Write(title, 0, title.Length);
                }
                //BinaryWriter binaryWriter = new BinaryWriter(File.Create(path));
                //binaryWriter.Write(ToString());
                //binaryWriter.Dispose();
            }
        }
        public HighWay this[int index]
        {
            get
            {
                if (index < 0 || index >= highwaysList.Count)
                {
                    throw new IndexOutOfRangeException("Index is out of range.");
                }
                return highwaysList[index];
            }
        }
        public void Sort()
        {
            highwaysList.Sort();
        }
        public HighWay FindShortestRoadWithMostLanes()
        {
            HighWay minHighway = highwaysList[0];
            for(int i = 0; i < highwaysList.Count; ++i)
            {
                if (minHighway.NumberLanes < highwaysList[i].NumberLanes ||
                    (minHighway.NumberLanes == highwaysList[i].NumberLanes &&
                    minHighway.RoadLength > highwaysList[i].RoadLength))
                    minHighway = highwaysList[i];
            }
            return minHighway;
        }
        public Dictionary<RoadType, HighwayList> FindGroupedSeparatedRoadsMoreTwoLines()
        {
            //List<HighwayList> GroupedHighwayLists = new List<HighwayList>();
            //RoadType currRoadType;
            //for(int i = 0; i < roadTypesCount; ++i)
            //{
            //    currRoadType = (RoadType)i;
            //    GroupedHighwayLists.Add(new HighwayList());
            //    for (int j = 0; j < highwaysList.Count; ++j)
            //    {
            //        if(highwaysList[j].RoadType == currRoadType)
            //        {
            //            GroupedHighwayLists[i].highwaysList.Add(highwaysList[j]);
            //        }
            //    }
            //}
            //return GroupedHighwayLists;
            Dictionary<RoadType, HighwayList> GroupedHighwayLists = new Dictionary<RoadType, HighwayList>();

            //List<HighwayList> GroupedHighwayLists = new List<HighwayList>();
            RoadType currRoadType;
            for (int i = 0; i < roadTypesCount; ++i)
            {
                currRoadType = (RoadType)i;
                GroupedHighwayLists.Add(currRoadType, new HighwayList());
                for (int j = 0; j < highwaysList.Count; ++j)
                    if (highwaysList[j].RoadType == currRoadType && 
                        highwaysList[j].RoadDivider == Availability.available && 
                        highwaysList[j].NumberLanes > 2)
                        GroupedHighwayLists[currRoadType].highwaysList.Add(highwaysList[j]);
            }
            return GroupedHighwayLists;
        }

        public HighwayList FindRegionalRoadsMostLanesCrosswalkAvailable()
        {
            HighwayList regionalRoadsList = new HighwayList();
            uint maxLanesCount = 0;
            for (int i = 0; i < highwaysList.Count; ++i)
            {
                if(highwaysList[i].RoadType == RoadType.regional &&
                    highwaysList[i].Banquette == Availability.available)
                {
                    if (maxLanesCount < highwaysList[i].NumberLanes)
                    {
                        maxLanesCount = highwaysList[i].NumberLanes;
                        regionalRoadsList.highwaysList.Clear();
                    }
                    if(maxLanesCount == highwaysList[i].NumberLanes)
                        regionalRoadsList.highwaysList.Add(highwaysList[i]);
                }
            }
            return regionalRoadsList;
        }
        public override string ToString()
        {
            string print = "";
            for (int i = 0; i < highwaysList.Count; ++i)
                print += highwaysList[i] + "\n";
            return print;
        }

    }
}
