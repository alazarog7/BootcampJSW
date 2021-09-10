using System;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlTag parentTag = new HtmlParentElement("<html>");
            parentTag.SetStartTag("<html>");
            parentTag.SetEndTag("</html>");
            HtmlTag p1 = new HtmlParentElement("<body>");
            p1.SetStartTag("<body>");
            p1.SetEndTag("</body>");
            parentTag.addChildTag(p1);

            HtmlTag child1 = new HtmlElement("<p>");
            child1.SetStartTag("<p>");
            child1.SetEndTag("</p>");
            child1.SetTagBody("Testing html tag librery");
            
            p1.addChildTag(child1);

            child1 = new HtmlElement("<p>");
            child1.SetStartTag("<p>");
            child1.SetEndTag("</p>");
            child1.SetTagBody("Paragraph 2");

            p1.addChildTag(child1);

            parentTag.GenerateHtml();

        }
    }
}
