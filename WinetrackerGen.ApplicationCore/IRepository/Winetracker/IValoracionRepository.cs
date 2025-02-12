
using System;
using WinetrackerGen.ApplicationCore.EN.Winetracker;
using WinetrackerGen.ApplicationCore.CP.Winetracker;

namespace WinetrackerGen.ApplicationCore.IRepository.Winetracker
{
public partial interface IValoracionRepository
{
void setSessionCP (GenericSessionCP session);

ValoracionEN ReadOIDDefault (int id
                             );

void ModifyDefault (ValoracionEN valoracion);

System.Collections.Generic.IList<ValoracionEN> ReadAllDefault (int first, int size);



int New_ (ValoracionEN valoracion);

void Modify (ValoracionEN valoracion);


void Destroy (int id
              );


ValoracionEN ReadOID (int id
                      );


System.Collections.Generic.IList<ValoracionEN> ReadAll (int first, int size);
}
}
