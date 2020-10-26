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
	
	public Tile FirstTile;
	public Tile LastTile;
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
		if(Input.GetKey(KeyCode.W)){
			
			Vector2 newpos = new Vector2(0,1);
			SelectNextTile(newpos);
		}
				//input Down
		if(Input.GetKey(KeyCode.S)){
			
			Vector2 newpos = new Vector2(0,-1);
			SelectNextTile(newpos);
		}
				//input Left
		if(Input.GetKey(KeyCode.A)){
			
			Vector2 newpos = new Vector2(-1,0);
			SelectNextTile(newpos);
		}
				//input Right
		if(Input.GetKey(KeyCode.D)){
			
			Vector2 newpos = new Vector2(1,0);
			SelectNextTile(newpos);
		}
    }
	private void init(){
		FirstTile = null;
		LastTile = null;
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
	private void SelectNextTile(Vector2 newpos){
			
			//if the Tile is already a path  you clean all the paths and you die
			if(gm.getTileStatus(actualLocation + newpos) == Tile.Status.Path){
				gm.CleanAllPaths();
				actualLocation= new Vector2(0,0);
				moveToTile();
				return ;
			}
			//change status of Tile to path
			if(gm.getTileStatus(actualLocation + newpos) == Tile.Status.Grown){
				if(gm.getTileStatus(actualLocation) == Tile.Status.Border){
					FirstTile = gm.getTile(actualLocation);
				}
				actualLocation += newpos;
				moveToTile();
				gm.SetStatusTile(actualLocation,Tile.Status.Path);
				return ;
			}
			//change status of Tile to path
			if(gm.getTileStatus(actualLocation + newpos) == Tile.Status.Border){
				if(gm.getTileStatus(actualLocation) == Tile.Status.Path){
					LastTile = gm.getTile(actualLocation);
					gm.FillFloodAlgorithm(gm.getTile(new Vector2(actualLocation.x-1,actualLocation.y)));
					//gm.getTile(new Vector2(actualLocation.x-1,actualLocation.y)).currentStatus = Tile.Status.Cut;
				}
				actualLocation += newpos;
				moveToTile();
				return ;
			}
			actualLocation += newpos;
			moveToTile();
	}
}
