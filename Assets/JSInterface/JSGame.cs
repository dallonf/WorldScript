using System;
using Jurassic;
using Jurassic.Library;
using UnityEngine;

public class JSGame : ObjectInstance
{	
	private GameContext context;
	
	public JSGame(ScriptEngine engine, GameContext context) : base(engine)	{
		this.context = context;
		this.PopulateFunctions();
	}
	
	[JSFunction]
	public JSBlockType BlockType(string name)
	{
		if (context.BlockTypes.ContainsKey(name)) {
			return context.BlockTypes[name];
		} else {
			JSBlockType blockType = new JSBlockType(Engine, name);
			context.BlockTypes.Add(name, blockType);
			return blockType;
		}
	}
	
	[JSFunction(Name = "setBlock")]
	public void SetBlock(int x, int y, string blockType)	
	{
		context.SetBlock(x, y, BlockType(blockType));	
	}
}


