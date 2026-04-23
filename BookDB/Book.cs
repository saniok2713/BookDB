using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDB {
    internal class Book {
        public string Titolo { get; set; }
        public string Autore { get; set; }
        public int Pagine { get; set; }
        public DateOnly Data { get; set; }

    }
}
