using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalSettings
{
    private static bool audioOn = true;

    public static bool AudioOn
    {
        get { return audioOn; }
        set { audioOn = value; }
    }

    
}
