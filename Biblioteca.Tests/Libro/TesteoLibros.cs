using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca_uts.Datos;
using Biblioteca_uts.Models;

namespace Biblioteca_Tests.Libro
{
    public class TesteoLibros
    {
        LibrosModel _lib = new LibrosModel();
        LibrosDatos _LDatos = new LibrosDatos();

        //obtener
        [Test]
        public void Obtener() {
            var libro = _LDatos.ObtenerLibro(1);
            Console.WriteLine(libro.No_Adquisicion);
            Console.WriteLine(libro.Titulo);
            Console.WriteLine(libro.Fecha_adquisicion);
            Console.WriteLine(libro.Ibsn);
            Console.WriteLine(libro.Clasificacion);
            Console.WriteLine(libro.No_Estante);
            Console.WriteLine(libro.Cantidad);
            Console.WriteLine(libro.Estatus);
            Console.WriteLine(libro.Procedencia);
            Console.WriteLine(libro.No_factura);
        }
        //Guardar
        [Test]
        public void TestGuardarLibrosVerdadero()
        {
            // Asigna los valores a las propiedades del objeto lib
            _lib.No_Adquisicion = 2;
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

        [Test]
        public void TestGuardarLibrosFalso()
        {
            // Asigna los valores a las propiedades del objeto lib
            _lib.No_Adquisicion = 2;
            _lib.Titulo = "TEST Falso";
            _lib.Fecha_adquisicion = new DateTime(2023, 10, 25, 0, 0, 0);
            _lib.Ibsn = "646-556-5165";
            _lib.Clasificacion = "comedia";
            _lib.No_Estante = 7;
            _lib.Cantidad = 4;
            _lib.Estatus = "Ocupado";
            _lib.Procedencia = "Donado";
            _lib.No_factura = "Donado";

            // Llama al método GuardarLibro con el objeto lib como argumento
            bool _Lib = _LDatos.GuardarLibro(_lib);
            Assert.IsFalse(_Lib);
        }

        //Editar
        [Test]
        public void TestEditarLibrosVerdadero()
        {
            // Asigna los valores a las propiedades del objeto lib
            _lib.No_Adquisicion = 2;
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
            bool Lib = _LDatos.EditarLibro(_lib);
            Assert.IsTrue(Lib);
        }

        [Test]
        public void TestEditarLibrosFalso()
        {
            // Asigna los valores a las propiedades del objeto lib
            _lib.No_Adquisicion = 2;
            _lib.Titulo = "TEST Falso";
            _lib.Fecha_adquisicion = new DateTime(2023, 10, 25, 0, 0, 0);
            _lib.Ibsn = "646-556-5165";
            _lib.Clasificacion = "comedia";
            _lib.No_Estante = 7;
            _lib.Cantidad = 4;
            _lib.Estatus = "Ocupado";
            _lib.Procedencia = "Donado";
            _lib.No_factura = "Donado";

            // Llama al método GuardarLibro con el objeto lib como argumento
            bool _Lib = _LDatos.EditarLibro(_lib);
            Assert.IsFalse(_Lib);
        }
 
        //Eliminar
        [Test]
        public void TesteEliminoLibroVerdadero()
        {
            bool Lib = _LDatos.EliminarLibro(2);
            Assert.IsTrue(Lib);
        }

        [Test]
        public void TesteEliminoLibroFalso()
        {
            bool Lib = _LDatos.EliminarLibro(2);
            Assert.IsFalse(Lib);
        }
        
    }
}
