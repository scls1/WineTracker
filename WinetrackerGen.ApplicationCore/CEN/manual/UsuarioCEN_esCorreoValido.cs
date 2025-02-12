
using System;
using System.Text;
using System.Collections.Generic;
using WinetrackerGen.ApplicationCore.Exceptions;
using WinetrackerGen.ApplicationCore.EN.Winetracker;
using WinetrackerGen.ApplicationCore.IRepository.Winetracker;


/*PROTECTED REGION ID(usingWinetrackerGen.ApplicationCore.CEN.Winetracker_Usuario_esCorreoValido) ENABLED START*/
//  references to other libraries
using System.Text.RegularExpressions;
/*PROTECTED REGION END*/

namespace WinetrackerGen.ApplicationCore.CEN.Winetracker
{
public partial class UsuarioCEN
{
public bool EsCorreoValido (string p_email)
{
        /*PROTECTED REGION ID(WinetrackerGen.ApplicationCore.CEN.Winetracker_Usuario_esCorreoValido) ENABLED START*/


        // Expresi�n regular actualizada seg�n las reglas
        string patron = @"^[A-Za-z0-9]+[A-Za-z0-9._-]*[A-Za-z0-9]+@[A-Za-z]+\.[A-Za-z]+$";

        return Regex.IsMatch (p_email, patron);



        /*PROTECTED REGION END*/
}
}
}
