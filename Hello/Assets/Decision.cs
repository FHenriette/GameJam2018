using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Complete;

public abstract class Decision : Scriptable
{
    public abstract bool Decide(StateController controller);
}