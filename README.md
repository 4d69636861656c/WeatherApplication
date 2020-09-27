# Weather Forecast Application 

An application developed in C# that takes advantage of OpenWeatherMap's freely available online API. The service allows you to regularly download current weather and forecast data in JSON format. 

## Usage 
### Get a token 
First of all, you should get a token from [OpenWeatherMap](https://openweathermap.org/), as I did not include one in this project. 
### Copy and paste your key 
Open the project in your preferred code editor and place your key into the view model class and run the program. That's all. If the key is valid, the program will now run and display weather data. 

## Description 
### Pattern used 
This project is written in C# and uses the MVVM pattern. You can find the idea behind this pattern here: [MVVM Pattern](https://en.wikipedia.org/wiki/Model%E2%80%93view%E2%80%93viewmodel).
![](https://upload.wikimedia.org/wikipedia/commons/thumb/8/87/MVVMPattern.png/500px-MVVMPattern.png) 
### Models 
![](https://github.com/4d69636861656c/WeatherApplication/blob/master/WeatherApplication/Resources/Diagrams/WeatherForecastAppModels.png) 
Models hold application data. They’re usually structs or simple classes. The classes in this project are modeled after the JSON file structure that is received from OpenWeatherMap upon calling the API. By doing so, it is easier for us to extract only the relevant data by using Json.NET. Json.NET is a popular high-performance and flexible JSON serializer for converting between .NET objects and JSON. Find out more by visiting the [official website](https://github.com/JamesNK/Newtonsoft.Json).  
### View Model 
View models transform model information into values that can be displayed on a view. They’re usually classes, so they can be passed around as references. The ForecastViewModel class found in this project is responsible for all the logic that makes the program work. By implementing INotifyPropertyChanged, we can notify changes in the properties of our objects. This is where everything is put together for easy use. This is also where the bound properties reside. 
### View 
Views display visual elements and controls on the screen. In this case, it's a form where we bind UI element values to view model properties. All the actual logic is handled by the view model. 
![](https://github.com/4d69636861656c/WeatherApplication/blob/master/WeatherApplication/Resources/Images/Views/WeatherForecastApplicationMainView.png) 
