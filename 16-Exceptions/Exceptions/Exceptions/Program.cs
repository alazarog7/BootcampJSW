using Serilog;
using System;
using System.Diagnostics;
using System.Net;

namespace Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {

            AppDomain.CurrentDomain.FirstChanceException += (sender, eventArg) =>
            {
                Debug.WriteLine(eventArg.Exception.ToString());

            };

            //WebClient wc = null;

            //try
            //{
            //    string param = "https://www.google.com/dfkahfdjkah%20f%20kdjashfjkdsfjdhsajfasdhj"; //null;
            //    wc = new WebClient();
            //    var resultData = wc.DownloadString(param);
            //}
            //catch (ArgumentNullException e)
            //{
            //    Console.WriteLine("Error!!!");
            //}
            //catch( WebException ex)
            //when((ex.Response as HttpWebResponse)?.StatusCode == HttpStatusCode.NotFound)
            //{
            //    Console.WriteLine("Not Found!!!");
            //}
            //catch (Exception ex)
            //{

            //}
            //finally
            //{
            //    wc.Dispose();
            //}
            //try
            //{
            //    DoBilling(1);
            //} 
            //catch(ClientBillingException ex)
            //{
            //    Console.WriteLine(ex);
            //}


            //var date = GetDate(new SqlDateReated(), null);

            try
            {
                int number = 5;

                number += number / (0);
            } 
            catch(Exception ex)
            {
                Log.Error(string.Format("Description {0}", new Guid()));
            }

            


        }


        public static DateTime? GetDate(SqlDateReated reader, string columnName)
        {
            DateTime? dateTime = null;

            try
            {
                dateTime = DateTime.Parse(reader[columnName].ToString());
            }
            catch
            {
                throw;
            }
            return dateTime;
        }

        public static void DoBilling(int clientID)
        {
            object client = null;

            if(client == null)
            {
                throw new ClientBillingException(string.Format("Unable to find a client"));
            }
        }
    }

    public class ClientBillingException: Exception
    {
        public ClientBillingException(string message): base(message) { }
    }

    
}
