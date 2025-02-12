
using System;
using WinetrackerGen.ApplicationCore.EN.Winetracker;
using WinetrackerGen.ApplicationCore.CP.Winetracker;

namespace WinetrackerGen.ApplicationCore.IRepository.Winetracker
{
public partial interface IUsuarioRepository
{
void setSessionCP (GenericSessionCP session);

UsuarioEN ReadOIDDefault (string correo
                          );

void ModifyDefault (UsuarioEN usuario);

System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size);



string New_ (UsuarioEN usuario);

void Modify (UsuarioEN usuario);


void Destroy (string correo
              );


UsuarioEN ReadOID (string correo
                   );


System.Collections.Generic.IList<UsuarioEN> ReadAll (int first, int size);
}
}
