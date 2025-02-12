
using System;
using System.Text;
using System.Collections.Generic;
using WinetrackerGen.ApplicationCore.Exceptions;
using WinetrackerGen.ApplicationCore.EN.Winetracker;
using WinetrackerGen.ApplicationCore.IRepository.Winetracker;
using System.Text.RegularExpressions;


/*PROTECTED REGION ID(usingWinetrackerGen.ApplicationCore.CEN.Winetracker_Usuario_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WinetrackerGen.ApplicationCore.CEN.Winetracker
{
    public partial class UsuarioCEN
    {
        public int New_(int p_id, string p_nombre, string p_correo, string p_password, string p_foto, WinetrackerGen.ApplicationCore.Enumerated.Winetracker.ProvinciasEnum p_provincia)
        {
            /*PROTECTED REGION ID(WinetrackerGen.ApplicationCore.CEN.Winetracker_Usuario_new__customized) START*/

            UsuarioEN usuarioEN = null;

            int oid;

            //Initialized UsuarioEN
            usuarioEN = new UsuarioEN();
            usuarioEN.Id = p_id;

            usuarioEN.Nombre = p_nombre;

            if (EsCorreoValido(p_correo))
            {

                usuarioEN.Correo = p_correo;

            }
            else
            {
                throw new Exception("El formato del correo no es válido.");
            }

            usuarioEN.Password = p_password;

            usuarioEN.Foto = p_foto;

            usuarioEN.Provincia = p_provincia;

            //Call to UsuarioRepository

            oid = _IUsuarioRepository.New_(usuarioEN);
            return oid;
            /*PROTECTED REGION END*/
        }

        private bool EsCorreoValido(string p_correo)
        {
            string patron = @"^[A-Za-z0-9]+[A-Za-z0-9._-]*[A-Za-z0-9]+@[A-Za-z]+\.[A-Za-z]+$";
            return Regex.IsMatch(p_correo, patron);
        }
    }
}
