using System;
using System.Collections.Generic;
using System.Linq;

namespace DelegatesAndEvents
{
    //public delegate void WorkPerformendHandler(int hours, WorkType worktype);
    public delegate int BizRulesDelegate(int x, int y);

    class Program
    {
        static void Main(string[] args)
        {
            var custs = new List<Customer>()
            {
                new Customer {City = "Phoenix", FirstName = "John", LastName = "Doe", ID = 1},
                new Customer {City = "Phoenix", FirstName = "Jane", LastName = "Doe", ID = 500},
                new Customer {City = "Seattle", FirstName = "Suki", LastName = "Pizzoro", ID = 3},
                new Customer {City = "New York City", FirstName = "Michelle", LastName = "Smith", ID = 4},
            };

            var phxCusts = custs
                .Where(c => c.City == "Phoenix" && c.ID < 500)
                .OrderBy(c => c.FirstName);

            foreach(var cust in phxCusts)
                Console.WriteLine(cust.FirstName);

            //WorkPerformendHandler del1 = new WorkPerformendHandler(WorkPerformed1);
            //WorkPerformendHandler del2 = new WorkPerformendHandler(WorkPerformed2);
            //WorkPerformendHandler del3 = new WorkPerformendHandler(WorkPerformed3);

            //del1(5, WorkType.Golf);
            //del2(10, WorkType.GenerateReports);

            //DoWork(del2);
            //del1 += del2;
            //del1 += del3;

            //del1 += del2 + del3;

            //int finalHours = del1(10, WorkType.GenerateReports);
            //Console.WriteLine(finalHours);

            var data = new ProcessData();
            BizRulesDelegate addDel = (x, y) => x + y;
            BizRulesDelegate multiplyDel = (x, y) => x * y;
            //data.Process(2, 3, multiplyDel);

            Func<int, int, int> funcAddDel = (x, y) => x + y;
            Func<int, int, int> funcMultipleDel = (x, y) => x * y;
            data.ProcessFunc(3, 2, funcMultipleDel);


            //Action<int, int> myAction = (x, y) => Console.WriteLine(x + y);
            //Action<int, int> myMultiplyAction = (x, y) => Console.WriteLine(x * y);
            //data.ProcessAction(2, 3, myMultiplyAction);

            var worker = new Worker();
            //worker.WorkPerformed += new EventHandler<WorkPerformedEventArgs>(Worker_WorkPerformed);
            //worker.WorkPerformed += Worker_WorkPerformed;
            //Asignarlo anonimamente
            //worker.WorkPerformed += delegate (object sender, WorkPerformedEventArgs e)
            //{
            //    Console.WriteLine("Hours worked: " + e.Hours + " " + e.WorkType);
            //};

            //Lambdas
            worker.WorkPerformed += (s, e) =>
            {
                Console.WriteLine("Hours worked: " + e.Hours + " hours(s) doing: " + e.WorkType);
                Console.WriteLine("Some other value");
            };
            

            //worker.WorkComplete += Worker_WorkCompleted;
            //worker.WorkComplete += delegate (object sender, EventArgs e)
            //{
            //    Console.WriteLine("Worker is done");
            //};

            worker.WorkComplete += (s, e) => Console.WriteLine("Worker is done");

            worker.DoWork(8, WorkType.GenerateReports);
            Console.Read();
        }

        //private static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        //{
        //    Console.WriteLine("Hours worked: " + e.Hours + " " + e.WorkType);
        //}

        //No es necesario lo crea haciendo Tab
        //static void Worker_WorkPerformed(object sender, WorkPerformedEventArgs e)
        //{
        //    Console.WriteLine("Hours worked: " + e.Hours + " " + e.WorkType);
        //}

        //static void Worker_WorkCompleted(object sender, EventArgs e)
        //{
        //    Console.WriteLine("Worker is done");
        //}
        

        //static void DoWork(WorkPerformendHandler del)
        //{
        //    //WorkPerformed1(5, WorkType.GoToMeetings);
        //    del(5, WorkType.GoToMeetings);
        //}

        //static int WorkPerformed1(int hours, WorkType workType)
        //{
        //    Console.WriteLine("WorkPerformend1 called " + hours.ToString());
        //    return hours + 1;
        //}

        //static int WorkPerformed2(int hours, WorkType workType)
        //{
        //    Console.WriteLine("WorkPerformend2 called " + hours.ToString());
        //    return hours + 2;
        //}

        //static int WorkPerformed3(int hours, WorkType workType)
        //{
        //    Console.WriteLine("WorkPerformend3 called " + hours.ToString());
        //    return hours + 3;
        //}
    }

    public enum WorkType
    {
        GoToMeetings,
        Golf,
        GenerateReports
    }
}
