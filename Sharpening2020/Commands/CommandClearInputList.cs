﻿using System;
using System.Collections.Generic;

using Sharpening2020.Attributes;
using Sharpening2020.Input;
using Sharpening2020.Players;

using ProtoBuf;

namespace Sharpening2020.Commands
{
    [ProtoContract]
    [AttributeDoNotSaveCommand]
    class CommandClearInputList : CommandBase
    {
        [ProtoMember(1)]
        public readonly LazyGameObject<Player> Player;

        private CommandClearInputList() { }

        public CommandClearInputList(Int32 pid)
        {
            Player = new LazyGameObject<Player>(pid);
        }

        public override void Do(Game g)
        {
            if(g.InputHandlers.ContainsKey(Player.ID))
            {
                prev = new List<InputStateBase>();

                prev.AddRange(g.InputHandlers[Player.ID].InputList);

                g.InputHandlers[Player.ID].InputList.Clear();
            }
        }

        private List<InputStateBase> prev;

        public override void Undo(Game g)
        {
            if(prev != null)
            {
                g.InputHandlers[Player.ID].InputList.AddRange(prev);
            }
        }

        public override object Clone()
        {
            return new CommandClearInputList(Player.ID);
        }
    }
}
