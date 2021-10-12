using System;
using System.Runtime.Serialization;

namespace Week4.Library.Core
{
    [DataContract]
    public class Book
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Isbn { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string Author { get; set; }

        public string Print()
        {
            return $"Id: {Id}, ISBN: {Isbn}, Title: {Title} - Autore: {Author}";
        }
    }
}
