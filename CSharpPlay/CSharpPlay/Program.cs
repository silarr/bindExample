using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpPlay
{
    public class BaseNancyModule
    {
        // Just to mock Nancy's behaviour
        public Func<string, string> Get;

        public string Bind<T>(Func<string> getResponseFunc)
        {
            this.Bind<T>();
            return getResponseFunc();
        }

        public void Bind<T>()
        {
            // Implemented by Nancy
        }
    }

    public class SomeNancyModule : BaseNancyModule
    {
        public void Request()
        {
            this.Get = _ => this.Bind<MyModel>(() => this.GetResponse());
        }

        public string GetResponse()
        {
           return "DO something";
        }
    }

    public class MyModel
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            var t = new SomeNancyModule();
            t.Request();
            var r = t.Get("some_url");
        }
    }
}
