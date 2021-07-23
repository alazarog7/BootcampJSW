using System;

namespace SingleResponsability
{
    class Program
    {
        static void Main(string[] args)
        {
            Book book = new Book()
            {
                name = "La vaca",
                authorName = "Camilo Cruz"
            };
        }

    }

    public class Book
    {
        public string name { get; set; }
        public string authorName { get; set; }
        public int year { get; set; }
        public int price { get; set; }
        public string isbn { get; set; }
    }

    public class Invoice
    {
        public Book book { get; set; }
        public int quantity { get; set; }
        public double discountRate { get; set; }
        public double taxRate { get; set; }
        public double total { get; set; }

        public Invoice(Book book, int quantity, double discountRate, double taxRate)
        {
            this.book = book;
            this.quantity = quantity;
            this.discountRate = discountRate;
            this.taxRate = taxRate;
        }

        public double calculateTotal()
        {
            var price = book.price * quantity* (1-discountRate);

            return price * (1 + taxRate);
        }

    }

    public class InvoicePersistence
    {
        private Invoice invoice;

        public InvoicePersistence(Invoice invoice)
        {
            this.invoice = invoice;
        }

        public void saveToFile(String fileName)
        {
            Console.WriteLine("Saving ...{0}", fileName);
            Console.WriteLine(this.invoice.ToString());
        }
    }

    public class InvoicePrint
    {

        private Invoice invoice;

        public InvoicePrint(Invoice invoice)
        {
            this.invoice = invoice;
        }
        public void printInvoice()
        {
            Console.WriteLine("Printing ...");
            Console.WriteLine(invoice.ToString());
        }
    }
    
}




