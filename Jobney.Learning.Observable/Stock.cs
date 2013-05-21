namespace Jobney.Learning.Observable
{
    public class Stock
    {

        //declare a delegate for the event
        public delegate void AskPriceDelegate(object aPrice);
        //declare the event using the delegate
        public event AskPriceDelegate AskPriceChanged;

        //instance variable for ask price
        object askPrice;

        //property for ask price
        public object AskPrice
        {

            set
            {
                //set the instance variable
                askPrice = value;

                //fire the event
                AskPriceChanged(askPrice);
            }

        }//AskPrice property

    }//Stock class
}
