using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prjVolumen.Shape
{
    interface IShapeScreen
    {
        Double getArea();
    }

    interface IMainScreen
    {
        void updateArea(Double area);
    }
}
