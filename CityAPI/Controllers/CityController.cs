using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using City_API.Models;
using Utilities;
using System.Data;
using System.Data.SqlClient;

namespace City_API.Controllers
{
    [Produces("application/json")]
    [Route("api/Cities")]
    public class CityController : ControllerBase
    {
        [HttpGet] // GET api/Cities/
        [HttpGet("GetCities")]   // GET api/Cities/GetCities
        public List<City> GetCities()
        {
            //local var
            List<City> CityList = new List<City>();
            DBConnect dbconn = new DBConnect();
            string sqlcomm = "SELECT * FROM p4_cities";
            DataSet myDataSet = new DataSet();

            try
            {
                //get dataset
                myDataSet = dbconn.GetDataSet(sqlcomm);

                foreach (DataRow dr in myDataSet.Tables[0].Rows)
                {
                    //local var
                    City City = new City();

                    City.Id = dr["CityId"].ToString();
                    City.Name = (string)dr["CityName"];
                    City.State = (string)dr["CityState"];
                    City.Population = (int)dr["Population"];
                    City.MedianHouseIncome = (int)dr["MedianHouseIncome"];
                    City.PercRenters = (decimal)dr["PercRenters"];
                    City.PercOwners = (decimal)dr["PercOwners"];
                    City.MaleMedianAge = (int)dr["MaleMedianAge"];
                    City.FemaleMedianAge = (int)dr["FemaleMedianAge"];
                    City.UnemploymentRate = (decimal)dr["UnemploymentRate"];
                    City.BurglaryRate = (decimal)dr["BurglaryRate"];
                    City.MotorVehicleTheftRate = (decimal)dr["MotorVehicleTheftRate"];

                    //Add to list
                    CityList.Add(City);
                }//end foreach
                return CityList;
            }
            catch (SqlException sqlex)
            {
                return null;
            }//end catch sql ex
            catch (Exception ex)
            {
                return null;
            }//end catch
        }//end GetCities

        [HttpGet("CitiesByBurglaryRate")]   // GET /api/Cities/CitiesByBurglaryRate/
        public List<City> GetCitiesByBurglaryRate(decimal targetValue, string op)
        {
            string procedure = "getCityByBurglaryRate";
            string StoredProcedure = SwitchStoredProcedure(procedure, op);
            //local var
            List<City> CityList = new List<City>();
            DBConnect dbconn = new DBConnect();

            SqlCommand sqlcomm = new SqlCommand(StoredProcedure);
            sqlcomm.CommandType = System.Data.CommandType.StoredProcedure;
            sqlcomm.Parameters.Add(new SqlParameter("@targetVal", targetValue));
            DataSet myDataSet = new DataSet();

            try
            {
                //get dataset
                myDataSet = dbconn.GetDataSetUsingCmdObj(sqlcomm);

                foreach (DataRow dr in myDataSet.Tables[0].Rows)
                {
                    //local var
                    City City = new City();

                    City.Id = dr["CityId"].ToString();
                    City.Name = (string)dr["CityName"];
                    City.State = (string)dr["CityState"];
                    City.Population = (int)dr["Population"];
                    City.MedianHouseIncome = (int)dr["MedianHouseIncome"];
                    City.PercRenters = (decimal)dr["PercRenters"];
                    City.PercOwners = (decimal)dr["PercOwners"];
                    City.MaleMedianAge = (int)dr["MaleMedianAge"];
                    City.FemaleMedianAge = (int)dr["FemaleMedianAge"];
                    City.UnemploymentRate = (decimal)dr["UnemploymentRate"];
                    City.BurglaryRate = (decimal)dr["BurglaryRate"];
                    City.MotorVehicleTheftRate = (decimal)dr["MotorVehicleTheftRate"];

                    //Add to list
                    CityList.Add(City);
                }//end foreach
                return CityList;
            }
            catch (SqlException sqlex)
            {
                return null;
            }//end catch sql ex
            catch (Exception ex)
            {
                return null;
            }//end catch
        }//end get burglary rate

