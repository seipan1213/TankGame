using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class junkai : MonoBehaviour
{

    public Transform[] spots;
    public Transform[] kanou;
    public GameObject spot;
    public GameObject area;
    public GameObject area1;
    public GameObject area2;
    Area seiatu;
    Area seiatu1;
    Area seiatu2;

    public int i = 0;
    public int k = 0;
    public bool decision;
    public GameObject jun;
    public Vector3 distance;
    public Vector3 moku;
    public Vector3 posi;
    public Vector3 kari;
    public int n;
    // Use this for initialization
    void Start()
    {
        seiatu = area.GetComponent<Area>();
        seiatu1 = area1.GetComponent<Area>();
        seiatu2 = area2.GetComponent<Area>();
        spots = new Transform[spot.transform.childCount];
        kanou = new Transform[spot.transform.childCount];
        for (int c = 0; c < spot.transform.childCount; c++)
        {
            spots[c] = spot.gameObject.transform.GetChild(c);
        }
        decision = true;
        Next();
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        float kyori1 = Vector3.Distance(this.transform.position, area.transform.position);
        float kyori2 = Vector3.Distance(this.transform.position, area1.transform.position);
        float kyori3 = Vector3.Distance(this.transform.position, area2.transform.position);

        if (kyori1 < 40 && seiatu.senkyo != 1 || kyori2 < 40 && seiatu1.senkyo != 1 || kyori3 < 40 && seiatu2.senkyo != 1)
        {
            if (decision)
            {
                if (kyori1 > kyori2 && kyori2 > kyori3 && seiatu2.senkyo != 1) 
                {
                    moku = area2.transform.position;
                }
                else if (kyori1 > kyori2 && kyori2 < kyori3 && seiatu1.senkyo != 1) 
                {
                    moku = area1.transform.position;
                }
                else
                {
                    moku = area2.transform.position;
                }
                moku = moku + new Vector3(Random.Range(-10, 11),0, Random.Range(-10, 11));
                moku = new Vector3(moku.x, 0.5f, moku.z);
                decision = false;
            }
            if (Vector3.Distance(moku, this.gameObject.transform.position) < 1)
            {
                decision = true;
            }
            this.transform.LookAt(moku);
        }
        else
        {

            this.transform.LookAt(posi);
            if (Vector3.Distance(this.gameObject.transform.position, posi) <= 1)
            {
                i++;
                if (i >= spots.Length || kanou[i] == null)
                {
                    i = 0;
                }
                Next();
            }
        }
          this.transform.Translate(Vector3.forward * 0.2f);

    }
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.transform.tag == "syogai")
        {
            Next();
        }
    }
    void Next()
    {
        for (int c = 0; c < spot.transform.childCount; c++)
        {
            jun.transform.LookAt(spots[c]);
            Ray ray = new Ray(jun.transform.position, jun.transform.forward);
            Debug.DrawRay(ray.origin, ray.direction * 200, Color.red, Time.deltaTime);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 200))
            {

                if (hit.transform.gameObject.tag != "ground" && hit.transform.gameObject.tag != "syogai" && spots[c].position != kari) 
                {
                    kanou[k] = spots[c];
                    k++;
                    Debug.Log(hit.transform.gameObject.tag);
                }
            }
        }
        n = 0;
        do
        {
            n++;
        } while (kanou[n] != null);
        k = 0;
        int rand = Random.Range(0, n);
        kari = kanou[rand].transform.position;
        posi = kari + new Vector3(Random.Range(-5, 5), 0, Random.Range(-5, 5));



    }
}
        //for (int g = 0; g< 3; g++)
        //{
        //    switch (g)
        //    {
        //        case 0:
        //            kakunin.transform.LookAt(area.transform.position);
        //            Ray ray = new Ray(kakunin.transform.position, kakunin.transform.forward);
//Debug.DrawRay(ray.origin, ray.direction * 200, Color.red, Time.deltaTime);
//RaycastHit hit;
//                    if (Physics.Raycast(ray, out hit, 50))
//                    {

//                        if (hit.transform.gameObject.tag != "seiatu")
//                        {
//                            stop = false;
//                        }
//                    }
//                    break;
//                case 1:
//                    kakunin.transform.LookAt(area.transform.position);
//                    ray = new Ray(kakunin.transform.position, kakunin.transform.forward);
//Debug.DrawRay(ray.origin, ray.direction* 200, Color.red, Time.deltaTime);
//                    if (Physics.Raycast(ray, out hit, 50))
//                    {

//                        if (hit.transform.gameObject.tag != "seiatu")
//                        {
//                            stop1 = false;
//                        }
//                    }
//                    break;
//                case 2:
//                    kakunin.transform.LookAt(area.transform.position);
//                    ray = new Ray(kakunin.transform.position, kakunin.transform.forward);
//Debug.DrawRay(ray.origin, ray.direction* 200, Color.red, Time.deltaTime);
//                    if (Physics.Raycast(ray, out hit, 50))
//                    {

//                        if (hit.transform.gameObject.tag != "seiatu")
//                        {
//                            stop2 = false;
//                        }
//                    }
//                    break;
//            }
//        }

