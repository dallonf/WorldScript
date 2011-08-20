using UnityEngine;
using Jurassic;
using System.Collections;
using System.Collections.Generic;

public class GameContext : MonoBehaviour
{
	
	public ObservableDictionary<string, JSBlockType> BlockTypes { get; private set; }
	public JSMap Map { get; private set; }
	
	public ScriptEngine ScriptEngine { get; private set; }

	// Use this for initialization
	void Awake ()
	{
		ScriptEngine = new ScriptEngine();
		ScriptEngine.SetGlobalValue("console", new JSConsole(ScriptEngine));
		
		BlockTypes = new ObservableDictionary<string, JSBlockType>();
		BlockTypes.OnAdded += HandleBlockTypesOnAdded;
		
		Map = new JSMap(ScriptEngine);
	}

	private void HandleBlockTypesOnAdded(object sender, ObservableDictionary<string, JSBlockType>.DictionaryEventArgs e)
	{
		//Send over network
	}
}


