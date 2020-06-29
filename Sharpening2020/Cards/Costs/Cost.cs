using System;
using System.Collections.Generic;

using Sharpening2020.Cards.Costs;
using Sharpening2020.Cards.Costs.ActionCosts;

namespace Sharpening2020.Cards.Costs
{
    public class Cost : ICloneable
    {
        public List<ActionCostPart> ActionParts = new List<ActionCostPart>();

        public List<ManaCostPart> ManaParts = new List<ManaCostPart>();

        public List<ActionCostPart> PaidActions = new List<ActionCostPart>();

        public List<ManaCostPart> PaidMana = new List<ManaCostPart>();

        public Boolean AreActionsPaid()
        {
            return ActionParts.Count == PaidActions.Count;
        }

        public Boolean IsManaPaid()
        {
            return ManaParts.Count == PaidMana.Count;
        }

        public Boolean IsPaid()
        {
            return AreActionsPaid() && IsManaPaid();
        }

        public void SetPaid(ActionCostPart acb)
        {
            if (ActionParts.Contains(acb))
            {
                PaidActions.Add(acb);
            }
        }

        public void SetPaid(ManaCostPart mcb)
        {
            if(ManaParts.Contains(mcb))
            {
                PaidMana.Add(mcb);
            }
        }

        public List<ManaCostPart> GetUnpaidMana()
        {
            List<ManaCostPart> res = new List<ManaCostPart>();
            res.AddRange(ManaParts);
            foreach(ManaCostPart paid in PaidMana)
            {
                res.Remove(paid);
            }

            return res;
        }

        public void ClearPaid()
        {
            PaidActions.Clear();
            PaidMana.Clear();
        }

        public object Clone()
        {
            Cost ret = new Cost();
            foreach(ActionCostPart acp in ActionParts)
            {
                ret.ActionParts.Add((ActionCostPart)acp.Clone());
            }
            foreach(ManaCostPart mcp in ManaParts)
            {
                ret.ManaParts.Add((ManaCostPart)mcp.Clone());
            }

            return ret;
        }
    }
}
