using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        do
        {
            HashSet<string> A = ObtenerConjunto("A");
            HashSet<string> B = ObtenerConjunto("B");
            HashSet<string> C = ObtenerConjunto("C");

            ImprimirConjunto("A", A);
            ImprimirConjunto("B", B);
            ImprimirConjunto("C", C);

            MostrarMenu(A, B, C);
        } while (true);
    }

    static HashSet<string> ObtenerConjunto(string nombre)
    {
        Console.WriteLine($"Ingrese elementos para el conjunto {nombre} (separe con comas):");
        string[] elementos = Console.ReadLine().Split(',');
        HashSet<string> conjunto = new HashSet<string>(elementos);
        return conjunto;
    }

    static void ImprimirConjunto(string nombre, HashSet<string> conjunto)
    {
        Console.WriteLine($"\nConjunto {nombre} = {{{string.Join(", ", conjunto)}}}");
    }

    static void MostrarMenu(HashSet<string> A, HashSet<string> B, HashSet<string> C)
    {
        string opcion;

        do
        {
            Console.WriteLine("\nSeleccione una operación:");
            Console.WriteLine("1. Realizar intersección");
            Console.WriteLine("2. Realizar unión");
            Console.WriteLine("3. Salir");

            opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    RealizarInterseccion(A, B, C);
                    break;
                case "2":
                    RealizarUnion(A, B, C);
                    break;
                case "3":
                    Environment.Exit(0); // Salir del programa
                    break;
                default:
                    Console.WriteLine("Opción no válida. Por favor, elija una opción válida.");
                    break;
            }
        } while (opcion != "3");
    }

    static void RealizarInterseccion(HashSet<string> A, HashSet<string> B, HashSet<string> C)
    {
        Console.WriteLine("\nSeleccione los conjuntos para la intersección (por ejemplo, A,B,C):");
        string[] conjuntos = Console.ReadLine().Split(',');

        List<HashSet<string>> conjuntosSeleccionados = new List<HashSet<string>>();

        foreach (string conjunto in conjuntos)
        {
            switch (conjunto.Trim().ToUpper())
            {
                case "A":
                    conjuntosSeleccionados.Add(A);
                    break;
                case "B":
                    conjuntosSeleccionados.Add(B);
                    break;
                case "C":
                    conjuntosSeleccionados.Add(C);
                    break;
                default:
                    Console.WriteLine("Conjunto no válido. Por favor, elija entre A, B o C.");
                    return;
            }
        }

        HashSet<string> interseccion = new HashSet<string>(conjuntosSeleccionados.First());

        foreach (var conjunto in conjuntosSeleccionados.Skip(1))
        {
            interseccion.IntersectWith(conjunto);
        }

        string conjuntosTexto = string.Join(" y ", conjuntos);
        ImprimirConjunto($"Intersección de {conjuntosTexto}", interseccion);
    }

    static void RealizarUnion(HashSet<string> A, HashSet<string> B, HashSet<string> C)
    {
        Console.WriteLine("\nSeleccione los conjuntos para la unión (por ejemplo, A,B,C):");
        string[] conjuntos = Console.ReadLine().Split(',');

        HashSet<string> union = new HashSet<string>();

        List<string> conjuntosSeleccionados = new List<string>();

        foreach (string conjunto in conjuntos)
        {
            switch (conjunto.Trim().ToUpper())
            {
                case "A":
                    union.UnionWith(A);
                    conjuntosSeleccionados.Add("A");
                    break;
                case "B":
                    union.UnionWith(B);
                    conjuntosSeleccionados.Add("B");
                    break;
                case "C":
                    union.UnionWith(C);
                    conjuntosSeleccionados.Add("C");
                    break;
                default:
                    Console.WriteLine("Conjunto no válido. Por favor, elija entre A, B o C.");
                    return;
            }
        }

        string conjuntosTexto = string.Join(" y ", conjuntosSeleccionados);
        ImprimirConjunto($"Unión de {conjuntosTexto}", union);
    }
}