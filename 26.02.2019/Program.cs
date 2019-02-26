using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26._02._2019
{
    public delegate void CarEngineHandlet(string masgForCaller);
    public class Car
    {
        public Car()
        {
            MaxtSpeed = 100;

        }
        public Car(string name, int MaxSpeed, int CurrentSpeed)
        {
            this.CurrentSpeed = CurrentSpeed;
            this.MaxtSpeed = MaxSpeed;
            this.Name = name;
        }

        public int CurrentSpeed { get; set; }
        public int MaxtSpeed { get; set; }
        public string Name { get; set; }

        private bool CarIsDead;        

        private CarEngineHandlet listofHandlers;

        public void RegisterCarEngine(CarEngineHandlet methodCall)
        {
            listofHandlers += methodCall;
        }

        public void Accelerate(int delta)
        {
            if (CarIsDead)
            {
                if (listofHandlers != null)
                {
                    //listofHandlers("car is dead");
                    listofHandlers.Invoke("Sorry car is dead");

                }
               
            }
            else
            {
                this.CurrentSpeed += delta;
                if (10 == (MaxtSpeed - CurrentSpeed) && listofHandlers != null)
                {
                    listofHandlers.Invoke("Careful");
                }
                if (CurrentSpeed >= MaxtSpeed)
                {
                    CarIsDead = true;
                }
                else
                {
                    Console.WriteLine("Current speed: {0}", CurrentSpeed);
                }
            }
        }
    }

    public class people
    {
        public void test()
        {
        }
    }

    //1 Обьявление делегата
    public delegate void GetMessage();
    public delegate int Operation(int x, int y);
    class Program
    {
        //2 Создаем переменную делегата
        static GetMessage del;
        // static Operation op;
        static void Main(string[] args)
        {
            Car car = new Car("Volvo", 100, 10);
            car.RegisterCarEngine(onCarEngineEvent);
            car.RegisterCarEngine(onCarEngineEvent2);
            car.RegisterCarEngine(onCarEngineEvent3);


            for (int i = 0; i < 6; i++)
            {
                car.Accelerate(20);
            }

            Console.ReadLine();
            
            
            //if (DateTime.Now.Hour < 12)
            //{
            //    ShowMessage(GoodMorning);
            //}
            //else
            //{
            //    ShowMessage(GoodEvening);

            //}

            //people p = new people(); 
            //del = p.test;

            ////ссылка на метод
            //Operation op = new Operation(Add);
            //int result = op.Invoke(4,5);
            //Console.WriteLine(result);

            //op = Multiply;
            //result = op.Invoke(4, 5);
            //Console.WriteLine(result);

            //result = op(4, 5);


            //if (DateTime.Now.Hour < 12)
            //{
            //    del = GoodMorning;
            //}
            //else
            //{
            //    del = GoodEvening;
            //}

            //вызов метода
            //del();
            // del.Invoke();
            Console.ReadLine();

        }

        private static void onCarEngineEvent(string msg)
        {
            Console.WriteLine("Message");
            Console.WriteLine("--> {0}", msg);
            Console.WriteLine("-------------------------");
        }

        private static void onCarEngineEvent2(string msg)
        {
            Console.WriteLine("Message");
            Console.WriteLine("--> {0}", msg);
            Console.WriteLine("-------------------------");
        }

        private static void onCarEngineEvent3(string msg)
        {
            Console.WriteLine("Message");
            Console.WriteLine("-->{0}", msg);
            Console.WriteLine("-------------------------");
        }
        private static void GoodMorning()
        {
            // Console.WriteLine("GoodMorning");

        }
        private static void GoodEvening()
        {
            Console.WriteLine("GoodEvening");
        }

        private static int Add(int x, int y)
        {
            return x + y;
        }

        private static int Multiply(int x, int y)
        {
            return x * y;
        }

        private static void ShowMessage(GetMessage _del)
        {
            _del.Invoke();
        }

    }
}
