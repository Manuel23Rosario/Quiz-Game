using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Quiz_Game
{
    class Program
    {
        public static List<Pregunta> preguntas = new List<Pregunta>();
        public static List<Respuestas> repuestas = new List<Respuestas>();
        public static Dictionary<string,int> scors = new Dictionary<string, int>();

        public static void PreguntasYOpciones()
        {
            preguntas.Add(new Pregunta
            {
                Id = 1,
                preguntaText = "¿Cuántos jugadores tiene un equipo de fútbol en el campo al inicio de un partido oficial?",
                Opciones = new List<Opciones>()
                {
                    new Opciones {Id = 1, Text = "12" },
                    new Opciones {Id = 2, Text = "9" },
                    new Opciones {Id = 3, Text = "11", EsValido = true},
                    new Opciones {Id = 4, Text = "10"}
                }
            });

            preguntas.Add(new Pregunta
            {
                Id = 2,
                preguntaText = "¿Quién ha ganado más títulos de Grand Slam en la historia del tenis masculino (hasta 2024)?",
                Opciones = new List<Opciones>()
                {
                    new Opciones {Id = 1, Text = "Roger Federer"},
                    new Opciones {Id = 2, Text = "Novak Djokovic", EsValido = true},
                    new Opciones {Id = 3, Text = "Rafael Nadal"},
                    new Opciones {Id = 4, Text = "Andy Murray"}
                }
            });

            preguntas.Add(new Pregunta
            {
                Id = 3,
                preguntaText = "¿En qué país se celebraron los Juegos Olímpicos de 2016?",
                Opciones = new List<Opciones>()
                {
                    new Opciones {Id = 1, Text = "Japón"},
                    new Opciones {Id = 2, Text = "China"},
                    new Opciones {Id = 3, Text = "Brasil", EsValido =true},
                    new Opciones {Id = 4, Text = "Grecia"}
                }
            });

            preguntas.Add(new Pregunta
            {
                Id = 4,
                preguntaText = "¿Cuál es el país con más Copas del Mundo de fútbol ganadas (hasta 2022)?",
                Opciones = new List<Opciones>()
                {
                    new Opciones {Id = 1, Text = "Alemania"},
                    new Opciones {Id = 2, Text = "Italia"},
                    new Opciones {Id = 3, Text = "Argentina"},
                    new Opciones {Id = 4, Text = "Brasil", EsValido = true}
                }
            });
        }

        public static void IniciarJuego()
        {
            Console.Write("Ingrese su nombre:");
            string nombre = Console.ReadLine();

            Console.WriteLine($"{nombre} contesta estas preguntas de manera correcta");
            Console.WriteLine();

            foreach (var item in preguntas)
            {
                Console.WriteLine(item.preguntaText);
                Console.WriteLine("Por favor contesta eligiendo 1,2,3 o 4");
                foreach (var opcion in item.Opciones)
                {
                    Console.WriteLine($"{opcion.Id}-{opcion.Text}");
                    
                }
                Console.Write("Ingresa la respuesta:");
                int respuesta = ValidarDatos();
                AddRespuestaLista(respuesta,item);
                Console.WriteLine();
            }
            int score = ValidarRespuestas();
            Console.WriteLine($"Muy bien {nombre} respondiste correctamente {score}/{preguntas.Count} preguntas.");
            AddScorsDicti(nombre, score);
            VerScoreTotales();

            repuestas = new List<Respuestas>();

            Console.WriteLine("Quieres jugar otra vez /si/no?");
            string jugarOtraVez = Console.ReadLine();

            if(jugarOtraVez.ToLower().Trim() == "si")
            {
                IniciarJuego();
            }

        }

        public static int ValidarDatos()
        {
            int respuesta = int.Parse(Console.ReadLine());

            try
            {
                if (respuesta.ToString() is null)
                    throw new Exception("Tiene que ingresar un numero entre 1 y 4.");

                if (respuesta == 1 || respuesta == 2 || respuesta == 3 || respuesta == 4)
                {
                    switch (respuesta)
                    {
                        case 1:
                            return respuesta;
                        case 2:
                            return respuesta;
                        case 3:
                            return respuesta;
                        case 4:
                            return respuesta;
                    }
                }
                else
                {
                    Console.WriteLine("Tiene que ingresar un numero entre 1 y 4.");
                     respuesta = ValidarDatos();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error:{ex.Message}");
            }

            return respuesta;
        }

        public static void AddRespuestaLista(int respuesta, Pregunta pregunta)
        {
            repuestas.Add(new Respuestas
            {
                IdPregunta = pregunta.Id,
                opciones = SelectOpcion(respuesta,pregunta)
            });
        }

        public static Opciones SelectOpcion(int respuesta, Pregunta pregunta)
        {
            Opciones selectOpciones = new Opciones();

            foreach (var item in pregunta.Opciones)
            {
               if(respuesta == item.Id)
               {
                    selectOpciones = item;
               }
            }

            return selectOpciones;
        }

        public static int ValidarRespuestas()
        {
            int score = 0;
            foreach (var item in repuestas)
            {
                if (item.opciones.EsValido)
                    score++;
            }
            return score;
        }

        public static void AddScorsDicti(string name, int score)
        {
            bool actualizar = false;

            foreach (var item in scors)
            {
                if (item.Key == name)
                {
                    scors[item.Key] = score;
                    actualizar = true;
                }
            }
            if (!actualizar)
                scors.Add(name, score);
        }

        public static void VerScoreTotales()
        {
            Console.WriteLine("-Player-----------------------Score------------");
            foreach (var item in scors)
            {
                Console.WriteLine($" {item.Key}\t\t\t\t{item.Value}");
                Console.WriteLine("-----------------------------------------------");
            }
        }

        static void Main(string[] args)
        {
            PreguntasYOpciones();
            IniciarJuego();
        }
    }
}
