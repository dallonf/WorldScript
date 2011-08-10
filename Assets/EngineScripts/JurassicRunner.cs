using UnityEngine;
using Jurassic;
using System;

public class JurassicRunner : MonoBehaviour 
{
	public TextAsset[] Scripts;
	public PlayerScript Player;
	
	private ScriptEngine scriptEngine;
	
	void Awake () 
	{
		scriptEngine = new ScriptEngine();
		scriptEngine.SetGlobalValue("console", new JSConsole(scriptEngine));
		scriptEngine.SetGlobalValue("me", new JSPlayer(scriptEngine, Player));
		
		foreach (var script in Scripts) {
			Debug.Log("Running " + script.name);
			scriptEngine.Execute(script.text);
		}
	}
}
