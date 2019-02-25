using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{

    public static int gridWidth = 10;
    public static int gridHeight = 20;
    // Start is called before the first frame update
    void Start()
    {
        SpawnNextTetramino();
    }

    // Update is called once per frame
    void Update()
    {

    }

    string GetRandomTetramino()
    {
        string name = "Tetramino_J";
        switch (Random.Range(0,7))
        {
            case 0: name = "Tetramino_O"; break;
            case 1: name = "Tetramino_I"; break;
            case 2: name = "Tetramino_J"; break;
            case 3: name = "Tetramino_L"; break;
            case 4: name = "Tetramino_S"; break;
            case 5: name = "Tetramino_T"; break;
            case 6: name = "Tetramino_Z"; break;
        }
        return name;
    }
    public void SpawnNextTetramino()
    {
        Instantiate(Resources.Load(GetRandomTetramino()),new Vector3(5,20),Quaternion.identity);
        
    }

    public bool CheckIsInsideGrid(Vector2 pos)
    {
        return ((int)pos.x >= 0 && (int)pos.x < gridWidth && (int)pos.y >= 0);
    }
    public Vector2 Round(Vector2 pos)
    {
        return new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y));
    }
}
