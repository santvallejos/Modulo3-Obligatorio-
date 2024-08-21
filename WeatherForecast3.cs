using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulo3_Obligatorio
{
    public class User
    {
        public string Name { get; set; }
        public string Position { get; set; }

        //Definimos al Usuario con su nombre y posición
        public User(string name, string position)
        {
            Name = name;
            Position = position;
        }
    }

    public class TemperatureRecord
    {
        public int Temperature { get; set; }
        public User PersonTurn { get; set; }
        public string RegistrationDate { get; set; }
        public string RegistrationTime { get; set; }

        //Definimos el registro de temperatura que se almacenara en la matriz
        public TemperatureRecord(int temperature, User personturn, string registrationdate, string registrationtime)
        {
            Temperature = temperature;
            PersonTurn = personturn;
            RegistrationDate = registrationdate;
            RegistrationTime = registrationtime;
        }
    }

    public class WeatherForecast3
    {
        //Definimos una matriz que como tipo es TemperatureRecord(Objeto)
        public TemperatureRecord[,] tempsRecords;

        //Añadir los registros 
        public void AddTemperatureRecord(TemperatureRecord record, int week, int days)
        {
            if (week >= 0 && week < tempsRecords.GetLength(0) && days >= 0 && days < tempsRecords.GetLength(1))
            {
                tempsRecords[week, days] = record;
            }
            else
            {
                Console.WriteLine("\nError al ingresar el registro a la matriz!.");
            }
        }

        //Mostrar temperatura especifica
        public int SeeTemperature(int week, int day)
        {
            if (week >= 0 && week < tempsRecords.GetLength(0) && day >= 0 && day < tempsRecords.GetLength(1))
            {
                return tempsRecords[week, day].Temperature;
            }
            else
            {
                throw new ArgumentOutOfRangeException("Los índices de fila o columna están fuera de los límites de la matriz.");
            }
        }

        //Clase estatica donde se encuentran las operaciones del programa
        /* public static class CalculateTemperatures
        {
            //Tiene que recibir una una objeto del tipo TemperatureRecords ya que al ser estatica no podemos trabajar sobre el objeto definido en la clase WeatherForecast3
            static void averageWeeks(TemperatureRecord[,] tempsRecords)
            {
                List<double> averageTempsWeeks = new List<double>();//Declaracion de lista cone el promedio de cada semana

                for (int i = 0; i < tempsRecords.GetLength(0); i++) // Recorre las filas
                {
                    int sum = 0;

                    for (int j = 0; j < tempsRecords.GetLength(1); j++) // Recorre las columnas
                    {
                        //suma todos los valores de cada columna de una fila y los guarda en la variable sum
                        sum += tempsRecords[i, j].Temperature;
                    }

                    double average;

                    if (i == tempsRecords.GetLength(0) - 1)
                    {
                        average = sum / 3;//Si se encuentra en la ultima semana
                    }
                    else
                    {
                        average = sum / 7;
                    }

                    averageTempsWeeks.Add(average);//Lo inserta en la lista

                    Console.WriteLine($"\nEl promedio de la semana {i + 1} es: {averageTempsWeeks[i]}");
                }
            }

            static void averageTempsMonth(TemperatureRecord[,] tempsRecords)
            {
                int sum = 0;
                foreach (var item in tempsRecords)
                {
                    sum += item.Temperature;
                }
                double averageTempsMonth = sum / 31;

                Console.WriteLine($"\nEl promedio de temperatura del mes es: {averageTempsMonth}");
            }

            //Lista de temperaturas que superan el umbral
            static void Threshold(TemperatureRecord[,] tempsRecords)
            {
                //Declaracion de la variable umbral sin inicializar
                List<int> threshold = new List<int>();

                for (int i = 0; i < tempsRecords.GetLength(0); i++)
                {
                    for (int j = 0; j < tempsRecords.GetLength(1); j++)
                    {
                        //Si el valor es mayor a 20 se guarda en el umbral
                        if (tempsRecords[i, j].Temperature > 20)
                        {
                            threshold.Add(tempsRecords[i, j].Temperature);
                        }
                    }
                }

                Console.WriteLine("\nLas temperaturas que superaron el umbral son: ");
                foreach (var item in threshold)
                {
                    Console.WriteLine($"{item}°C");
                }
            }

            //Temperatura mas alta del mes
            static void tempsHigher(TemperatureRecord[,] tempsRecords)
            {
                int max = tempsRecords[0, 0].Temperature;

                // Recorremos la matriz para encontrar el valor máximo
                for (int i = 0; i < tempsRecords.GetLength(0); i++)
                {
                    for (int j = 0; j < tempsRecords.GetLength(1); j++)
                    {
                        if (tempsRecords[i, j].Temperature > max)
                        {
                            max = tempsRecords[i, j].Temperature;
                        }
                    }
                }

                Console.WriteLine($"\nLa temperatura mas alta del mes es: {max}°");
            }

            //Temperatura mas baja del mes
            static void tempsLess(TemperatureRecord[,] tempsRecords)
            {
                int min = tempsRecords[0, 0].Temperature;

                for (int i = 0; i < tempsRecords.GetLength(0); i++)
                {
                    for (int j = 0; j < tempsRecords.GetLength(1); j++)
                    {
                        if (tempsRecords[i, j].Temperature < min && tempsRecords[i, j].Temperature != 0)
                        {
                            min = tempsRecords[i, j].Temperature;
                        }
                    }
                }

                Console.WriteLine($"La temperatura mas baja del mes es: {min}°");
            }
        } */

        // Mostrar todos los registros
        public void DisplayAllTemperatures()
        {
            for (int week = 0; week < tempsRecords.GetLength(0); week++)
            {
                for (int day = 0; day < tempsRecords.GetLength(1); day++)
                {              
                    //Evaluamos si los datos no son NULL
                    if (tempsRecords[week, day] != null)
                    {
                        Console.WriteLine($"Week {week + 1}, Day {day + 1}: " +
                            $"Temperature: {tempsRecords[week, day].Temperature}, " +
                            $"Recorded by: {tempsRecords[week, day].PersonTurn.Name} ({tempsRecords[week, day].PersonTurn.Position}), " +
                            $"Date: {tempsRecords[week, day].RegistrationDate}, " +
                            $"Time: {tempsRecords[week, day].RegistrationTime}");
                    }
                    else
                    {
                        Console.WriteLine($"Week {week + 1}, Day {day + 1}: No record available.");
                    }
                }
            }
        }

        // Constructor que inicializa la matriz
        public WeatherForecast3()
        {
            tempsRecords = new TemperatureRecord[5, 7];
        }
    }
}
