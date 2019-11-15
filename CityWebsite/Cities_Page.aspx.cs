using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ValidatorLibrary;

namespace Project4
{
    public partial class Cities_Page : System.Web.UI.Page
    {
        String webApiUrl = "http://cis-iis2.temple.edu/Spring2019/CIS3342_tuc47460/Project4WS/api/Cities/";

        protected void Page_Load(object sender, EventArgs e)
        {
            container.InnerHtml = CityGUI.DisplayCities(getAllCities());
        }

        public void btnEdit_Click(object sender, EventArgs e)
        {
            string cityName = txtSearchName.Text;
            WebRequest request = WebRequest.Create(webApiUrl + "CityByName" + "?cityName=" + cityName);
            WebResponse response = request.GetResponse();

            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();

            reader.Close();
            response.Close();

            // Deserialize a JSON string that contains an array of JSON objects into an Array of Team objects.
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<City> CityList = js.Deserialize<List<City>>(data);
            if (CityList != null)
            {
                if (CityList.Count > 0)
                {
                    ActionMode();

                    lblWarning.Visible = false;

                    City city = CityList[0];

                    txtId.Text = city.Id;
                    txtBurgRate.Text = city.BurglaryRate.ToString();
                    txtFemaleMedAge.Text = city.FemaleMedianAge.ToString();
                    txtMaleMedAge.Text = city.MaleMedianAge.ToString();
                    txtMedHI.Text = city.MedianHouseIncome.ToString();
                    txtVehTheftRate.Text = city.MotorVehicleTheftRate.ToString();
                    txtName.Text = city.Name;
                    txtPercOwn.Text = city.PercOwners.ToString();
                    txtRent.Text = city.PercRenters.ToString();
                    txtPop.Text = city.Population.ToString();
                    txtState.Text = city.State;
                    txtUnemploymentRate.Text = city.UnemploymentRate.ToString();
                }
                else
                {
                    lblWarning.Visible = true;
                    lblWarning.Text = "No Records Found";
                }//end else
            }
            else
            {
                lblWarning.Visible = true;
                lblWarning.Text = "No Records Found";
            }//end else

        }//end btnEditClick

        private void ActionMode()
        {
            btnEdit.Visible = false;
            btnAdd.Visible = false;
            btnSubmit.Visible = true;
            btnCancel.Visible = true;
            txtBurgRate.ReadOnly = false;
            txtFemaleMedAge.ReadOnly = false;
            txtMaleMedAge.ReadOnly = false;
            txtMedHI.ReadOnly = false;
            txtName.ReadOnly = false;
            txtPercOwn.ReadOnly = false;
            txtPop.ReadOnly = false;
            txtRent.ReadOnly = false;
            txtUnemploymentRate.ReadOnly = false;
            txtVehTheftRate.ReadOnly = false;
            txtState.ReadOnly = false;
        }

