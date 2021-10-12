using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Week4.Library.Core.Models
{
    [DataContract]
    public class Prestito
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int IdLibro { get; set; }
        [DataMember]
        public Book _Book { get; set; } // ???
        [DataMember]
        public string Utente { get; set; }
        [DataMember]
        public DateTime DataPrestito { get; set; }
        [DataMember]
        public DateTime DataReso { get; set; }

        public string Print()
        {
            return $"Prestito:\t Id: {Id}, IdLibro: {IdLibro},Utente: {Utente} - Data Prestito: {DataPrestito} - Data Reso: {DataReso}";
        }
    }
}
