using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
	public Vector2 position = new Vector2(0,0);
	private MapCreator _mapCreator;
	public enum Status {Border,Path,Cut,Grown};
	
	[SerializeField]
	public Status currentStatus;
    // Start is called before the first frame update
    void Start()
    {
		//Get Mapcreator from tag
		GameObject temp_MapCreator =  GameObject.FindGameObjectWithTag("MapCreator");
		
		_mapCreator = temp_MapCreator.GetComponent<MapCreator>();
		
        currentStatus = Status.Grown;//default value to the tiles
    }

    // Update is called once per frame
    void Update()
    {
        ChangeColorBasedOnStatus();
		CheckStatus();
    }
	void CheckStatus(){
		//see if the tile is on border
		if(position.x == 0 || position.x == (_mapCreator.dimension.x -1) || position.y ==0 || position.y == (_mapCreator.dimension.y-1)){
			currentStatus = Status.Border;
		}
	}
	void ChangeColorBasedOnStatus(){
		
		if(currentStatus == Status.Grown){
			GetComponent<SpriteRenderer>().color = Color.white;
		}
		if(currentStatus == Status.Border){
			GetComponent<SpriteRenderer>().color = Color.blue;
		}
		if(currentStatus == Status.Path){
			GetComponent<SpriteRenderer>().color = Color.red;
		}
		if(currentStatus == Status.Cut){
			GetComponent<SpriteRenderer>().color = Color.gray;
		}
	}
}
