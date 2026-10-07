using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio
{
    internal class Program
    {
        static int max = 100;
        static string[] nombres = new string[max];
        static double[] notas = new double[max];
        static int contador = 0;

        static public void Titulo()
        {
            Console.WriteLine("Sistema de Gestión de Notas");
        }

        static public void registrar_estudiante()
        {
            Console.WriteLine("Resgistro de Estudiante Nuevo: ");
            if (contador >= 100)
            {
                Console.WriteLine("Alcanzo la Capacidad Maxima");
                return;
            }
            Console.Write("Ingresar Nombre del Estudiante: ");
            string nombre = Console.ReadLine();
            double nota;
            while (true)
            {
                Console.Write("Ingresar Nota[0-20]: ");
                nota = double.Parse(Console.ReadLine());
                if (nota >= 0 && nota <= 20)
                {
                    break;
                }
                Console.WriteLine("Error volver a ingresar la nota[0-20]. ");
            }
            nombres[contador] = nombre;
            notas[contador] = nota;
            contador++;
            Console.WriteLine("Registro con exito...!!");
        }

        static public void buscar_estudiante()
        {
            Console.WriteLine("********BUSCAR ESTUDIANTE********");
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados");
                return;
            }
            Console.Write("Ingresar nombre a buscar: ");
            string nom_buscar = Console.ReadLine().ToLower();
            bool encontrado = false;
            for (int i = 0; i < contador; i++)
            {
                if (nombres[i].ToLower() == nom_buscar)
                {
                    Console.WriteLine("Estudiante encontrado: ");
                    Console.WriteLine(nombres[i] + " tiene " + notas[i]);
                    encontrado = true;
                    break;
                }
            }
            if (!encontrado)
                Console.WriteLine("Estudiante no encontrado....");
        }

        static public void Mostrar()
        {
            Console.WriteLine("******LISTADO ORIGINAL******");
            if (contador == 0)
            {
                Console.Write("No hay estudiantes registrados");
                return;
            }
            Console.WriteLine("\tNOMBRE \t\tNOTAS");
            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine("\t" + nombres[i] + "\t\t" + notas[i]);
            }
        }

        static public void burbuja()
        {
            Console.WriteLine("*******ORDENAMIENTO ASCENDENTE******");
            double temp_nota;
            string temp_nombre;
            for (int i = 0; i < contador - 1; i++)
            {
                for (int j = 0; j < contador - 1 - i; j++)
                {
                    if (notas[j] > notas[j + 1])
                    {
                        temp_nota = notas[j];
                        notas[j] = notas[j + 1];
                        notas[j + 1] = temp_nota;

                        temp_nombre = nombres[j];
                        nombres[j] = nombres[j + 1];
                        nombres[j + 1] = temp_nombre;
                    }
                }
            }
        }

        static public void Seleccion()
        {
            Console.WriteLine("*******ORDENAMIENTO POR SELECCION******");
            for (int i = 0; i < contador - 1; i++)
            {
                int min_idx = i;
                for (int j = i + 1; j < contador; j++)
                {
                    if (notas[j] < notas[min_idx])
                    {
                        min_idx = j;
                    }
                }

                double temp_nota = notas[min_idx];
                notas[min_idx] = notas[i];
                notas[i] = temp_nota;

                string temp_nombre = nombres[min_idx];
                nombres[min_idx] = nombres[i];
                nombres[i] = temp_nombre;
            }
        }

        // NUEVO MÉTODO: Ordenamiento Descendente de mayor a menor nota
        static public void Descendente()
        {
            Console.WriteLine("*******ORDENAMIENTO DESCENDENTE (Mayor a Menor)******");
            double temp_nota;
            string temp_nombre;
            for (int i = 0; i < contador - 1; i++)
            {
                for (int j = 0; j < contador - 1 - i; j++)
                {
                    if (notas[j] < notas[j + 1]) // Cambiado a '<' para que sea de mayor a menor
                    {
                        temp_nota = notas[j];
                        notas[j] = notas[j + 1];
                        notas[j + 1] = temp_nota;

                        temp_nombre = nombres[j];
                        nombres[j] = nombres[j + 1];
                        nombres[j + 1] = temp_nombre;
                    }
                }
            }
        }

        static public void Nota_maxima()
        {
            Console.WriteLine("*********NOTA MÁXIMA*********");
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados");
                return;
            }

            double max_nota = notas[0];
            string max_nombre = nombres[0];

            for (int i = 1; i < contador; i++)
            {
                if (notas[i] > max_nota)
                {
                    max_nota = notas[i];
                    max_nombre = nombres[i];
                }
            }
            Console.WriteLine("La nota más alta es " + max_nota + " del estudiante: " + max_nombre);
        }

        static public void Promedio()
        {
            Console.WriteLine("*********PROMEDIO GENERAL*********");
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados");
                return;
            }

            double suma = 0;
            for (int i = 0; i < contador; i++)
            {
                suma += notas[i];
            }
            double prom = suma / contador;
            Console.WriteLine("El promedio general de notas del salón es: " + prom.ToString("0.00"));
        }

        static public void Modificar_nota()
        {
            Console.WriteLine("*********MODIFICAR NOTA*********");
            if (contador == 0)
            {
                Console.WriteLine("Nohay estudiantes registrados");
                return;
            }
            Console.WriteLine("Ingresar nombre del estudiante: ");
            string nom_buscar = Console.ReadLine().ToLower();
            for (int i = 0; i < contador; i++)
            {
                if (nombres[i].ToLower() == nom_buscar)
                {
                    Console.WriteLine(nombres[i] + "tiene" + notas[i]);
                    double nueva_nota;
                    while (true)
                    {
                        Console.Write("Ingresar la nueva nota: ");
                        nueva_nota = double.Parse(Console.ReadLine());
                        if (nueva_nota >= 0 && nueva_nota <= 20)
                        {
                            notas[i] = nueva_nota;
                            Console.WriteLine("Nota modificada correctamente");
                            return;
                        }
                        Console.WriteLine("Nota fuera de rango [0-20]");
                    }
                }
            }
            Console.WriteLine("Estudiante no encontrado....");
        }

        static void Main(string[] args)
        {
            Titulo();
            int opc = 0;
            while (opc != 10) // Ajustado a 10 para salir
            {
                Console.WriteLine("*****MENU PRINCIPAL*********");
                Console.WriteLine("1. Registrar estudiante");
                Console.WriteLine("2. Buscar estudiantes");
                Console.WriteLine("3. Modificar nota");
                Console.WriteLine("4. Mostrar lista sin ordenar");
                Console.WriteLine("5. Ordenar con burbuja (Ascendente)");
                Console.WriteLine("6. Ordenar con Seleccion (Ascendente)");
                Console.WriteLine("7. Ordenar Descendente"); // Agregada
                Console.WriteLine("8. Ver Nota Máxima");
                Console.WriteLine("9. Ver Promedio General"); // Aquí calculas el promedio
                Console.WriteLine("10. Salir");
                Console.Write("Ingresar opcion: ");
                opc = int.Parse(Console.ReadLine());

                if (opc < 1 || opc > 10)
                {
                    Console.WriteLine("Error, opcion fuera de rango[1-10]:");
                    continue;
                }
                switch (opc)
                {
                    case 1:
                        registrar_estudiante();
                        break;
                    case 2:
                        buscar_estudiante();
                        break;
                    case 3:
                        Modificar_nota();
                        break;
                    case 4:
                        Mostrar();
                        break;
                    case 5:
                        burbuja();
                        Console.WriteLine();
                        Mostrar();
                        break;
                    case 6:
                        Seleccion();
                        Console.WriteLine();
                        Mostrar();
                        break;
                    case 7:
                        Descendente();
                        Console.WriteLine();
                        Mostrar();
                        break;
                    case 8:
                        Nota_maxima();
                        break;
                    case 9:
                        Promedio();
                        break;
                    case 10:
                        Console.WriteLine("Gracias por usar el sistema");
                        break;
                    default:
                        Console.WriteLine("Opcion incorrecta..!!");
                        break;
                }
                Console.ReadKey();
            }
        }
    }
}
