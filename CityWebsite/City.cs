using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project4
{
    public class City
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string State { get; set; }
        public int Population { get; set; }
        public decimal MedianHouseIncome { get; set; }
        public decimal PercOwners { get; set; }
        public decimal PercRenters { get; set; }
        public int MaleMedianAge { get; set; }
        public int FemaleMedianAge { get; set; }
        public decimal UnemploymentRate { get; set; }
        public decimal BurglaryRate { get; set; }
        public decimal MotorVehicleTheftRate { get; set; }

        public City() { }//default constructor

        //utilities
        public int GetIDInt()
        {
            //local var
            int num = -1;
            //try parse
            int.TryParse(this.Id, out num);
            //return num
            return num;
        }//end getIDInt
    }
}
