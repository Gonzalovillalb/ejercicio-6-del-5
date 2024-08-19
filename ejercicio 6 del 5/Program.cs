namespace ejercicio_6_del_5
{
    internal class Program
    {

        class Punto
        {
            public double X { get; set; }
            public double Y { get; set; }

            public Punto(double x, double y)
            {
                X = x;
                Y = y;
            }

            public double DistanciaAlOrigen()
            {
                return Math.Sqrt(X * X + Y * Y);
            }

            public double DistanciaA(Punto otro)
            {
                return Math.Sqrt(Math.Pow(X - otro.X, 2) + Math.Pow(Y - otro.Y, 2));
            }

            public int Cuadrante()
            {
                if (X > 0 && Y > 0) return 1;
                if (X < 0 && Y > 0) return 2;
                if (X < 0 && Y < 0) return 3;
                if (X > 0 && Y < 0) return 4;
                return 0; // Si está en un eje
            }

            public override string ToString()
            {
                return $"({X}, {Y})";
            }
        }

        class Programa
        {
            static void Main()
            {
                Random random = new Random();
                List<Punto> puntos = new List<Punto>();

                // Generar 20 puntos aleatorios
                for (int i = 0; i < 20; i++)
                {
                    double x = random.Next(-10, 11);
                    double y = random.Next(-10, 11);
                    puntos.Add(new Punto(x, y));
                }

                // Mostrar puntos con su distancia al origen
                Console.WriteLine("Puntos con su distancia al origen:");
                foreach (var punto in puntos)
                {
                    Console.WriteLine($"{punto}: Distancia al origen = {punto.DistanciaAlOrigen():0.00}");
                }

                // Filtrar y mostrar puntos por cuadrante
                for (int i = 1; i <= 4; i++)
                {
                    Console.WriteLine($"\nPuntos en el cuadrante {i}:");
                    foreach (var punto in puntos)
                    {
                        if (punto.Cuadrante() == i)
                        {
                            Console.WriteLine(punto);
                        }
                    }
                }

                // Mostrar distancias entre puntos
                Console.WriteLine("\nDistancias entre puntos:");
                for (int i = 0; i < puntos.Count - 1; i++)
                {
                    Console.WriteLine($"Distancia entre {puntos[i]} y {puntos[i + 1]} = {puntos[i].DistanciaA(puntos[i + 1]):0.00}");
                }

                // Modificar un punto
                Console.Write("\nIngrese el índice del punto a modificar (0-19): ");
                int indice = int.Parse(Console.ReadLine());

                if (indice >= 0 && indice < puntos.Count)
                {
                    Console.Write("Ingrese nueva coordenada X: ");
                    double nuevaX = double.Parse(Console.ReadLine());
                    Console.Write("Ingrese nueva coordenada Y: ");
                    double nuevaY = double.Parse(Console.ReadLine());

                    puntos[indice].X = nuevaX;
                    puntos[indice].Y = nuevaY;

                    Console.WriteLine($"Punto modificado: {puntos[indice]}");
                }
                else
                {
                    Console.WriteLine("Índice fuera de rango.");
                }
            }
        }

    }
    }

