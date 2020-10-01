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
