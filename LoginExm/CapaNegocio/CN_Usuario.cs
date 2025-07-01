using System;
using System.Security.Cryptography;
using System.Text;
using Capa_Datos;
using System.Data;

namespace Capa_Negocio
{
    public class CN_Usuarios
    {
        private CD_Usuarios datosUsuarios = new CD_Usuarios();

        public string RegistrarUsuario(string cedula, string nombre, string apellido, DateTime fechaNacimiento, string clavePlano, int tipoUsuarioId)
        {
            int edadMeses = CalcularEdadMeses(fechaNacimiento);
            string clasificacionEdad = ClasificarEdad(edadMeses);
            string signoZodiacal = ObtenerSignoZodiacal(fechaNacimiento);
            string nick = GenerarNick(nombre, apellido, cedula);
            byte[] claveHash = GenerarClave(clavePlano);

            bool registroExitoso = datosUsuarios.InsertarUsuario(
                cedula, nombre, apellido, claveHash,
                fechaNacimiento, signoZodiacal,
                edadMeses, clasificacionEdad,
                nick, tipoUsuarioId
            );

            if (registroExitoso)
                return nick;
            else
                return null;
        }


        public bool CambiarClave(int id, string nuevaClave)
        {
            byte[] claveHash = GenerarClave(nuevaClave);
            return datosUsuarios.ActualizarClaveFinal(id, claveHash);
        }



        public DataRow ValidarLogin(string nick, string clavePlano)
        {
            byte[] claveHash = GenerarClave(clavePlano);
            return datosUsuarios.ValidarLogin(nick, claveHash);
        }

        private int CalcularEdadMeses(DateTime fechaNac)
        {
            DateTime ahora = DateTime.Now;
            int meses = ((ahora.Year - fechaNac.Year) * 12) + ahora.Month - fechaNac.Month;
            return meses;
        }

        private string ClasificarEdad(int edadMeses)
        {
            int edadAnios = edadMeses / 12;
            if (edadAnios <= 12) return "Niño";
            if (edadAnios <= 25) return "Joven";
            if (edadAnios <= 60) return "Adulto";
            return "Tercera Edad";
        }

        private string ObtenerSignoZodiacal(DateTime fechaNac)
        {
            int dia = fechaNac.Day;
            int mes = fechaNac.Month;

            if ((mes == 3 && dia >= 21) || (mes == 4 && dia <= 19)) return "Aries";
            if ((mes == 4 && dia >= 20) || (mes == 5 && dia <= 20)) return "Tauro";
            if ((mes == 5 && dia >= 21) || (mes == 6 && dia <= 20)) return "Géminis";
            if ((mes == 6 && dia >= 21) || (mes == 7 && dia <= 22)) return "Cáncer";
            if ((mes == 7 && dia >= 23) || (mes == 8 && dia <= 22)) return "Leo";
            if ((mes == 8 && dia >= 23) || (mes == 9 && dia <= 22)) return "Virgo";
            if ((mes == 9 && dia >= 23) || (mes == 10 && dia <= 22)) return "Libra";
            if ((mes == 10 && dia >= 23) || (mes == 11 && dia <= 21)) return "Escorpio";
            if ((mes == 11 && dia >= 22) || (mes == 12 && dia <= 21)) return "Sagitario";
            if ((mes == 12 && dia >= 22) || (mes == 1 && dia <= 19)) return "Capricornio";
            if ((mes == 1 && dia >= 20) || (mes == 2 && dia <= 18)) return "Acuario";
            return "Piscis";
        }


        private string GenerarNick(string nombre, string apellido, string cedula)
        {
            Random rnd = new Random();
            string random3 = rnd.Next(100, 1000).ToString();
            string inicialNombre = nombre.Substring(0, 1).ToUpper();
            string letraFinalApellido = apellido.Substring(apellido.Length - 1, 1).ToUpper();
            string cedulaIntermedio = cedula.Substring(3, 4);
            return random3 + inicialNombre + letraFinalApellido + cedulaIntermedio;
        }

        private byte[] GenerarClave(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(Encoding.UTF8.GetBytes(input.Trim()));
            }
        }


        public DataRow ObtenerDetallesUsuario(int id)
        {
            return datosUsuarios.ObtenerDetallesUsuario(id);
        }

        public string GenerarClaveTemporal(string nick)
        {
            string claveTemporal = GenerarCodigoTemporal();
            byte[] claveHash = GenerarClave(claveTemporal);

            bool actualizado = datosUsuarios.ActualizarClaveTemporal(nick, claveHash);

            if (actualizado)
            {
                return claveTemporal; // Devolvemos la clave temporal para mostrarla luego
            }
            else
            {
                return null;
            }
        }


        private string GenerarCodigoTemporal()
        {
            const string caracteres = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random rnd = new Random();
            char[] buffer = new char[6];
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = caracteres[rnd.Next(caracteres.Length)];
            }
            return new string(buffer);
        }

        public DataRow ObtenerEstadoUsuario(int id)
        {
            return datosUsuarios.ObtenerEstadoUsuario(id);
        }


    }
}
