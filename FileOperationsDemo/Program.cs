using System;
using System.IO;

namespace FileOperationsDemo
{
    class Program
    {
        private string fileName= @"D:\Products.txt";

        FileStream fileStream;

        FileInfo file=null;

        private void AddProduct()
        {
            StreamWriter writer = null;
            if (!File.Exists(fileName))
            {
                fileStream = new FileStream(fileName, FileMode.CreateNew, FileAccess.Write);
            }
            else
            {
                fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Write);
            }
            Console.WriteLine("Enter ProductName    :");
            string productName = Console.ReadLine();

            Console.WriteLine("Enter CategoryID :");
            int categoryID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter price  :");
            double price = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Enter QuantityAvailable    :");
            int quantityAvailable = Convert.ToInt32(Console.ReadLine());

            Product productOne = new Product(productName,categoryID,price,quantityAvailable);
            writer = new StreamWriter(fileStream);

            //writing Comma Seperated Values (CSV)
            writer.WriteLine("{0},{1},{2},{3},{4}", productOne.ProductID, productOne.ProductName, productOne.CategoryID, productOne.Price, productOne.QuantityAvailable);

            Console.WriteLine("Product details are saved in the file successfully!");
            //Closes the current stream writer object and also the underlying file stream object
            writer.Close();

        }

        private void DisplayDetails()
        {
            StreamReader reader = null;
            string productData = null;
            file = new FileInfo(fileName);
            //File can be used to check the file existence
            if (File.Exists(fileName) && file.Length > 0)
            {
                fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                reader = new StreamReader(fileStream);
                productData = reader.ReadLine();
                string[] productElement=productData.Split(',');
                Console.WriteLine("ProductID\tProductName\tCategoryID\tPrice\tQuantityAvailable");
                foreach (string p in productElement){
                    Console.Write(p+"\t");
                }
            }
            else
            {
                Console.WriteLine("Sorry!! File does not exist or No contents to read");
            }
            reader.Close();
        }

        private void SearchProduct()
        {
            StreamReader reader = null;
            string productData = null;
            string productToSearch=null;
            file = new FileInfo(fileName);
            //File can be used to check the file existence
            Console.WriteLine("Enter Product ID:");
            productToSearch = Console.ReadLine();
            if (File.Exists(fileName) && file.Length > 0)
            {
                fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                reader = new StreamReader(fileStream);
                productData = reader.ReadLine();
                bool found=productData.Contains(productToSearch);
                if (found)
                {
                    Console.WriteLine(productData);
                }
                else
                {
                    Console.WriteLine("Product not found");
                }

            }

        }

        static void Main(string[] args)
        {
            Program o = new Program();
            //o.AddProduct();
            //o.DisplayDetails();
            //o.SearchProduct();
        }
    }
}
