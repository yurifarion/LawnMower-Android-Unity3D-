using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCreator : MonoBehaviour
{
	 [SerializeField]
	 public Vector2 dimension = new Vector2(0,0);
	 [SerializeField]
	 private float distanceTile = 1;
	 public Transform originSpawner;
	 public GameObject Tile_prefab;
	 
    // Start is called before the first frame update
    void Start()
    {
		//Create a map full of Tiles following the Dimension
		for(int i = 0 ; i < dimension.x ; ++i){
			
			for(int j = 0 ; j < dimension.y ; ++j){
				Vector3 pos = new Vector3(originSpawner.position.x + distanceTile*i,originSpawner.position.y + distanceTile*j,originSpawner.position.z);
				GameObject tile = Instantiate(Tile_prefab,pos,originSpawner.rotation);
				
				//If the tile have the component then we put the right position on it
				if(tile.GetComponent<Tile>() != null){
					tile.GetComponent<Tile>().position = new Vector2(i,j);
				}
			}
			
		}
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
