using System;
using System.Collections.Generic;

using Sharpening2020.Commands;

namespace Sharpening2020
{
    public class Executor
    {
        public Stack<ICommand> UndoStack = new Stack<ICommand>();

        public Game MyGame;

        public void Do(ICommand com)
        {
            UndoStack.Push(com);
            com.Do(MyGame);            
        }

        public void Undo()
        {
            ICommand com = UndoStack.Pop();
            com.Undo(MyGame);
        }
    }
}
