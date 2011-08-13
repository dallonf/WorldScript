using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameContext : MonoBehaviour
{
	public Material BaseBlockMaterial;
	public GameObject BlockPrefab;
	
	public Dictionary<string, JSBlockType> BlockTypes { get; private set; }
	public JSBlockType[,] Map { get; set; }

	// Use this for initialization
	void Awake ()
	{
		BlockTypes = new Dictionary<string, JSBlockType>();
		Map = new JSBlockType[128, 128];
	}
	
	public void SetBlock(int x, int y, JSBlockType blockType)
	{
		Map[x, y] = blockType;
		//Loop through all blocks objects, see if we have to update or add one
		GameObject foundBlock = null;
		foreach (var block in GameObject.FindGameObjectsWithTag("Block"))
		{
			if (Mathf.Approximately(block.transform.position.x, x) && Mathf.Approximately(block.transform.position.y, y)) {
				foundBlock = block;
				break;
			}
		}
		
		if (foundBlock == null)
		{
			foundBlock = (GameObject)Instantiate(BlockPrefab, new Vector3(x, y, 0), Quaternion.identity);
		}
		
		if (blockType.Material == null) {
			blockType.Material = new Material(BaseBlockMaterial);
		}
		
		//This part is inefficient, should be done with an observer
		blockType.Material.SetColor("_Color", new Color((float)blockType.Red / 255, (float)blockType.Green / 255, (float)blockType.Blue / 255));
		
		foundBlock.renderer.material = blockType.Material;
		
	}
}


