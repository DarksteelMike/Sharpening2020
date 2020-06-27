using System;
using System.Collections.Generic;

using Sharpening2020.Commands;

namespace Sharpening2020
{
    public class Executor
    {
        private readonly Stack<CommandBase> UndoStack = new Stack<CommandBase>();
        private readonly Stack<CommandBase> RedoStack = new Stack<CommandBase>();

        public delegate void CommandPerformedEvent(CommandBase cb);

        public event CommandPerformedEvent CommandPerformed;

        public Game MyGame;

        public Boolean SuspendViewUpdates = false;

        public void Do(CommandBase com)
        {
            if (MyGame.DebugFlag == DebugMode.Commands)
                MyGame.DebugAlert("Doing " + com.ToString());

            UndoStack.Push(com);
            com.Do(MyGame);

            if (!SuspendViewUpdates)
                com.UpdateViews(MyGame);

            CommandPerformed?.Invoke(com);
        }

        public void Undo()
        {
            if (UndoStack.Count == 0)
                return;

            CommandBase com = UndoStack.Pop();
            com.Undo(MyGame);
            RedoStack.Push(com);

            if (!SuspendViewUpdates)
                com.UpdateViews(MyGame);
        }

        public void Redo()
        {
            if (RedoStack.Count == 0)
                return;

            Do(RedoStack.Pop());
        }
    }
}
