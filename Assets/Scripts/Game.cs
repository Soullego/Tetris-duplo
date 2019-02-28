using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    GameObject TetraminoNext, TetraminoActive, Field;
    public static int gridWidth = 10;
    public static int gridHeight = 20;


    float fall = 0;
	float move = 0;
    float fallSpeed = 1;
	float MoveSpeed = 0.15f;

    public bool allowRotation = true;
    public bool limitRotation = false;
    // Start is called before the first frame update
    void Start()
    {
        Field = (GameObject)Instantiate(Resources.Load("Prefabs/Field"),new Vector3(4,-1),Quaternion.identity);
        SpawnNextTetramino();
    }

    // Update is called once per frame
    void Update()
    {

    }

    string GetRandomTetramino()
    {
        string name = "Prefabs/Tetramino_J";
        switch (Random.Range(0,7))
        {
		case 0: name = "Prefabs/Tetramino_O"; break;
		case 1: name = "Prefabs/Tetramino_I"; break;
		case 2: name = "Prefabs/Tetramino_J"; break;
		case 3: name = "Prefabs/Tetramino_L"; break;
		case 4: name = "Prefabs/Tetramino_S"; break;
		case 5: name = "Prefabs/Tetramino_T"; break;
		case 6: name = "Prefabs/Tetramino_Z"; break;
        }
        return name;
    }
    public void SpawnNextTetramino()
    {
        TetraminoNext = (GameObject)Instantiate(Resources.Load(GetRandomTetramino()),new Vector3(4,18),Quaternion.identity);
        
    }
    void Fall()
    {
        if (Time.time - fall >= fallSpeed)
        {
            transform.position += Vector3.down;
			if (!CheckIsValidPosition())
            { 
                TetraminoActive.transform.SetParent(Field.transform,false);
                SpawnNextTetramino();
            }
            fall = Time.time;
        }
    }

    bool CheckIsInsideGrid(Vector2 pos)
    {
        return ((int)pos.x >= 0 && (int)pos.x < gridWidth && (int)pos.y > 0);
    }
    Vector2 Round(Vector2 pos)
    {
        return new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y));
    }
    void CheckUserInPut ()
    {
		if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
		{
			transform.position += Vector3.right;
			if (!CheckIsValidPosition()) { transform.position += Vector3.left; }
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
		{
			transform.position += Vector3.left;
			if (!CheckIsValidPosition()) { transform.position += Vector3.right; }
		}
		if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
		{
			transform.position += Vector3.down;
			if (!CheckIsValidPosition()) { transform.position += Vector3.up; }
		}

		if (Time.time - move >= MoveSpeed)
		{
			if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
	        {
				transform.position += Vector3.right;
				if (!CheckIsValidPosition()) { transform.position += Vector3.left; }
	        }
			if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
	        {
	            transform.position += Vector3.left;
	            if (!CheckIsValidPosition()) { transform.position += Vector3.right; }
	        }
			if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
	        {
	            transform.position += Vector3.down;
	            if (!CheckIsValidPosition()) { transform.position += Vector3.up; }
	        }
			move = Time.time;
		}
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (Tetramino.rotationMode)
			{
				if (limitRotation)
				{
					if (transform.rotation.eulerAngles.z >= 90)
					{
						transform.Rotate(0, 0, -90);
					}
					else
					{
						transform.Rotate(0, 0, 90);
					}
				}
				else
				{
					transform.Rotate(0, 0, 90);
				}
				if (!CheckIsValidPosition())
				{
					if (limitRotation)
					{
						if (transform.rotation.eulerAngles.z >= 90)
						{
							transform.Rotate(0, 0, -90);
						}
						else
						{
							transform.Rotate(0, 0, 90);
						}
					}
					else
					{
						transform.Rotate(0, 0, -90);
					}
				}

			}

		}
    }

    bool CheckIsValidPosition()
    {
        foreach(Transform mino in transform)
        {
            Vector2 pos = Round(mino.position);
            if (CheckIsInsideGrid(pos) == false)
            {
                return false;
            }
        }
        return true;
    }
}