        [HttpGet("CitiesByVehicleTheftRate")]   // GET /api/Cities/CitiesByVehicleTheftRate/
        public List<City> GetCitiesByVehicleTheftRate(decimal targetValue, string op)
        {
            string procedure = "getCityByVehicleTheftRate";
            string StoredProcedure = SwitchStoredProcedure(procedure, op);
            //local var
            List<City> CityList = new List<City>();
            DBConnect dbconn = new DBConnect();

            SqlCommand sqlcomm = new SqlCommand(StoredProcedure);
            sqlcomm.CommandType = System.Data.CommandType.StoredProcedure;
            sqlcomm.Parameters.Add(new SqlParameter("@targetVal", targetValue));
            DataSet myDataSet = new DataSet();

            try
            {
                //get dataset
                myDataSet = dbconn.GetDataSetUsingCmdObj(sqlcomm);

                foreach (DataRow dr in myDataSet.Tables[0].Rows)
                {
                    //local var
                    City City = new City();

                    City.Id = dr["CityId"].ToString();
                    City.Name = (string)dr["CityName"];
                    City.State = (string)dr["CityState"];
                    City.Population = (int)dr["Population"];
                    City.MedianHouseIncome = (int)dr["MedianHouseIncome"];
                    City.PercRenters = (decimal)dr["PercRenters"];
                    City.PercOwners = (decimal)dr["PercOwners"];
                    City.MaleMedianAge = (int)dr["MaleMedianAge"];
                    City.FemaleMedianAge = (int)dr["FemaleMedianAge"];
                    City.UnemploymentRate = (decimal)dr["UnemploymentRate"];
                    City.BurglaryRate = (decimal)dr["BurglaryRate"];
                    City.MotorVehicleTheftRate = (decimal)dr["MotorVehicleTheftRate"];

                    //Add to list
                    CityList.Add(City);
                }//end foreach
                return CityList;
            }
            catch (SqlException sqlex)
            {
                return null;
            }//end catch sql ex
            catch (Exception ex)
            {
                return null;
            }//end catch
        }//end get cities by vehicle theft rate

        [HttpGet("CitiesByMaleMedianAge")]   // GET /api/Cities/CitiesByMaleMedianAge/
        public List<City> GetCitiesByMaleMedianAge(decimal targetValue, string op)
        {
            string procedure = "getCityByMaleMedianAge";
            string StoredProcedure = SwitchStoredProcedure(procedure, op);
            //local var
            List<City> CityList = new List<City>();
            DBConnect dbconn = new DBConnect();

            SqlCommand sqlcomm = new SqlCommand(StoredProcedure);
            sqlcomm.CommandType = System.Data.CommandType.StoredProcedure;
            sqlcomm.Parameters.Add(new SqlParameter("@targetVal", targetValue));
            DataSet myDataSet = new DataSet();

            try
            {
                //get dataset
                myDataSet = dbconn.GetDataSetUsingCmdObj(sqlcomm);

                foreach (DataRow dr in myDataSet.Tables[0].Rows)
                {
                    //local var
                    City City = new City();

                    City.Id = dr["CityId"].ToString();
                    City.Name = (string)dr["CityName"];
                    City.State = (string)dr["CityState"];
                    City.Population = (int)dr["Population"];
                    City.MedianHouseIncome = (int)dr["MedianHouseIncome"];
                    City.PercRenters = (decimal)dr["PercRenters"];
                    City.PercOwners = (decimal)dr["PercOwners"];
                    City.MaleMedianAge = (int)dr["MaleMedianAge"];
                    City.FemaleMedianAge = (int)dr["FemaleMedianAge"];
                    City.UnemploymentRate = (decimal)dr["UnemploymentRate"];
                    City.BurglaryRate = (decimal)dr["BurglaryRate"];
                    City.MotorVehicleTheftRate = (decimal)dr["MotorVehicleTheftRate"];

                    //Add to list
                    CityList.Add(City);
                }//end foreach
                return CityList;
            }
            catch (SqlException sqlex)
            {
                return null;
            }//end catch sql ex
            catch (Exception ex)
            {
                return null;
            }//end catch
        }//end get cities by male median age

