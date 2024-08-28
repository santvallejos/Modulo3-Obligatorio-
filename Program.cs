using Modulo3_Obligatorio;

WeatherForecast3 registros = new();

User usuario1 = new(User.Names.Santiago);
TemperatureRecord registro1 = new(30, usuario1, "24-08-24", "22:08");

registros.AddTemperatureRecord(registro1, 0,0);

int temperatura = registros.SeeTemperature(0, 0);

Console.WriteLine(temperatura);

WeatherForecast3.CalculateTemperatures.AverageWeeks(registros.tempsRecords);

WeatherForecast3.CalculateTemperatures.Threshold(registros.tempsRecords);

WeatherForecast3.CalculateTemperatures.AverageTempsMonth(registros.tempsRecords);