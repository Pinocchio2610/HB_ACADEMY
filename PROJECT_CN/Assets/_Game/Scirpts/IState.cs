using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public interface IState 
{
    public void OnEnter(Player player )
    {
    }
    public void OnExcuted(Player player )
    { 
    }
    public void OnExit(Player player)
    {
    }
}
