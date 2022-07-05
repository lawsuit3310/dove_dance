using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{
    Transform trans;
    public GameObject player;
    // Start is called before the first frame update
    private void Awake()
    {
        trans = GetComponent<Transform>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(player.transform.position.x )< 16)
        {
            trans.position = new Vector3(player.transform.position.x, trans.position.y, trans.position.z);
        }

        if (Mathf.Abs(player.transform.position.y) < 8.5)
        {
            trans.position = new Vector3(trans.position.x, player.transform.position.y, trans.position.z);
        }
    }
}
