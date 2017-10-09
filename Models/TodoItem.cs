using static System.Console;
using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Util;
namespace TodoApi.Models
{
    /* Abstract class */
    public abstract class TodoAction
    {
        public abstract void addTodo();
    }

// try interface
    public interface ITodoItem
    {
         void GetItem();
    }

    // structs
    public struct TodoSchema
    {
        public string Title;
        public string Content;
        /* you can have constructor for struct too, just have to assign all properties */
        // public TodoSchema(string title, string content)
        // {
        //     Title = title;
        //     Content = content;
        // }
    }

    public class SuperTodoItem : TodoItem
    {
        private string _name;
        // base is like super in javascript
        public SuperTodoItem(string name) : base(name)
        {
            // calling method from base class 
            base.Square(2);
        }
    }
    public class TodoItem
    {
        // read only properties
        static readonly string ReadOnlyString = "kkfk";

        // emun can only contain one data type
        public enum Status
        {
            Idle = 1,
            OnGoing = 2,
            Completed = 3
        };
        // static constructor
        static TodoItem()
        {
            // Static constructorlet you init the class upon it loads before any staic member are called or used
        }


        //constructor
        public TodoItem(string name)

        {
            /** test native object extend method */
            string me = "this is me";
            WriteLine($"lets count me -- {me.Count()}");

            /* Nullable type */
            int? Nullable = null;

            TodoSchema TodoStruct = new TodoSchema();
            TodoStruct.Title = "Struct title";

            // u can create a struct without new 
            TodoSchema TodoStruct2;
            TodoStruct.Title = "Struct2 title";

            // create a struct with json like obj and initialize 
            TodoSchema TodoStruct3 = new TodoSchema
            {
                Title = "hello",
                Content = "my content"
            };
            /* TodoApi are passed by value  */

            // through getter setter
            _name = name;
            // similar to json object 
            var SomeObj = new
            {
                Foo = "foo",
                Bar = "bar"
            };
        }

        /** 
        Struct on default are passed with copy use 'ref' to pass it by reference
         */
        public void changeStruct(ref TodoSchema todo)
        {
            todo.Title = "Hi";
        }
        public long Id { get; set; }
        // example of getter setter
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
        // public bool IsComplete { get; set; }
        public DateTime Created = DateTime.Now;

        // optional param with =
        public bool IsGood(bool good = true)
        {
            return good;
        }
        // lambda only supports single line
        public int Square(int num) => num * num;

        // Method override
        public int Square(string text)
        {
            // parse to integer
            int num = Int32.Parse(text);
            return num * num;
        }
        // any num of params 
        public void MultiParam(params object[] data)
        {
            foreach (var item in data)
            {
                Write($"{item} --- ");
            }
        }
    }


}