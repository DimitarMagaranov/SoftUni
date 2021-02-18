using System;

namespace MXGP
{
    using Models.Motorcycles;
    using MXGP.Core.Models;
    using MXGP.Models.Motorcycles.Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Engine engine = new Engine();

            engine.Run();
        }
    }
}
