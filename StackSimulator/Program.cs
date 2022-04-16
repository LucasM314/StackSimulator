using System;
using System.Linq;
using AsmResolver.DotNet;

namespace StackSimulator
{
    public static class Program
    {
        private static void Main()
        {
             Console.WriteLine("Welcome in StackSimulator");
             var moduleDef = ModuleDefinition.FromFile(@"D:\Projects [DEV]\Reverse Engineering\StackSimulator\StackSimulator\bin\Release\net5.0\TestFile.exe");
             var methodToEmulate = moduleDef.TopLevelTypes.First(t => t.Name == "Program").Methods.First(m => m.Name == "Main");
             var methodEmulator = new MethodEmulator(methodToEmulate);
             methodEmulator.Emulate();
             Console.WriteLine(methodEmulator.Stack.Pop());

             Console.ReadLine();
        }
    }
}