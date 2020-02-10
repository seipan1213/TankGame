using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{

    public GameObject tama;
    public GameObject masi;
    public GameObject fire;
    public GameObject[] weapon;
    private int buki = 0;
    public Transform barrel;
    public float kankaku;
    public float firing;
    public float power = 8000f;
    public GameObject main;
    public GameObject sub;
    public GameObject fsub;
    public GameObject text;

    // Use this for initialization
    void Start()
    {
        weapon = new GameObject[] { tama, masi, fire };
        main.SetActive(true);
        sub.SetActive(false);
        fsub.SetActive(false);
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown("1"))
        {
            buki = 0;
            kankaku = 1.8f;
            main.SetActive(true);
            sub.SetActive(false);
            fsub.SetActive(false);
        }
        if (Input.GetKeyDown("2"))
        {
            buki = 1;
            main.SetActive(false);
            sub.SetActive(true);
            fsub.SetActive(false);

        }
        if (Input.GetKeyDown("3"))
        {
            buki = 2;
            main.SetActive(false);
            sub.SetActive(false);
            fsub.SetActive(true);

        }
        kankaku += Time.deltaTime;
        Shot();

    }
    public void Shot()
    {
        switch(buki){
            case 0:
                firing = 2;
                break;
            case 1:
                firing = 0.1f;
                break;
            case 2:
                firing = 0.02f;
                break;
        }
        if (kankaku >= firing)
        {
            if (Input.GetMouseButton(0) && text.activeSelf == false)
            {
                GameObject shot = Instantiate(weapon[buki], barrel.position, barrel.rotation);
                if (buki != 2)
                {
                    shot.GetComponent<Rigidbody>().AddForce(barrel.forward * 8000);
                }
                else
                {
                    shot.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                    Destroy(shot, 0.2f);
                }
                kankaku = 0;
            }
        }
    }
    public float Shot(Transform hassya, int arms, float reroad)
    {
        float firing = 0;
        switch (arms)
        {
            case 0:
                firing = 2;
                break;
            case 1:
                firing = 0.3f;
                break;
            case 2:
                firing = 0.05f;
                break;
        }
        if (reroad >= firing)
        {
            GameObject shot = Instantiate(weapon[arms], hassya.position, hassya.rotation);
            if (arms != 2)
            {
                shot.GetComponent<Rigidbody>().AddForce(hassya.forward * 8000);
            }
            else
            {
                shot.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
                Destroy(shot, 0.2f);
            }
            reroad = 0;
        }
        return reroad;
    }
}

