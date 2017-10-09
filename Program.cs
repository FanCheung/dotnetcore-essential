/** Preprocessor */
// see it as DEV=true
#define DEV
#undef DEV
#define PROD

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using static System.Console;
using TodoApi.Models;
/** alias */
using Todo = TodoApi.Models;


namespace dotnet
{
    public class Car
    {
        int wheel = 3;
        string size = "small";
    }

    public class Program
    {

        enum step
        {
            step1 = 1,
            step2 = 2,
            step3 = 3
        };

        // scope is different
        const int AConst = 10;

        // Arguments can be passed to main in console
        public static void Main(string[] args)
        {
            // Program.ClassPlay();
            // Program.VarAndTypes();
            // Program.Array();

            // Program.TryTuple();
            Program.OperatorAndCast();
            BuildWebHost(args).Run();
        }

        /*casting and operators */
        public static void OperatorAndCast()
        {

            object o2 = 2334;
            string str = o2 as string;
            // casting to int
            int int1 = (int)o2;

            // if casing fail try convert
            //    Convert.ToDouble(int);

            // convert to string
            o2.ToString();

            // int goodNum=null;
            // ? make it nullable otherwise it throws error
            int? goodNum = null;
            // similar to || operator 
            int? b = goodNum ?? 3;

            /* check reference eqaulity  
            useful when for compare object
            */
            bool B1 = ReferenceEquals(new int[] { 3, 3 }, new int[] { 3, 3 });
            Write($"---------{B1}");

        }

        /* Arrays  */
        public static void Array()
        {
            // empty array init
            int[] IntArray = new int[3];
            // init a array with a length
            string[] IntArray2 = { "1", "2", "3" };
            string StringNum = IntArray2[1];

            // iterate array 
            for (int i = 0; i < IntArray2.Length; i++)
            {
                Write(IntArray2[i]);
            }

            foreach (string Value in IntArray2)
            {
                Write(Value);
            }

            /* multi dimensional array */
            int[,] TwoDimension = new int[2, 2];
            // alternative init
            int[,] TwoDimension2 ={
                 {2,3} ,{1,2}
             };
            // jagged array i.e item can have different length 
            int[][] JaggedArray = new int[4][];
            // using array instance method to modify value 
            JaggedArray.SetValue(new[] { 12, 999 }, 0);
            WriteLine(JaggedArray[0]);

            // clone an array 
            int[][] temp = (int[][])JaggedArray.Clone();

            // sorting array
            string[] Names = { "ben", "alan", "cat" };
        }

        public static void TryTuple()
        {
            var result = Tuple.Create(1, 3);
            // access with redsult.Item1 Item2... silly 
            WriteLine(result.Item1);
        }

        public static void ClassPlay()
        {
            TodoItem doIt = new TodoItem("hello");
            // explicit param
            int num = doIt.Square(num: 4);
            // implicit param
            num = doIt.Square(6);
            WriteLine(doIt.Created);
            doIt.MultiParam('A', 23, 43);
        }
        public static void VarAndTypes()
        {
#if PROD
#warning "preprocessor warning"
            WriteLine("production variable");
#else
// that throw the error and stop the build
#error "print some error"
            WriteLine("development variable");
#endif
            /** Numbers
             */
            const int AConst = 10;
            // float need append F support 7 digits
            float AFloat = 20.32F;
            // double support 15 digit no need F
            double ADouble = 230.234;
            WriteLine(ADouble);
            WriteLine(AConst);

            // constant is implicitly static
            WriteLine(Program.AConst);

            /** String
             */
            // can only use single quote
            char AChar = '\"';
            // string   
            WriteLine(AChar);

            string AString = "C:'\\abc";
            // adding @ will manipulte ignore escape 

            string BString = @"'C:\abc output \ ignore escape
            and it support line break";

            string CString = $"cstring {AString}";
            WriteLine(AString);
            WriteLine(BString);
            WriteLine(CString);

            string inputCmd;
            // ReadLine() will pause excution
            inputCmd = ReadLine();
            WriteLine(inputCmd);
            WriteLine(AFloat);
            WriteLine(AFloat.GetType().Namespace);
            // print System.single
            /** Enum */

            WriteLine($"steps: {Program.step.step1}");
            WriteLine(Program.step.step1.ToString());
            // you get 'step1'
            /** Switch case no fall through */
            string ACase = "A";
            switch (ACase)
            {
                case "skip":
                case "A":
                    goto case "B";
                case "B":
                    WriteLine("reach b");
                    break;
                default:
                    WriteLine("reach default");
                    break;
            }
            /** loopppp */
            for (int i = 0; i < 10; i++)
            {
                WriteLine(i);
            }

            // do while loop
            int j = 1;
            do
            {
                j++;
                if (j > 10) break;
            } while (true);

        }
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
