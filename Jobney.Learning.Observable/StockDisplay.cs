using System;

namespace Jobney.Learning.Observable
{
    //represents the user interface in the application
    public class StockDisplay
    {

        public void AskPriceChanged(object aPrice)
        {
            Console.Write("The new ask price is:" + aPrice + "\r\n");
        }

    }//StockDispslay class
}
