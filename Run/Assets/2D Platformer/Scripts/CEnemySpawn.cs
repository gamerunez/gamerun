using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CEnemySpawn :MonoBehaviour,iBaseGame{
    public CEnemy myEnemy1;
    public CEnemy myEnemy2;

    public Transform positionSpawnRight;
    public Transform positionSpawnLeft;
    [SerializeField]
    private List<CEnemy> listEnemy = new List<CEnemy>();

    void Awake()
    {
        ObjectManager.Instance.listGameUpdate.Add(this);
    }
    public void SpawnEnemy()
    {
        StartCoroutine(Spawn(myEnemy1,positionSpawnRight.position,-3.0f));
        StartCoroutine(Spawn(myEnemy2,positionSpawnLeft.position,2.0f));
    }

    private IEnumerator Spawn(CEnemy _enemy,Vector3 _positionStart,float _velo)
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(1.5f,2.0f));
            CEnemy enemy = Instantiate<CEnemy>(_enemy, this.transform);
            enemy.Setup(_positionStart, _velo);
            listEnemy.Add(enemy);
        }
    }
      
    #region iBaseGame implementation

    public void Initiate()
    {
        SpawnEnemy();
    }

    public void UpdateGame(float _deltaTime)
    {
        for (int i = 0; i < listEnemy.Count; i++)
        {
            if (listEnemy[i] == null)
            {
                listEnemy.RemoveAt(i);
            }
            else
                listEnemy[i].Move(Time.deltaTime);
        }
    }

    #endregion
}
