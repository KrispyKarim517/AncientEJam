using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Gear
{
    bool CanUse(string required_item);
    void Use();
}
