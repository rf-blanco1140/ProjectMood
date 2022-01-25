using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Void Event", menuName = "ScriptableObjects/GameEvents/Void GameEvent")]
public class VoidEvent : BaseGameEvent<Void>
{

    public void Raise() => Raise(new Void());

}
