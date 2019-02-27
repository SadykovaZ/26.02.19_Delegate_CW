using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _26._02._2019
{
    public class EventArgs
    {
        public static readonly System.EventArgs Empty;
        public EventArgs()
        {

        }

    }

    public class CarEvents : EventArgs
    {
        public readonly string msg;
        public CarEvents(string msg)
        {
            this.msg = msg;
        }
    }


    public delegate void CarEngineHandlet(string masgForCaller);
    public class Car
    {
        public event CarEngineHandlet Exploded;
        public event CarEngineHandlet AboutToBlow;

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

       // private CarEngineHandlet listofHandlers;

        //public void RegisterCarEngine(CarEngineHandlet methodCall)
        //{
        //    listofHandlers += methodCall;
        //}

        public void Accelerate(int delta)
        {
            if (CarIsDead)
            {
                if (Exploded != null)
                {
                    //listofHandlers("car is dead");
                    Exploded.Invoke("Sorry car is dead");
                }               
            }
            else
            {
                this.CurrentSpeed += delta;
                if (10 == (MaxtSpeed - CurrentSpeed) && AboutToBlow != null)
                {
                    AboutToBlow.Invoke("Careful");
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

    public delegate int Sum(int number);
    public delegate int LengthLogin(string s);
    public delegate bool BoolPassword(string s1, string s2);


    class Program
    {
        //2 Создаем переменную делегата
        static GetMessage del;
        // static Operation op;
        static void Main(string[] args)
        {

            setLogin();

            return;
            #region
            CarEngineHandlet handler =
               delegate (string mes)
                //delegate (string mes)
            {
                Console.WriteLine("Message");
                Console.WriteLine("--> {0}", mes);
                Console.WriteLine("-------------------------");
            };
            handler("Ola");

            ShowMessage("Hola", (string msg) => 
            {
                Console.WriteLine(msg);
            });
            #endregion
            Sum del1 = SumValue();
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Sum {0} equals: {1}",i, del1.Invoke(i));
            }

            #region
            Car car = new Car("Volvo", 100, 10);

            car.Exploded += handler;
            //зарегестрировать событие
            car.AboutToBlow += onCarEngineEvent;

            CarEngineHandlet d = new CarEngineHandlet(onCarEngineEvent);
            car.Exploded += d;

            //car.RegisterCarEngine(onCarEngineEvent);
            //car.RegisterCarEngine(onCarEngineEvent2);
            //car.RegisterCarEngine(onCarEngineEvent3);


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
            #endregion
            Console.ReadLine();

        }
        static void setLogin()
        {
            string login = "15354";
            LengthLogin lengthLoginDelegate = s => s.Length;
            LengthLogin lengthLoginDelegate2 = (string s) => { return s.Length; };
            //LengthLogin lengthLoginDelegate3 = (string s) => { return s.Length; };

            //блочные лямба выражения
            BoolPassword bp = (s1,s2) =>{ return true; };
            bool res = bp.Invoke("", "");
            Console.WriteLine(res);
            int lengthLogin = lengthLoginDelegate(login);
        }
        static Sum SumValue()
        {
            int result = 0;

            Sum del = (int number) =>
            {
                for (int i = 0; i < number; i++)
                {
                    result += i;
                }
                return result;

            };

            return del;
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

        private static void ShowMessage(string msg, CarEngineHandlet handler)
        {
            handler.Invoke(msg);
        }

    }
}
