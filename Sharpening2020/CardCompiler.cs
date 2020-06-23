using System;
using System.IO;
using Microsoft.CSharp;
using System.CodeDom.Compiler;
using System.Reflection;

using Sharpening2020.Cards;


namespace Sharpening2020
{
    class CardCompiler
    {
        public static Card Compile(String name)
        {
            String classname = "Cards.";
            foreach(char c in name)
            {
                if (char.IsLetter(c))
                    classname += c;
                else
                    classname += '_';
            }

            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters parameters = new CompilerParameters();

            parameters.ReferencedAssemblies.Add(Assembly.GetAssembly(typeof(CardCompiler)).Location);
            parameters.GenerateInMemory = true;
            parameters.GenerateExecutable = false;
            

            CompilerResults res = provider.CompileAssemblyFromFile(parameters, "Cards" + Path.DirectorySeparatorChar + name + ".cs");

            //AppDomain.CurrentDomain.Load(File.ReadAllBytes(res.PathToAssembly));

            return (Card)Activator.CreateInstance(res.CompiledAssembly.GetType(classname));

            //return (Card)res.CompiledAssembly.GetType(classname).GetConstructors()[0].Invoke(new Object[0]);
        }
    }
}
