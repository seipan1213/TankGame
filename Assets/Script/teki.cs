using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class teki : MonoBehaviour
{

    private Vector3 pozi;
    private Transform tank;
    public Transform mazl;
    public GameObject[] weapon;
    public GameObject tama;
    public GameObject masi;
    public GameObject fire;
    public float kyori;
    private float kankaku = 0;
    private float power = 2500;
    private GameObject[] friends;
    public GameObject bou;
    public Slider slider;
    public float enemyHP;
    public GameObject Canva;
    public GameObject Explo;
    public GameObject repair;
    public int buki;
    shooting st;
    Rigidbody rid;
    private GameObject manager;
    public Transform[] spots;
    public Transform[] kanou;
    private GameObject spot;
    private GameObject area;
    private GameObject area1;
    private GameObject area2;
    Area seiatu;
    Area seiatu1;
    Area seiatu2;
    public GameObject kakunin;
    public int i = 0;
    public int k = 0;
    public bool decision;
    public GameObject jun;
    public Vector3 moku;
    public Vector3 sei;
    public Vector3 posi;
    public Vector3 kari;
    private Vector3[] kako = new Vector3[4];
    public int back = 0;
    public int n;
    private AudioClip oto;

    // Use this for initialization
    void Start()
    {
        for (int y = 0; y < 4; y++)
        {
            kako[y] = new Vector3(0, 0, 0);
        }
        manager = GameObject.Find("GameManager");
        rid = GetComponent<Rigidbody>();
        rid.sleepThreshold = -1;
        st = manager.GetComponent<shooting>();
        weapon = new GameObject[] { tama, masi, fire };
        Tuyosa();
        tank = GameObject.Find("Tank").transform;
        Lookfor();
        decision = true;
        spot = GameObject.Find("Junkai");
        area = GameObject.Find("seiatu");
        area1 = GameObject.Find("seiatu1");
        area2 = GameObject.Find("seiatu2");
        seiatu = area.GetComponent<Area>();
        seiatu1 = area1.GetComponent<Area>();
        seiatu2 = area2.GetComponent<Area>();
        spots = new Transform[spot.transform.childCount];
        kanou = new Transform[spot.transform.childCount];
        for (int c = 0; c < spot.transform.childCount; c++)
        {
            spots[c] = spot.gameObject.transform.GetChild(c);
        }
        Next();
        this.gameObject.transform.LookAt(pozi);
    }

    // FixedUpdate is called once per frame
    void FixedUpdate()
    {
        if (tank != null)
        {

            Canva.transform.LookAt(Camera.main.transform);
            if (friends.Length != 0)
            {
                if (friends[0] == null || Vector3.Distance(this.transform.position, friends[0].transform.position) > 50)
                {
                    //state = mikatastate.sarch;
                    Lookfor();

                }

                if (Vector3.Distance(this.transform.position, friends[0].transform.position) <= 50)
                {
                    bou.transform.LookAt(friends[0].transform.position);
                    Ray ray = new Ray(bou.transform.position, bou.transform.forward);
                    Debug.DrawRay(ray.origin, ray.direction * 200, Color.red, Time.deltaTime);
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit, 100))
                    {
                        if (hit.transform.gameObject.tag != "ground" && hit.transform.gameObject.tag != "syogai" && hit.transform.gameObject.tag != "Enemy")
                        {
                            Vector3 muki = new Vector3(friends[0].transform.position.x, this.transform.position.y, friends[0].transform.position.z);
                            this.gameObject.transform.LookAt(muki);
                            kankaku += Time.deltaTime;
                            kankaku = st.Shot(mazl, buki, kankaku);

                            if (Vector3.Distance(this.transform.position, friends[0].transform.position) >= kyori)
                            {
                                rid.AddForce(transform.forward * power);
                            }
                        }
                        else
                        {
                            rid.AddForce(transform.forward * power);
                            Move();
                            Lookfor();
                        }
                    }
                }
                else
                {
                    rid.AddForce(transform.forward * power);
                    Move();
                    Lookfor();
                }
            }
            else
            {
                rid.AddForce(transform.forward * power);
                Move();
                Lookfor();
            }
            if (Vector3.Distance(this.transform.position, pozi) <= 1)
            {
                Move();
            }
        }
    }
    void Lookfor()
    {
        friends = GameObject.FindGameObjectsWithTag("mikata");

        for (int i = 0; i <= friends.Length - 1; i++)
        {
            if (Vector3.Distance(this.transform.position, friends[0].transform.position) > Vector3.Distance(this.transform.position, friends[i].transform.position))
            {
                friends[0] = friends[i];
            }
        }
    }
    public void Tuyosa()
    {
        int size = Random.Range(1, 11);

        if (size == 1)
        {
            kyori = 5;
            buki = 2;
        }
        else if (size <= 3)
        {
            kyori = 25;
            buki = 0;
        }
        else
        {
            kyori = 25;
            buki = 1;
        }
        enemyHP = Random.Range(200, 300);
        slider.maxValue = enemyHP;
        slider.value = enemyHP;

    }
    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.transform.tag == "syogai")
        {
            Next();
        }

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "tama")
        {
            enemyHP -= 70;
            slider.value = enemyHP;
        }
        if (other.gameObject.tag == "masi")
        {
            enemyHP -= 8;
            slider.value = enemyHP;

        }
        if (other.gameObject.tag == "Fire")
        {
            enemyHP -= 2f;
            slider.value = enemyHP;

        }
        if (enemyHP <= 0)
        {
            if (Random.Range(0, 5) < 1)
            {
                Instantiate(repair, this.transform.position, this.transform.rotation);
            }
            Destroy(this.gameObject);
            GameObject baku = Instantiate(Explo) as GameObject;
            baku.transform.position = this.transform.position;
            Destroy(baku.gameObject, 3.0f);
        }
    }
    void Move()
    {
        float kyori1 = Vector3.Distance(this.transform.position, area.transform.position);
        float kyori2 = Vector3.Distance(this.transform.position, area1.transform.position);
        float kyori3 = Vector3.Distance(this.transform.position, area2.transform.position);
        if (kyori1 < 50 && seiatu.senkyo != 2 || kyori2 < 50 && seiatu1.senkyo != 2 || kyori3 < 50 && seiatu2.senkyo != 2)
        {
            if (decision)
            {
                if (kyori1 > kyori2 && kyori2 > kyori3 && seiatu2.senkyo != 2)
                {
                    moku = area2.transform.position;
                    moku = new Vector3(moku.x, 0.5f, moku.z);
                    sei = area2.transform.position;

                }
                else if (kyori1 > kyori2 && kyori2 < kyori3 && seiatu1.senkyo != 2)
                {
                    moku = area1.transform.position;
                    moku = new Vector3(moku.x, 0.5f, moku.z);
                    sei = area1.transform.position;

                }
                else
                {
                    moku = area.transform.position;
                    moku = new Vector3(moku.x, 0.5f, moku.z);
                    sei = area.transform.position;

                }
                decision = false;
            }
            kakunin.transform.LookAt(sei);
            Ray ray = new Ray(kakunin.transform.position, kakunin.transform.forward);
            Debug.DrawRay(ray.origin, ray.direction * 200, Color.red, Time.deltaTime);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 50))
            {

                if (hit.transform.gameObject.tag != "ground" && hit.transform.gameObject.tag != "syogai")
                {
                    if (Vector3.Distance(this.gameObject.transform.position, moku) < 1)
                    {
                        moku = sei + new Vector3(Random.Range(-10, 11), 0, Random.Range(-10, 11));
                        moku = new Vector3(moku.x, 0.5f, moku.z);

                    }
                    this.transform.LookAt(moku);
                }

            }

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



    }
    void Next()
    {
        for (int c = 0; c < spot.transform.childCount; c++)
        {
            jun.transform.LookAt(spots[c]);
            Ray ray = new Ray(jun.transform.position, jun.transform.forward);
            Debug.DrawRay(ray.origin, ray.direction * 200, Color.red, Time.deltaTime);
            RaycastHit hit1;
            if (Physics.Raycast(ray, out hit1, 200))
            {

                if (hit1.transform.gameObject.tag != "syogai" && hit1.transform.gameObject.tag != "ground"  && spots[c].position != kako[0] && spots[c].position != kako[1] && spots[c].position != kako[2] && spots[c].position != kako[3]) 
                {
                    kanou[k] = spots[c];
                    k++;
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
        kako[back] = kari;
        back++;
        if (back > 3)
        {
            back = 0;
        }
        posi = kari + new Vector3(Random.Range(-2, 3), 0, Random.Range(-2, 3));


    }

}

