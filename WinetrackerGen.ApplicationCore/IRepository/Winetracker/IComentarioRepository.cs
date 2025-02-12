
using System;
using WinetrackerGen.ApplicationCore.EN.Winetracker;
using WinetrackerGen.ApplicationCore.CP.Winetracker;

namespace WinetrackerGen.ApplicationCore.IRepository.Winetracker
{
public partial interface IComentarioRepository
{
void setSessionCP (GenericSessionCP session);

ComentarioEN ReadOIDDefault (int id
                             );

void ModifyDefault (ComentarioEN comentario);

System.Collections.Generic.IList<ComentarioEN> ReadAllDefault (int first, int size);



int New_ (ComentarioEN comentario);

void Modify (ComentarioEN comentario);


void Destroy (int id
              );



ComentarioEN ReadOID (int id
                      );


System.Collections.Generic.IList<ComentarioEN> ReadAll (int first, int size);


System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ComentarioEN> DameComentarioPorArticulo (int ? p_articulo);
}
}
