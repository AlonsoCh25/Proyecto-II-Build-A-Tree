using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading;
using DefaultNamespace;
using Unity.Mathematics;
using UnityEngine.UI;
using Random = System.Random;

public class GameManager : MonoBehaviour
{
    public GameObject circulo;
    public GameObject triangulo;
    public GameObject cuadrado;
    public GameObject rombo;
    public GameObject menuPrincipal;
    public GameObject menuGameOver;
    public GameObject plataforma1;
    public GameObject plataforma2;
    public GameObject plataforma3;
    public GameObject plataforma4;
    public GameObject plataforma5;
    public GameObject plataforma6;
    public GameObject plataforma7;
    public GameObject plataforma8;
    public GameObject reyInicio;
    public GameObject frogInicio;
    public GameObject pinkInicio;
    public GameObject blueInicio;
    public GameObject PInicio1;
    public GameObject PInicio2;
    public GameObject PInicio3;
    public GameObject PInicio4;
    public GameObject C_15;
    public GameObject C_6;
    public GameObject C_7;
    public GameObject C_4;
    public GameObject C_5;
    public GameObject C_23;
    public GameObject C_50;
    public GameObject C_71;
    public GameObject Cu_21;
    public GameObject Cu_23;
    public GameObject Cu_44;
    public GameObject Cu_45;
    public GameObject Cu_55;
    public GameObject Cu_58;
    public GameObject Cu_77;
    public GameObject T_11;
    public GameObject T_12;
    public GameObject T_15;
    public GameObject T_44;
    public GameObject T_55;
    public GameObject T_59;
    public GameObject T_70;
    public GameObject R_34;
    public GameObject R_36;
    public GameObject R_38;
    public GameObject R_39;
    public GameObject R_44;
    public GameObject R_50;
    public GameObject R_69;
    public GameObject R_91;
    public GameObject C_15_n;
    public GameObject C_6_n;
    public GameObject C_7_n;
    public GameObject C_4_n;
    public GameObject C_5_n;
    public GameObject C_23_n;
    public GameObject C_50_n;
    public GameObject C_71_n;
    public GameObject Cu_21_n;
    public GameObject Cu_23_n;
    public GameObject Cu_44_n;
    public GameObject Cu_45_n;
    public GameObject Cu_55_n;
    public GameObject Cu_58_n;
    public GameObject Cu_77_n;
    public GameObject T_11_n;
    public GameObject T_12_n;
    public GameObject T_15_n;
    public GameObject T_44_n;
    public GameObject T_55_n;
    public GameObject T_59_n;
    public GameObject T_70_n;
    public GameObject R_34_n;
    public GameObject R_36_n;
    public GameObject R_38_n;
    public GameObject R_39_n;
    public GameObject R_44_n;
    public GameObject R_50_n;
    public GameObject R_69_n;
    public GameObject R_91_n;
    public Text PuntajeRey;
    public Text PuntajeBlue;
    public Text PuntajePink;
    public Text PuntajeFrog;
    public Text NomRey;
    public Text NomBlue;
    public Text NomPink;
    public Text NomFrog;
    public Text TiempoJuego;
    public int TiempoInt;
    public float TiempoFloat;
    public Text TiempoBTS;
    public int TiempoBTSInt;
    public float TiempoBTSFloat = 120f;
    public Text TiempoBTree;
    public int TiempoBTreeInt;
    public float TiempoBTreeFloat = 120f;
    public Text TiempoAVL;
    public int TiempoAVLInt;
    public float TiempoAVLFloat = 120f;
    public Text TiempoSplay;
    public int TiempoSplayInt;
    public float TiempoSplayFloat = 120f;
    public InputField Jugador1;
    public InputField Jugador2;
    public InputField Jugador3;
    public InputField Jugador4;
    public Renderer fondo;
    public bool gameOver = false;
    public bool start = false;
    public List<GameObject> plataformas;
    public List<GameObject> personajesinicio;
    public List<Node> Circulos;
    public List<GameObject> G_Circulos;
    public List<GameObject> G_Cuadrados;
    public List<GameObject> G_Rombos;
    public List<GameObject> G_Triangulos;
    public List<Node> Rombos;
    public List<Node> Triangulos;
    public List<Node> Cuadrados;
    public bool Challenge_circulo;
    private bool G_circulo = false;
    public bool C_15_b;
    public bool C_6_b;
    public bool C_7_b;
    public bool C_4_b;
    public bool C_5_b;
    public bool C_23_b;
    public bool C_50_b;
    public bool C_71_b;
    public bool Challenge_cuadrado;
    private bool G_cuadrado = false;
    public bool Cu_21_b;
    public bool Cu_23_b;
    public bool Cu_44_b;
    public bool Cu_45_b;
    public bool Cu_55_b;
    public bool Cu_58_b;
    public bool Cu_77_b;
    public bool Challenge_rombo;
    public bool G_rombo = false;
    public bool R_34_b;
    public bool R_36_b;
    public bool R_38_b;
    public bool R_39_b;
    public bool R_44_b;
    public bool R_50_b;
    public bool R_69_b;
    public bool R_91_b;
    public bool Challenge_triangulo;
    public bool G_triangulo = false;
    public bool T_11_b;
    public bool T_12_b;
    public bool T_15_b;
    public bool T_44_b;
    public bool T_55_b;
    public bool T_59_b;
    public bool T_70_b;
    public GameObject g_circulo;
    public GameObject g_cuadrado;
    public GameObject g_rombo;
    public GameObject g_triangulo;
    public bool ATiempoBTS;
    public bool ATiempoAVL;
    public bool ATiempoBtree;
    public bool ATiempoSplay;
    private Random pos;
    public string Message;
    public Client client;
    public GameObject PAtaque;
    public GameObject PEscudo;
    public GameObject PDoubleJ;
    public bool PAtaque_b;
    public bool PEscudo_b;
    public bool PDoubleJ_b;
    // Start is called before the first frame update
    

