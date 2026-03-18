using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace drabeg_Forms_14_03
{
    class Producto
    {
        //Definir una propiedad automática llamada Código de tipo string con acceso público para lectura (get) y escritura (set)
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int Cantidad { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
        public string Garantia { get; set; }
        public DateTime FechaGarantia { get; set; }

        //Creación de un constructor. Es un método especial que se ejecuta automáticamente al crear una instancia de la clase.
        //El constructor se utiliza para inicializar los objetos de la clase con valores específicos.

        public Producto(string codigo, string nombre, int cantidad, double precio, int stock, string garantia, DateTime fechaGarantia)
        {
            Codigo = codigo;
            Nombre = nombre;
            Cantidad = cantidad;
            Precio = precio;
            Stock = stock;
            Garantia = garantia;
            FechaGarantia = fechaGarantia;
        }
    }
}
