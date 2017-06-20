/* 
AutoBuilder.cs
Automatically changes the target platform and creates a build.

 */
using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using System.IO;
 
public static class AutoBuilder {
 
	static string GetProjectName()
	{
		string[] s = Application.dataPath.Split('/');
		return s[s.Length - 2];
	}
 
	static string[] GetScenePaths()
	{
		string[] scenes = new string[EditorBuildSettings.scenes.Length];
 
		for(int i = 0; i < scenes.Length; i++)
		{
			scenes[i] = EditorBuildSettings.scenes[i].path;
		}
 
		return scenes;
	}


	[MenuItem("AutoBuilder/Android APK export")]
	static void PerformAndroidBuild () {
		EditorUserBuildSettings.SwitchActiveBuildTarget(BuildTarget.Android);
		BuildPipeline.BuildPlayer(GetScenePaths(), "../Android/Rockstar.apk", BuildTarget.Android,BuildOptions.None);
	}
	
	[MenuItem("AutoBuilder/Android Project Build Step")]
	static void androidBuild () {
		Debug.Log("Command line build android version\n------------------\n------------------");

		// string[] scenes = GetBuildScenes();
		string[] scenes = GetScenePaths();
		//string path = GetBuildPathAndroid();
		string path = "../Android/UnityExport";
		if(scenes == null || scenes.Length==0 || path == null)
			return;

		Debug.Log(string.Format("Path: \"{0}\"", path));
		for(int i=0; i<scenes.Length; ++i)
		{
			Debug.Log(string.Format("Scene[{0}]: \"{1}\"", i, scenes[i]));
		}

		Debug.Log("Starting Android Build!");
		BuildPipeline.BuildPlayer(scenes, path, BuildTarget.Android, BuildOptions.AcceptExternalModificationsToPlayer);
		// BuildPipeline.buil
	}
}