        [HttpGet("CitiesByFemaleMedianAge")]   // GET /api/Cities/CitiesByFemaleMedianAge/
        public List<City> GetCitiesByFemaleMedianAge(decimal targetValue, string op)
        {
            string procedure = "getCityByFemaleMedianAge";
            string StoredProcedure = SwitchStoredProcedure(procedure, op);
            //local var
            List<City> CityList = new List<City>();
            DBConnect dbconn = new DBConnect();

            SqlCommand sqlcomm = new SqlCommand(StoredProcedure);
            sqlcomm.CommandType = System.Data.CommandType.StoredProcedure;
            sqlcomm.Parameters.Add(new SqlParameter("@targetVal", targetValue));
            DataSet myDataSet = new DataSet();

            try
            {
                //get dataset
                myDataSet = dbconn.GetDataSetUsingCmdObj(sqlcomm);

                foreach (DataRow dr in myDataSet.Tables[0].Rows)
                {
                    //local var
                    City City = new City();

                    City.Id = dr["CityId"].ToString();
                    City.Name = (string)dr["CityName"];
                    City.State = (string)dr["CityState"];
                    City.Population = (int)dr["Population"];
                    City.MedianHouseIncome = (int)dr["MedianHouseIncome"];
                    City.PercRenters = (decimal)dr["PercRenters"];
                    City.PercOwners = (decimal)dr["PercOwners"];
                    City.MaleMedianAge = (int)dr["MaleMedianAge"];
                    City.FemaleMedianAge = (int)dr["FemaleMedianAge"];
                    City.UnemploymentRate = (decimal)dr["UnemploymentRate"];
                    City.BurglaryRate = (decimal)dr["BurglaryRate"];
                    City.MotorVehicleTheftRate = (decimal)dr["MotorVehicleTheftRate"];

                    //Add to list
                    CityList.Add(City);
                }//end foreach
                return CityList;
            }
            catch (SqlException sqlex)
            {
                return null;
            }//end catch sql ex
            catch (Exception ex)
            {
                return null;
            }//end catch
        }//end get cities by male median age

        private static string SwitchStoredProcedure(string procedure, string op)
        {
            string StoredProcedure = "";

            //switch stored procedure depending on op
            switch (op)
            {
                case "=":
                    StoredProcedure = procedure + "Equal";
                    break;
                case "!=":
                    StoredProcedure = procedure + "NEqual";
                    break;
                case ">=":
                    StoredProcedure = procedure + "GEqual";
                    break;
                case "<=":
                    StoredProcedure = procedure + "LEqual";
                    break;
                case "<":
                    StoredProcedure = procedure + "L";
                    break;
                case ">":
                    StoredProcedure = procedure + "G";
                    break;
                default:
                    StoredProcedure = procedure + "Equal";
                    break;
            }//end switch

            return StoredProcedure;
        }

        [HttpPost] // POST api/Cities/
        [HttpPost("Add")] // POST /api/Cities/Add
        public string AddCity([FromBody] City theCity)
        {
            if (theCity != null)
            {
                if (GetCityByName(theCity.Name).Count == 0)
                {
                    //local var
                    DBConnect dbconn = new DBConnect();
                    SqlCommand comm = new SqlCommand("dbo.insertCity");
                    //Command params
                    comm.CommandType = System.Data.CommandType.StoredProcedure;
                    comm.Parameters.Add(new SqlParameter("@CityName", theCity.Name));
                    comm.Parameters.Add(new SqlParameter("@CityState", theCity.State));
                    comm.Parameters.Add(new SqlParameter("@Population", theCity.Population));
                    comm.Parameters.Add(new SqlParameter("@MedianHouseIncome", theCity.MedianHouseIncome));
                    comm.Parameters.Add(new SqlParameter("@PercOwners", theCity.PercOwners));
                    comm.Parameters.Add(new SqlParameter("@PercRenters", theCity.PercRenters));
                    comm.Parameters.Add(new SqlParameter("@MaleMedianAge", theCity.MaleMedianAge));
                    comm.Parameters.Add(new SqlParameter("@FemaleMedianAge", theCity.FemaleMedianAge));
                    comm.Parameters.Add(new SqlParameter("@UnemploymentRate", theCity.UnemploymentRate));
                    comm.Parameters.Add(new SqlParameter("@BurglaryRate", theCity.BurglaryRate));
                    comm.Parameters.Add(new SqlParameter("@MotorVehicleTheftRate", theCity.MotorVehicleTheftRate));

                    try
                    {
                        //doUpdate
                        if (dbconn.DoUpdateUsingCmdObj(comm) > 0)
                        {
                            return "ADDED";
                        }//end if
                        else
                        {
                            return "NOT-ADDED";
                        }//end else
                    }//end try
                    catch (SqlException sqlex)
                    {
                        return "SQL EXCEPTION ERROR. NOT ADDED";
                    }//end catch sql ex
                    catch (Exception ex)
                    {
                        return "GENERAL EXCEPTION OCCURED. NOT ADDED";
                    }//end catch
                }
                else
                {
                    return "CITY EXISTS IN DATABASE NOT ADDED.";
                }
            }//end if
            else
            {
                return "WRONGFORMAT";
            }
        }//end add City

