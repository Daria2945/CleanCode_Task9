namespace CleanCode_Task9
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            DataBaseContext context = new DataBaseContext();
            Repository repository = new Repository(context);
            Service service = new Service(repository);

            PresenterFactory presenterFactory = new PresenterFactory(service);

            View view = new View(presenterFactory);

            Application.Run(view);
        }
    }
}