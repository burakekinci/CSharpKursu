using System;

namespace Events
{
    //eventlar birer delegate temellidir
    public delegate void StockContol();
    class Product
    {
        int _stock;

        public Product(int stock)
        {
            _stock = stock;
        }

        public event StockContol StockContolEvent;
        public string ProductName { get; set; } 
        public int Stock 
        {
            get{ return _stock; }
            set
            {
                _stock = value;
                if(value<15 && StockContolEvent != null) //evente abone olunmussa
                {
                    StockContolEvent();
                }
            }

        }

        public void Sell(int amount)
        {
            Stock -= amount;
            Console.WriteLine("{1} Stock Amount: {0}",Stock, ProductName);
        }
    }
}
