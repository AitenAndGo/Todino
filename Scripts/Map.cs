using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{

    public int width = 19;
    public int height = 19;

    // map table full of 0 at start
    private int[,] map;
    public List<List<Vector2>> roads;

    public List<Vector2> road1;
    public List<Vector2> road2;
    public List<Vector2> road3;
    public List<Vector2> road4;


    // Start is called before the first frame update
    void Start()
    {
        roads = new List<List<Vector2>>();
        road1 = new List<Vector2>();
        road2 = new List<Vector2>();
        road3 = new List<Vector2>();
        road4 = new List<Vector2>();

        map = new int[width, height];

        fill_roads();
        // making cell occupied on map
        RoadsOccupied();


    }

    void fill_roads(){
        road1.Add(new Vector2(0, 9));
        road1.Add(new Vector2(0, 8));
        road1.Add(new Vector2(-1, 8));
        road1.Add(new Vector2(-2, 8));
        road1.Add(new Vector2(-3, 8));
        road1.Add(new Vector2(-3, 7));
        road1.Add(new Vector2(-4, 7));
        road1.Add(new Vector2(-5, 7));
        road1.Add(new Vector2(-5, 6));
        road1.Add(new Vector2(-5, 5));
        road1.Add(new Vector2(-4, 5));
        road1.Add(new Vector2(-3, 5));
        road1.Add(new Vector2(-2, 5));
        road1.Add(new Vector2(-1, 5));
        road1.Add(new Vector2(0, 5));
        road1.Add(new Vector2(0, 4));
        road1.Add(new Vector2(0, 3));
        road1.Add(new Vector2(0, 2));

        // road 2
        road2.Add(new Vector2(9, 0));
        road2.Add(new Vector2(8, 0));
        road2.Add(new Vector2(8, 1));
        road2.Add(new Vector2(8, 2));
        road2.Add(new Vector2(8, 3));
        road2.Add(new Vector2(8, 4));
        road2.Add(new Vector2(8, 5));
        road2.Add(new Vector2(7, 5));
        road2.Add(new Vector2(7, 6));
        road2.Add(new Vector2(6, 6));
        road2.Add(new Vector2(5, 6));
        road2.Add(new Vector2(5, 5));
        road2.Add(new Vector2(5, 4));
        road2.Add(new Vector2(5, 3));
        road2.Add(new Vector2(5, 2));
        road2.Add(new Vector2(5, 1));
        road2.Add(new Vector2(4, 1));
        road2.Add(new Vector2(4, 0));
        road2.Add(new Vector2(3, 0));
        road2.Add(new Vector2(2, 0));

        // road 3
        road3.Add(new Vector2(0, -9));
        road3.Add(new Vector2(0, -8));
        road3.Add(new Vector2(0, -7));
        road3.Add(new Vector2(1, -7));
        road3.Add(new Vector2(2, -7));
        road3.Add(new Vector2(3, -7));
        road3.Add(new Vector2(4, -7));
        road3.Add(new Vector2(4, -8));
        road3.Add(new Vector2(5, -8));
        road3.Add(new Vector2(6, -8));
        road3.Add(new Vector2(7, -8));
        road3.Add(new Vector2(7, -7));
        road3.Add(new Vector2(7, -6));
        road3.Add(new Vector2(7, -5));
        road3.Add(new Vector2(7, -4));
        road3.Add(new Vector2(6, -4));
        road3.Add(new Vector2(5, -4));
        road3.Add(new Vector2(4, -4));
        road3.Add(new Vector2(3, -4));
        road3.Add(new Vector2(2, -4));
        road3.Add(new Vector2(1, -4));
        road3.Add(new Vector2(0, -4));
        road3.Add(new Vector2(0, -3));
        road3.Add(new Vector2(0, -2));

        // road 4
        road4.Add(new Vector2(-9, 0));
        road4.Add(new Vector2(-8, 0));
        road4.Add(new Vector2(-8, 1));
        road4.Add(new Vector2(-7, 1));
        road4.Add(new Vector2(-7, 2));
        road4.Add(new Vector2(-7, 3));
        road4.Add(new Vector2(-6, 3));
        road4.Add(new Vector2(-5, 3));
        road4.Add(new Vector2(-5, 2));
        road4.Add(new Vector2(-5, 1));
        road4.Add(new Vector2(-5, 0));
        road4.Add(new Vector2(-5, -1));
        road4.Add(new Vector2(-6, -1));
        road4.Add(new Vector2(-6, -2));
        road4.Add(new Vector2(-7, -2));
        road4.Add(new Vector2(-8, -2));
        road4.Add(new Vector2(-8, -3));
        road4.Add(new Vector2(-8, -4));
        road4.Add(new Vector2(-8, -5));
        road4.Add(new Vector2(-8, -6));
        road4.Add(new Vector2(-8, -7));
        road4.Add(new Vector2(-7, -7));
        road4.Add(new Vector2(-6, -7));
        road4.Add(new Vector2(-5, -7));
        road4.Add(new Vector2(-4, -7));
        road4.Add(new Vector2(-4, -6));
        road4.Add(new Vector2(-4, -5));
        road4.Add(new Vector2(-4, -4));
        road4.Add(new Vector2(-3, -4));
        road4.Add(new Vector2(-3, -3));
        road4.Add(new Vector2(-3, -2));
        road4.Add(new Vector2(-3, -1));
        road4.Add(new Vector2(-3, 0));
        road4.Add(new Vector2(-2, 0));

        // appendig roads to main roads list
        roads.Add(road1);
        roads.Add(road2);
        roads.Add(road3);
        roads.Add(road4);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(IsFreeCell(0, 2));
    }

    // checking if a Cell is Free
    public bool IsFreeCell(int x, int y)
    {
        return map[x, y] == 0;
    }

    public void AddObject(int x, int y)
    {
        map[x, y] = 1;
    }

    public void RemoveObject(int x, int y)
    {
        map[x, y] = 0;
    }

    public void RoadsOccupied()
    {
        foreach (List<Vector2> road in roads){
            foreach (Vector2 vector in road)
            {
                AddObject( (int)vector.x + 9, (int)vector.y + 9);
            }
        }
    }

}