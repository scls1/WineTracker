

using System;
using System.Text;
using System.Collections.Generic;

using WinetrackerGen.ApplicationCore.Exceptions;

using WinetrackerGen.ApplicationCore.EN.Winetracker;
using WinetrackerGen.ApplicationCore.IRepository.Winetracker;


namespace WinetrackerGen.ApplicationCore.CEN.Winetracker
{
/*
 *      Definition of the class MegustaCEN
 *
 */
public partial class MegustaCEN
{
private IMegustaRepository _IMegustaRepository;

public MegustaCEN(IMegustaRepository _IMegustaRepository)
{
        this._IMegustaRepository = _IMegustaRepository;
}

public IMegustaRepository get_IMegustaRepository ()
{
        return this._IMegustaRepository;
}

public void Modify (int p_Megusta_OID)
{
        MegustaEN megustaEN = null;

        //Initialized MegustaEN
        megustaEN = new MegustaEN ();
        megustaEN.Id = p_Megusta_OID;
        //Call to MegustaRepository

        _IMegustaRepository.Modify (megustaEN);
}

public void Destroy (int id
                     )
{
        _IMegustaRepository.Destroy (id);
}
}
}
