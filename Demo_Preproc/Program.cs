#define DemoVersionWithTimeLimit
//#undef DemoVersionWithTimeLimit

using System;

class Demo_Preproc
{
    static void Main()
    {

#if myProjectWideSymbol     // Project Properties => Build => General : Conditional compilation symbols
        Console.WriteLine("myProjectWideSymbol SET");
#else
        Console.WriteLine("myProjectWideSymbol UNSET");
#endif

#if !myProjectWideSymbol || !DemoVersionWithTimeLimit     // Project Properties => Build => Conditional compilation symbols
#error Нельзя работать (даже компилировать!), если такое случается
#endif

#pragma warning disable 219, 1030
#pragma warning restore 1030
        //#line 10000 "SourceFile.cs" // Changes the reported line number and file name
#warning Не забудьте поменять настроечки перед релизом!!!     // warning CS1030
        //#line default
        const int intExpireLength = 30;
        string strVersionDesc = null;
#pragma warning disable 219, 1030
        int intExpireCount = 0;     // warning 219

#if DemoVersionWithTimeLimit
        intExpireCount = intExpireLength;
        strVersionDesc = "This version of Supergame Plus will expire in 30 days";

#elif DemoVersionWithoutTimeLimit
        strVersionDesc = "Demo Version of Supergame Plus";

#elif OEMVersion
        strVersionDesc = "Supergame Plus, distributed under license";

#else
        strVersionDesc = "The original Supergame Plus!!";
#endif
        Console.WriteLine(strVersionDesc);


        #region Область кода


        Console.WriteLine("#region Область кода");


        #endregion  // Область кода

    }
}