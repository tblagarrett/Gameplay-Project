using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public float distanceToGround;
    private static PlayerManager _instance; // make a static private variable of the component data type
    public static PlayerManager Instance { get { return _instance; } } // make a public way to access the private variable\
    public GameObject Player { get { return GameObject.FindWithTag("Player"); } }

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
        // This will place a shadow under the player every half second
        StartCoroutine(PlaceShadow());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator PlaceShadow()
    {
        for(;;)
        {
            Ray ray = new Ray(this.Player.transform.position, Vector3.down);
            RaycastHit hit;
            if (Physics.Raycast(this.Player.transform.position, Vector3.down, out hit, distanceToGround))
            {
                Debug.Log(hit.point);
            }

            yield return new WaitForSeconds(.1f);
        }
    }

    IEnumerator Fade(GameObject obj)
    {
        Color c = GetComponent<Renderer>().material.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            c.a = alpha;
            GetComponent<Renderer>().material.color = c;
            yield return new WaitForSeconds(.1f);
        }
    }
}