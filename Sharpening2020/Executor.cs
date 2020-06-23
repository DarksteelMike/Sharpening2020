﻿using System;
using System.Collections.Generic;

using Sharpening2020.Commands;

namespace Sharpening2020
{
    public class Executor
    {
        public Stack<CommandBase> UndoStack = new Stack<CommandBase>();

        public delegate void CommandPerformedEvent(CommandBase cb);

        public event CommandPerformedEvent CommandPerformed;

        public Game MyGame;

        public Boolean SuspendViewUpdates = false;

        public void Do(CommandBase com)
        {
            UndoStack.Push(com);
            com.Do(MyGame);

            if(CommandPerformed != null)
                CommandPerformed(com);
        }

        public void Undo()
        {
            CommandBase com = UndoStack.Pop();
            com.Undo(MyGame);

            if (!SuspendViewUpdates)
                com.UpdateViews(MyGame);
        }
    }
}
