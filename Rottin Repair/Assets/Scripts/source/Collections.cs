using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Collections
{
    public enum Parts
    {
        None,
        Head,
        Body,
        ArmL,
        ArmR,
        LegL,
        LegR
    }

    public enum ZombieTypes
    {
        Nurse
    }

    public class Const
    {
        public const int BODYPARTS = 6;

        public const int MAXDECAYSTATES = 3;

        public const int MAXINVENTORYSPACE = 10;
    }

    [System.Serializable]
    public class ZombiePart
    {
        public Parts part;

        public ZombieTypes zombieType;

        [Range(0, Const.MAXDECAYSTATES-1)]
        public int decayState;

        public Image image;
    }

    [System.Serializable]
    public class ZombieSetup
    {
        public Dictionary<Parts, ZombiePart> parts;

        public int SetupScore {
            get
            {
                int sum = 0;
                foreach(KeyValuePair<Parts, ZombiePart> pair in parts)
                {
                    sum += (Const.MAXDECAYSTATES - pair.Value.decayState);
                }
                return sum;
            }
        }

        public bool HasPart(Parts part)
        {
            return parts.ContainsKey(part);
        }

        public void RemovePart(Parts partToRemove)
        {
            if (parts.ContainsKey(partToRemove))
            {
                parts.Remove(partToRemove);
            }
        }

        public void AddPart(ZombiePart part)
        {
            if(parts.ContainsKey(part.part)) {
                return;
            }
            parts.Add(part.part, part);
        }
    }
}
