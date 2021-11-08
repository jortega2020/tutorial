using System;

namespace SomeRandomService
{
    public class ErrorService
    {
        public ErrorService()
        {
        }

        #region Basic Examples

        public string GetDayOfTheWeekByIndex(int index)
        {
            string[] weekDays = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };
            string shortDayName = "";
            try
            {
                shortDayName = weekDays[index];
            }catch(Exception ex)
            {
                Console.WriteLine($"There is an error: {ex.Message}, Route of error: {ex.StackTrace}");
            }

            return shortDayName;
        }

        public double Division(int num1, int num2)
        {
            double result = 0;
            try
            {
                result = num1 / num2;
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Are you high!? You can't divide by Zero");
                Console.WriteLine(e);
            }
            finally
            {
                Console.WriteLine("Everything is cool man! Relax....");
            }

            return result;
        }

        public int GetInt(int[] array, int index)
        {
            int result = 0;
            try
            {
                result = array[index];
            }
            catch (IndexOutOfRangeException e)
            {
                throw new ArgumentOutOfRangeException(
                    "Parameter index is out of range.", e);
            }
            return result;
        }

        #endregion

        #region Bubble Up Example
        public void bubbleUp()
        {
            try
            {
                Console.WriteLine("Making Call to FunctionA");
                FunctionA();
                Console.WriteLine("Everything is fine!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("\nFollowing exception occured:\n\n" + ex);
            }
            finally
            {
                Console.WriteLine("\n\nInside finally block.");
                Console.ReadLine();
            }
        }

        public static void FunctionA()
        {
            Console.WriteLine("Inside FunctionA -> Making Call to FunctionB()");
            FunctionB();
            Console.WriteLine("Successfully returned from FunctionB()");
        }
        public static void FunctionB()
        {
            Console.WriteLine("Inside FunctionB -> Making Call to FunctionC()");
            FunctionC();
            Console.WriteLine("Successfully returned from FunctionC()");
        }
        public static void FunctionC()
        {
            Console.WriteLine("Inside FunctionC -> Making Call to FunctionD()");
            FunctionD();
            Console.WriteLine("Successfully returned from FunctionD()");
        }
        public static void FunctionD()
        {
            Console.WriteLine("Inside FunctionD -> Making Call to FunctionE()");
            FunctionF();
            Console.WriteLine("Successfully returned from FunctionE()");
        }
        public static void FunctionE()
        {
            Console.WriteLine("Inside FunctionE");
            throw new Exception("Something scary happen!!!");
        }

        public static void FunctionF()
        {
            try
            {
                Console.WriteLine("Inside FunctionF");
                throw new Exception("Something scary happen!!!");
            }
            catch(Exception ex)
            {
                Console.WriteLine("My cool exception strategy : " + ex);
            }
        }
        #endregion
    }
}