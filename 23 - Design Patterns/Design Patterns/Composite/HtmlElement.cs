using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{
    public class HtmlElement : HtmlTag
    {
        private string TagName;
        private string StartTag;
        private string EndTag;
        private string TagBody;

        public HtmlElement(string name)
        {
            this.TagName = name;
        }

        public override void GenerateHtml()
        {
            Console.WriteLine($"{StartTag}{TagBody}{EndTag}");
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

        public override void SetTagBody(string name)
        {
            this.TagBody = name;
        }
    }
}
