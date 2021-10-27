using System;

namespace Highway.Models
{
    public enum RoadType { state, regional, areal, local } // enumerated type for all road types
    public enum Availability { unavailable, available } // enumerated type for availability of banquette and separator
    public class HighWay
    {
        private static int _countRoads; // static value to keep count of roads of current HighwayList 
        private string _roadName; // current road name
        private RoadType _roadType; // current road type
        private double _roadLength; // current road length
        private int _roadCountLanes; // current road count length
        private Availability _roadBanquette; // current road banquette
        private Availability _roadSeparator; // current road separator

        public static int CountRoads // getter and setter for staic value
        {
            get => _countRoads; // get value
            set => _countRoads = value; // set value
        }
        public string NameHighway // getter and setter for road name
        {
            get => _roadName; // get value
            set => _roadName = value; // set value
        }
        public RoadType RoadType // getter and setter for road type
        {
            get => _roadType; // get value
            set => _roadType = value; //set value
        }
        public double RoadLength // getter and setter for road length
        {
            get => _roadLength; // get value
            set => _roadLength = value; // set value
        }
        public int NumberLanes  // getter and setter for road count lanes
        {
            get => _roadCountLanes; // get value
            set => _roadCountLanes = value; // set value
        }
        public Availability Banquette // getter and setter for road banquette
        {
            get => _roadBanquette; // get value
            set => _roadBanquette = value; // set value
        }
        public Availability RoadSeparator // getter and setter for road separator
        {
            get => _roadSeparator; // get value
            set => _roadSeparator = value;// set value
        }

        public HighWay(string nameHighway = "", string roadType = "", double roadLength = 0,
            int numberLanes = 0, string banquette = "", string roadSeparator = "") // create road with given values
        {
            CountRoads++; // increment CountRoads to have current road count
            this._roadName = nameHighway;
            this._roadType = (RoadType)Enum.Parse(typeof(RoadType), roadType, true); // parse string to enum value
            this._roadLength = roadLength;
            this._roadCountLanes = numberLanes;
            this._roadBanquette = (Availability)Enum.Parse(typeof(Availability), banquette, true); // parse string to enum value
            this._roadSeparator = (Availability)Enum.Parse(typeof(Availability), roadSeparator, true); // parse string to enum value
        }
        public HighWay(string nameHighway, RoadType roadType, double roadLength, int numberLanes, 
            Availability banquette, Availability roadSeparator) // create road with given values
        {
            CountRoads++; // increment CountRoads to have current road count
            this._roadName = nameHighway;
            this._roadType = roadType;
            this._roadLength = roadLength;
            this._roadCountLanes = numberLanes;
            this._roadBanquette = banquette;
            this._roadSeparator = roadSeparator;
        }
        public HighWay(HighWay highWay) // create same road as given
        {
            CountRoads++; // increment CountRoads to have current road count
            this._roadName = highWay.NameHighway; // copy all values
            this._roadType = highWay.RoadType;
            this._roadLength = highWay.RoadLength;
            this._roadCountLanes = highWay.NumberLanes;
            this._roadBanquette = highWay.Banquette;
            this._roadSeparator = highWay.RoadSeparator;
        }
        public override string ToString() // convert road to string
        {
            return String.Format($"{_roadName} {_roadType} {_roadLength} " +
                $"{_roadCountLanes} {_roadBanquette} {_roadSeparator}"); // return final string
        }
    }
}
