using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iterator
{
    public class ShapeIterator : Iterator<Shape>
    {
        private Shape[] shapes;
        public int position = 0;

        public ShapeIterator(Shape[] shape)
        {
            this.shapes = shape;
        }

        public bool HasNext()
        {
            return this.position < shapes.Length && shapes[this.position] is not null;
        }

        public Shape Next()
        {
            return this.shapes[this.position++];
        }

        public void Remove()
        {
            for (int i = position - 1; i < shapes.Length - 1; i++)
                this.shapes[i] = this.shapes[i+1];
        }

    }
}
