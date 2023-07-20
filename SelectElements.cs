using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Selection;

namespace LKBIM.Functions
{
    class SelectElements
    {
        public List<Element> selectelements(UIDocument uidoc, Document doc)
        {
            IList<Reference> pickedObj = uidoc.Selection.PickObjects(ObjectType.Element, "Select elements");
            List<ElementId> ids = (from Reference r in pickedObj select r.ElementId).ToList();
            List<Element> list = new List<Element>();
            foreach (ElementId id in ids)
            {
                Element ele = doc.GetElement(id);
                list.Add(ele);
            }
            
            
            return list;
        }
        //SelectElements sc = new SelectElements();
        //List<Element> ele = sc.selectelements(uidoc, doc);


    }
}