    public void Evento()
    {
        bool Active = true;
        while (Active)
        {
            if (start)
            {
                client.SendMessage("Active");
                print("HERE");
                Active = false;
            }
        }
        while (true)
        {
            if (client.GetMessage() != null)
            {
                Message = client.GetMessage();
                client.setMessage(null);
                print(Message);
                switch (Message)
                {
                    case "force_push":
                        PAtaque_b = true;
                        break;
                    case "shield":
                        PEscudo_b = true;
                        break;
                    case "air-jump":
                        PDoubleJ_b = true;
                        break;
                    case "c_bts":
                        G_rombo = true;
                        break;
                    case "R_34":
                        R_34_b = true;
                        break;
                    case "R_36":
                        R_36_b = true;
                        break;
                    case "R_38":
                        R_38_b = true;
                        break;
                    case "R_39":
                        R_39_b = true;
                        break;
                    case "R_44":
                        R_44_b = true;
                        break;
                    case "R_50":
                        R_50_b = true;
                        break;
                    case "R_69":
                        R_69_b = true;
                        break;
                    case "R_91":
                        R_91_b = true;
                        break;
                    case "c_avl":
                        G_circulo = true;
                        break;
                    case "C_15":
                        C_15_b = true;
                        break;
                    case "C_6":
                        C_6_b = true;
                        break;
                    case "C_7":
                        C_7_b = true;
                        break;
                    case "C_4":
                        C_4_b = true;
                        break;
                    case "C_5":
                        C_5_b = true;
                        break;
                    case "C_23":
                        C_23_b = true;
                        break;
                    case "C_50":
                        C_50_b = true;
                        break;
                    case "C_71":
                        C_71_b = true;
                        break;
                    case "c_btree":
                        G_cuadrado = true;
                        break;
                    case "Cu_21":
                        Cu_21_b = true;
                        break;
                    case "Cu_23":
                        Cu_23_b = true;
                        break;
                    case "Cu_44":
                        Cu_44_b = true;
                        break;
                    case "Cu_45":
                        Cu_45_b = true;
                        break;
                    case "Cu_55":
                        Cu_55_b = true;
                        break;
                    case "Cu_58":
                        Cu_58_b = true;
                        break;
                    case "Cu_77":
                        Cu_77_b = true;
                        break;
                    case "c_splay":
                        G_triangulo = true;
                        break;
                    case "T_11":
                        T_11_b = true;
                        break;
                    case "T_12":
                        T_12_b = true;
                        break;
                    case "T_15":
                        T_15_b = true;
                        break;
                    case "T_44":
                        T_44_b = true;
                        break;
                    case "T_55":
                        T_55_b = true;
                        break;
                    case "T_59":
                        T_59_b = true;
                        break;
                    case "T_70":
                        T_70_b = true;
                        break;
                }
            }

        }
    }
    void Start()
    {
        client = new Client();
        client.Connect();
        //Inicia el cliente
        Thread Event = new Thread(new ThreadStart(Evento));
        Event.Start();
        Thread t_client = new Thread(new ThreadStart(client.ReceiveMessage));
        t_client.Start();
        
        print("SSSSSSSSSSSSSSSSSSSSSSSSss");
        G_Circulos.Add(Instantiate(C_15_n, new Vector2((float) 12.55, (float) 3.37),Quaternion.identity));
        G_Circulos.Add(Instantiate(C_6_n, new Vector2((float) 11.49, (float) 2.01), Quaternion.identity));
        G_Circulos.Add(Instantiate(C_7_n, new Vector2((float) 12, (float) 1.03),Quaternion.identity));
        G_Circulos.Add(Instantiate(C_4_n, new Vector2((float) 10.99, (float) 1.04), Quaternion.identity));
        G_Circulos.Add(Instantiate(C_5_n, new Vector2((float) 11.5, (float) 0.05), Quaternion.identity));
        G_Circulos.Add(Instantiate(C_23_n, new Vector2((float) 13.01, (float) 1.03), Quaternion.identity));
        G_Circulos.Add(Instantiate(C_50_n, new Vector2((float) 13.5, (float) 1.97), Quaternion.identity));
        G_Circulos.Add(Instantiate(C_71_n, new Vector2((float) 13.98, (float) 1.02), Quaternion.identity));

        // Crear arbol Btree
        G_Cuadrados.Add(Instantiate(Cu_21_n, new Vector2((float) 6.704, (float) 1.317), Quaternion.identity));
        G_Cuadrados.Add(Instantiate(Cu_23_n, new Vector2((float) 7.023, (float) 2.309), Quaternion.identity));
        G_Cuadrados.Add(Instantiate(Cu_44_n, new Vector2((float) 7.34, (float) 1.32), Quaternion.identity));
        G_Cuadrados.Add(Instantiate(Cu_45_n, new Vector2((float) 8.01, (float) 3.33), Quaternion.identity));
        G_Cuadrados.Add(Instantiate(Cu_55_n, new Vector2((float) 8.702, (float) 1.317), Quaternion.identity));
        G_Cuadrados.Add(Instantiate(Cu_58_n, new Vector2((float) 9.001, (float) 2.313), Quaternion.identity));
        G_Cuadrados.Add(Instantiate(Cu_77_n, new Vector2((float) 9.334, (float) 1.321), Quaternion.identity));
        
        //Crear arbol BTS
        G_Rombos.Add(Instantiate(R_34_n,new Vector2((float)6.5,(float)-5.42),Quaternion.identity));
        G_Rombos.Add(Instantiate(R_36_n,new Vector2((float)6.98,(float)-4.4),Quaternion.identity));
        G_Rombos.Add(Instantiate(R_38_n,new Vector2((float)7.5,(float)-5.42),Quaternion.identity));
        G_Rombos.Add(Instantiate(R_39_n,new Vector2((float)7.99,(float)-6.48),Quaternion.identity));
        G_Rombos.Add(Instantiate(R_44_n,new Vector2((float)7.99,(float)-3.41),Quaternion.identity));
        G_Rombos.Add(Instantiate(R_50_n,new Vector2((float)8.48,(float)-5.43),Quaternion.identity));
        G_Rombos.Add(Instantiate(R_69_n,new Vector2((float)9.01,(float)-4.44),Quaternion.identity));
        G_Rombos.Add(Instantiate(R_91_n,new Vector2((float)9.55,(float)-5.39),Quaternion.identity));
        
        //Crear arbol Splay
        G_Triangulos.Add(Instantiate(T_11_n,new Vector2((float)10.981,(float)-5.614),Quaternion.identity));
        G_Triangulos.Add(Instantiate(T_12_n,new Vector2((float)11.87,(float)-4.54),Quaternion.identity));
        G_Triangulos.Add(Instantiate(T_15_n,new Vector2((float)12.491,(float)-3.594),Quaternion.identity));
        G_Triangulos.Add(Instantiate(T_44_n,new Vector2((float)12.43,(float)-5.61),Quaternion.identity));
        G_Triangulos.Add(Instantiate(T_55_n,new Vector2((float)13.347,(float)-6.593),Quaternion.identity));
        G_Triangulos.Add(Instantiate(T_59_n,new Vector2((float)12.951,(float)-4.614),Quaternion.identity));
        G_Triangulos.Add(Instantiate(T_70_n,new Vector2((float)13.981,(float)-5.614),Quaternion.identity));
        
        // Crear Plataformas
        plataformas.Add(Instantiate(plataforma1, new Vector2((float)-13,(float)4.5),Quaternion.identity));
        plataformas.Add(Instantiate(plataforma2, new Vector2((float)-5.5,(float)4.5),Quaternion.identity));
        plataformas.Add(Instantiate(plataforma3, new Vector2((float)-9.5,(float)1),Quaternion.identity));
        plataformas.Add(Instantiate(plataforma4,new Vector2((float)-1.5,(float)1),Quaternion.identity));
        plataformas.Add(Instantiate(plataforma5,new Vector2((float)-13.5,(float)-2.5),Quaternion.identity));
        plataformas.Add(Instantiate(plataforma6,new Vector2((float)-6,(float)-2.5),Quaternion.identity));
        plataformas.Add(Instantiate(plataforma7,new Vector2((float)-12.5,(float)-6),Quaternion.identity));
        plataformas.Add(Instantiate(plataforma8,new Vector2((float)-1,(float)-6),Quaternion.identity));
        PInicio1 = Instantiate(reyInicio, new Vector2(-11, 6),Quaternion.identity);
        PInicio2 = Instantiate(blueInicio, new Vector2(11, 6), Quaternion.identity);
        PInicio3 = Instantiate(pinkInicio, new Vector2(-11, -6), Quaternion.identity);
        PInicio4 = Instantiate(frogInicio, new Vector2(11, -6), Quaternion.identity);
    }
    
