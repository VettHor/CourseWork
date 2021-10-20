using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Highway.Models
{
    public enum RoadType { state, regional, areal, local }
    public enum Availability { unavailable, available }
    public class HighWay
    {
        protected string _nameHighway;
        protected RoadType _roadType;
        protected uint _roadLength;
        protected uint _numberLanes;
        protected Availability _banquette;
        protected Availability _roadDivider;

        public string NameHighway
        {
            get => _nameHighway;
            set => _nameHighway = value;
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
            get => _numberLanes;
            set => _numberLanes = value;
        }
        public Availability Banquette
        {
            get => _banquette;
            set => _banquette = value;
        }
        public Availability RoadDivider
        {
            get => _roadDivider;
            set => _roadDivider = value;
        }
        public HighWay(string nameHighway = "", string roadType = "", uint roadLength = 0, 
            uint numberLanes = 0, string banquette = "", string roadDivider = "")
        {
            this._nameHighway = nameHighway;
            this._roadType = (RoadType)Enum.Parse(typeof(RoadType), roadType, true);
            this._roadLength = roadLength;
            this._numberLanes = numberLanes;
            this._banquette = (Availability)Enum.Parse(typeof(Availability), banquette, true);
            this._roadDivider = (Availability)Enum.Parse(typeof(Availability), roadDivider, true);
        }
    }
}
