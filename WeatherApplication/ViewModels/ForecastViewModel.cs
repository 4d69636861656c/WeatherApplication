﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using WeatherApplication.Models;

namespace WeatherApplication.ViewModels
{
    class ForecastViewModel : INotifyPropertyChanged
    {
        #region Constants
        private const string API_KEY = "4c06b57f32656f388a2256e2432c3e63";
        private const string URL = "http://api.openweathermap.org/data/2.5/forecast?q={CITY}&units=metric&exclude=daily,hourly&appid={API_KEY}";
        #endregion

        #region Private Members
        private string _city;
        #endregion

        #region Public Constructor
        public ForecastViewModel()
        {
            City = "London";
        }
        #endregion

        #region INotifityPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(String info)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(info));
        }
        #endregion

        #region Properties
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
                this.NotifyPropertyChanged("City");
            }

        }

        public string TemperatureNow
        {
            get
            {
                if (GetConnectionStatus())
                {
                    return Convert.ToString(ReturnListOfForecastsForDay(0).Main.Temp);
                }
                else
                {
                    return null;
                }
            }
        }

        public DataTable ForecastDatatable
        {
            get
            {
                return RetrieveForecastDatatableAsync().Result;
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Checks the connection by attempting to retrieve a dummy forecast list for today. 
        /// </summary>
        /// <returns></returns>
        public bool GetConnectionStatus()
        {
            List listOfForecasts;

            try
            {
                listOfForecasts = new List();
                listOfForecasts = ReturnListOfForecastsForDay(0);
            }
            catch (Exception)
            {

                return false;
            }

            if (listOfForecasts != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Retrieves a datatable which can be used to populate objects that accept a DataTable DataSource setter. 
        /// It accepts 1 to 6 days (integer number) as arguments. Anything over that is probably unrealiable. 
        /// </summary>
        /// <param name="numberOfRows"></param>
        /// <returns>DataTable</returns>
        public DataTable RetrieveForecastDatatable(int numberOfRows = 6)
        {
            if (numberOfRows <= 0)
            {
                numberOfRows = 1;
            }

            if (numberOfRows > 6)
            {
                numberOfRows = 6;
            }

            string[] columnHeaders, rowHeaders;
            InitializeRowAndColumnHeaders(out columnHeaders, out rowHeaders);

            //Create a new DataTable. 
            var datatable = new DataTable();

            // Add headers to rows and columns. 
            for (int i = 0; i < columnHeaders.Length; i++)
            {
                datatable.Columns.Add($"{columnHeaders[i]}");
            }

            // Check connection. Populate rows. 
            if (GetConnectionStatus())
            {
                for (int currentIndex = 0; currentIndex < numberOfRows; currentIndex++)
                {
                    datatable.Rows.Add(
                        rowHeaders[currentIndex],
                        ReturnListOfForecastsForDay(currentIndex).Main.Temp.ToString(),
                        ReturnListOfForecastsForDay(currentIndex).Main.FeelsLike.ToString(),
                        ReturnListOfForecastsForDay(currentIndex).Main.TempMin.ToString(),
                        ReturnListOfForecastsForDay(currentIndex).Main.TempMax.ToString(),
                        ReturnListOfForecastsForDay(currentIndex).Main.Humidity.ToString(),
                        ReturnListOfForecastsForDay(currentIndex).Wind.Speed.ToString(),
                        ReturnListOfForecastsForDay(currentIndex).Main.Pressure.ToString(),
                        ReturnListOfForecastsForDay(currentIndex).Visibility.ToString()
                    );
                }
            }
            else
            {
                for (int currentIndex = 0; currentIndex < numberOfRows; currentIndex++)
                {
                    datatable.Rows.Add(
                        rowHeaders[currentIndex],
                        "-",
                        "-",
                        "-",
                        "-",
                        "-",
                        "-",
                        "-",
                        "-"
                    );
                }
            }

            // Return a dataTable for binding its contents to the property. 
            return datatable;
        }

        public Task<DataTable> RetrieveForecastDatatableAsync(int numberOfRows = 6)
        {
            return Task.Run(() => RetrieveForecastDatatable(numberOfRows));
        }
        #endregion

        #region Private Methods
        private List ReturnListOfForecastsForDay(int day)
        {
            string completeUrl = URL;
            completeUrl = completeUrl.Replace("{CITY}", this.City);
            completeUrl = completeUrl.Replace("{API_KEY}", API_KEY);
            List dailyForecast = null;

            // Create a web client. Dispose of it after getting necessary data. 
            using (WebClient client = new WebClient())
            {
                // Get the response string from the CompleteUrl. 
                try
                {
                    string downloadedString = client.DownloadString(completeUrl);

                    Root deserializedRootObject = JsonConvert.DeserializeObject<Root>(downloadedString);

                    List<List> listOfForecasts = new List<List>();

                    // TODO: Get rid of clutter and comments. 

                    // A sentinel for today's forecast being added to te list. 
                    bool addedTodaysForecast = false;
                    for (int counter = 0; counter < deserializedRootObject.List.Count; counter++)
                    {
                        //MessageBox.Show("" + deserializedRootObject.List.Count);
                        // Get the time stored in the JSON file. 
                        DateTime jsonTime = DateTime.Parse(deserializedRootObject.List[counter].DtTxt);
                        //MessageBox.Show("" + jsonTime.Hour);

                        // If current time is over 12 PM, then the forecast should be added for whatever hour is available today. 
                        if ((jsonTime.Date == DateTime.Now.Date && jsonTime.Hour > 12) && !addedTodaysForecast)
                        {
                            listOfForecasts.Add(deserializedRootObject.List[counter]);
                            addedTodaysForecast = true;
                            //MessageBox.Show("" + listOfForecasts[counter].DtTxt);
                            //MessageBox.Show("" + listOfForecasts[counter].Main.Temp);
                        }

                        // Skip the hourly forecast to get prediction for 12:00 PM every day. 
                        if (jsonTime.Hour >= 11 && jsonTime.Hour <= 13)
                        {
                            listOfForecasts.Add(deserializedRootObject.List[counter]);
                            addedTodaysForecast = true;
                            //MessageBox.Show("" + listOfForecasts[counter].DtTxt);
                            //MessageBox.Show("" + listOfForecasts[counter].Main.Temp);
                        }
                    }

                    dailyForecast = listOfForecasts[day];
                }
                catch (WebException webException)
                {
                    Debug.WriteLine(webException.Message);
                }
                catch (Exception exception)
                {
                    Debug.WriteLine(exception.Message);
                }
            }

            return dailyForecast;
        }

        private static void InitializeRowAndColumnHeaders(out string[] columnHeaders, out string[] rowHeaders)
        {
            // Column headers. 
            columnHeaders = new string[]
            {
                " ",
                "Temperature (°C)",
                "Feels like",
                "Temperature Min",
                "Temperature Max",
                "Humidity (%)",
                "Wind Speed (m/s)",
                "Atmospheric Pressure (hPa)",
                "Visibility (m)"
            };

            // Row headers. 
            rowHeaders = new string[]
            {
                    DateTime.Now.DayOfWeek.ToString(),
                    (DateTime.Now.AddDays(1).DayOfWeek).ToString(),
                    (DateTime.Now.AddDays(2).DayOfWeek).ToString(),
                    (DateTime.Now.AddDays(3).DayOfWeek).ToString(),
                    (DateTime.Now.AddDays(4).DayOfWeek).ToString(),
                    (DateTime.Now.AddDays(5).DayOfWeek).ToString(),
                    (DateTime.Now.AddDays(6).DayOfWeek).ToString()
            };
        }
        #endregion
    }
}