using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BridgeLesson
{
    class Abstraction
    {
        protected IColor _color;
        protected IMaterial _material;

        public Abstraction(IColor color, IMaterial material)
        {
            this._color = color;
            this._material = material;
        }

        public virtual string Operation()
        {
            return "Abstract: Base operation with:\n" + _color.OperationColor() + _material.OperationMaterial();
        }
    }



    // Можно расширить Абстракцию без изменения классов Реализации.
    class ExtendedAbstraction : Abstraction
    {
        public ExtendedAbstraction(IColor color,IMaterial material) : base(color, material)
        {
        }

        public override string Operation()
        {
            return "ExtendedAbstraction: Extended operation with:\n" + base._color.OperationColor() + base._material.OperationMaterial();
        }
    }



    // Реализация устанавливает интерфейс для всех классов реализации. Он не
    // должен соответствовать интерфейсу Абстракции. На практике оба интерфейса
    // могут быть совершенно разными. Как правило, интерфейс Реализации
    // предоставляет только примитивные операции, в то время как Абстракция
    // определяет операции более высокого уровня, основанные на этих примитивах.
    public interface IColor
    {
        string OperationColor();
    }

    public interface IMaterial
    {
        string OperationMaterial();
    }


    // Каждая Конкретная Реализация соответствует определённой платформе и
    // реализует интерфейс Реализации с использованием API этой платформы.
    class ColorImplementation : IColor
    {
        public string OperationColor()
        {
            return "ColorImplementation: Color result.\n";
        }
    }



    class MaterialImplementation : IMaterial
    {
        public string OperationMaterial()
        {
            return "MaterialImplementation: Material result.\n";
        }
    }



    class Client
    {
        // За исключением этапа инициализации, когда объект Абстракции
        // связывается с определённым объектом Реализации, клиентский код должен
        // зависеть только от класса Абстракции. Таким образом, клиентский код
        // может поддерживать любую комбинацию абстракции и реализации.
        public void ClientCode(Abstraction abstraction)
        {
            Console.Write(abstraction.Operation());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();

            Abstraction abstraction;
            // Клиентский код должен работать с любой предварительно
            // сконфигурированной комбинацией абстракции и реализации.
            abstraction = new Abstraction(new ColorImplementation(),new MaterialImplementation());
            client.ClientCode(abstraction);

            Console.WriteLine();

            abstraction = new ExtendedAbstraction(new ColorImplementation(), new MaterialImplementation());
            client.ClientCode(abstraction);

            Console.ReadLine();
        }
    }
}
