﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Gear : MonoBehaviour
{
    
    public bool CanUse(string required_item)
    {
        return required_item.Equals(this.gameObject.tag);
    }

    public abstract void Use();
    public virtual void UnUse()
    {
        
    }
}
