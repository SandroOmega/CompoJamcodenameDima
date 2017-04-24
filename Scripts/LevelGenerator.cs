using System.Collections;
using System.Collections.Generic;
using Random = UnityEngine.Random;
using UnityEngine;

public class LevelGenerator : MonoBehaviour {
    Transform lvl;
    public struct  Level
    {
        int x;
        int y;
        [SerializeField]
        public GameObject lvl;

        public void SetX(int i)
        {
            x = i;
        }
        public void SetY(int i)
        {
            y = i;
        }
    }

    public void LevelSetup()
    {
        
    }

    public GameObject floorFragments;
    public GameObject wallFragments;
    public Transform StartPosition;
    private int Difficulty;
    public Level part = new Level();
    void SetDifficulty(int n)
    {
        Difficulty = n;
    }

    void SetLevelParameters(int x,int y)
    {
        part.SetX(30);
        part.SetY(8);
    }
    public void Generation()
    {
    
        

    }
}