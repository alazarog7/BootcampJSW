using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public class HtmlParentElement : HtmlTag
    {

        private string TagName;
        private string StartTag;
        private string EndTag;
        private List<HtmlTag> ChildrenTag = new List<HtmlTag>();

        public HtmlParentElement(string name)
        {
            this.TagName = name;
        }

        public override void GenerateHtml()
        {
            Console.WriteLine(this.StartTag);

            foreach(var element in ChildrenTag)
            {
                element.GenerateHtml();
            }

            Console.WriteLine(this.EndTag);
        }

        protected override string GetTagName()
        {
            return this.TagName;
        }

        public override void SetEndTag(string name)
        {
            this.EndTag = name;
        }

        public override void SetStartTag(string name)
        {
            this.StartTag = name;
        }

        public override void addChildTag(HtmlTag tag)
        {
            this.ChildrenTag.Add(tag);
        }

        public override void RemoveChildTag(HtmlTag tag)
        {
            this.RemoveChildTag(tag);
        }

        public override List<HtmlTag> GetChildren()
        {
            return this.ChildrenTag;
        }

    }
}
