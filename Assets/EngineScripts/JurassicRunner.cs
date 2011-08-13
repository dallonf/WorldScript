using UnityEngine;
using Jurassic;
using Jurassic.Library;
using System;

public class JurassicRunner : MonoBehaviour 
{
	public TextAsset[] Scripts;
	public PlayerScript Player;
	
	public GameContext Context;
	
	private ScriptEngine scriptEngine;
	
	void Awake () 
	{
		scriptEngine = new ScriptEngine();
		scriptEngine.SetGlobalValue("console", new JSConsole(scriptEngine));
		scriptEngine.SetGlobalValue("me", new JSPlayer(scriptEngine, Player));
		
		foreach (var script in Scripts) {
			Debug.Log("Running " + script.name);
			var scriptFunc = scriptEngine.Evaluate<ObjectInstance>("({run: function(game){" + script.text + "}})");
			
			var game = new JSGame(scriptEngine, Context);
			(scriptFunc["run"] as FunctionInstance).Call(null, game); //Will eventually be a script instance, game context
			
		}
	}
}
