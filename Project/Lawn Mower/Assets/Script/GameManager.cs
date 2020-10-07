using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private MapCreator _mapCreator;
	private List<Tile> allTiles = new List<Tile>();
	
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LateStart(0.1f));
    }
	//Init after the MapCreate actually creates the map
	IEnumerator LateStart(float waitTime)
    {
         yield return new WaitForSeconds(waitTime);
		 init();
         //Your Function You Want to Call
    }
	//return Tiles
	public List<Tile> GetTiles(){
		return allTiles;
	}
	//return Tile Status based on Tile
	public Tile.Status getTileStatus(Tile t){
		
		return allTiles[allTiles.IndexOf(t)].currentStatus;
	}
	//return Tile Status based on Position
	public Tile.Status getTileStatus(Vector2 position){
		
		Tile temp = null;
		foreach(Tile t in allTiles){
			if(t.position == position){
				temp = t;
			}
		}
		return allTiles[allTiles.IndexOf(temp)].currentStatus;
	}
	//return Tile  based on Position
	public Tile getTile(Vector2 position){
		
		Tile temp = null;
		foreach(Tile t in allTiles){
			if(t.position == position){
				temp = t;
			}
		}
		return allTiles[allTiles.IndexOf(temp)];
	}
	public void FillFloodAlgorithm(Tile t){
		List<Tile> floodFillList = new List<Tile>();
		
		//Adiciona Vizinhos do primeiro Tile
			//Adiciona Vizinhos do primeiro Tile
			if(getTileStatus(new Vector2(t.position.x-1,t.position.y)) == Tile.Status.Grown && getTile(new Vector2(t.position.x-1,t.position.y)).visited == false){
				floodFillList.Add(getTile(new Vector2(t.position.x-1,t.position.y)));
				getTile(new Vector2(t.position.x-1,t.position.y)).visited = true;
				
			}
			if(getTileStatus(new Vector2(t.position.x-1,t.position.y+1)) == Tile.Status.Grown && getTile(new Vector2(t.position.x-1,t.position.y+1)).visited == false){
				floodFillList.Add(getTile(new Vector2(t.position.x-1,t.position.y+1)));
				getTile(new Vector2(t.position.x-1,t.position.y+1)).visited = true;
			}
			if(getTileStatus(new Vector2(t.position.x,t.position.y+1)) == Tile.Status.Grown && getTile(new Vector2(t.position.x,t.position.y+1)).visited == false){
				floodFillList.Add(getTile(new Vector2(t.position.x,t.position.y+1)));
				getTile(new Vector2(t.position.x,t.position.y+1)).visited = true;
			}
			if(getTileStatus(new Vector2(t.position.x+1,t.position.y+1)) == Tile.Status.Grown && getTile(new Vector2(t.position.x+1,t.position.y+1)).visited == false){
				floodFillList.Add(getTile(new Vector2(t.position.x+1,t.position.y+1)));
				getTile(new Vector2(t.position.x+1,t.position.y+1)).visited = true;
			}
			if(getTileStatus(new Vector2(t.position.x+1,t.position.y)) == Tile.Status.Grown && getTile(new Vector2(t.position.x+1,t.position.y)).visited == false){
				floodFillList.Add(getTile(new Vector2(t.position.x+1,t.position.y)));
				getTile(new Vector2(t.position.x+1,t.position.y)).visited = true;
			}
			if(getTileStatus(new Vector2(t.position.x+1,t.position.y-1)) == Tile.Status.Grown && getTile(new Vector2(t.position.x+1,t.position.y-1)).visited == false){
				floodFillList.Add(getTile(new Vector2(t.position.x+1,t.position.y-1)));
				getTile(new Vector2(t.position.x+1,t.position.y-1)).visited = true;
			}
			if(getTileStatus(new Vector2(t.position.x,t.position.y-1)) == Tile.Status.Grown && getTile(new Vector2(t.position.x,t.position.y-1)).visited == false){
				floodFillList.Add(getTile(new Vector2(t.position.x,t.position.y-1)));
				getTile(new Vector2(t.position.x,t.position.y-1)).visited = true;
			}
			if(getTileStatus(new Vector2(t.position.x-1,t.position.y-1)) == Tile.Status.Grown && getTile(new Vector2(t.position.x-1,t.position.y-1)).visited == false){
				floodFillList.Add(getTile(new Vector2(t.position.x-1,t.position.y-1)));
				getTile(new Vector2(t.position.x-1,t.position.y-1)).visited = true;
			}
		
		t.visited = true;
		t.currentStatus = Tile.Status.Cut;
		
		
		while(floodFillList.Count > 0){
			 t = floodFillList[floodFillList.Count-1];
			
				//Adiciona Vizinhos do primeiro Tile
			if(getTileStatus(new Vector2(t.position.x-1,t.position.y)) == Tile.Status.Grown && getTile(new Vector2(t.position.x-1,t.position.y)).visited == false){
				floodFillList.Add(getTile(new Vector2(t.position.x-1,t.position.y)));
				getTile(new Vector2(t.position.x-1,t.position.y)).visited = true;
				Debug.Log("Add");
			}
			if(getTileStatus(new Vector2(t.position.x-1,t.position.y+1)) == Tile.Status.Grown && getTile(new Vector2(t.position.x-1,t.position.y+1)).visited == false){
				floodFillList.Add(getTile(new Vector2(t.position.x-1,t.position.y+1)));
				getTile(new Vector2(t.position.x-1,t.position.y+1)).visited = true;
				Debug.Log("Add");
			}
			if(getTileStatus(new Vector2(t.position.x,t.position.y+1)) == Tile.Status.Grown && getTile(new Vector2(t.position.x,t.position.y+1)).visited == false){
				floodFillList.Add(getTile(new Vector2(t.position.x,t.position.y+1)));
				getTile(new Vector2(t.position.x,t.position.y+1)).visited = true;
				Debug.Log("Add");
			}
			if(getTileStatus(new Vector2(t.position.x+1,t.position.y+1)) == Tile.Status.Grown && getTile(new Vector2(t.position.x+1,t.position.y+1)).visited == false){
				floodFillList.Add(getTile(new Vector2(t.position.x+1,t.position.y+1)));
				getTile(new Vector2(t.position.x+1,t.position.y+1)).visited = true;
				Debug.Log("Add");
			}
			if(getTileStatus(new Vector2(t.position.x+1,t.position.y)) == Tile.Status.Grown && getTile(new Vector2(t.position.x+1,t.position.y)).visited == false){
				floodFillList.Add(getTile(new Vector2(t.position.x+1,t.position.y)));
				getTile(new Vector2(t.position.x+1,t.position.y)).visited = true;
				Debug.Log("Add");
			}
			if(getTileStatus(new Vector2(t.position.x+1,t.position.y-1)) == Tile.Status.Grown && getTile(new Vector2(t.position.x+1,t.position.y-1)).visited == false){
				floodFillList.Add(getTile(new Vector2(t.position.x+1,t.position.y-1)));
				getTile(new Vector2(t.position.x+1,t.position.y-1)).visited = true;
				Debug.Log("Add");
			}
			if(getTileStatus(new Vector2(t.position.x,t.position.y-1)) == Tile.Status.Grown && getTile(new Vector2(t.position.x,t.position.y-1)).visited == false){
				floodFillList.Add(getTile(new Vector2(t.position.x,t.position.y-1)));
				getTile(new Vector2(t.position.x,t.position.y-1)).visited = true;
				Debug.Log("Add");
			}
			if(getTileStatus(new Vector2(t.position.x-1,t.position.y-1)) == Tile.Status.Grown && getTile(new Vector2(t.position.x-1,t.position.y-1)).visited == false){
				floodFillList.Add(getTile(new Vector2(t.position.x-1,t.position.y-1)));
				getTile(new Vector2(t.position.x-1,t.position.y-1)).visited = true;
				Debug.Log("Add");
			}
			
		t.currentStatus = Tile.Status.Cut;
		floodFillList.Remove(t);
		}
	}
	
	
	//Set Tile Status based on Tile
	public void SetStatusTile(Vector2 position,Tile.Status s){
		
		Tile temp = null;
		foreach(Tile t in allTiles){
			if(t.position == position){
				t.currentStatus = s;
			}
		}
		 
	}
	public void CleanAllPaths(){
		foreach(Tile t in allTiles){
			if(t.currentStatus == Tile.Status.Path){
				t.currentStatus = Tile.Status.Grown;
			}
		}
	}
	void init(){
		//Get Mapcreator from tag
		GameObject temp_MapCreator =  GameObject.FindGameObjectWithTag("MapCreator");
		
		_mapCreator = temp_MapCreator.GetComponent<MapCreator>();
		//get all the tiles in the game
		GameObject[] temp_tiles = GameObject.FindGameObjectsWithTag("Tile");
		
		foreach(GameObject g in temp_tiles){
			allTiles.Add(g.GetComponent<Tile>());
		}
	}
    // Update is called once per frame
    void Update()
    {
        
    }
}
