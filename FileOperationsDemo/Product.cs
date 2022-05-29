using System;
using System.Collections.Generic;
using System.Text;

namespace FileOperationsDemo
{
    class Product
    {
        static int counter;
        public int CategoryID { get; set; }
        public double Price { get; set; }
        public string ProductID { get; set; }
        public string ProductName { get; set; }
        public int QuantityAvailable { get; set; }
        static Product()
        {
            counter = 1001;
        }
        public Product(string productName,int categoryID,double price,int quantityAvailable)
        {
            ProductID = 'P' + Convert.ToString(counter);
            ProductName = productName;
            CategoryID = categoryID;
            Price = price;
            QuantityAvailable = quantityAvailable;
            counter += 1;
        }

    }
}
