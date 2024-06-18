using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericCoin : MonoBehaviour
{
    public GameObject Dogecoin;
    public GameObject Bitcoin;
    public GameObject Litecoin;
    public GameObject IOARToken;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Dogelaser")
        {
            if(this.tag == "wingedDogecoin")
            {
               Instantiate(Dogecoin, transform.position, transform.rotation);
            }
            if (this.tag == "wingedLitecoin")
            {
                Instantiate(Litecoin, transform.position, transform.rotation);
            }
            if (this.tag == "wingedBitcoin")
            {
                Instantiate(Bitcoin, transform.position, transform.rotation);
            }
            if (this.tag == "wingedIOARToken")
            {
                Instantiate(IOARToken, transform.position, transform.rotation);
            }
            Destroy(this.gameObject);
        } 
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
