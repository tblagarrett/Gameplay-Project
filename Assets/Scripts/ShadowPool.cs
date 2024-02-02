using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;


// https://www.youtube.com/watch?v=YCHJwnmUGDk&t=1s&ab_channel=bendux
// Help on setting up an object pool

public class ShadowPool : MonoBehaviour
{
    private static ShadowPool _instance;
    public static ShadowPool Instance {  get { return _instance; } }
    private List<GameObject> pool = new List<GameObject>();
    private int amountToPool = 20;
    [SerializeField] private int lifespan = 1;
    [SerializeField] private GameObject shadowPrefab;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        { // if there is already a value assigned to the private variable and its not this, destroy this
            Destroy(this.gameObject);
        }
        else
        { // if there is no value assigned to the private variable, assign this as the reference
            _instance = this;

        }
        DontDestroyOnLoad(this);
    }

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject obj = Instantiate(shadowPrefab, this.transform);
            obj.SetActive(false);
            pool.Add(obj);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetPooledObject()
    {
        for (int i = 0; i < pool.Count; i++)
        {
            if (!pool[i].activeSelf)
            {
                return pool[i];
            }
        }

        return null;
    }

    public void Reset()
    {
        for (int i = 0; i< pool.Count; i++)
        {
            pool[i].SetActive(false);
        }
    }

    public IEnumerator Destroy(GameObject shadow)
    {
        yield return new WaitForSeconds(lifespan);
        shadow.SetActive(false);
    }
}
