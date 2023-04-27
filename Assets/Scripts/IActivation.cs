using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActivation
{
    public void OnActive(params IStats[] stats);
}
