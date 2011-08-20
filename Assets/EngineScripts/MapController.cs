using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Jurassic.Library;

public class MapController : MonoBehaviour
{
	private GameContext context;
	
	public Material BaseBlockMaterial;
	public GameObject BlockPrefab;
	
	private Dictionary<string, Material> blockMaterials = new Dictionary<string, Material>();
	
	void Start ()
	{
		context = GetComponent<GameContext>();
		context.BlockTypes.OnAdded += BlockTypes_OnAdded;
		
		context.Map.BlockChanged += Map_BlockChanged;
	}

	private void BlockTypes_OnAdded (object sender, ObservableDictionary<string, JSBlockType>.DictionaryEventArgs e)
	{
		var material = new Material(BaseBlockMaterial);
		material.color = GetColor(e.Value);
		blockMaterials.Add(e.Key, material);
		e.Value.ColorChanged += BlockType_ColorChanged;
	}

	void BlockType_ColorChanged (object sender, ParamEventArgs<JSBlockType> e)
	{
		var blockType = sender as JSBlockType;
		blockMaterials[blockType.Name].color = GetColor(e.Value);
	}
	
	private void Map_BlockChanged (object sender, JSMap.BlockChangedEventArgs e)
	{
		//Loop through all blocks objects, see if we have to update or add one
		GameObject foundBlock = null;
		foreach (var block in GameObject.FindGameObjectsWithTag("Block"))
		{
			if (Mathf.Approximately(block.transform.position.x, e.X) && Mathf.Approximately(block.transform.position.y, e.Y)) {
				foundBlock = block;
				break;
			}
		}
		
		if (e.BlockType == null)
		{
			if (foundBlock != null) 
			{
				DestroyObject(foundBlock);
			}
		}
		else
		{
			if (foundBlock == null)
			{
				foundBlock = (GameObject)Instantiate(BlockPrefab, new Vector3(e.X, e.Y, 0), Quaternion.identity);
			}
			
			foundBlock.renderer.material = blockMaterials[e.BlockType.Name];
		}
	} 
	
	private Color GetColor(JSBlockType jColor)
	{
		int red = jColor.Red;
		int green = jColor.Green;
		int blue = jColor.Blue;
		
		return new Color(red / 255f, green / 255f, blue / 255f);		
	}
}

