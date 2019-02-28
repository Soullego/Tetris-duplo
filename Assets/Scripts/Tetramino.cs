using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tetramino : MonoBehaviour
{
	public enum RotationType
	{
		Blocked = 0,
		Limited = 1,
		Allowed = 2
	}
    [SerializeField] public RotationType rotationMode = RotationType.Blocked;
    
    // Start is called before the first frame update
    void Start()
    {
		
    }

    //// Update is called once per frame
    void Update()
    {
		
    }

    

    
}
