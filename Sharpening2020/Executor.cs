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

        public void UndoUntilMarker(CommandMarkerType mt)
        {
            if (UndoStack.Count == 0)
                return;

            CommandBase com;
            Boolean KeepGoing = true;
            do
            {
                com = UndoStack.Pop();
                com.Undo(MyGame);

                if(com is CommandMarker)
                {
                    if(((CommandMarker)com).MyType == mt)
                    {
                        KeepGoing = false;
                    }
                }

                if (!SuspendViewUpdates)
                    com.UpdateViews(MyGame);
            } while (KeepGoing && UndoStack.Count > 0);
        }

        public void Redo()
        {
            if (RedoStack.Count == 0)
                return;

            Do(RedoStack.Pop());
        }
    }
}
