using System;
using Jurassic;
using Jurassic.Library;
using UnityEngine;

public class JSPlayer : ObjectInstance
{
	
	private PlayerScript player;
	
	public JSPlayer(ScriptEngine engine, PlayerScript player) : base(engine)
	{
		this.player = player;
		this.PopulateFunctions();
	}
	
	[JSProperty(Name = "speed")]
	public double Speed
	{ 
		get { return player.Speed; }
		set { player.Speed = (float)value; }
	}
	
	[JSFunction(Name = "jumpVelocity")]
	public double JumpVelocity() { return player.JumpVelocity; }
	[JSFunction(Name = "jumpVelocity")]
	public void JumpVelocity(double val) { player.JumpVelocity = (float)val; }

}


