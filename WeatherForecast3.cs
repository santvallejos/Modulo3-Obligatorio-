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
        public Positions Position { get; set;}

        //Definimos al Usuario con su nombre y posición
        public User(Names name, Positions position)
        {
            Name = name;
            Position = position;
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

        // Constructor que inicializa la matriz
        public WeatherForecast3()
        {
            tempsRecords = new TemperatureRecord[5, 7];
        }
    }
}
