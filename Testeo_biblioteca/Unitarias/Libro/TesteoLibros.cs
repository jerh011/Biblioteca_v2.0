using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca_uts.Datos;
using Biblioteca_uts.Models;

namespace Testeo_biblioteca.Unitarias.Libro
{
    public class TesteoLibros
    {
        LibrosModel _lib = new LibrosModel();
        LibrosDatos _LDatos = new LibrosDatos();

        //Testeo a para optener un libro con un No_Adquisicion en este caso "50"
        [TestCase(50)]
        public void Obtener(int id)
        {
            // Llama al método ObtenerLibro con el objeto libro como argumento
            var libro = _LDatos.ObtenerLibro(id);
            //Imprime en consola los datos de el libro obtenido
            Console.WriteLine("Numero-------:" + libro.No_Adquisicion);
            Console.WriteLine("Titulo-------:" + libro.Titulo);
            Console.WriteLine("Fecha--------:" + libro.Fecha_adquisicion);
            Console.WriteLine("Ibsn---------:" + libro.Ibsn);
            Console.WriteLine("Clasificacion:" + libro.Clasificacion);
            Console.WriteLine("Estante------:" + libro.No_Estante);
            Console.WriteLine("Cantidad-----:" + libro.Cantidad);
            Console.WriteLine("Estatus------:" + libro.Estatus);
            Console.WriteLine("Precedencia--:" + libro.Procedencia);
            Console.WriteLine("No factura---:" + libro.No_factura);
        }

        //testeo para realisar un registro en este caso con la Numero de 
        //de adquisicion "50"
        [TestCase(50)]
        [TestCase(50)]
        public void TestGuardarLibros(int id)
        {
            _lib.No_Adquisicion = id;
            _lib.Titulo = "TEST verdadero";
            _lib.Fecha_adquisicion = new DateTime(2023, 10, 25, 0, 0, 0);
            _lib.Ibsn = "646-456-1654";
            _lib.Clasificacion = "Recetas";
            _lib.No_Estante = 7;
            _lib.Cantidad = 4;
            _lib.Estatus = "Desocupados";
            _lib.Procedencia = "Comprado";
            _lib.No_factura = "Re-123ca-asd122";
            // Llama al método GuardarLibro con el objeto lib como argumento
            bool Lib = _LDatos.GuardarLibro(_lib);
            Assert.IsTrue(Lib);
        }

        //Testeo a para Editar un libro con un No_Adquisicion en este caso "50"
        [TestCase(50)]
        public void TestEditarLibros(int id)
        {
            // Asigna los valores a las propiedades del objeto lib
            _lib.No_Adquisicion = id;
            _lib.Titulo = "TEST verdadero";
            _lib.Fecha_adquisicion = new DateTime(2023, 10, 25, 0, 0, 0);
            _lib.Ibsn = "646-456-1654";
            _lib.Clasificacion = "Recetas";
            _lib.No_Estante = 7;
            _lib.Cantidad = 4;
            _lib.Estatus = "Desocupados";
            _lib.Procedencia = "Comprado";
            _lib.No_factura = "Re-123ca-asd122";

            // Llama al método editar con el objeto lib como argumento
            bool Lib = _LDatos.EditarLibro(_lib);
            Assert.IsTrue(Lib);
        }

        //testeo para realisar una eliminacion en este caso con la Numero de 
        //de adquisicion "1","50"
        [TestCase(1)]
        [TestCase(50)]
        public void TesteElimino(int id)
        {

           //llamda al metodo eliminar Lib el objeto Lib como argumento
            bool Lib = _LDatos.EliminarLibro(id);
            Assert.IsTrue(Lib);
        }


    }
}
