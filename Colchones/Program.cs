using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Colchones
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Introduce tu nombre: ");
            string nombre = Console.ReadLine();
            Limpiar();
            Console.Write("Introduce el modelo: ");
            string tipo = Console.ReadLine();
            Limpiar();
            Console.Write("Introduce el precio unitario: ");
            float precioU = float.Parse(Console.ReadLine());
            Limpiar();

            Colchon colchon = new Colchon(nombre, tipo, precioU);
            float motomami = colchon.Calculo();
            colchon.Info();
            colchon.Desplegar(motomami);
            Limpiar();

            Socio socio = new Socio(nombre,tipo , precioU);
            motomami = socio.Calculo();
            socio.Info();
            socio.Desplegar(motomami);
            Limpiar();
        }
        static void Limpiar()
        {
            Console.WriteLine("Presiona cualquier tecla para seguir. ");
            Console.ReadKey();
            Console.Clear();
        }
    }
    abstract class Texto
    {
        public string nombre, tipo;
        public double costoU;

        public Texto(string nombre, string tipo, double costoU)
        {
            this.nombre = nombre;
            this.tipo = tipo;
            this.costoU = costoU;
        }
        public void Info()
        {
            Console.WriteLine($"Cliente: {nombre}\nMarca de colchon: {tipo}     Costo Unitaro: {costoU}");
        }
        public abstract string Mensaje();
    }
    interface IDatos
    {
        float Calculo();
        void Desplegar(float motomami);
    }
    class Colchon : Texto, IDatos
    {
        public Colchon(string nombre, string tipo, double costoU) :base(nombre,tipo,costoU)
        {
            
        }
        public float Calculo() => (float)((costoU * .15) + costoU);
        public void Desplegar(float motomami)
        {
            Console.WriteLine($"Costo con envio: {motomami}");
        }
        public override string Mensaje()
        {
            return "Mensaje desde Colchon";
        }
        ~Colchon()
        {
            Console.WriteLine("Destructor clase base");
        }       
    }
    class Socio : Texto, IDatos
    {
        public Socio(string nombre, string tipo, double costoU) :base(nombre, tipo, costoU)
        {
            
        }
        public float Calculo() => (float)(costoU - (costoU * .15));
        public void Desplegar(float motomami)
        {
            Console.WriteLine($"Costo de socio: {motomami}");
        }
        public override string Mensaje()
        {
            return "Mensaje desde Socio";
        }
        ~Socio()
        {
            Console.WriteLine("Destructor clase derivada");
            }
    }
}