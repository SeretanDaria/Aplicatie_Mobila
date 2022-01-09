using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Aplicatie_Mobila.Models
{
    public class Clienti
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nr_telefon { get; set; }
        public string Nr_persoane { get; set; }
        [OneToMany]
        public List<ListaRezervari> ListaRezervari { get; set; }
    }
}
