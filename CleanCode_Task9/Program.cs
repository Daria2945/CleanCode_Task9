namespace CleanCode_Task9
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            View view = new View();

            DataBaseContext context = new DataBaseContext();
            Repository repository = new Repository(context);
            Service service = new Service(repository);

            Presenter presenter = new Presenter(view, service);

            Application.Run(view);
        }
    }
}