using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

///1. Imprime as palavras (words) que contêm "ei";
///2. Imprime as categorias e nomes dos produtos ordenados pela categria e depois pelo nome;
///3. Imprime as categorias e nomes dos produtos que têm algum produto sem stock (=0);
///4. Imprime os números (numbers) impares;
///5. Imprime os números de 1 a 100, mas para múltiplos de 3 imprime antes "Fizz" e para múltiplos de 5 imprime antes "Buzz".
///     Para múltiplos de 3 e 5 imprime antes "FizzBuzz".
///   5.1. Encontra outra solução para o mesmo problema.
namespace FizzBuzz
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] words = { "believe", "relief", "receipt", "field" };
        private int[] numbers = { 1, 2, 8, 11, 3, 19, 41, 65, 19, 20, 40, 100 };
        private Dictionary<int, string> multiplesWord = new Dictionary<int, string>();
        private OperationsList operationsList;
        private ProductOperations productOperations;
        private OpenClosedExamples openClosedExamples;
        private string textToShow = string.Empty;

        public List<Product> GetProductList()
        {
            List<Product> prodList = new List<Product>();
            prodList.Add(new Product("Veggies", ProductCategory.FOOD, 10));
            prodList.Add(new Product("Apple", ProductCategory.FOOD, 2));
            prodList.Add(new Product("Pear", ProductCategory.FOOD, 0));
            
            prodList.Add(new Product("T-shirt", ProductCategory.CLOTHES, 2));
            prodList.Add(new Product("Sweater", ProductCategory.CLOTHES, 50));
            prodList.Add(new Product("Jeans", ProductCategory.CLOTHES, 0));

            prodList.Add(new Product("Mouse", ProductCategory.ELECTRONICS, 2));
            prodList.Add(new Product("Iphone", ProductCategory.ELECTRONICS, 200));
            prodList.Add(new Product("Laptop", ProductCategory.ELECTRONICS, 10));
            prodList.Add(new Product("Digital camera", ProductCategory.ELECTRONICS, 5));
            return prodList;
        }

        public MainWindow()
        {
            InitializeComponent();
            this.InitializeClasses();
            this.InitializeMultiplesValues();
            this.ExecuteTasks();            
        }

        private void InitializeClasses()
        {
            this.operationsList = new OperationsList();
            this.productOperations = new ProductOperations();
            this.openClosedExamples = new OpenClosedExamples();
        }

        private void ExecuteTasks()
        {
            this.PrintWordsContainingEI();
            this.PrintOrderedCategories();
            this.PrintProductsWithoutStock();
            this.PrintOddNumbersFromAList();
            this.PrintNumbersWithStringV1();
            this.PrintNumbersWithStringV2();
        }

        //Generate a Dictionary with key = number and Value = correspondent string
        private void InitializeMultiplesValues()
        {
            this.multiplesWord.Add(3, "Fizz");
            this.multiplesWord.Add(5, "Buzz");
        }

        //Iterate over a list and print all words taht contains the word "ei"
        private void PrintWordsContainingEI()
        {
            List<string> wordsContainingEI = this.operationsList.SearchWordsContainingGivenString(this.words, "ei");
            this.textToShow += "1) Words containing 'ei'" + "\n";

            foreach (string word in wordsContainingEI)
            {
                this.textToShow += word + "\n";
            }

            this._txt_box.Text = this.textToShow ;
        }
        
        //Print all products ordered by category and name
        private void PrintOrderedCategories()
        {
            List<Product> orderedProductsList = this.productOperations.OrderByCategoryAndByName(GetProductList());

            this.textToShow += "\r\n " + "2) Products ordered by category and Name" + "\n";

            foreach (Product product in orderedProductsList)
            {
                this.textToShow += "Category: " + product.Category + " Product Name: " + product.Name + "\n";
            }

            this._txt_box.Text = this.textToShow;
        }

        //Print all categories and products without stock
        private void PrintProductsWithoutStock()
        {
            List<Product> productsWithoutStock = this.productOperations.CheckProductsWithoutStock(GetProductList());

            this.textToShow += "\r\n " + "3) Products without stock" + "\n";

            foreach (Product product in productsWithoutStock)
            {
                this.textToShow += "Category: " + product.Category + " Name: " + product.Name + "\n";
            }

            this._txt_box.Text = this.textToShow;
        }

        //Print all odd numbers from a list
        private void PrintOddNumbersFromAList()
        {
            List<int> oddNumbers = this.operationsList.OddNumbers(numbers);

            this.textToShow += "\r\n " + "4) Odd Numbers: " + "\n";

            foreach (int number in oddNumbers)
            {
                this.textToShow += number + "\n";
            }

            this._txt_box.Text = this.textToShow;
        }
       
        private void PrintNumbersWithStringV1()
        {
            List<string> stringsToPrint = this.operationsList.WordsToPrintV1(this.multiplesWord);

            this.textToShow += "\r\n " + "5) Multiples Version1: " + "\n";

            foreach (string word in stringsToPrint)
            {
                this.textToShow += word + "\n";
            }

            this._txt_box.Text = this.textToShow ;
        }

        private void PrintNumbersWithStringV2()
        {
            KeyValuePair<int, string>[] stringsToPrint = this.operationsList.WordsToPrintV2();
            this.textToShow += "\r\n " + "5) Multiples Version2: " + "\n";

            foreach (KeyValuePair<int, string> kvp in stringsToPrint)
            {
                this.textToShow += kvp.Value +"\n";
            }

            this._txt_box.Text = this.textToShow;
        }
    }
}
