

using System;
using System.Text;
using System.Collections.Generic;

using WinetrackerGen.ApplicationCore.Exceptions;

using WinetrackerGen.ApplicationCore.EN.Winetracker;
using WinetrackerGen.ApplicationCore.IRepository.Winetracker;
using Newtonsoft.Json;
using WinetrackerGen.ApplicationCore.Enumerated.Winetracker;


namespace WinetrackerGen.ApplicationCore.CEN.Winetracker
{
/*
 *      Definition of the class UsuarioCEN
 *
 */
public partial class UsuarioCEN
{
private IUsuarioRepository _IUsuarioRepository;

public UsuarioCEN(IUsuarioRepository _IUsuarioRepository)
{
        this._IUsuarioRepository = _IUsuarioRepository;
}

public IUsuarioRepository get_IUsuarioRepository ()
{
        return this._IUsuarioRepository;
}
        public void Modify(string p_Usuario_OID, string p_nombre, string p_password, string p_foto, ProvinciasEnum p_provincia)
        {
            UsuarioEN usuarioEN = _IUsuarioRepository.ReadOID(p_Usuario_OID); // Leer el usuario actual
            if (usuarioEN == null)
            {
                throw new Exception("El usuario no existe.");
            }

            System.Diagnostics.Debug.WriteLine($"Modify - Antes de actualizar: Nombre={usuarioEN.Nombre}, Password={usuarioEN.Password}, Foto={usuarioEN.Foto}");

            // Actualizar campos solo si no son nulos
            usuarioEN.Nombre = p_nombre ?? usuarioEN.Nombre;

            // Si la contraseña es nula o vacía, no modificarla
            if (!string.IsNullOrEmpty(p_password))
            {
                System.Diagnostics.Debug.WriteLine($"Modify - Contraseña modificada.");
                usuarioEN.Password = p_password;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine($"Modify - Contraseña no modificada.");
            }

            usuarioEN.Foto = p_foto ?? usuarioEN.Foto;
            usuarioEN.Provincia = p_provincia;

            System.Diagnostics.Debug.WriteLine($"Modify - Después de actualizar: Nombre={usuarioEN.Nombre}, Password={usuarioEN.Password}, Foto={usuarioEN.Foto}");

            _IUsuarioRepository.Modify(usuarioEN);
        }



        public void Destroy (string correo
                     )
{
        _IUsuarioRepository.Destroy (correo);
}

public UsuarioEN ReadOID (string correo
                          )
{
        UsuarioEN usuarioEN = null;

        usuarioEN = _IUsuarioRepository.ReadOID (correo);
        return usuarioEN;
}

public System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size)
{
        System.Collections.Generic.IList<UsuarioEN> list = null;

        list = _IUsuarioRepository.ReadAll (first, size);
        return list;
}
public string Login (string p_Usuario_OID, string p_pass)
{
        string result = null;
        UsuarioEN en = _IUsuarioRepository.ReadOIDDefault (p_Usuario_OID);

        if (en != null && en.Password.Equals (Utils.Util.GetEncondeMD5 (p_pass)))
                result = this.GetToken (en.Correo);

        return result;
}




private string Encode (string nombre, string correo)
{
        var payload = new Dictionary<string, object>(){
                { "nombre", nombre }, { "correo", correo }
        };
        string token = Jose.JWT.Encode (payload, Utils.Util.getKey (), Jose.JwsAlgorithm.HS256);

        return token;
}

public string GetToken (string correo)
{
        UsuarioEN en = _IUsuarioRepository.ReadOIDDefault (correo);
        string token = Encode (en.Nombre, en.Correo);

        return token;
}
public string CheckToken (string token)
{
        string result = null;

        try
        {
                string decodedToken = Utils.Util.Decode (token);



                string id = (string)ObtenerCORREO (decodedToken);

                UsuarioEN en = _IUsuarioRepository.ReadOIDDefault (id);

                if (en != null && ((string)en.Correo).Equals (ObtenerCORREO (decodedToken))
                    && ((string)en.Nombre).Equals (ObtenerNOMBRE (decodedToken))) {
                        result = id;
                }
                else throw new ModelException ("El token es incorrecto");
        } catch (Exception)
        {
                throw new ModelException ("El token es incorrecto");
        }

        return result;
}


public string ObtenerNOMBRE (string decodedToken)
{
        try
        {
                Dictionary<string, object> results = JsonConvert.DeserializeObject<Dictionary<string, object> >(decodedToken);
                string nombre = (string)results ["nombre"];
                return nombre;
        }
        catch
        {
                throw new Exception ("El token enviado no es correcto");
        }
}

public string ObtenerCORREO (string decodedToken)
{
        try
        {
                Dictionary<string, object> results = JsonConvert.DeserializeObject<Dictionary<string, object> >(decodedToken);
                string correo = (string)results ["correo"];
                return correo;
        }
        catch
        {
                throw new Exception ("El token enviado no es correcto");
        }
}
}
}
