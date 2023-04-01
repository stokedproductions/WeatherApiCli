using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Image;

using WeatherService;


namespace PDFGenerator
{
    public class PDFGenerator
    {
        public static void GeneratePdf(WeatherData weatherData, string city)
        {
            string filename = string.Format("{0}.pdf", city);

            if (filename.Length == 0) {
                Console.WriteLine("Exception: No File Name Provided");
                Environment.Exit(-1);
            }

            if (weatherData != null)
            {
                Console.WriteLine("Generating your Report....");
                
                Current current =  weatherData.Current ?? new Current();
                Location location = weatherData.Location ?? new Location();

                PdfWriter writer = new PdfWriter(filename);
                PdfDocument pdf = new PdfDocument(writer);
                Document document = new Document(pdf);

                if (city.Length != 0) {
                    Paragraph header = new Paragraph($"Current Weather for {city}").SetTextAlignment(TextAlignment.CENTER)
                    .SetFontSize(20);
                    document.Add(header);
                }

                if (location?.Name?.Length != 0) {
                    Paragraph name = new Paragraph($"Name: {location?.Name}").SetFontSize(12);
                    document.Add(name);
                }

                if (location?.Country?.Length != 0) {
                    Paragraph country = new Paragraph($"Country: {location?.Country}").SetFontSize(12);
                    document.Add(country);
                }

                if (location?.Region?.Length != 0) {
                    Paragraph region = new Paragraph($"Region: {location?.Region}").SetFontSize(12);
                    document.Add(region);
                }

                if (location?.Lat?.Length != 0) {
                    Paragraph lat = new Paragraph($"Latatude: {location?.Lat}").SetFontSize(12);
                    document.Add(lat);
                }

                if (location?.Lon?.Length != 0) {
                    Paragraph lon = new Paragraph($"Longatude: {location?.Lon}").SetFontSize(12);
                    document.Add(lon);
                }

                if (location?.Localtime?.Length != 0) {
                    Paragraph localTime = new Paragraph($"Local Time: {location?.Localtime}").SetFontSize(12);
                    document.Add(localTime);
                }

                if (location?.Timezone_id?.Length != 0) {
                    Paragraph timeZone = new Paragraph($"Timezone: {location?.Timezone_id}").SetFontSize(12);
                    document.Add(timeZone);
                }

                if (current?.Observation_time?.Length != 0) {
                    Paragraph time = new Paragraph($"Observation Time: {current?.Observation_time}").SetFontSize(12);
                    document.Add(time);
                }

                if (current?.Temperature.ToString().Length != 0) {
                    Paragraph temp = new Paragraph($"Temperature: {current?.Temperature}°C").SetFontSize(12);
                    document.Add(temp);
                }
                
                if (current?.Cloudcover.ToString().Length != 0) {
                    Paragraph cloudCover = new Paragraph($"Cloud Cover: {current?.Cloudcover}").SetFontSize(12);
                    document.Add(cloudCover);
                }

                if (current?.Wind_speed.ToString().Length != 0) {
                    Paragraph windSpeed = new Paragraph($"Wind Speed: {current?.Wind_speed}").SetFontSize(12);
                    document.Add(windSpeed);
                }

                if (current?.Wind_degree.ToString().Length != 0) {
                    Paragraph windDegree = new Paragraph($"Wind Degree: {current?.Wind_degree}").SetFontSize(12);
                    document.Add(windDegree);
                }

                if (current?.Wind_dir?.Length != 0) {
                    Paragraph windDir = new Paragraph($"Wind Direction: {current?.Wind_dir}").SetFontSize(12);
                    document.Add(windDir);
                }

                if (current?.Pressure.ToString()?.Length != 0) {
                    Paragraph pressure = new Paragraph($"Pressure: {current?.Pressure}").SetFontSize(12);
                    document.Add(pressure);
                }

                if (current?.Precip.ToString()?.Length != 0) {
                    Paragraph precip = new Paragraph($"Precip: {current?.Precip}").SetFontSize(12);
                    document.Add(precip);
                }

                if (current?.Humidity.ToString()?.Length != 0) {
                    Paragraph humidity = new Paragraph($"Humidity: {current?.Humidity}").SetFontSize(12);
                    document.Add(humidity);
                }

                if (current?.Feelslike.ToString().Length != 0) {
                    Paragraph feelslike = new Paragraph($"Feelslike: {current?.Feelslike}").SetFontSize(12);
                    document.Add(feelslike);
                }

                if (current?.Uv_index.ToString().Length != 0) {
                    Paragraph uvIndex = new Paragraph($"Uv_index: {current?.Uv_index}").SetFontSize(12);
                    document.Add(uvIndex);
                }

                if (current?.Visibility.ToString().Length != 0) {
                    Paragraph visibility = new Paragraph($"Visibility: {current?.Visibility}").SetFontSize(12);
                    document.Add(visibility);
                }

                if (current?.Is_day?.Length != 0) {
                    Paragraph isDay = new Paragraph($"Is Day time: {current?.Is_day}").SetFontSize(12);
                    document.Add(isDay);
                }

                 if (current?.Weather_descriptions?.Length != 0) {
                    Paragraph weatherDesc = new Paragraph($"Weather Description: {current?.Weather_descriptions?[0] ?? 
                        "No Description Available"}")
                        .SetFontSize(12);
                    document.Add(weatherDesc);
                 }
                
                if (current?.Weather_icons?.Length > 0 && !string.IsNullOrEmpty(current.Weather_icons[0]))
                {
                    Image weatherIcon = new Image(ImageDataFactory.Create(new Uri(current.Weather_icons[0])))
                        .SetWidth(50)
                        .SetHeight(50);
                    document.Add(weatherIcon);
                }
                
                document.Close();

                Console.WriteLine($"PDF report generated for {city}");
            }
            else {
                Console.WriteLine("Exception: Weather Data was not provided");
                Environment.Exit(-1);
            }
        }
    }
}
