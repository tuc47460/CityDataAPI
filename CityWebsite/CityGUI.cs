using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI.HtmlControls;

namespace Project4
{
    public static class CityGUI
    {
        public static string DisplayCities(List<City> theCityList)
        {
            City dummy = new City();
            string htmlString = "<table class='table table-striped table-hover thead-dark'>";
            htmlString += "<tr class'thead-dark'>";
            foreach (PropertyInfo prop in dummy.GetType().GetProperties())
            {
                htmlString += "<th>" + NameSwitch(prop.Name) + "</th>";
            }//for each property in city
            htmlString += "</tr>";

            foreach (City city in theCityList)
            {
                htmlString += "<tr>";
                htmlString += "<td>" + city.Id +"</td>";
                htmlString += "<td>" + city.Name + "</td>";
                htmlString += "<td>" + city.State + "</td>";
                htmlString += "<td>" + String.Format("{0:#,##0}", city.Population) + "</td>";
                htmlString += "<td>" + city.MedianHouseIncome.ToString("C") + "</td>";
                htmlString += "<td>" + city.PercOwners + "</td>";
                htmlString += "<td>" + city.PercRenters + "</td>";
                htmlString += "<td>" + city.MaleMedianAge + "</td>";
                htmlString += "<td>" + city.FemaleMedianAge + "</td>";
                htmlString += "<td>" + city.UnemploymentRate + "</td>";
                htmlString += "<td>" + city.BurglaryRate + "</td>";
                htmlString += "<td>" + city.MotorVehicleTheftRate + "</td>";
                htmlString += "</tr>";
            }//end foreach
            htmlString += "</table>";
            return htmlString;
        }//end Display Cities

        public static string NameSwitch(string header)
        {
            switch (header)
            {
                case "Id":
                    return "Id";
                case "Name":
                    return "Name";
                case "State":
                    return "State";
                case "Population":
                    return "Population";
                case "MedianHouseIncome":
                    return "Household Median Income";
                case "PercOwners":
                    return "% Home Owners";
                case "PercRenters":
                    return "% Home Renters";
                case "MaleMedianAge":
                    return "Male Median Age";
                case "FemaleMedianAge":
                    return "Female Median Age";
                case "UnemploymentRate":
                    return "% Unemployment";
                case "BurglaryRate":
                    return "Burglary Rate";
                case "MotorVehicleTheftRate":
                    return "Vehicle Theft Rate";
                default:
                    return "";
            }//end switch
        }//end NameSwitch
    }//end city gui
}