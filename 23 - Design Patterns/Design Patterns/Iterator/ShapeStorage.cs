using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    class ShapeStorage
    {
        private Shape[] shapes = new Shape[6];
        private int index = 0;

        public void AddShape(string shape)
        {
            shapes[index++] = new Shape(index, shape);
        }

        public Shape[] GetShapes()
        {
            return shapes;
        }
    }
}
