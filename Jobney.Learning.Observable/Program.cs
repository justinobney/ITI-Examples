using System;

namespace Jobney.Learning.Observable
{
    public static class MainClass
    {
        public static void Main()
        {

            //create new display and stock instances
            var stockDisplay = new StockDisplay();
            var stock = new Stock();

            //create a new delegate instance and bind it
            //to the observer's askpricechanged method
            var aDelegate = new
               Stock.AskPriceDelegate(stockDisplay.AskPriceChanged);

            //add the delegate to the event
            stock.AskPriceChanged += aDelegate;

            //loop 100 times and modify the ask price
            for (var looper = 0; looper < 100; looper++)
            {
                stock.AskPrice = looper;
            }

            //remove the delegate from the event
            stock.AskPriceChanged -= aDelegate;

            Console.WriteLine("Complete..");
            Console.ReadLine();

        }//Main

    }//MainClass
}
