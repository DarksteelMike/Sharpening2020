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

        public List<Type> triggerOnCommandTypes = new List<Type>();

        public Executor()
        {
            triggerOnCommandTypes.Add(typeof(CommandMoveCard));
            triggerOnCommandTypes.Add(typeof(CommandGainLife));
            triggerOnCommandTypes.Add(typeof(CommandLoseLife));
            triggerOnCommandTypes.Add(typeof(CommandTap));
            triggerOnCommandTypes.Add(typeof(CommandUntap));
            triggerOnCommandTypes.Add(typeof(CommandAddCounter));
            triggerOnCommandTypes.Add(typeof(CommandShuffleLibrary));
        }

        public void Do(CommandBase com)
        {
            MyGame.DebugAlert(DebugMode.Commands, "Doing " + com.ToString(MyGame));

            UndoStack.Push(com);
            com.Do(MyGame);

            if (!SuspendViewUpdates)
                com.UpdateViews(MyGame);

            if(triggerOnCommandTypes.Contains(com.GetType()))
            {
                MyGame.MyTriggerHandler.GatherTriggers(com);
            }

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
