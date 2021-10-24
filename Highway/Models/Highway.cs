using System;

namespace Highway.Models
{
    public enum RoadType { state, regional, areal, local }
    public enum Availability { unavailable, available }
    public class HighWay : IComparable<HighWay>
    {
        protected string _roadName;
        protected RoadType _roadType;
        protected uint _roadLength;
        protected uint _roadCountLanes;
        protected Availability _roadBanquette;
        protected Availability _roadSeparator;

        public string NameHighway
        {
            get => _roadName;
            set => _roadName = value;
        }
        public RoadType RoadType
        {
            get => _roadType;
            set => _roadType = value;
        }
        public uint RoadLength
        {
            get => _roadLength;
            set => _roadLength = value;
        }
        public uint NumberLanes
        {
            get => _roadCountLanes;
            set => _roadCountLanes = value;
        }
        public Availability Banquette
        {
            get => _roadBanquette;
            set => _roadBanquette = value;
        }
        public Availability RoadSeparator
        {
            get => _roadSeparator;
            set => _roadSeparator = value;
        }
        public HighWay(string nameHighway = "", string roadType = "", uint roadLength = 0, 
            uint numberLanes = 0, string banquette = "", string roadSeparator = "")
        {
            this._roadName = nameHighway;
            this._roadType = (RoadType)Enum.Parse(typeof(RoadType), roadType, true);
            this._roadLength = roadLength;
            this._roadCountLanes = numberLanes;
            this._roadBanquette = (Availability)Enum.Parse(typeof(Availability), banquette, true);
            this._roadSeparator = (Availability)Enum.Parse(typeof(Availability), roadSeparator, true);
        }

        public int CompareTo(HighWay obj)
        {
            return this.RoadLength.CompareTo(obj.RoadLength);
        }
        public override string ToString()
        {
            return String.Format($"{_roadName} {_roadType} {_roadLength} {_roadCountLanes} {_roadBanquette} {_roadSeparator}");
        }

    }
}
