using System;
using System.Collections.Generic;
using System.IO;
using Sharpening2020.Attributes;
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
        private Boolean isLoading = false;
        public Boolean IsLoading
        {
            get { return isLoading; }
        }

        public List<Type> triggerOnCommandTypes = new List<Type>();
        public List<Type> doNotSaveTypes = new List<Type>();

        public Executor()
        {
            triggerOnCommandTypes.Add(typeof(CommandMoveCard));
            triggerOnCommandTypes.Add(typeof(CommandGainLife));
            triggerOnCommandTypes.Add(typeof(CommandLoseLife));
            triggerOnCommandTypes.Add(typeof(CommandSetIsTapped));
            triggerOnCommandTypes.Add(typeof(CommandAddCounter));
            triggerOnCommandTypes.Add(typeof(CommandShuffleLibrary));

            doNotSaveTypes.Add(typeof(CommandClearInputList));
            doNotSaveTypes.Add(typeof(CommandEnterInputState));
            doNotSaveTypes.Add(typeof(CommandRemoveTopInputStates));
            doNotSaveTypes.Add(typeof(CommandSetAttackingState));
            doNotSaveTypes.Add(typeof(CommandSetBlockingState));
            doNotSaveTypes.Add(typeof(CommandSetHavePriorityState));
            doNotSaveTypes.Add(typeof(CommandSetPayActionCostState));
            doNotSaveTypes.Add(typeof(CommandSetPayManaCostState));
            doNotSaveTypes.Add(typeof(CommandSetTargetState));
            doNotSaveTypes.Add(typeof(CommandResetManaCost));
            doNotSaveTypes.Add(typeof(CommandResetActionCost));
            doNotSaveTypes.Add(typeof(CommandResetTargets));
            doNotSaveTypes.Add(typeof(CommandSetIsActivating));
            doNotSaveTypes.Add(typeof(CommandSetWaitingForOpponentsState));
        }

        public void Do(CommandBase com)
        {
            MyGame.DebugAlert(DebugMode.Commands, "Doing " + com.ToString(MyGame));

            if(!(com is CommandGroup))
            {
                UndoStack.Push(com);
            }

            com.Do(MyGame);

            if (!SuspendViewUpdates)
                com.UpdateViews(MyGame);

            if(triggerOnCommandTypes.Contains(com.GetType()) && !IsLoading)
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

        public void Save(FileStream fs)
        {
            //List<CommandBase> res = new List<CommandBase>();
            CommandBase[] stack = UndoStack.ToArray();
            List<CommandBase> res = new List<CommandBase>();
            
            foreach(CommandBase com in stack)
            {
                if(true)//Attribute.GetCustomAttribute(com.GetType(),typeof(AttributeDoNotSaveCommand)) == null)
                {
                    res.Add(com);
                }/*
                if(!doNotSaveTypes.Contains(com.GetType()))
                {
                    res.Add(com);
                }*/
            }
            CommandBase[] arrRes = res.ToArray();

             ProtoBuf.Serializer.Serialize(fs, res); 
        }

        public void Load(FileStream fs)
        {
            isLoading = true;
            SuspendViewUpdates = false;
            CommandBase[] coms = ProtoBuf.Serializer.Deserialize<CommandBase[]>(fs);
            Array.Reverse(coms);

            foreach(CommandBase com in coms)
            {
                 Do(com);
            }

            MyGame.EnterAllInputStates();

            isLoading = false;
        }

        public void Replay(FileStream fs)
        {
            isLoading = true;
            CommandBase[] coms = ProtoBuf.Serializer.Deserialize<CommandBase[]>(fs);
            Array.Reverse(coms);

            foreach (CommandBase com in coms)
            {
                Do(com);
                
                System.Threading.Thread.Sleep(250);

            }

            MyGame.EnterAllInputStates();

            isLoading = false;
        }
    }
}
