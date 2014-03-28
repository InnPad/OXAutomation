
namespace OXAutomation
{
    class Program
    {
        static void Main(string[] args)
        {
            var service = new Service();

            service.InitializeService();

            service.StartImplementation();

            while (true)
            {
                System.Threading.Thread.Sleep(10);
            }
        }
    }
}
