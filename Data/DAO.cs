using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Data
{
    internal class DAO 
    {
        static object _lock = new object();
         

        public static void wrtiteToFile(Ball ball, string time)
        {
            Monitor.Enter(_lock);
            StreamWriter sw = null;
            try
            {
                sw = new StreamWriter("../../../../../Data/log.txt", append: true);

                sw.WriteLine(time +
                    " Ball " 
                    + ball.Id 
                    + " moved: " 
                    + " PositionX: " 
                    + Math.Round(ball.PositionX, 4)
                    + " PositionY: " 
                    + Math.Round(ball.PositionY, 4)
                    +" SpeedX: "
                    + Math.Round(ball.SpeedX, 4)
                    + " SpeedY: "
                    + Math.Round(ball.SpeedY, 4));

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file cannot be found.");
            }
            catch (IOException)
            {
                Console.WriteLine("An I/O error has occurred.");
            }
            catch (OutOfMemoryException)
            {
                Console.WriteLine("There is insufficient memory to read the file.");
            }
            catch (SynchronizationLockException exception)
            {
                throw new Exception("Checking collision synchronization lock not working", exception);
            }
            finally
            {
                sw.Dispose();
                Monitor.Exit(_lock);
            }
        }
    }
}
