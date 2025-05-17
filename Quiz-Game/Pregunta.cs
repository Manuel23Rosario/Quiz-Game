using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quiz_Game
{
    public class Pregunta
    {
        public int Id { get; set; }
        public string preguntaText { get; set; }
        public List<Opciones> Opciones { get; set; } 
    }
}
