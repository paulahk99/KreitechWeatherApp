//using Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Interfaz_De_Usuario
{
    public partial class MainPage : Form
    {
        public MontevideoWeatherInfo montevideoWeatherInfo { get; set; }

        public MainPage()
        {
            InitializeComponent();
            montevideoWeatherInfo = getInfo();
            lblSky.Text = montevideoWeatherInfo.weather[0].description + ", Max: " + ((int)(montevideoWeatherInfo.main.temp_max) / 12).ToString() + "°C  " + "Min: " + ((int)(montevideoWeatherInfo.main.temp_min) / 12).ToString() + "°C  "; 
        }

        private void btnHumidity_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Humidity:";
            lblInformation.Text = montevideoWeatherInfo.main.humidity.ToString() + "%";
            lblInformation2.Visible = false;
        }

        private void btnWind_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Wind:";
            lblInformation.Text = "Speed: " + montevideoWeatherInfo.wind.speed.ToString() +" km/h ";
            lblInformation2.Visible = true;
            lblInformation2.Text = "Degrees: " + montevideoWeatherInfo.wind.deg.ToString();
        }

        private void btnVisibility_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Visibility:";
            lblInformation.Text = montevideoWeatherInfo.visibility.ToString();
            lblInformation2.Visible = false;
        }

        private void btnPressure_Click(object sender, EventArgs e)
        {
            lblTitle.Text = "Pressure:";
            lblInformation.Text = montevideoWeatherInfo.main.pressure.ToString() + " hPa";
            lblInformation2.Visible = false;
        }

        public MontevideoWeatherInfo getInfo()
        {
            MontevideoWeatherInfo mvdWeatherInfo;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(@"http://api.openweathermap.org/data/2.5/weather?id=3441575&appid=b91fc1a607acb48bc4f0ed011d246ff8");
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                var json = reader.ReadToEnd();
                mvdWeatherInfo = JsonConvert.DeserializeObject<MontevideoWeatherInfo>(json);
            }
            lblExample.Text = "nubes: " + mvdWeatherInfo.main.feels_like.ToString();
            return mvdWeatherInfo;
        }
    }
}
