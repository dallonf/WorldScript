using System;
using Jurassic;
using Jurassic.Library;
using UnityEngine;

public class JSMap : ObjectInstance
{	
	public class BlockChangedEventArgs : EventArgs
	{
		public int X {get;set;}
		public int Y {get;set;}
		public JSBlockType BlockType {get;set;}
		
		public BlockChangedEventArgs(int x, int y, JSBlockType blockType)
		{
			X = x;
			Y = y;
			BlockType = blockType;
		}
	}
	
	public event EventHandler<BlockChangedEventArgs> BlockChanged;
	
	private JSBlockType[,] Map { get; set; }
	
	public JSMap(ScriptEngine engine) : base(engine)	{
		Map = new JSBlockType[128, 128];
		this.PopulateFunctions();
	}
	
	[JSFunction(Name = "get")]
	public JSBlockType Get(int x, int y)
	{
		return Map[x,y];
	}
	
	[JSFunction(Name = "set")]
	public void Set(int x, int y, JSBlockType blockType)
	{
		Map[x,y] = blockType;
		BlockChanged(this, new BlockChangedEventArgs(x, y, blockType));
	}
	
	[JSFunction(Name = "remove")]
	public void Remove(int x, int y)
	{
		Map[x,y] = null;
		BlockChanged(this, new BlockChangedEventArgs(x, y, null));
	}
	
	
}


