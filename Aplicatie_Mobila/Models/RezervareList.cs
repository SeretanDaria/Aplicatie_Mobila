using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Aplicatie_Mobila.Models
{
    public class RezervareList //salveaza fiecare lista de rezervare
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nume { get; set; }
        public DateTime Data { get; set; }
    }
}
