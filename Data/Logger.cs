using System;
using System.Threading;
using System.IO;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Data
{
    internal class Logger : IDisposable
    {
        private ConcurrentQueue<DiagnosticData> buffer = new ConcurrentQueue<DiagnosticData>();
        static object _lock = new object();
        private Task fileWritter;
        private StreamWriter sw;

        public Logger()
        {
            fileWritter = new Task(() => writter());
        }

        public void addToBuffer(DiagnosticData diagnosticData)
        {
            Monitor.Enter(_lock);
            try
            {
                buffer.Enqueue(diagnosticData);
                if (fileWritter.Status == TaskStatus.RanToCompletion || fileWritter.Status == TaskStatus.Created)
                {
                    fileWritter = new Task(() => writter());
                    sw = new StreamWriter("../../../../../Data/log.txt", append: true);
                    fileWritter.Start();
                }
            }
            finally
            {
                Monitor.Exit(_lock);
            }

        }

        public void writter()
        {
            try
            {
                while (!buffer.IsEmpty)
                {
                    DiagnosticData diagnosticData;                    
                    if (buffer.TryDequeue(out diagnosticData))
                    {
                        sw.WriteLine(logFormatter(diagnosticData));
                    }  
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file cannot be found.");
            }
            catch (IOException)
            {
                Console.WriteLine("An I/O error has occurred.");
            }
            finally
            {
                Dispose();
            }   
        }

        private string logFormatter(DiagnosticData diagnosticData)
        {
            string log = " Ball "
                    + diagnosticData.Id
                    + " moved: "
                    + " PositionX: "
                    + Math.Round(diagnosticData.PositionX, 4)
                    + " PositionY: "
                    + Math.Round(diagnosticData.PositionY, 4)
                    + " SpeedX: "
                    + Math.Round(diagnosticData.SpeedX, 4)
                    + " SpeedY: "
                    + Math.Round(diagnosticData.SpeedY, 4);
            return log;
        }

        public void Dispose()
        {
            sw.Close();
            sw.Dispose(); 
        }
    }
}
