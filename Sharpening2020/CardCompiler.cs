using System;
using System.IO;
using Microsoft.CSharp;
using System.CodeDom.Compiler;

using Sharpening2020.Cards;


namespace Sharpening2020
{
    class CardCompiler
    {
        public static Card Compile(String name)
        {
            String classname = "";
            foreach(char c in name)
            {
                if (char.IsLetter(c))
                    classname += c;
                else
                    classname += '_';
            }

            CSharpCodeProvider provider = new CSharpCodeProvider();
            CompilerParameters parameters = new CompilerParameters();

            parameters.ReferencedAssemblies.Add("..\\..\\Sharpening2020.dll");
            parameters.GenerateInMemory = true;
            parameters.GenerateExecutable = false;
            

            CompilerResults res = provider.CompileAssemblyFromFile(parameters, "Cards" + Path.DirectorySeparatorChar + name + ".cs");

            //AppDomain.CurrentDomain.Load(File.ReadAllBytes(res.PathToAssembly));

            return (Card)Activator.CreateInstance(res.CompiledAssembly.GetType(classname));
        }
    }
}
