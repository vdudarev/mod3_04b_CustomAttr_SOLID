using Demo_SOLID.DI;
using Demo_SOLID.LSPbad;
using Demo_SOLID.LSPOk;
using System;

namespace Demo_SOLID
{
    class Program
    {
        static void Main(string[] args)
        {
            // LSPbadDemo.MainBad();    // RE
            LSPOkDemo.MainOk();

            Demo_DI.Demo();
        }
    }
}
