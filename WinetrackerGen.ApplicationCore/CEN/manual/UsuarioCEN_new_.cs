
using System;
using System.Text;
using System.Collections.Generic;
using WinetrackerGen.ApplicationCore.Exceptions;
using WinetrackerGen.ApplicationCore.EN.Winetracker;
using WinetrackerGen.ApplicationCore.IRepository.Winetracker;
using WinetrackerGen.ApplicationCore.CP.Winetracker;


/*PROTECTED REGION ID(usingWinetrackerGen.ApplicationCore.CEN.Winetracker_Usuario_new_) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WinetrackerGen.ApplicationCore.CEN.Winetracker
{
public partial class UsuarioCEN
{
public string New_ (string p_nombre, string p_correo, String p_password, string p_foto, WinetrackerGen.ApplicationCore.Enumerated.Winetracker.ProvinciasEnum p_provincia)
{
        /*PROTECTED REGION ID(WinetrackerGen.ApplicationCore.CEN.Winetracker_Usuario_new__customized) ENABLED START*/

        UsuarioEN usuarioEN = null;

        string oid;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();

        usuarioEN.Nombre = p_nombre;

            if (EsCorreoValido (p_correo)) {
                usuarioEN.Correo = p_correo;
            }
            else{
                throw new Exception("El formato del correo no es v�lido.");
            }

        usuarioEN.Password = (Utils.Util.GetEncondeMD5(p_password));

            if (p_foto != null)
            {
                usuarioEN.Foto = p_foto;

            }
            else
            {
                usuarioEN.Foto = "default.png";
            }

            usuarioEN.Provincia = p_provincia;

        //Call to UsuarioRepository

        oid = _IUsuarioRepository.New_ (usuarioEN);
        return oid;
        /*PROTECTED REGION END*/
}
}
}
