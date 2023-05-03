using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public abstract class NPC : NetworkBehaviour
{
    public NPCInfo npcInfo;

    public abstract void UseItem();
}