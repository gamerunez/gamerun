using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGroundSpawn :MonoBehaviour,iBaseGame {
    public float speedMove = 10.0f;
    public float positionY  = -3.0f;
    [SerializeField]
    private Vector3 screenSize = new Vector3();
    [SerializeField]
    private Vector3 startPoint = new Vector3();

    public CGround groundLeft;
    public CGround groundMiddle;
    public CGround groundRight;

    private float space = 0;
   
    [SerializeField]
    private Vector2 lastPosition = new Vector2();

    [SerializeField]
    private List<CGround> listground = new List<CGround>();
   
    void Awake()
    {
        ObjectManager.Instance.listGameUpdate.Add(this);
    }

    #region iBaseGame implementation

    public void Initiate()
    {
        screenSize = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width,Screen.height));
        startPoint = new Vector3(-screenSize.x , positionY);
        //
        for (int i = 0; i < 25; i++)
        {
            CGround groundClone = Instantiate<CGround>(groundMiddle,this.transform);
            groundClone.SetUp(new Vector2(startPoint.x+i,positionY));
            listground.Add(groundClone);
        }
    }

    public void UpdateGame(float _deltaTime)
    {
        
    }

    #endregion
}
