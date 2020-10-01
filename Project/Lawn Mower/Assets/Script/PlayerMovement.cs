using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField]
	private List<Tile> alltiles = new List<Tile>();
	[SerializeField]
	private Vector2 actualLocation = new Vector2(0,0);
	private GameManager gm;
	void Start(){
		//Get Gamemanager from tag
		GameObject temp_gm =  GameObject.FindGameObjectWithTag("GameManager");
		
		gm = temp_gm.GetComponent<GameManager>();
	}
    // Update is called once per frame
    void Update()
    {
        if(alltiles.Count == 0){
			init();
		}
		//input up
		if(Input.GetKeyDown(KeyCode.W)){
			
			Vector2 newpos = new Vector2(0,1);
			actualLocation += newpos;
			//if the Tile is already a path  you clean all the paths and you die
			if(gm.getTileStatus(actualLocation) == Tile.Status.Path){
				gm.CleanAllPaths();
				actualLocation= new Vector2(0,0);
			}
			//change status of Tile to path
			if(gm.getTileStatus(actualLocation) != Tile.Status.Border){
				gm.SetStatusTile(actualLocation,Tile.Status.Path);
			}
			
			moveToTile();
		}
				//input Down
		if(Input.GetKeyDown(KeyCode.S)){
			
			Vector2 newpos = new Vector2(0,-1);
			actualLocation += newpos;
			//if the Tile is already a path  you clean all the paths and you die
			if(gm.getTileStatus(actualLocation) == Tile.Status.Path){
				gm.CleanAllPaths();
				actualLocation= new Vector2(0,0);
			}
			//change status of Tile to path
			if(gm.getTileStatus(actualLocation) != Tile.Status.Border){
				gm.SetStatusTile(actualLocation,Tile.Status.Path);
			}
			
			moveToTile();
		}
				//input Left
		if(Input.GetKeyDown(KeyCode.A)){
			
			Vector2 newpos = new Vector2(-1,0);
			actualLocation += newpos;
			//if the Tile is already a path  you clean all the paths and you die
			if(gm.getTileStatus(actualLocation) == Tile.Status.Path){
				gm.CleanAllPaths();
				actualLocation= new Vector2(0,0);
			}
			//change status of Tile to path
			if(gm.getTileStatus(actualLocation) != Tile.Status.Border){
				gm.SetStatusTile(actualLocation,Tile.Status.Path);
			}
			
			moveToTile();
		}
				//input Right
		if(Input.GetKeyDown(KeyCode.D)){
			
			Vector2 newpos = new Vector2(1,0);
			actualLocation += newpos;
			//if the Tile is already a path  you clean all the paths and you die
			if(gm.getTileStatus(actualLocation) == Tile.Status.Path){
				gm.CleanAllPaths();
				actualLocation= new Vector2(0,0);
			}
			//change status of Tile to path
			if(gm.getTileStatus(actualLocation) != Tile.Status.Border){
				gm.SetStatusTile(actualLocation,Tile.Status.Path);
			}
			
			moveToTile();
		}
    }
	private void init(){
		 GameObject[] temp = GameObject.FindGameObjectsWithTag("Tile");
		//pick all the tiles component from the array and put on the list
		foreach(GameObject i in temp){
			if(i.GetComponent<Tile>() != null){
				alltiles.Add(i.GetComponent<Tile>());
			}
		}
		moveToTile();
	}
	private void moveToTile(){
		
		//move player to the position that matches with the tile
		foreach(Tile t in alltiles){
			if(actualLocation == t.position){
				transform.position = t.gameObject.transform.position;
			}
		}
	}
}
