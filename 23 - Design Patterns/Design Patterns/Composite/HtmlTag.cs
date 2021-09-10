using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public abstract class HtmlTag
    {
        protected abstract string GetTagName();

        public abstract void SetStartTag(string name);

        public abstract void SetEndTag(string name);

        public abstract void GenerateHtml();

        public virtual void SetTagBody(string name)
        {

        }

        public virtual void addChildTag(HtmlTag tag)
        {

        }

        public virtual void RemoveChildTag(HtmlTag tag)
        {

        }

        public virtual List<HtmlTag> GetChildren()
        {
            return new List<HtmlTag>();
        }

    }
}
