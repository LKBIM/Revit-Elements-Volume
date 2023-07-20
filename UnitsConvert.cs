using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;

namespace MyRevitCommands.Funkcje
{
    class UnitsConvert
    {
        public static double UC(double a)
        {
            double b = UnitUtils.ConvertToInternalUnits(a, UnitTypeId.Meters);
            return b;
        }

    }
}
//double c = UnitsConvert.UC(1);