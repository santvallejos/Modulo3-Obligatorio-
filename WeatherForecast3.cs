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
        private Positions _position { get; set;}
        public Positions Position
        {
            get { return _position; }
            set 
            {
                if(Name == Names.Santiago || Name == Names.Lola || Name == Names.Valentin)
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
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException(nameof(Temperature),"La temperatura ingresada es Menor a 0");
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
                if(weeks == 0  && days == 0)
                {
                    tempsRecords[weeks, days] = record;
                }
                else if (tempsRecords[weeks, days].PersonTurn.Position == tempsRecords[weeks, days - 1].PersonTurn.Position)
                {
                    Console.WriteLine("\nEl registro porque el usuario anterior que registro es de su misma posicion");
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

        // Constructor que inicializa la matriz
        public WeatherForecast3()
        {
            tempsRecords = new TemperatureRecord[5, 7];
        }
    }
}
