
using System;
using WinetrackerGen.ApplicationCore.EN.Winetracker;
using WinetrackerGen.ApplicationCore.CP.Winetracker;

namespace WinetrackerGen.ApplicationCore.IRepository.Winetracker
{
public partial interface IArticuloRepository
{
void setSessionCP (GenericSessionCP session);

ArticuloEN ReadOIDDefault (int id
                           );

void ModifyDefault (ArticuloEN articulo);

System.Collections.Generic.IList<ArticuloEN> ReadAllDefault (int first, int size);



int New_ (ArticuloEN articulo);

void Modify (ArticuloEN articulo);


void Destroy (int id
              );


ArticuloEN ReadOID (int id
                    );


System.Collections.Generic.IList<ArticuloEN> ReadAll (int first, int size);



System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN> DameArticuloPorVino (WinetrackerGen.ApplicationCore.Enumerated.Winetracker.VinosEnum ? p_tipoVino);


System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN> DameArticuloPorUva (WinetrackerGen.ApplicationCore.Enumerated.Winetracker.UvasEnum ? p_tipoUva);


System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN> DameArticuloPorMaridaje (WinetrackerGen.ApplicationCore.Enumerated.Winetracker.MaridajeEnum ? p_maridaje);


System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN> DameArticuloPorRegion (WinetrackerGen.ApplicationCore.Enumerated.Winetracker.RegionEnum ? p_region);


System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN> DameArticuloPorPrecio (float ? p_presupuesto);


System.Collections.Generic.IList<WinetrackerGen.ApplicationCore.EN.Winetracker.ArticuloEN> DameArticuloPorUsuario (string p_usuario);
}
}
