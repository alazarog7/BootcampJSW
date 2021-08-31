using FactoryMethod.Services;
using System;

namespace FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayService errrorXmlDisplayService = new ErrorXmlDisplayService();
            errrorXmlDisplayService.Display();

            DisplayService feedbackXmlDisplayService = new FeedbackXmlDisplayService();
            feedbackXmlDisplayService.Display();

            DisplayService orderXmlDisplayService = new OrderXmlDisplayService();
            orderXmlDisplayService.Display();

            DisplayService responseXmlDisplayService = new ResponseXmlDisplayService();
            responseXmlDisplayService.Display();
        }
    }
}
