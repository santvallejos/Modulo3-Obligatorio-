using Modulo3_Obligatorio;

//Añadir y mostrar los registros de temperatura
WeatherForecast3 RegistrosClima = new WeatherForecast3();

User usuario1 = new User("Santiago", "Pasante");

TemperatureRecord registro1 = new TemperatureRecord(27, usuario1, "21-08-24", "16:40");

RegistrosClima.AddTemperatureRecord(registro1, 0,0);

RegistrosClima.DisplayAllTemperatures();

