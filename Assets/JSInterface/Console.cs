using System;
using System.Collections;

using UnityEngine;

using Jurassic;
using Jurassic.Library;

public class JSConsole : ObjectInstance {

	public JSConsole(ScriptEngine engine) : base(engine)
	{
		PopulateFunctions();
	}
	
	[JSFunction(Name = "log")]
	public void Log(string s)
	{
		Debug.Log(s);
	}
}
