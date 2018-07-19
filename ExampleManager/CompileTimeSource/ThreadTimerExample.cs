using Core.Infrastructure;
using System;
using System.Diagnostics;
using System.Threading;

namespace ExampleManager.CompileTimeSource
{
    [ExampleClass]
    class ThreadTimerExample
    {
        public static void Main()
        {
            var timer = new TimerExecution();
            timer.RunTimer();
        }

        class TimerExecution
        {
            public void RunTimer()
            {
                StateObjClass StateObj = new StateObjClass();
                StateObj.TimerCanceled = false;
                StateObj.SomeValue = 8;
                TimerCallback TimerDelegate =
                    new TimerCallback(TimerTask);

                // Create a timer that calls a procedure every 2 seconds.  
                // Note: There is no Start method; the timer starts running as soon as   
                // the instance is created.  
                System.Threading.Timer TimerItem =
                    new System.Threading.Timer(TimerDelegate, StateObj, 2000, 2000);

                // Save a reference for Dispose.  
                StateObj.TimerReference = TimerItem;

                // Run for ten loops.  
                while (StateObj.SomeValue < 10)
                {
                    // Wait one second.  
                    System.Threading.Thread.Sleep(5000);
                }

                // Request Dispose of the timer object.  
                StateObj.TimerCanceled = true;
            }

            private void TimerTask(object StateObj)
            {
                StateObjClass State = (StateObjClass)StateObj;
                // Use the interlocked class to increment the counter variable.  
                System.Threading.Interlocked.Increment(ref State.SomeValue);
                Console.WriteLine($"Launched new thread {DateTime.Now.ToString()}");
                if (State.TimerCanceled)
                // Dispose Requested.  
                {
                    State.TimerReference.Dispose();
                    Debug.WriteLine("Done  " + DateTime.Now.ToString());
                }
            }
        }
        
    }

    public class StateObjClass
    {
        // Used to hold parameters for calls to TimerTask.  
        public int SomeValue;
        public System.Threading.Timer TimerReference;
        public bool TimerCanceled;

        public StateObjClass()
        {


        }
        public StateObjClass(int someValue, Timer timerReference, bool timerCanceled)
        {
            SomeValue = someValue;
            TimerReference = timerReference;
            TimerCanceled = timerCanceled;
        }
    }

    
}
