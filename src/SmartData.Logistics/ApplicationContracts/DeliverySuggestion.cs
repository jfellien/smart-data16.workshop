using System;

namespace ApplicationContracts
{
    public class DeliverySuggestion
    {
        public DeliverySuggestion(DateTime date)
        {
            Date = date;
        }
        public DateTime Date { get; private set; }
    }
}