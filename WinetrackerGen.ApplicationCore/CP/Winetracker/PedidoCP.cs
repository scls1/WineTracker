
using System;
using System.Text;
using System.Collections.Generic;
using WinetrackerGen.ApplicationCore.Exceptions;
using WinetrackerGen.ApplicationCore.EN.Winetracker;
using WinetrackerGen.ApplicationCore.IRepository.Winetracker;
using WinetrackerGen.ApplicationCore.CEN.Winetracker;
using WinetrackerGen.ApplicationCore.Utils;



namespace WinetrackerGen.ApplicationCore.CP.Winetracker
{
public partial class PedidoCP : GenericBasicCP
{
public PedidoCP(GenericSessionCP currentSession)
        : base (currentSession)
{
}

public PedidoCP(GenericSessionCP currentSession, GenericUnitOfWorkUtils unitUtils)
        : base (currentSession, unitUtils)
{
}
}
}
