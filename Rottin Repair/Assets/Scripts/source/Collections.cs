using System.Collections.Generic; using UnityEngine;  namespace Collections {     public enum Parts     {         None,         Head,         Body,         ArmL,         ArmR,         LegL,         LegR     }      public enum ZombieTypes     {         Nurse,         Fetishist     }      public class Const     {         public const int BODYPARTS = 6;          public const int MAXDECAYSTATES = 3;          public const int MAXINVENTORYSPACE = 10;     }      [System.Serializable]     public class ZombiePartSilhouettes
    {
        public Parts part;         public Sprite silhouette;
    }      [System.Serializable]     public class ZombiePart     {         public Parts part;          public ZombieTypes zombieType;          [Range(0, Const.MAXDECAYSTATES - 1)]         public int decayState;          public Sprite sprite;     }      [System.Serializable]     public class ZombieSetup     {         public Dictionary<Parts, ZombiePart> parts = new Dictionary<Parts, ZombiePart>();          public int SetupScore
        {             get             {                 int sum = 0;                 Debug.Log(parts);                 foreach (KeyValuePair<Parts, ZombiePart> pair in parts)                 {                     sum += (Const.MAXDECAYSTATES - pair.Value.decayState);                 }                 return sum;             }         }          public bool HasPart(Parts part)         {             return parts.ContainsKey(part);         }          public void RemovePart(Parts partToRemove)         {             if (HasPart(partToRemove))             {                 parts.Remove(partToRemove);             }         }          public void AddPart(ZombiePart part)         {             if (HasPart(part.part))
            {                 return;             }             parts.Add(part.part, part);         }     }      [System.Serializable]     public struct QuickTimeEventValues
    {         // one cycle in Math.PI seconds by default
        public float cursorSpeed;          // TO DO: array of section structs
    }      [System.Serializable]     public struct QuickTimeEvent
    {
        // TO DO: section struct
    } }  