        // Update is called once per frame
    void Update()
    {
        if (PAtaque_b)
        {
            Instantiate(PAtaque, new Vector2((float) 4.3, (float) 13.23), Quaternion.identity);
            PAtaque_b = false;
            Destroy(GameObject.FindWithTag("PAtaque"), 10);
        }
        if (PEscudo_b)
        {
            Instantiate(PEscudo, new Vector2((float) 2.3, (float) 13.23), Quaternion.identity);
            PEscudo_b = false;
            Destroy(GameObject.FindWithTag("PEscudo"), 10);
        }
        if (PDoubleJ_b)
        {
            Instantiate(PDoubleJ, new Vector2((float) -2.3, (float) 13.23), Quaternion.identity);
            PDoubleJ_b = false;
            Destroy(GameObject.FindWithTag("PDoubleJ"), 10);
        }
        if (Challenge_circulo)
        {
            client.SendMessage("Active_C_circulo");
            Challenge_circulo = false;
        }
        if (C_15_b)
        {
            Instantiate(C_15, new Vector2((float)-4.92, (float) 13.23), Quaternion.identity);
            C_15_b = false;
            Destroy(GameObject.FindWithTag("C_15"),10);
        }
        if (C_6_b)
        {
            Instantiate(C_6, new Vector2((float)2.70, (float) 13.23), Quaternion.identity);
            C_6_b = false;
            Destroy(GameObject.FindWithTag("C_6"),10);
        }
        if (C_7_b)
        {
            Instantiate(C_7, new Vector2((float)-2.21, (float) 13.23), Quaternion.identity);
            C_7_b = false;
            Destroy(GameObject.FindWithTag("C_7"),10);
        }
        if (C_4_b)
        {
            Instantiate(C_4, new Vector2((float)0.99, (float) 13.23), Quaternion.identity);
            C_4_b = false;
            Destroy(GameObject.FindWithTag("C_4"),10);
        }
        if (C_5_b)
        {
            Instantiate(C_5, new Vector2((float)-3.95, (float) 13.23), Quaternion.identity);
            C_5_b = false;
            Destroy(GameObject.FindWithTag("C_5"),10);
        }
        if (C_23_b)
        {
            Instantiate(C_23, new Vector2((float)-9.68, (float) 13.23), Quaternion.identity);
            C_23_b = false;
            Destroy(GameObject.FindWithTag("C_23"),10);
        }
        if (C_50_b)
        {
            Instantiate(C_50, new Vector2((float)-2.09, (float) 13.23), Quaternion.identity);
            C_50_b = false;
            Destroy(GameObject.FindWithTag("C_50"),10);
        }
        if (C_71_b)
        {
            Instantiate(C_71, new Vector2((float)1.25, (float) 13.23), Quaternion.identity);
            C_71_b = false;
            Destroy(GameObject.FindWithTag("C_71"),10);
        }
        if (G_circulo)
        {
            Instantiate(g_circulo, new Vector2((float)-1.48, (float) 13.23), Quaternion.identity);
            G_circulo = false;
            Destroy(GameObject.FindWithTag("C_circulo"),10);
        }
        if (Challenge_cuadrado)
        {
            client.SendMessage("Active_C_cuadrado");
            Challenge_cuadrado = false;
        }
        if (Cu_21_b)
        {
            Instantiate(Cu_21, new Vector2((float)-3.44, (float) 13.23), Quaternion.identity);
            Cu_21_b = false;
            Destroy(GameObject.FindWithTag("Cu_21"),10);
        }
        if (Cu_23_b)
        {
            Instantiate(Cu_23, new Vector2((float)-4.26, (float) 13.23), Quaternion.identity);
            Cu_23_b = false;
            Destroy(GameObject.FindWithTag("Cu_23"),10);
        }
        if (Cu_44_b)
        {
            Instantiate(Cu_44, new Vector2((float)-10.04, (float) 13.23), Quaternion.identity);
            Cu_44_b = false;
            Destroy(GameObject.FindWithTag("Cu_44"),10);
        }
        if (Cu_45_b)
        {
            Instantiate(Cu_45, new Vector2((float)-7.21, (float) 13.23), Quaternion.identity);
            Cu_45_b = false;
            Destroy(GameObject.FindWithTag("Cu_45"),10);
        }
        if (Cu_55_b)
        {
            Instantiate(Cu_55, new Vector2((float)-5.69, (float) 13.23), Quaternion.identity);
            Cu_55_b = false;
            Destroy(GameObject.FindWithTag("Cu_55"),10);
        }
        if (Cu_58_b)
        {
            Instantiate(Cu_58, new Vector2((float)-8.41, (float) 13.23), Quaternion.identity);
            Cu_58_b = false;
            Destroy(GameObject.FindWithTag("Cu_58"),10);
        }
        if (Cu_77_b)
        {
            Instantiate(Cu_77, new Vector2((float)3.02, (float) 13.23), Quaternion.identity);
            Cu_77_b = false;
            Destroy(GameObject.FindWithTag("Cu_77"),10);
        }
        if (G_cuadrado)
        {
            Instantiate(g_cuadrado, new Vector2((float)0.04, (float) 13.23), Quaternion.identity);
            G_cuadrado = false;
            Destroy(GameObject.FindWithTag("C_cuadrado"),10);
        }
        if (Challenge_rombo)
        {
            client.SendMessage("Active_C_rombo");
            Challenge_rombo = false;
        }
        if (R_34_b)
        {
            Instantiate(R_34, new Vector2((float)4.08, (float) 13.23), Quaternion.identity);
            R_34_b = false;
            Destroy(GameObject.FindWithTag("R_34"),10);
        }
        if (R_36_b)
        {
            Instantiate(R_36, new Vector2((float)-14.35, (float) 13.23), Quaternion.identity);
            R_36_b = false;
            Destroy(GameObject.FindWithTag("R_36"),10);
        }
        if (R_38_b)
        {
            Instantiate(R_38, new Vector2((float)-6.88, (float) 13.23), Quaternion.identity);
            R_38_b = false;
            Destroy(GameObject.FindWithTag("R_38"),10);
        }
        if (R_39_b)
        {
            Instantiate(R_39, new Vector2((float)-0.62, (float) 13.23), Quaternion.identity);
            R_39_b = false;
            Destroy(GameObject.FindWithTag("R_39"),10);
        }
        if (R_44_b)
        {
            Instantiate(R_44, new Vector2((float)-5.65, (float) 13.23), Quaternion.identity);
            R_44_b = false;
            Destroy(GameObject.FindWithTag("R_44"),10);
        }
        if (R_50_b)
        {
            Instantiate(R_50, new Vector2((float)0.37, (float) 13.23), Quaternion.identity);
            R_50_b = false;
            Destroy(GameObject.FindWithTag("R_50"),10);
        }
        if (R_69_b)
        {
            Instantiate(R_69, new Vector2((float)-1.29, (float) 13.23), Quaternion.identity);
            R_69_b = false;
            Destroy(GameObject.FindWithTag("R_69"),10);
        }
        if (R_91_b)
        {
            Instantiate(R_91, new Vector2((float)-1.72, (float) 13.23), Quaternion.identity);
            R_91_b = false;
            Destroy(GameObject.FindWithTag("R_91"),10);
        }
        if (G_rombo)
        {
            Instantiate(g_rombo, new Vector2((float)-9.45, (float) 13.23), Quaternion.identity);
            G_rombo = false;
            Destroy(GameObject.FindWithTag("C_rombo"),10);
        }
        if (Challenge_triangulo)
        {
            client.SendMessage("Active_C_triangulo");
            Challenge_triangulo = false;
        }
        if (T_11_b)
        {
            Instantiate(T_11, new Vector2((float)2.77, (float) 13.23), Quaternion.identity);
            T_11_b = false;
            Destroy(GameObject.FindWithTag("T_11"),10);
        }
        if (T_12_b)
        {
            Instantiate(T_12, new Vector2((float)-12.23, (float) 13.23), Quaternion.identity);
            T_12_b = false;
            Destroy(GameObject.FindWithTag("T_12"),10);
        }
        if (T_15_b)
        {
            Instantiate(T_15, new Vector2((float)-6.59, (float) 13.23), Quaternion.identity);
            T_15_b = false;
            Destroy(GameObject.FindWithTag("T_15"),10);
        }
        if (T_44_b)
        {
            Instantiate(T_44, new Vector2((float)-7.68, (float) 13.23), Quaternion.identity);
            T_44_b = false;
            Destroy(GameObject.FindWithTag("T_44"),10);
        }
        if (T_55_b)
        {
            Instantiate(T_55, new Vector2((float)1.36, (float) 13.23), Quaternion.identity);
            T_55_b = false;
            Destroy(GameObject.FindWithTag("T_55"),10);
        }
        if (T_59_b)
        {
            Instantiate(T_59, new Vector2((float)-11.59, (float) 13.23), Quaternion.identity);
            T_59_b = false;
            Destroy(GameObject.FindWithTag("T_59"),10);
        }
        if (T_70_b)
        {
            Instantiate(T_70, new Vector2((float)2.46, (float) 13.23), Quaternion.identity);
            T_70_b = false;
            Destroy(GameObject.FindWithTag("T_70"),10);
        }
        if (G_triangulo)
        {
            Instantiate(g_triangulo, new Vector2((float)5.06, (float) 13.23), Quaternion.identity);
            G_triangulo = false;
            Destroy(GameObject.FindWithTag("C_triangulo"),10);
        }
        if (start == false)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                start = true;
                Destroy(PInicio1.gameObject);
                Destroy(PInicio2.gameObject);
                Destroy(PInicio3.gameObject);
                Destroy(PInicio4.gameObject);
            }
        }
        if (start == true && gameOver == true)
        {
            menuGameOver.SetActive(true);
            
            if (Input.GetKeyDown(KeyCode.X))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        if (start == true && gameOver == false)
        {
            menuPrincipal.SetActive(false);
            
            fondo.material.mainTextureOffset = fondo.material.mainTextureOffset + new Vector2(0.02f, 0) * Time.deltaTime;
        }
        //Tiempo
        if (start == true)
        {
            TiempoFloat += Time.deltaTime;
            TiempoInt = (int) TiempoFloat;
            TiempoJuego.text = TiempoInt.ToString();
            if (ATiempoBTS == true && TiempoBTSFloat > (float) 0)
            {
                TiempoBTSFloat -= Time.deltaTime;
                TiempoBTSInt = (int) TiempoBTSFloat; 
                TiempoBTS.text = TiempoBTSInt.ToString();

            }
            if (ATiempoBtree == true && TiempoBTreeFloat >  (float) 0)
            {
                TiempoBTreeFloat -= Time.deltaTime;
                TiempoBTreeInt = (int) TiempoBTreeFloat;
                TiempoBTree.text = TiempoBTreeInt.ToString();

            }
            if (ATiempoAVL == true && TiempoAVLFloat >  (float) 0)
            {
                TiempoAVLFloat -= Time.deltaTime;
                TiempoAVLInt = (int) TiempoAVLFloat;
                TiempoAVL.text = TiempoAVLInt.ToString();
            }
            if (ATiempoSplay == true && TiempoSplayFloat >  (float) 0)
            {
                TiempoSplayFloat -= Time.deltaTime;
                TiempoSplayInt = (int) TiempoSplayFloat;
                TiempoSplay.text = TiempoSplayInt.ToString();
            }
        }
        /*
        if (Jugador1.text != "")
        {
            NomRey.text = (Jugador1.text).ToString();
        }
        if (Jugador2.text != "")
        {
            NomBlue.text = (Jugador2.text).ToString();
        }
        if (Jugador3.text != "")
        {
            NomPink.text = (Jugador3.text).ToString();
        }
        if (Jugador4.text != "")
        {
            NomFrog.text = (Jugador4.text).ToString();
        }*/
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        throw new NotImplementedException();
    }
}
