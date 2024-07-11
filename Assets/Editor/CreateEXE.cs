using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using DG.DOTweenEditor;
using DG.Tweening;

public class BuildScript
{
    public static void PerformBuild()
    {
        string[] scenes = { "Assets/Scenes/MainMenu.unity", "Assets/Scenes/Level1.unity","Assets/Scenes/level2.unity" }; // 替换为你的场景路径
        BuildPipeline.BuildPlayer(scenes, "F:\\mygame\\MyGame.exe", BuildTarget.StandaloneWindows, BuildOptions.None);
        Debug.Log("Build Completed!");
    }
}