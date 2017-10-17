using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicTiles : MonoBehaviour
{
	public int tileWidth, tileHeight;

	public Transform target;
	
	public GameObject tilePrefab;
	GameObject[] tiles;

	float realPosX, realPosY;

	int gridPosX, gridPosY;
	int prevGridPosX, prevGridPosY;

	void Start ()
	{
		tiles = new GameObject[9];

		tiles [0] = Instantiate (tilePrefab, new Vector3 (tileWidth * -1, 0, tileHeight *  1), Quaternion.identity, transform);
		tiles [1] = Instantiate (tilePrefab, new Vector3 (tileWidth *  0, 0, tileHeight *  1), Quaternion.identity, transform);
		tiles [2] = Instantiate (tilePrefab, new Vector3 (tileWidth *  1, 0, tileHeight *  1), Quaternion.identity, transform);
		tiles [3] = Instantiate (tilePrefab, new Vector3 (tileWidth * -1, 0, tileHeight *  0), Quaternion.identity, transform);
		tiles [4] = Instantiate (tilePrefab, new Vector3 (tileWidth *  0, 0, tileHeight *  0), Quaternion.identity, transform);
		tiles [5] = Instantiate (tilePrefab, new Vector3 (tileWidth *  1, 0, tileHeight *  0), Quaternion.identity, transform);
		tiles [6] = Instantiate (tilePrefab, new Vector3 (tileWidth * -1, 0, tileHeight * -1), Quaternion.identity, transform);
		tiles [7] = Instantiate (tilePrefab, new Vector3 (tileWidth *  0, 0, tileHeight * -1), Quaternion.identity, transform);
		tiles [8] = Instantiate (tilePrefab, new Vector3 (tileWidth *  1, 0, tileHeight * -1), Quaternion.identity, transform);
	}

	void Update () 
	{
		UpdateRealPosition ();
		UpdateGridPosition ();
		CheckTileChange ();
	}

	private void UpdateRealPosition()
	{
		realPosX = target.position.x;
		realPosY = target.position.z;
	}

	private void UpdateGridPosition()
	{
		prevGridPosX = gridPosX;
		prevGridPosY = gridPosY;

		gridPosX = (int)Mathf.Round (realPosX / tileWidth);
		gridPosY = (int)Mathf.Round (realPosY / tileHeight);
	}

	private void CheckTileChange()
	{
		if (prevGridPosX < gridPosX)
			MoveRight ();
		else if (prevGridPosX > gridPosX)
			MoveLeft ();

		if (prevGridPosY < gridPosY)
			MoveUp ();
		else if (prevGridPosY > gridPosY)
			MoveDown ();
	}

	private void MoveUp()
	{
		//Debug.Log ("Move Up");
		for (int i = 0; i < 3; i++) {
			tiles [i + 6].transform.position = tiles [i].transform.position + Vector3.forward * tileHeight;
			GameObject temp = tiles [i];
			tiles [i] = tiles [i + 6];
			tiles [i + 6] = tiles [i + 3];
			tiles [i + 3] = temp;
		}

	}

	private void MoveDown()
	{
		//Debug.Log ("Move Down");
		for (int i = 0; i < 3; i++) {
			tiles [i].transform.position = tiles [i + 6].transform.position + Vector3.back * tileHeight;
			GameObject temp = tiles [i + 6];
			tiles [i + 6] = tiles [i];
			tiles [i] = tiles [i + 3];
			tiles [i + 3] = temp;
		}
	}

	private void MoveRight()
	{
		//Debug.Log ("Move Right");
		for (int i = 0; i < 9; i+=3) {
			tiles [i].transform.position = tiles [i + 2].transform.position + Vector3.right * tileWidth;
			GameObject temp = tiles [i + 2];
			tiles [i + 2] = tiles [i];
			tiles [i] = tiles [i + 1];
			tiles [i + 1] = temp;
		}
	}

	private void MoveLeft()
	{
		//Debug.Log ("Move Left");
		for (int i = 0; i < 9; i+=3) {
			tiles [i + 2].transform.position = tiles [i].transform.position + Vector3.left * tileWidth;
			GameObject temp = tiles [i];
			tiles [i] = tiles [i + 2];
			tiles [i + 2] = tiles [i + 1];
			tiles [i + 1] = temp;
		}
	}
}
