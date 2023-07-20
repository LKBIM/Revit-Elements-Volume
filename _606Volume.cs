using System;
using System.Collections.Generic;
using System.Text;
using Autodesk.Revit;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;
using System.Windows.Forms;
using LKBIM.Functions;
using static Autodesk.Revit.DB.SpecTypeId;
using System.Linq;

namespace LKBIM
{
    [Autodesk.Revit.Attributes.Transaction(Autodesk.Revit.Attributes.TransactionMode.ReadOnly)]
    [Autodesk.Revit.Attributes.Regeneration(Autodesk.Revit.Attributes.RegenerationOption.Manual)]
    [Autodesk.Revit.Attributes.Journaling(Autodesk.Revit.Attributes.JournalingMode.NoCommandData)]
    public class _606Volume : IExternalCommand
    {
        public Autodesk.Revit.UI.Result Execute(ExternalCommandData commandData, ref string message,
            ElementSet elements)
        {
            Autodesk.Revit.UI.UIApplication uiapp = commandData.Application;
            UIDocument uidoc = uiapp.ActiveUIDocument;
            Document doc = uidoc.Document;
            try
            {
                //select elements
                SelectElements seletion = new SelectElements();
                List<Element> ele = seletion.selectelements(uidoc, doc);
                //Check if Element's geoemtry exists
                Options goptions = new Options();
                goptions.DetailLevel = ViewDetailLevel.Fine;
                List<GeometryElement> a1 = new List<GeometryElement>();    
                foreach (Element el in ele)
                {
                    GeometryElement a = el.get_Geometry(goptions);
                    a1.Add(a);
                }
                if (a1.Contains(null))
                {
                    TaskDialog.Show("Cancel", "Only Geometrical Elements are allowded");
                    return Result.Failed;
                }
                //GetVolume
                List<double> vol = new List<double>();
                foreach (Element Eelem in ele)
                {
                    Parameter param = Eelem.get_Parameter(BuiltInParameter.HOST_VOLUME_COMPUTED);
                    if (param != null)
                    {
                        vol.Add(Eelem.get_Parameter(BuiltInParameter.HOST_VOLUME_COMPUTED).AsDouble());
                    }
                    else
                    {
                        vol.Add(0);
                    }
                }
                string c = ele.Count.ToString();
                double obj = 0;
                for (int i = 0; i < vol.Count; i++)
                {
                    obj += vol[i];
                }
                obj = UnitUtils.ConvertFromInternalUnits(obj, UnitTypeId.CubicMeters);
                obj = Math.Round(obj, 3, MidpointRounding.ToEven);

                //Form

                _606Form propertiesForm = new _606Form(c, obj);
                propertiesForm.ShowDialog();
                return Result.Succeeded;
            }
            catch (Exception e)
            {
                TaskDialog.Show("Cancel", "Operation Canceled");
                return Result.Failed;
            }
        }
    }
}
