using System;

namespace exercise_stopwatch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n");
            Console.WriteLine("Stopwatch commands: s = start; p = pause/resume, c = stop\n");

            while (true)
            {
                var stopwatch = new Stopwatch();
                
                Console.WriteLine("Press s to start the stopwatch. \t\tPress control+c to exit");

                try
                {
                    stopwatch.Start(Convert.ToChar(Console.ReadKey().Key));
                }
                catch (System.Exception ex)
                {
                    Console.WriteLine("\nError: " + ex.Message);
                    continue;
                }

                reading:
                Console.WriteLine("\nReading...\t'p' = pause, 'c' = stop/cancel");

                try
                {
                    var input = Convert.ToChar(Console.ReadKey().Key);
                    var duration = stopwatch.StopOrPause(input);
                    if (input == 'P')
                    {
                        resume:
                        Console.WriteLine("\npaused\t'p' = resume, 'c' = cancel\t" + duration.ToString().Substring(0, duration.ToString().Length - 5));

                        var input1 = Convert.ToChar(Console.ReadKey().Key);
                        if (input1 == 'P')
                        {
                            stopwatch.Resume(input1);
                            goto reading;
                        }

                        else if (input1 == 'C')
                        {
                            var duration1 = stopwatch.CancelOnPause();
                            Console.WriteLine("\n\nDuration:\t" + duration1.ToString().Substring(0, duration1.ToString().Length - 5) + "\n");
                            continue;
                        }

                        else 
                        {
                            Console.WriteLine($"\nInvalid input {input1.ToString().ToLower()}");
                            goto resume;
                        }
                    }

                    Console.WriteLine("\n\nDuration:\t" + duration.ToString().Substring(0, duration.ToString().Length - 5) + "\n");
                }

                catch (System.Exception ex)
                {
                    Console.Write("\nError: " + ex.Message + "\n");
                    goto reading;
                }
            }
        }
    }
}
