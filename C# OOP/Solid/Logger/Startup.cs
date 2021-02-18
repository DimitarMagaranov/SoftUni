namespace Logger
{
    using Logger.Core;

    public class Startup
    {
        public static void Main()
        {
            Engine engine = new Engine(new CommandInterpreter());

            engine.Run();
        }
    }
}
