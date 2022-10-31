using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DelegatesAndEvents
{
    //public delegate int WorkPerformendHandler(object semder, WorkPerformedEventArgs e);

    public class Worker
    {
        //public event WorkPerformendHandler WorkPerformed;
        public event EventHandler<WorkPerformedEventArgs> WorkPerformed;
        public event EventHandler WorkComplete;

        public void DoWork(int hours, WorkType workType)
        {
            for (int i = 0; i < hours; i++)
            {
                //Raise event
                Thread.Sleep(1000);
                OnWorkPerformed(i + 1, workType);
            }
            //Raise event
            OnWorkCompleted();
        }

        protected virtual void OnWorkPerformed(int hours, WorkType workType)
        {
            //if (WorkPerformed != null)
            //    WorkPerformed(hours, workType);

            //var del = WorkPerformed as WorkPerformendHandler;
            var del = WorkPerformed as EventHandler<WorkPerformedEventArgs>;
            if (del != null)
                del(this, new WorkPerformedEventArgs(hours, workType));
        }

        protected virtual void OnWorkCompleted()
        {

            var del = WorkComplete as EventHandler;
            if (del != null)
                del(this, EventArgs.Empty);
        }
    }
}
