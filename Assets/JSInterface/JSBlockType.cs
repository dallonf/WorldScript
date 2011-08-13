using System;
using Jurassic;
using Jurassic.Library;
using UnityEngine;

public class JSBlockType : ObjectInstance
{	
	
	private string name;
	
	public JSBlockType(ScriptEngine engine, string name) : base(engine)	{
		this.name = name;
		this.PopulateFunctions();
	}
	
	[JSProperty(Name = "name")]
	public string Name { get { return name; } }
	[JSProperty(Name = "red")]
	public byte Red { get; set; }
	[JSProperty(Name = "green")]
	public byte Green { get; set; }
	[JSProperty(Name = "blue")]
	public byte Blue { get; set; }
	
	public Material Material {get; set;}
}