        [HttpPost] // POST api/Cities/
        [HttpPost("Update")] // POST /api/Cities/Update
        public bool UpdateCity([FromBody] City theCity)
        {
            if (theCity != null)
            {
                //local var
                DBConnect dbconn = new DBConnect();
                SqlCommand comm = new SqlCommand("dbo.updateCity");
                //Command params
                comm.CommandType = System.Data.CommandType.StoredProcedure;
                comm.Parameters.Add(new SqlParameter("@CityId", theCity.GetIDInt()));
                comm.Parameters.Add(new SqlParameter("@CityName", theCity.Name));
                comm.Parameters.Add(new SqlParameter("@CityState", theCity.State));
                comm.Parameters.Add(new SqlParameter("@Population", theCity.Population));
                comm.Parameters.Add(new SqlParameter("@MedianHouseIncome", theCity.MedianHouseIncome));
                comm.Parameters.Add(new SqlParameter("@PercOwners", theCity.PercOwners));
                comm.Parameters.Add(new SqlParameter("@PercRenters", theCity.PercRenters));
                comm.Parameters.Add(new SqlParameter("@MaleMedianAge", theCity.MaleMedianAge));
                comm.Parameters.Add(new SqlParameter("@FemaleMedianAge", theCity.FemaleMedianAge));
                comm.Parameters.Add(new SqlParameter("@UnemploymentRate", theCity.UnemploymentRate));
                comm.Parameters.Add(new SqlParameter("@BurglaryRate", theCity.BurglaryRate));
                comm.Parameters.Add(new SqlParameter("@MotorVehicleTheftRate", theCity.MotorVehicleTheftRate));

                try
                {
                    //doUpdate
                    if (dbconn.DoUpdateUsingCmdObj(comm) > 0)
                    {
                        return true;
                    }//end if
                    else
                    {
                        return false;
                    }//end else
                }//end try
                catch (SqlException sqlex)
                {
                    return false;
                }//end catch sql ex
                catch (Exception ex)
                {
                    return false;
                }//end catch
            }//end if
            else
            {
                return false;
            }
        }//end add City

        [HttpGet("CityByName")] // POST /api/Cities/CityByName
        public List<City> GetCityByName(string cityName)
        {
            //local var
            List<City> CityList = new List<City>();
            DBConnect dbconn = new DBConnect();
            SqlCommand sqlcomm = new SqlCommand("dbo.getCityByName");
            DataSet myDataSet = new DataSet();
            //Command params
            sqlcomm.CommandType = System.Data.CommandType.StoredProcedure;
            sqlcomm.Parameters.Add(new SqlParameter("@CityName", cityName));

            try
            {
                //get dataset
                myDataSet = dbconn.GetDataSetUsingCmdObj(sqlcomm);

                foreach (DataRow dr in myDataSet.Tables[0].Rows)
                {
                    //local var
                    City City = new City();

                    City.Id = dr["CityId"].ToString();
                    City.Name = (string)dr["CityName"];
                    City.State = (string)dr["CityState"];
                    City.Population = (int)dr["Population"];
                    City.MedianHouseIncome = (int)dr["MedianHouseIncome"];
                    City.PercRenters = (decimal)dr["PercRenters"];
                    City.PercOwners = (decimal)dr["PercOwners"];
                    City.MaleMedianAge = (int)dr["MaleMedianAge"];
                    City.FemaleMedianAge = (int)dr["FemaleMedianAge"];
                    City.UnemploymentRate = (decimal)dr["UnemploymentRate"];
                    City.BurglaryRate = (decimal)dr["BurglaryRate"];
                    City.MotorVehicleTheftRate = (decimal)dr["MotorVehicleTheftRate"];

                    //Add to list
                    CityList.Add(City);
                }//end foreach
                return CityList;
            }
            catch (SqlException sqlex)
            {
                return null;
            }//end catch sql ex
            catch (Exception ex)
            {
                return null;
            }//end catch
        }//end city by name

