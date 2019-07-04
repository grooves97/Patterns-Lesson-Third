using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DecoratorPattern
{
    public abstract class Cake
    {
        public abstract string Operation();
    }

    // Конкретные Компоненты предоставляют реализации поведения по
    // умолчанию. Может быть несколько вариаций этих классов.
    class Bisquit : Cake
    {
        public override string Operation()
        {
            return "Бисквит";
        }
    }
    class ShortbreadDough : Cake
    {
        public override string Operation()
        {
            return "Песочное тесто";
        }
    }

    // Базовый класс Декоратора следует тому же интерфейсу, что и другие
    // компоненты. Основная цель этого класса - определить интерфейс обёртки для
    // всех конкретных декораторов. Реализация кода обёртки по умолчанию может
    // включать в себя  поле для хранения завёрнутого компонента и средства его
    // инициализации.
    abstract class CakeDecorator : Cake
    {
        protected Cake _component;

        public CakeDecorator(Cake component)
        {
            this._component = component;
        }

        public void SetComponent(Cake component)
        {
            this._component = component;
        }

        // Декоратор делегирует всю работу обёрнутому компоненту.
        public override string Operation()
        {
            if (this._component != null)
            {
                return this._component.Operation();
            }
            else
            {
                return string.Empty;
            }
        }
    }

    // Конкретные Декораторы вызывают обёрнутый объект и изменяют его
    // результат некоторым образом.
    class ChocolateDecorator : CakeDecorator
    {
        public ChocolateDecorator(Cake comp) : base(comp)
        {
        }

        // Декораторы могут вызывать родительскую реализацию операции,
        // вместо того, чтобы вызвать обёрнутый объект напрямую. Такой подход
        // упрощает расширение классов декораторов.
        public override string Operation()
        {
            return $"с шоколадом({base.Operation()})";
        }
    }

    // Декораторы могут выполнять своё поведение до или после вызова
    // обёрнутого объекта.
    class СinnamonDecorator : CakeDecorator
    {
        public СinnamonDecorator(Cake comp) : base(comp)
        {
        }

        public override string Operation()
        {
            return $"с корицей({base.Operation()})";
        }
    }
    class ChocolateCinnamonDecorator : CakeDecorator
    {
        public ChocolateCinnamonDecorator(Cake comp) : base(comp)
        {
        }

        public override string Operation()
        {
            return $"с шоколадом и корицей({base.Operation()})";
        }
    }

    public class Client
    {
        // Клиентский код работает со всеми объектами, используя интерфейс
        // Компонента. Таким образом, он остаётся независимым от конкретных
        // классов компонентов, с которыми работает.
        public void ClientCode(Cake component)
        {
            Console.WriteLine("RESULT: " + component.Operation());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            var bisquit = new Bisquit();
            Console.WriteLine("Client: I get a Bisquit component:");
            client.ClientCode(bisquit);
            Console.WriteLine();

            // ...так и декорированные.
            //
            // Обратите внимание, что декораторы могут обёртывать не только
            // простые компоненты, но и другие декораторы.
            ChocolateDecorator bisquitDecorator = new ChocolateDecorator(bisquit);

            Console.WriteLine();

            var shortbreadDough = new ShortbreadDough();
            Console.WriteLine("Client: I get a ShortbreadDough component:");

            СinnamonDecorator shortbreadDoughDecor = new СinnamonDecorator(shortbreadDough);
            Console.WriteLine("Client: Now I've got a decorated component:");
            client.ClientCode(shortbreadDoughDecor);
        }
    }
}
