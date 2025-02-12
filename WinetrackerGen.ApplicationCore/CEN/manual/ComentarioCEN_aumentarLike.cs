
using System;
using System.Text;
using System.Collections.Generic;
using WinetrackerGen.ApplicationCore.Exceptions;
using WinetrackerGen.ApplicationCore.EN.Winetracker;
using WinetrackerGen.ApplicationCore.IRepository.Winetracker;


/*PROTECTED REGION ID(usingWinetrackerGen.ApplicationCore.CEN.Winetracker_Comentario_aumentarLike) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace WinetrackerGen.ApplicationCore.CEN.Winetracker
{
public partial class ComentarioCEN
{
public void AumentarLike (int p_oid)
{
        /*PROTECTED REGION ID(WinetrackerGen.ApplicationCore.CEN.Winetracker_Comentario_aumentarLike) ENABLED START*/

        ComentarioEN comentarioEN = _IComentarioRepository.ReadOID (p_oid);


        comentarioEN.NumLikes += 1;


        _IComentarioRepository.ModifyDefault (comentarioEN);


        /*PROTECTED REGION END*/
}
}
}