        [HttpGet("CityByState")] // POST /api/Cities/CityByState
        public List<City> GetCityByState(string cityState)
        {
            //local var
            List<City> CityList = new List<City>();
            DBConnect dbconn = new DBConnect();
            SqlCommand sqlcomm = new SqlCommand("dbo.getCityByState");
            DataSet myDataSet = new DataSet();
            //Command params
            sqlcomm.CommandType = System.Data.CommandType.StoredProcedure;
            sqlcomm.Parameters.Add(new SqlParameter("@CityState", cityState));

            try
            {
                //get dataset
                myDataSet = dbconn.GetDataSetUsingCmdObj(sqlcomm);

                foreach (DataRow dr in myDataSet.Tables[0].Rows)
                {
                    //local var
                    City City = new City();

                    City.Id = dr["CityId"].ToString();
                    City.Name = (string)dr["CityName"];
                    City.State = (string)dr["CityState"];
                    City.Population = (int)dr["Population"];
                    City.MedianHouseIncome = (int)dr["MedianHouseIncome"];
                    City.PercRenters = (decimal)dr["PercRenters"];
                    City.PercOwners = (decimal)dr["PercOwners"];
                    City.MaleMedianAge = (int)dr["MaleMedianAge"];
                    City.FemaleMedianAge = (int)dr["FemaleMedianAge"];
                    City.UnemploymentRate = (decimal)dr["UnemploymentRate"];
                    City.BurglaryRate = (decimal)dr["BurglaryRate"];
                    City.MotorVehicleTheftRate = (decimal)dr["MotorVehicleTheftRate"];

                    //Add to list
                    CityList.Add(City);
                }//end foreach
                return CityList;
            }
            catch (SqlException sqlex)
            {
                return null;
            }//end catch sql ex
            catch (Exception ex)
            {
                return null;
            }//end catch
        }//end city by name

        [HttpGet("CityByNameAndState")] // POST /api/Cities/CityByNameAndState
        public List<City> GetCityByNameAndState(string cityName, string cityState)
        {
            //local var
            List<City> CityList = new List<City>();
            DBConnect dbconn = new DBConnect();
            SqlCommand sqlcomm = new SqlCommand("dbo.getCityByNameAndState");
            DataSet myDataSet = new DataSet();
            //Command params
            sqlcomm.CommandType = System.Data.CommandType.StoredProcedure;
            sqlcomm.Parameters.Add(new SqlParameter("@CityName", cityName));
            sqlcomm.Parameters.Add(new SqlParameter("@CityState", cityState));

            try
            {
                //get dataset
                myDataSet = dbconn.GetDataSetUsingCmdObj(sqlcomm);

                foreach (DataRow dr in myDataSet.Tables[0].Rows)
                {
                    //local var
                    City City = new City();

                    City.Id = dr["CityId"].ToString();
                    City.Name = (string)dr["CityName"];
                    City.State = (string)dr["CityState"];
                    City.Population = (int)dr["Population"];
                    City.MedianHouseIncome = (int)dr["MedianHouseIncome"];
                    City.PercRenters = (decimal)dr["PercRenters"];
                    City.PercOwners = (decimal)dr["PercOwners"];
                    City.MaleMedianAge = (int)dr["MaleMedianAge"];
                    City.FemaleMedianAge = (int)dr["FemaleMedianAge"];
                    City.UnemploymentRate = (decimal)dr["UnemploymentRate"];
                    City.BurglaryRate = (decimal)dr["BurglaryRate"];
                    City.MotorVehicleTheftRate = (decimal)dr["MotorVehicleTheftRate"];

                    //Add to list
                    CityList.Add(City);
                }//end foreach
                return CityList;
            }
            catch (SqlException sqlex)
            {
                return null;
            }//end catch sql ex
            catch (Exception ex)
            {
                return null;
            }//end catch
        }//end add City
    }
}