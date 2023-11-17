//using Biblioteca_uts.Models;
using Biblioteca_uts.Datos;
using Biblioteca_uts.Models;

namespace Biblioteca.Tests
{
    [TestFixture]

    public class TesteoEasy
    {
        //   private  LibrosModel libro; 
        [TestCase(42)]
        public void TestInt(int val)
        {
            Assert.That(val, Is.EqualTo(42));
        }

        [TestCase(4)]
        [TestCase(2)]
        public void TestMultiple(int x)
        {
            Assert.Multiple(() =>
            {
                Assert.That(x * 2, Is.EqualTo(4));
                Assert.That(x * 1 + 40, Is.EqualTo(42));
                Assert.That(x * 3 + 42, Is.EqualTo(48));
            });
        }


        [TestCase("Hola")]
        public void TestString(string val)
        {
            Assert.That(val, Is.EqualTo("Hola"));

        }

        //fail
        [Test]
        public void TestDouble()
        {
            double result = 4.0 + 2.0;
            Assert.That(result, Is.EqualTo(42.0).Within(0.1d), "Add double failed");
        }

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

    }
    //Segunda clase
    [TestFixture]
    public class MyTests
    {
        

        



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
