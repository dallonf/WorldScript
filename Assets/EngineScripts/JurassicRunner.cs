using UnityEngine;
using Jurassic;
using Jurassic.Library;
using System;

public class JurassicRunner : MonoBehaviour 
{
	public TextAsset[] Scripts;
	
	public GameContext Context;
	
	void Start () 
	{
		foreach (var script in Scripts) {
			Debug.Log("Running " + script.name);
			var scriptFunc = Context.ScriptEngine.Evaluate<ObjectInstance>("({run: function(game){" + script.text + "}})");
			
			var game = new JSGame(Context.ScriptEngine, Context);
			(scriptFunc["run"] as FunctionInstance).Call(null, game); //Will eventually be a script instance, game context
		}
	}
}
