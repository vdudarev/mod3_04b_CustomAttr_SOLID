using System;

namespace Demo_Attributes
{
    class Demo_AttrisDefined
    {

        [ReviewComment("Check it out", "2.4")]
        class MyClass { }

        public static void MainIsDefined()
        {
            MyClass mc = new MyClass(); // Create an instance of the class.
            Type t = mc.GetType(); // Get the Type object from the instance.
            bool isDefined = // Check the Type for the attribute.
                t.IsDefined(typeof(ReviewCommentAttribute), false);
            if (isDefined)
                Console.WriteLine($"ReviewComment is applied to type { t.Name }");
        }
    }
}