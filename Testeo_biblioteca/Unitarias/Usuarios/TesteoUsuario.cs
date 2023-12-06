using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca_uts.Controllers;
using Biblioteca_uts.Datos;
using Biblioteca_uts.Models;

namespace Testeo_biblioteca.Unitarias.Usuarios
{
    public class TesteoUsuario
    {
        UsariosModels _usuarios = new UsariosModels();
        UsuarioDatos _LDatos = new UsuarioDatos();

        //obtener
        [TestCase(123)]
        public void Obtener(int id)
        {
            var _Usuarios = _LDatos.ObtenerUsuario(id);
            Console.WriteLine("Identificador:" + _Usuarios.Identificador);
            Console.WriteLine("Nombres------:" + _Usuarios.Nombres);
            Console.WriteLine("ApePa--------:" + _Usuarios.ApePa);
            Console.WriteLine("ApeMa--------:" + _Usuarios.ApeMa);
            Console.WriteLine("Correo-------:" + _Usuarios.Correo);
            Console.WriteLine("Calle--------:" + _Usuarios.Calle);
            Console.WriteLine("Colonia------:" + _Usuarios.Colonia);
            Console.WriteLine("NroCasa------:" + _Usuarios.NroCasa);
            Console.WriteLine("tipo---------:" + _Usuarios.tipo);
            Console.WriteLine("Contraseña---:" + _Usuarios.Contraseña);
            Console.WriteLine("Usuario------:" + _Usuarios.Usuario);
        }
        //Guardar
        [Test]
        public void TestGuardarprestamossVerdadero()
        {
            _usuarios.Identificador = 0;
            _usuarios.Nombres = "Testeo_Nombrer";
            _usuarios.ApePa = "Testeo_Pateno";
            _usuarios.ApeMa = "Testeo_Materno";
            _usuarios.Correo = "Testeo_Correo";
            _usuarios.Calle = "Testeo_Calle";
            _usuarios.Colonia = "Testeo_Colonia";
            _usuarios.NroCasa = "Testeo_NumeroCasa";
            _usuarios.tipo = "Testeo_Tipo";
            _usuarios.Contraseña = "Testeo_Contraseña";
            _usuarios.Usuario = "Testeo_Usuario";

            bool _Pres = _LDatos.GuardarUsuario(_usuarios);
            Assert.IsTrue(_Pres);
        }

        [Test]
        public void TestGuardarprestamossFalso()
        {
            _usuarios.Identificador = 0;
            _usuarios.Nombres = "Testeo_Nombrer";
            _usuarios.ApePa = "Testeo_Pateno";
            _usuarios.ApeMa = "Testeo_Materno";
            _usuarios.Correo = "Testeo_Correo";
            _usuarios.Calle = "Testeo_Calle";
            _usuarios.Colonia = "Testeo_Colonia";
            _usuarios.NroCasa = "Testeo_NumeroCasa";
            _usuarios.tipo = "Testeo_Tipo";
            _usuarios.Contraseña = "Testeo_Contraseña";
            _usuarios.Usuario = "Testeo_Usuario";

            bool _Usuario = _LDatos.GuardarUsuario(_usuarios);
            Assert.IsFalse(_Usuario);

        }

        //Editar
        [Test]
        public void TestEditarprestamossVerdadero()
        {
            _usuarios.Identificador = 0;
            _usuarios.Nombres = "Jesus Eloy";
            _usuarios.ApePa = "Rodriguez";
            _usuarios.ApeMa = "Hernandez";
            _usuarios.Correo = "Testeo_Correo";
            _usuarios.Calle = "Testeo_Calle";
            _usuarios.Colonia = "Testeo_Colonia";
            _usuarios.NroCasa = "Nro_Casa";
            _usuarios.tipo = "Testeo_Tipo";
            _usuarios.Contraseña = "Testeo_Contraseña";
            _usuarios.Usuario = "Test_Usuario";

            bool _Usuario = _LDatos.EditarUsuario(_usuarios);
            Assert.IsTrue(_Usuario);
        }

        [TestCase(5)]
        public void TestEditarprestamossFalso(int Id)
        {
            _usuarios.Identificador = 0;
            _usuarios.Nombres = "Testeo_Nombrer";
            _usuarios.ApePa = "Testeo_Pateno";
            _usuarios.ApeMa = "Testeo_Materno";
            _usuarios.Correo = "Testeo_Correo";
            _usuarios.Calle = "Testeo_Calle";
            _usuarios.Colonia = "Testeo_Colonia";
            _usuarios.NroCasa = "Nro_Casa";
            _usuarios.tipo = "Testeo_Tipo";
            _usuarios.Contraseña = "Testeo_Contraseña";
            _usuarios.Usuario = "Test_Usuario";

            bool _Usuario = _LDatos.EditarUsuario(_usuarios);
            Assert.IsFalse(_Usuario);
        }

        //Eliminar
        [TestCase(5)]
        public void TesteEliminoprestamosVerdadero(int Id)
        {
            bool _Pres = _LDatos.EliminarUsuario(2);
            Assert.IsTrue(_Pres);
        }

        [TestCase(5)]
        public void TesteEliminoprestamosFalso(int Id)
        {
            bool _Pres = _LDatos.EliminarUsuario(2);
            Assert.IsFalse(_Pres);
        }

    }
}