

using System;
using System.Collections.Generic;
using WinetrackerGen.ApplicationCore.IRepository.Winetracker;
using WinetrackerGen.ApplicationCore.Utils;

namespace WinetrackerGen.ApplicationCore.CP.Winetracker
{
public abstract class GenericBasicCP
{
protected GenericSessionCP CPSession;
protected GenericUnitOfWorkRepository unitRepo;
protected GenericUnitOfWorkUtils unitUtils;

protected GenericBasicCP (GenericSessionCP currentSession)
{
        this.CPSession = currentSession;
        this.unitRepo = this.CPSession.UnitRepo;
}
protected GenericBasicCP(GenericSessionCP currentSession, GenericUnitOfWorkUtils unitUtils)
{
        this.CPSession = currentSession;
        this.unitRepo = this.CPSession.UnitRepo;
        this.unitUtils = unitUtils;
}
protected GenericBasicCP()
{
        this.CPSession = null;
        this.unitRepo = null;
}
}
}

