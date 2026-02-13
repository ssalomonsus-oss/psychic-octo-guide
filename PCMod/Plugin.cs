using System;
using BepInEx;
using BepInEx.Unity.IL2CPP;
using UnityEngine;

[BepInPlugin("com.moxxie.holdable", "HoldableTemplate PCMod", "1.0.0")]
public class HoldablePlugin : BasePlugin
{
    public override void Load()
    {
        Logger.LogInfo("HoldablePlugin (IL2CPP) loaded");
        var go = new GameObject("HoldableTestMenu");
        go.AddComponent<TestMenuBehaviour>();
        UnityEngine.Object.DontDestroyOnLoad(go);
    }
}

public class TestMenuBehaviour : MonoBehaviour
{
    bool rainbow = false;
    bool superJump = false;

    void OnGUI()
    {
        if (GUI.Button(new Rect(10,10,160,30), "Rainbow Hands")) {
            rainbow = !rainbow;
            Debug.Log("[HoldablePlugin] Rainbow Hands: " + rainbow);
        }
        if (GUI.Button(new Rect(10,50,160,30), "Super Jump")) {
            superJump = !superJump;
            Debug.Log("[HoldablePlugin] Super Jump: " + superJump);
        }
    }
}
