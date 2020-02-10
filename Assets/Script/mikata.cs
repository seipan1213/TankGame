using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class mikata : MonoBehaviour {

    public Image tomo;
    private GameObject tank;
    public GameObject bou;
    public GameObject tama;
    private Vector3 pozi;
    public float kankaku;
    public GameObject mazl;
    public Slider slider;
    public float mikataHP;
    private float power = 2500;
    public GameObject Canva;
    public GameObject Explo;
    private GameObject[] enemys;
    private GameObject temp;
    private bool sonzai = true;
    public int buki = 0;
    public bool tuiju = false;
    private GameObject manager;
    shooting st;
    Rigidbody rid;
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
    private float kyori;
    private float nagasa;
    public enum mikatastate
    {
        sarch,attack,target
    }
    public mikatastate state;
    // Use this for initialization
    void Start () {
        Tuyosa();
        for (int y = 0; y < 4; y++)
        {
            kako[y] = new Vector3(0, 0, 0);
        }
        manager = GameObject.Find("GameManager");
        st = manager.GetComponent<shooting>();
        mikataHP = 200;
        slider.maxValue = mikataHP;
        slider.value = mikataHP;
        tank = GameObject.Find("Tank");
        rid = GetComponent<Rigidbody>();
        rid.sleepThreshold = -1;
        Rand();
        decision = true;
        Sento();
        spot = GameObject.Find("Junkai");
        area = GameObject.Find("seiatu");
        area1 = GameObject.Find("seiatu1");
        area2 = GameObject.Find("seiatu2");
        seiatu = area.GetComponent<Area>();
        seiatu1 = area1.GetComponent<Area>();
        seiatu2 = area2.GetComponent<Area>();
        spots = new Transform[spot.transform.childCount];
        kanou = new Transform[spot.transform.childCount + 1];
        for (int c = 0; c < spot.transform.childCount; c++)
        {
            spots[c] = spot.gameObject.transform.GetChild(c);
        }
        Next();
        this.gameObject.transform.LookAt(pozi);

    }

    // FixedUpdate is called once per frame
    void FixedUpdate() {
        if (tank != null)
        {
            Canva.transform.LookAt(Camera.main.transform);
            Sento();
            if (tuiju)
            {
                tomo.gameObject.SetActive(true);
            }
            else
            {
                tomo.gameObject.SetActive(false);
            }
            if (Vector3.Distance(tank.transform.position, this.transform.position) >= 50)
            {
                tuiju = false;
            }
            if (enemys.Length != 0)
            {
                if (enemys[0] == null || Vector3.Distance(this.transform.position, enemys[0].transform.position) > 50)
                {
                    state = mikatastate.sarch;
                    Sento();

                }
                if (enemys[0].name== "EnemySIRO")
                {
                    nagasa = 100;
                }
                else
                {
                    nagasa = 50;
                }
                 if (Vector3.Distance(this.transform.position, enemys[0].transform.position) <= nagasa)
                {
                    bou.transform.LookAt(enemys[0].transform.position);
                    Ray ray = new Ray(bou.transform.position, bou.transform.forward);
                    Debug.DrawRay(ray.origin, ray.direction * 200, Color.red, Time.deltaTime);
                    RaycastHit hit;

                    if (Physics.Raycast(ray, out hit, 100))
                    {

                        if (hit.transform.gameObject.tag != "ground" && hit.transform.gameObject.tag != "syogai" && hit.transform.gameObject.tag != "mikata")
                        {
                            Vector3 muki = new Vector3(enemys[0].transform.position.x, this.transform.position.y, enemys[0].transform.position.z);
                            this.gameObject.transform.LookAt(muki);
                            kankaku += Time.deltaTime;
                            kankaku = st.Shot(mazl.transform, buki, kankaku);
                            state = mikatastate.attack;
                            if (Vector3.Distance(this.transform.position, enemys[0].transform.position) >= kyori)
                            {
                                rid.AddForce(transform.forward * power);
                            }
                        }
                        else
                        {
                            Debug.Log(1);
                            rid.AddForce(transform.forward * power);
                            if (tuiju)
                            {
                                this.gameObject.transform.LookAt(pozi);
                            }
                            else
                            {
                                Move();
                            }
                            Sento();
                        }
                    }
                }
                else
                {
                    if (tuiju)
                    {
                        this.gameObject.transform.LookAt(pozi);
                    }
                    else
                    {
                        Move();
                    }
                    rid.AddForce(transform.forward * power);
                    Sento();
                }
            }
            else
            {
                state = mikatastate.target;
                if (tuiju)
                {
                    this.gameObject.transform.LookAt(pozi);
                }
                else
                {
                    Move();
                }
                rid.AddForce(transform.forward * power);
                Sento();
            }
            if (Vector3.Distance(this.transform.position, pozi) <= 1 && tuiju)
            {
                Rand();
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "tama")
        {
            mikataHP -= 70;
            slider.value = mikataHP;
        }
        if (other.gameObject.tag == "masi")
        {
            mikataHP-= 8;
            slider.value = mikataHP;

        }
        if (other.gameObject.tag == "Fire")
        {
            mikataHP -= 2f;
            slider.value = mikataHP;

        }

        if (mikataHP <= 0)
        {
            Destroy(this.gameObject);
            GameObject baku = Instantiate(Explo) as GameObject;
            baku.transform.position = this.transform.position;
            Destroy(baku.gameObject, 3.0f);
        }
    }

    void OnCollisionStay(Collision other)
    {
        if (other.gameObject.tag != "ground" && other.gameObject.tag != "BOX" && tuiju)
        {
            Rand();
        }
        if (other.gameObject.name == "Tank")
        {
            tuiju = true;
        }
        if (other.gameObject.transform.tag == "syogai")
        {
            Next();
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
        mikataHP = Random.Range(200, 300);
        slider.maxValue = mikataHP;
        slider.value = mikataHP;

    }

    void Rand()
    {
        pozi = tank.transform.position;
        do
        {
            pozi = tank.transform.position + new Vector3(Random.Range(-10, 10),0, Random.Range(-10, 10));
            pozi = new Vector3(pozi.x, 0.5f, pozi.z);
        } while (pozi == tank.transform.position);
    }
    void Move()
    {
        float kyori1 = Vector3.Distance(this.transform.position, area.transform.position);
        float kyori2 = Vector3.Distance(this.transform.position, area1.transform.position);
        float kyori3 = Vector3.Distance(this.transform.position, area2.transform.position);
        if (kyori1 < 50 && seiatu.senkyo != 1 || kyori2 < 50 && seiatu1.senkyo != 1 || kyori3 < 50 && seiatu2.senkyo != 1)
        {
            if (decision)
            {
                if (kyori1 > kyori2 && kyori2 > kyori3 && seiatu2.senkyo != 1)
                {
                    moku = area2.transform.position;
                    moku = new Vector3(moku.x, 0.5f, moku.z);
                    sei = area2.transform.position;

                }
                else if (kyori1 > kyori2 && kyori2 < kyori3 && seiatu1.senkyo != 1)
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
                    if (Vector3.Distance(this.gameObject.transform.position,moku) < 1)
                    {
                        moku = sei + new Vector3(Random.Range(-10, 11), 0, Random.Range(-10, 11));
                        moku = new Vector3(moku.x, 0.5f, moku.z);
                        
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

                if (hit1.transform.gameObject.tag != "syogai" && hit1.transform.gameObject.tag != "ground" && spots[c].position != kako[0] && spots[c].position != kako[1] && spots[c].position != kako[2] && spots[c].position != kako[3]) 
                {
                    kanou[k] = spots[c];
                    k++;
                    Debug.Log(hit1.transform.gameObject.tag);
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

    void Sento()
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        for (int i = 0; i <= enemys.Length - 1; i++)
        {
            if (Vector3.Distance(this.transform.position, enemys[0].transform.position) > Vector3.Distance(this.transform.position, enemys[i].transform.position))
            {
                enemys[0] = enemys[i];
            }
        }
    }
}
