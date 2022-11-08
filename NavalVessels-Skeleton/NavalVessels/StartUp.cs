namespace NavalVessels
{
    using System;
    using System.Globalization;
    using System.Threading;
    using Core;
    using Core.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}