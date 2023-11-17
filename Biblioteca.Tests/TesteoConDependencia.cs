//using Biblioteca_uts.Datos;
//using Biblioteca_uts.Models;

namespace Biblioteca.Tests
{

    //Importante agregar dependencia
    
    [TestFixture]
    public class TesteoConDependencia
    {
        

        [TestCase(1, 2, 3)]
        [TestCase(0, 0, 0)]
        [TestCase(-1, 1, 0)]
        public void TestMethod(int a, int b, int expected)
        {
            // Act
            int result = a + b;

            // Assert
            Assert.AreEqual(expected, result);
        }



        [Test]
        public void TestGuardarLibrosVerdadero()
        {
            LibrosModel lib = new LibrosModel();
            LibrosDatos LDatos = new LibrosDatos();

            // Asigna los valores a las propiedades del objeto lib
            lib.No_Adquisicion = 2;
            lib.Titulo = "TEST Libro";
            lib.Fecha_adquisicion = new DateTime(2023, 10, 25, 0, 0, 0);
            lib.Ibsn = "6465-56165";
            lib.Clasificacion = "comedia";
            lib.No_Estante = 7;
            lib.Cantidad = 4;
            lib.Estatus = "Ocupado";
            lib.Procedencia = "Donado";
            lib.No_factura = "Donado";

            // Llama al método GuardarLibro con el objeto lib como argumento
            bool Lib = LDatos.GuardarLibro(lib);
            Assert.IsTrue(Lib);
        }
        [Test]
        public void TestGuardarLibrosFalso()
        {
            LibrosModel lib = new LibrosModel();
            LibrosDatos LDatos = new LibrosDatos();

            // Asigna los valores a las propiedades del objeto lib
            lib.No_Adquisicion = 2;
            lib.Titulo = "TEST Libro";
            lib.Fecha_adquisicion = new DateTime(2023, 10, 25, 0, 0, 0);
            lib.Ibsn = "6465-56165";
            lib.Clasificacion = "comedia";
            lib.No_Estante = 7;
            lib.Cantidad = 4;
            lib.Estatus = "Ocupado";
            lib.Procedencia = "Donado";
            lib.No_factura = "Donado";

            // Llama al método GuardarLibro con el objeto lib como argumento
            bool Lib = LDatos.GuardarLibro(lib);
            Assert.IsFalse(Lib);
        }
    }
}
