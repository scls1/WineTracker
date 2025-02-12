
using System;
using WinetrackerGen.ApplicationCore.EN.Winetracker;
using WinetrackerGen.ApplicationCore.CP.Winetracker;

namespace WinetrackerGen.ApplicationCore.IRepository.Winetracker
{
public partial interface IMegustaRepository
{
void setSessionCP (GenericSessionCP session);

MegustaEN ReadOIDDefault (int id
                          );

void ModifyDefault (MegustaEN megusta);

System.Collections.Generic.IList<MegustaEN> ReadAllDefault (int first, int size);



int New_ (MegustaEN megusta);

void Modify (MegustaEN megusta);


void Destroy (int id
              );
}
}
