using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca_uts.Controllers;
using Biblioteca_uts.Datos;
using Biblioteca_uts.Models;

namespace Testeo_biblioteca.Unitarias.Prestamos
{
    public class TesteoPestamos
    {
        PrestamosModels _prestamos = new PrestamosModels();
        PrestamosDatos _LDatos = new PrestamosDatos();
        CMT_PrestamoModels _CMT_PrestamoModels = new CMT_PrestamoModels();
        //obtener
        [TestCase(1)]
        public void Obtener(int id)
        {
            var prestamos = _LDatos.ObtenerPrestamo(id);
            Console.WriteLine("Id_Prestamo-----:" + prestamos.IdPrestamo);
            Console.WriteLine("Identificador---:" + prestamos.Identificador);
            Console.WriteLine("Fecha_Prestamo--:" + prestamos.Fecha_prestamo);
            Console.WriteLine("Fecha_Devolucion:" + prestamos.Fecha_devolucion);
            Console.WriteLine("No_Adquisicion--:" + prestamos.No_Adquisicion);
        }
        //Guardar
        [Test]
        public void TestGuardarprestamossVerdadero()
        {
            _prestamos.IdPrestamo = 0;
            _prestamos.Identificador = 1;
            _prestamos.Fecha_prestamo = new DateTime(2023, 10, 25, 0, 0, 0);
            _prestamos.Fecha_devolucion = new DateTime(2023, 10, 25, 0, 0, 0);
            _prestamos.No_Adquisicion = 1;

            bool _Pres = _LDatos.GuardarPrestamo(_prestamos);
            Assert.IsTrue(_Pres);
        }

        
        //Editar
        [Test]
        public void TestEditarprestamossVerdadero()
        {
            _prestamos.IdPrestamo = 0;
            _prestamos.Identificador = 1;
            _prestamos.Fecha_prestamo = new DateTime(2023, 10, 25, 0, 0, 0);
            _prestamos.Fecha_devolucion = new DateTime(2023, 10, 25, 0, 0, 0);
            _prestamos.No_Adquisicion = 1;

            bool _Pres = _LDatos.EditarPrestamo(_prestamos);
            Assert.IsTrue(_Pres);
        }

        //Eliminar
        [TestCase(5)]
        public void TesteEliminoprestamosVerdadero(int Id)
        {
            bool _Pres = _LDatos.EliminarPrestamo(2);
            Assert.IsTrue(_Pres);
        }

    }
}
