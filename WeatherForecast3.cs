using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modulo3_Obligatorio
{
    public class User
    {
        public Names Name { get; set; }
        private Positions _position { get; set; }
        public Positions Position
        {
            get { return _position; }
            set
            {
                if (Name == Names.Santiago || Name == Names.Lola || Name == Names.Valentin)
                {
                    _position = Positions.Pasante;
                }
                else
                {
                    _position = Positions.Profecional;
                }
            }
        }

        //Definimos 
        public User(Names name)
        {
            Name = name;
        }

        public enum Names
        {
            Santiago,
            Sofia,
            Lola,
            Luz,
            Valentin,
            Gonzalo
        }

        public enum Positions
        {
            Pasante,
            Profecional
        }
    }

    public class TemperatureRecord
    {
        private int _temperature { get; set; }
        public int Temperature
        {
            get { return _temperature; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Temperature), "La temperatura ingresada es Menor a 0");
                }
                _temperature = value;
            }
        }
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
        public void AddTemperatureRecord(TemperatureRecord record, int weeks, int days)
        {
            if (weeks >= 0 && weeks < tempsRecords.GetLength(0) && days >= 0 && days < tempsRecords.GetLength(1))
            {
                if (weeks == 0 && days == 0)
                {
                    tempsRecords[weeks, days] = record;
                }
                else if (tempsRecords[weeks, days].PersonTurn.Position == tempsRecords[weeks, days - 1].PersonTurn.Position)
                {
                    Console.WriteLine("\nEl registro no se puede ingresar porque el usuario anterior que registro es de su misma posicion");
                }
                else
                {
                    tempsRecords[weeks, days] = record;
                }

            }
            else
            {
                Console.WriteLine("\nError al ingresar el registro!.");
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

        public static class CalculateTemperatures
        {
            public static void AverageWeeks(TemperatureRecord[,] records)
            {
                List<int> averageTempsWeeks = new List<int>();

                for (int i = 0; i < records.GetLength(0); i++)
                {
                    int sum = 0;
                    int cont = 0;
                    for (int j = 0; j < records.GetLength(1); j++)
                    {
                        if (records[i, j]?.Temperature != null)
                        {
                            sum += records[i, j].Temperature;
                            cont++;
                        }
                    }

                    //Si el contador permanece en 0 indica que la semana no contiene ningun registro aun
                    if (cont == 0)
                    {
                        Console.WriteLine($"\nLa Semana {i + 1} no tiene ningun registro");
                    }
                    else //en el otro caso calcula el promedio y lo notifica
                    {
                        int average;

                        if (i == records.GetLength(0) - 1)
                        {
                            average = sum / 3;
                        }
                        else
                        {
                            average = sum / 7;
                        }

                        averageTempsWeeks.Add(average);//Lo inserta en la lista

                        Console.WriteLine($"\nEl promedio de la semana {i + 1} es: {averageTempsWeeks[i]}");
                    }
                }
            }

            public static void Threshold(TemperatureRecord[,] records)
            {
                List<TemperatureRecord> threshold = new List<TemperatureRecord>();

                for (int i = 0; i < records.GetLength(0); i++) //Recorre las filas
                {
                    for (int j = 0; j < records.GetLength(1); j++) // Recorre las columnas
                    {
                        //Si el valor es mayor a 20 se guarda en el umbral
                        if (records[i, j]?.Temperature != null && records[i, j].Temperature > 20)
                        {
                            threshold.Add(records[i, j]);
                        }
                    }
                }

                if (threshold.Count == 0)//Evaluar si la lista tiene elementos
                {
                    Console.WriteLine("\nNo hay registros de temperaturas que superen el umbral!");
                }
                else
                {
                    Console.WriteLine("\nLas temperaturas que superaron el umbral son: ");
                    foreach (var item in threshold)
                    {
                        Console.WriteLine($"{item.Temperature}° -> Regitrada el {item.RegistrationDate} a las {item.RegistrationTime} por {item.PersonTurn.Name}({item.PersonTurn.Position})");
                    }
                }
            }

            public static void AverageTempsMonth(TemperatureRecord[,] records)
            {
                double sum = 0;
                int cont = 0 ;
                foreach (var item in records)
                {
                    if(item?.Temperature != null)
                    {
                        sum += item.Temperature;
                        cont++;
                    }
                }

                if(cont == 0)
                {
                    Console.WriteLine("\nNo se encuentran registros en la matriz!");
                }
                else
                {
                double averageTempsMonth = sum / 31;

                Console.WriteLine($"\nEl promedio de temperatura del mes es: {averageTempsMonth:F2}");
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