        public List<City> getAllCities()
        {
            // Create an HTTP Web Request and get the HTTP Web Response from the server.
            WebRequest request = WebRequest.Create(webApiUrl + "GetCities");
            WebResponse response = request.GetResponse();

            // Read the data from the Web Response, which requires working with streams.
            Stream theDataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(theDataStream);
            String data = reader.ReadToEnd();

            reader.Close();
            response.Close();

            // Deserialize a JSON string that contains an array of JSON objects into an Array of Team objects.
            JavaScriptSerializer js = new JavaScriptSerializer();
            List<City> CityList = js.Deserialize<List<City>>(data);

            //return list
            return CityList;

        }//end getAllCities

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTargetVal.Text) && !string.IsNullOrWhiteSpace(txtTargetVal.Text))
            {
                lblWarning.Visible = false;
                string searchValue = txtTargetVal.Text;
                string searchOp = ddlSearchOp.SelectedValue;
                string searchType = ddlSearchType.SelectedValue;
                WebRequest request = WebRequest.Create(webApiUrl + searchType + "?targetValue=" + searchValue + "&op=" + searchOp);
                WebResponse response = request.GetResponse();

                // Read the data from the Web Response, which requires working with streams.
                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();

                reader.Close();
                response.Close();

                // Deserialize a JSON string that contains an array of JSON objects into an Array of Team objects.
                JavaScriptSerializer js = new JavaScriptSerializer();
                List<City> CityList = js.Deserialize<List<City>>(data);
                if (CityList != null)
                {
                    if (CityList.Count > 0)
                    {
                        container.InnerHtml = "";
                        container.InnerHtml = CityGUI.DisplayCities(CityList);
                    }
                    else
                    {
                        lblWarning.Visible = true;
                        lblWarning.Text = "No Records Found";
                    }
                }
                else
                {
                    lblWarning.Visible = true;
                    lblWarning.Text = "No Records Found";
                }

            }//end if
        }//end btn search

        protected void btnSearch1_Click(object sender, EventArgs e)
        {
            if (!StringValidator.IsNotEmptySpaceOrNull(txtSearchState.Text))
            {
                lblWarning.Visible = false;
                string cityName = txtSearchName.Text;
                WebRequest request = WebRequest.Create(webApiUrl + "CityByName" + "?cityName=" + cityName);
                WebResponse response = request.GetResponse();

                // Read the data from the Web Response, which requires working with streams.
                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();

                reader.Close();
                response.Close();

                // Deserialize a JSON string that contains an array of JSON objects into an Array of Team objects.
                JavaScriptSerializer js = new JavaScriptSerializer();
                List<City> CityList = js.Deserialize<List<City>>(data);
                if (CityList != null)
                {
                    container.InnerHtml = "";
                    container.InnerHtml = CityGUI.DisplayCities(CityList);
                }
                else
                {
                    lblWarning.Visible = true;
                    lblWarning.Text = "No Records Found";
                }
            }//end if
            else if (StringValidator.IsNotEmptySpaceOrNull(txtSearchState.Text)
                && StringValidator.IsNotEmptySpaceOrNull(txtSearchName.Text))
            {
                lblWarning.Visible = false;
                string cityState = txtSearchState.Text;
                string cityName = txtSearchName.Text;
                WebRequest request = WebRequest.Create(webApiUrl + "CityByNameAndState" + "?cityName=" + cityName + "&cityState=" + cityState);
                WebResponse response = request.GetResponse();

                // Read the data from the Web Response, which requires working with streams.
                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();

                reader.Close();
                response.Close();

                // Deserialize a JSON string that contains an array of JSON objects into an Array of Team objects.
                JavaScriptSerializer js = new JavaScriptSerializer();
                List<City> CityList = js.Deserialize<List<City>>(data);
                if (CityList != null)
                {
                    container.InnerHtml = "";
                    container.InnerHtml = CityGUI.DisplayCities(CityList);
                }
                else
                {
                    lblWarning.Visible = true;
                    lblWarning.Text = "No Records Found";
                }
            }//end else if
            else
            {
                lblWarning.Visible = false;
                string cityState = txtSearchState.Text;
                WebRequest request = WebRequest.Create(webApiUrl + "CityByState" + "?cityState=" + cityState);
                WebResponse response = request.GetResponse();

                // Read the data from the Web Response, which requires working with streams.
                Stream theDataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(theDataStream);
                String data = reader.ReadToEnd();

                reader.Close();
                response.Close();

                // Deserialize a JSON string that contains an array of JSON objects into an Array of Team objects.
                JavaScriptSerializer js = new JavaScriptSerializer();
                List<City> CityList = js.Deserialize<List<City>>(data);
                if (CityList != null)
                {
                    if (CityList.Count > 0)
                    {
                        container.InnerHtml = "";
                        container.InnerHtml = CityGUI.DisplayCities(CityList);
                    }//end if
                    else
                    {
                        lblWarning.Visible = true;
                        lblWarning.Text = "No Records Found";
                    }//end else
                }
                else
                {
                    lblWarning.Visible = true;
                    lblWarning.Text = "No Records Found";
                }
            }//end else if
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
            ActionMode();
        }//end btn add

        private void ClearTextBoxes()
        {
            txtId.Text = "";
            txtFemaleMedAge.Text = "";
            txtMaleMedAge.Text = "";
            txtMedHI.Text = "";
            txtName.Text = "";
            txtPercOwn.Text = "";
            txtPop.Text = "";
            txtRent.Text = "";
            txtUnemploymentRate.Text = "";
            txtVehTheftRate.Text = "";
            txtBurgRate.Text = "";
            txtState.Text = "";
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (ValidateTextBoxes())
            {
                lblWarning.Visible = false;
                DisplayMode();

                City City = new City();
                City.Id = txtId.Text;
                City.BurglaryRate = decimal.Parse(txtBurgRate.Text);
                City.FemaleMedianAge = int.Parse(txtFemaleMedAge.Text);
                City.MaleMedianAge = int.Parse(txtMaleMedAge.Text);
                City.MedianHouseIncome = decimal.Parse(txtMedHI.Text);
                City.MotorVehicleTheftRate = decimal.Parse(txtVehTheftRate.Text);
                City.Name = txtName.Text;
                City.PercOwners = decimal.Parse(txtPercOwn.Text);
                City.PercRenters = decimal.Parse(txtRent.Text);
                City.Population = int.Parse(txtPop.Text);
                City.State = txtState.Text;
                City.UnemploymentRate = decimal.Parse(txtUnemploymentRate.Text);

                // Serialize a Customer object into a JSON string.
                JavaScriptSerializer js = new JavaScriptSerializer();
                String jsonCity = js.Serialize(City);

                if (!string.IsNullOrEmpty(txtId.Text))
                {
                    try

                    {
                        WebRequest request = WebRequest.Create(webApiUrl + "Update");
                        request.Method = "POST";
                        request.ContentLength = jsonCity.Length;
                        request.ContentType = "application/json";

                        // Write the JSON data to the Web Request
                        StreamWriter writer = new StreamWriter(request.GetRequestStream());
                        writer.Write(jsonCity);
                        writer.Flush();
                        writer.Close();

                        // Read the data from the Web Response, which requires working with streams.
                        WebResponse response = request.GetResponse();
                        Stream theDataStream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(theDataStream);
                        String data = reader.ReadToEnd();

                        reader.Close();
                        response.Close();

                        if (data == "false")
                        {
                            lblWarning.Visible = true;
                            lblWarning.Text = "Record not Updated";
                        }//end if
                        else
                        {
                            lblWarning.Visible = true;
                            lblWarning.Text = "Record Updated";
                            container.InnerHtml = "";
                            container.InnerHtml = CityGUI.DisplayCities(getAllCities());
                        }//end else

                    }
                    catch (Exception ex)
                    {
                        lblWarning.Text = "Error: " + ex.Message;
                    }

                }//end if
                else
                {
                    try

                    {
                        WebRequest request = WebRequest.Create(webApiUrl + "Add");
                        request.Method = "POST";
                        request.ContentLength = jsonCity.Length;
                        request.ContentType = "application/json";

                        // Write the JSON data to the Web Request
                        StreamWriter writer = new StreamWriter(request.GetRequestStream());
                        writer.Write(jsonCity);
                        writer.Flush();
                        writer.Close();

                        // Read the data from the Web Response, which requires working with streams.
                        WebResponse response = request.GetResponse();
                        Stream theDataStream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(theDataStream);
                        String data = reader.ReadToEnd();

                        reader.Close();
                        response.Close();

                        if (data == "ADDED")
                        {
                            lblWarning.Visible = true;
                            lblWarning.Text = "Record Added";
                        }//end if
                        else
                        {
                            lblWarning.Visible = true;
                            lblWarning.Text = data.ToString();
                        }//end else
                        container.InnerHtml = "";
                        container.InnerHtml = CityGUI.DisplayCities(getAllCities());
                    }
                    catch (Exception ex)
                    {
                        lblWarning.Visible = true;
                        lblWarning.Text = "Error: " + ex.Message;
                    }
                }//end else
            }//end if
            else
            {
                lblWarning.Visible = true;
                lblWarning.Text = "All fields are required. Fields expecting a number will not accept letters";
            }//end else
        }//end btnsubmit click

        private bool ValidateTextBoxes()
        {
            return StringValidator.IsNotEmptySpaceOrNull(txtName.Text)
                            && StringValidator.IsNotEmptySpaceOrNull(txtState.Text)
                            && IntValidator.IsInteger(txtPop.Text)
                            && StringValidator.IsDecimal(txtMedHI.Text)
                            && StringValidator.IsDecimal(txtPercOwn.Text)
                            && StringValidator.IsDecimal(txtRent.Text)
                            && IntValidator.IsInteger(txtMaleMedAge.Text)
                            && IntValidator.IsInteger(txtFemaleMedAge.Text)
                            && StringValidator.IsDecimal(txtUnemploymentRate.Text)
                            && StringValidator.IsDecimal(txtBurgRate.Text)
                            && StringValidator.IsDecimal(txtVehTheftRate.Text);
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            DisplayMode();
            ClearTextBoxes();
        }//end btncancel click

        private void DisplayMode()
        {
            btnAdd.Visible = true;
            btnEdit.Visible = true;
            btnSubmit.Visible = false;
            btnCancel.Visible = false;
            txtBurgRate.ReadOnly = true;
            txtFemaleMedAge.ReadOnly = true;
            txtMaleMedAge.ReadOnly = true;
            txtMedHI.ReadOnly = true;
            txtName.ReadOnly = true;
            txtPercOwn.ReadOnly = true;
            txtPop.ReadOnly = true;
            txtRent.ReadOnly = true;
            txtUnemploymentRate.ReadOnly = true;
            txtVehTheftRate.ReadOnly = true;
            txtState.ReadOnly = true;
        }
    }
}