using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Aplicatie_Mobila.Models
{
    public class ListaRezervari
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [ForeignKey(typeof(RezervareList))]
        public int RezervareListID { get; set; }
        public int ClientiID { get; set; }
    }
}
