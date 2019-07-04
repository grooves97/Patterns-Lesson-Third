using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacadePattern
{
    public class Facade
    {
        protected Editor _editor;

        protected Speller _speller;

        protected Sender _sender;

        public Facade(Editor editor, Speller speller,Sender sender)
        {
            this._editor = editor;
            this._speller = speller;
            this._sender = sender;
        }

        // Методы Фасада удобны для быстрого доступа к сложной функциональности
        // подсистем. Однако клиенты получают только часть возможностей
        // подсистемы.
        public string Operation()
        {
            string result = "Facade initializes subsystems:\n";
            result += this._editor.operationReady();
            result += this._speller.operationReady();
            result += this._sender.operationReady();
            result += "Facade orders subsystems to perform the action:\n";
            result += this._editor.operationGo();
            result += this._speller.operationGo();
            result += this._sender.operationGo();
            return result;
        }
    }

    public class Editor
    {
        public string operationReady()
        {
            return "Editor: Ready!\n";
        }

        public string operationGo()
        {
            return "Editor: Edit this!\n";
        }
    }

    public class Speller
    {
        public string operationReady()
        {
            return "Speller: Get ready!\n";
        }

        public string operationGo()
        {
            return "Speller: Write or check this!\n";
        }
    }

    public class Sender
    {
        public string operationReady()
        {
            return "Sender: Get ready!\n";
        }

        public string operationGo()
        {
            return "Sender: Send this!\n";
        }
    }
    class Client
    {
        // Клиентский код работает со сложными подсистемами через простой
        // интерфейс, предоставляемый Фасадом. Когда фасад управляет жизненным
        // циклом подсистемы, клиент может даже не знать о существовании
        // подсистемы. Такой подход позволяет держать сложность под контролем.
        public static void ClientCode(Facade facade)
        {
            Console.Write(facade.Operation());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Editor editor = new Editor();
            Speller speller = new Speller();
            Sender sender = new Sender();
            Facade facade = new Facade(editor, speller, sender);
            Client.ClientCode(facade);

            Console.ReadLine();
        }
    }
}
