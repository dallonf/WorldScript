using System;
using Jurassic;
using Jurassic.Library;
using UnityEngine;

public class JSBlockType : ObjectInstance
{	
	private string name;
	
	public event ParamEventHandler<JSBlockType> ColorChanged;
	
	public JSBlockType(ScriptEngine engine, string name) : base(engine)	{
		this.PopulateFunctions();
		
		this.name = name;
	}
	
	[JSProperty(Name = "name")]
	public string Name { get { return name; } }
	
	private byte red;
	private byte green;
	private byte blue;
	
	[JSProperty(Name = "red")]
	public byte Red
	{
		get 
		{
			return red;
		}
		set
		{
			red = value;
			if (ColorChanged != null) {
				ColorChanged(this, new ParamEventArgs<JSBlockType>(this));
			}
		}
	}
	
	[JSProperty(Name = "green")]
	public byte Green
	{
		get 
		{
			return green;
		}
		set
		{
			green = value;
			if (ColorChanged != null) {
				ColorChanged(this, new ParamEventArgs<JSBlockType>(this));
			}
		}
	}
	
	[JSProperty(Name = "blue")]
	public byte Blue
	{
		get 
		{
			return blue;
		}
		set
		{
			blue = value;
			if (ColorChanged != null) {
				ColorChanged(this, new ParamEventArgs<JSBlockType>(this));
			}
		}
	}
}


