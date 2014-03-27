
namespace OXAutomation
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new Service();

            service.InitializeService();

            service.Start();

            while (true)
            {
                System.Threading.Thread.Sleep(10);
            }
        }
    }
}
