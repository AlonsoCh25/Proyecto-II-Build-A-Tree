using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
/**
 * script encargado del total de las acciones del jugador de nombre Rey
 * @autor Kenneth Castillo, Olman Rodriguez y Montserrat Monge.
 * @see https://youtu.be/4XvfpCz_vh8
 */
public class JRey : MonoBehaviour
{
    /**
     * Variables utilizadas por el personaje
     */
    public float fuerzaSalto;
    public GameManager gameManager;
    public float FuerzadeLado;
    public int puntajerey = 0;
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    public float FuerzadeAtaque;
    public bool salta;
    public bool golpea;
    public bool M_derecha;
    public bool M_izquierda;
    public bool force_push;
    public bool DobleSalto;
    public bool Escudo;
    public int Saltos;
    public List<GameObject> circulos;
    public List<GameObject> cuadrados;
    public List<GameObject> triangulos;
    public List<GameObject> rombos;
    public List<String> arbcompletoC;
    public List<String> arbcompletoCu;
    public List<String> arbcompletoR;
    public List<String> arbcompletoT;
    public string Challenge;
    public GameObject G_UltJugador;
    public int contador;
    
    public GameObject s_salto;
    public GameObject s_golpe;
    public GameObject s_poder;
    public GameObject s_token;
    public string ParseString(string s, int leng)
    {
        string n = null;
        n += s.Substring(0, leng);
        return n;
    }
    /**
     * Inicializa las funciones del personaje 
     */
    void Start()
    {
        contador = 0;
        G_UltJugador = gameManager.plataforma1;
        Challenge = "null";
        animator = GetComponent<Animator>();
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    /**
     * Actualizacion de los datos usados por el jugador
     */
    void Update()
    {
        
        if (G_UltJugador.tag == "Personaje")
        {
            contador++;
        }
        else
        {
            contador = 0;
        }
        if (G_UltJugador.transform.position.y < (float) -8.4197)
        {
            puntajerey += 50;
            (gameManager.PuntajeRey).text = puntajerey.ToString();
            G_UltJugador = G_UltJugador = gameManager.plataforma1;
            gameManager.NumJugadores--;
        }
        if (contador > 1500)
        {
            G_UltJugador = G_UltJugador = gameManager.plataforma1;
            contador = 0;
        }

        if (gameManager.start)
        {
            if (gameManager.Jugador1.text == "")
            {
                Destroy(GameObject.FindWithTag("Personaje"));
            }
            if (Input.GetKeyDown(KeyCode.W))
            {
                Destroy(Instantiate(s_salto), 5);
                if(!salta)
                {
                    if (Saltos >= 1)
                    {
                        animator.SetBool("estaSaltando", true);
                        rigidbody2D.AddForce(new Vector2(0, fuerzaSalto));
                        Saltos--;
                    }
                    else
                    {
                        salta = true;
                    }
                }
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                animator.SetBool("FuerzadeLado",false);
                rigidbody2D.AddForce(new Vector2(FuerzadeLado, 0));
                M_derecha = true;
                M_izquierda = false;
            } 
            if (Input.GetKeyDown(KeyCode.RightControl))
            {
                if (Escudo)
                {
                    //rigidbody2D = GetComponent<Rigidbody2D>();
                    rigidbody2D.mass = 100;
                }
            }

            if (Input.GetKeyUp(KeyCode.RightControl))
            {
                if (Escudo)
                {
                    //rigidbody2D = GetComponent<Rigidbody2D>();
                    rigidbody2D.mass = 1;
                }
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                animator.SetBool("RunRey",false);
                rigidbody2D.AddForce(new Vector2(-FuerzadeLado, 0));
                M_derecha = false;
                M_izquierda = true;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (force_push)
                {
                    if (M_derecha)
                    {
                        rigidbody2D.AddForce(new Vector2(FuerzadeLado+200, 0));
                    }

                    if (M_izquierda)
                    {
                        rigidbody2D.AddForce(new Vector2(-(FuerzadeLado+200), 0));
                    }
                }
            }
        }
        if (arbcompletoC.Count() == 8)
        {
            puntajerey += 100;
            (gameManager.PuntajeRey).text = puntajerey.ToString();
            gameManager.ATiempoAVL = false;
            gameManager.TiempoSplayFloat = 120f;
            gameManager.TiempoSplayInt = (int) gameManager.TiempoSplayFloat;
            gameManager.TiempoSplay.text = gameManager.TiempoSplayInt.ToString();
            gameManager.Challenge_circulo = false;
            Challenge = "null";
            int c = circulos.Count();
            for (int i = 0; i < c; i++)
            {
                Destroy(circulos[i]);
            }
            gameManager.client.SendMessage("Completo_C");
            arbcompletoC.Clear();

        }
        if (arbcompletoCu.Count() == 7)
        {
            puntajerey += 100;
            (gameManager.PuntajeRey).text = puntajerey.ToString();
            gameManager.ATiempoBtree = false;
            gameManager.TiempoBTreeFloat = 120f;
            gameManager.TiempoSplayInt = (int) gameManager.TiempoSplayFloat;
            gameManager.TiempoSplay.text = gameManager.TiempoSplayInt.ToString();
            gameManager.Challenge_cuadrado = false;
            Challenge = "null";
            int c = cuadrados.Count();
            for (int i = 0; i < c; i++)
            {
                Destroy(cuadrados[i]);
            }
            gameManager.client.SendMessage("Completo_Cu");
            arbcompletoCu.Clear();
        }

        if (arbcompletoR.Count() == 8)
        {
            puntajerey += 100;
            (gameManager.PuntajeRey).text = puntajerey.ToString();
            gameManager.ATiempoBTS = false;
            gameManager.TiempoBTSFloat = 120f;
            gameManager.TiempoSplayInt = (int) gameManager.TiempoSplayFloat;
            gameManager.TiempoSplay.text = gameManager.TiempoSplayInt.ToString();
            gameManager.Challenge_rombo = false;
            Challenge = "null";
            int c = rombos.Count();
            for (int i = 0; i < c; i++)
            {
                Destroy(rombos[i]);
            }
            gameManager.client.SendMessage("Completo_R");
            arbcompletoR.Clear();
        }

        if (arbcompletoT.Count() == 7)
        {
            puntajerey += 100;
            (gameManager.PuntajeRey).text = puntajerey.ToString();
            gameManager.ATiempoSplay = false;
            gameManager.TiempoSplayFloat = 120f;
            gameManager.TiempoSplayInt = (int) gameManager.TiempoSplayFloat;
            gameManager.TiempoSplay.text = gameManager.TiempoSplayInt.ToString();
            gameManager.Challenge_triangulo = false;
            Challenge = "null";
            int c = triangulos.Count();
            for (int i = 0; i < c; i++)
            {
                Destroy(triangulos[i]);
            }
            gameManager.client.SendMessage("Completo_T");
            arbcompletoT.Clear();
        }
    }
    /**
     * Introduce un elemento a la lista del jugador
     */
    private void Introducir_lista(string elemento)
    {
        bool existe = false;
        if (Challenge == "C")
        {
            int c = arbcompletoC.Count();
            for (int i = 0; i < c; i++)
            {
                if (arbcompletoC[i] == elemento)
                {
                    existe = true;
                }
            }
            if (!existe)
            {
                arbcompletoC.Add(elemento);
                
            }
        }
        if (Challenge == "Cu")
        {
            int c = arbcompletoCu.Count();
            for (int i = 0; i < c; i++)
            {
                if (arbcompletoCu[i] == elemento)
                {
                    existe = true;
                }
            }
            if (!existe)
            {
                arbcompletoCu.Add(elemento);
            }
        }
        if (Challenge == "R")
        {
            int c = arbcompletoR.Count();
            for (int i = 0; i < c; i++)
            {
                if (arbcompletoR[i] == elemento)
                {
                    existe = true;
                }
            }
            if (!existe)
            {
                arbcompletoR.Add(elemento);
            }
        }
        if (Challenge == "T")
        {
            int c = arbcompletoT.Count();
            for (int i = 0; i < c; i++)
            {
                if (arbcompletoT[i] == elemento)
                {
                    existe = true;
                }
            }
            if (!existe)
            {
                arbcompletoT.Add(elemento);
            }
        }
    }
    /**
    * Colisiones del jugador con los objetos u otros personajes de lainterfaz
    */
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Suelo")
        {
            if (DobleSalto)
            {
                Saltos = 2;
            }
            else
            {
                Saltos = 1;
            }

            salta = false;
        }
        if (collision.gameObject.tag == "Personaje")
        {
            contador = 0;
            golpea = false;
            G_UltJugador = collision.gameObject;
            Destroy(Instantiate(s_golpe), 5);
        }
        if (collision.gameObject.tag == "C_circulo")
        {
            Destroy(Instantiate(s_token), 5);
            if (Challenge == "null")
            {
                Challenge = "C";
                gameManager.ATiempoAVL = true;
                Destroy(collision.gameObject);
                gameManager.Challenge_circulo = true;
            }
        }
        if (collision.gameObject.tag == "C_15")
        {
            Destroy(Instantiate(s_token), 5);
            if (ParseString(collision.gameObject.tag, 1) == "C" && Challenge == "C")
            {
                circulos.Add(Instantiate(gameManager.circulo, new Vector2((float) 12.55, (float) 3.37),
                    Quaternion.identity));
                Introducir_lista("C_15");
                gameManager.client.SendMessage("C_15");
            }
            else
            {
                if (Challenge == "C")
                {
                    int c = circulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(circulos[i]);
                    }
                    arbcompletoC.Clear();
                    gameManager.client.SendMessage("Reiniciar_C");
                }
                if (Challenge == "R")
                {
                    int c = rombos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(rombos[i]);
                    }
                    arbcompletoR.Clear();
                    gameManager.client.SendMessage("Reiniciar_R");
                }
                if (Challenge == "Cu")
                {
                    int c = cuadrados.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(cuadrados[i]);
                    }
                    arbcompletoCu.Clear();
                    gameManager.client.SendMessage("Reiniciar_Cu");
                }
                if (Challenge == "T")
                {
                    int c = triangulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(triangulos[i]);
                    }
                    arbcompletoT.Clear();
                    gameManager.client.SendMessage("Reiniciar_T");
                }
            }
            Destroy(collision.gameObject);
            
        }
        if (collision.gameObject.tag == "C_6")
        {
            Destroy(Instantiate(s_token), 5);
            if (ParseString(collision.gameObject.tag, 1) == "C" && Challenge == "C")
            {
                circulos.Add(Instantiate(gameManager.circulo, new Vector2((float) 11.49, (float) 2.01), Quaternion.identity));
                Introducir_lista("C_6");
                gameManager.client.SendMessage("C_6");
            }
            else
            {
                if (Challenge == "C")
                {
                    int c = circulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(circulos[i]);
                    }
                    arbcompletoC.Clear();
                    gameManager.client.SendMessage("Reiniciar_C");
                }
                if (Challenge == "R")
                {
                    int c = rombos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(rombos[i]);
                    }
                    arbcompletoR.Clear();
                    gameManager.client.SendMessage("Reiniciar_R");
                }
                if (Challenge == "Cu")
                {
                    int c = cuadrados.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(cuadrados[i]);
                    }
                    arbcompletoCu.Clear();
                    gameManager.client.SendMessage("Reiniciar_Cu");
                }
                if (Challenge == "T")
                {
                    int c = triangulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(triangulos[i]);
                    }
                    arbcompletoT.Clear();
                    gameManager.client.SendMessage("Reiniciar_T");
                }
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "C_7")
        {
            Destroy(Instantiate(s_token), 5);
            if (ParseString(collision.gameObject.tag, 1) == "C" && Challenge == "C")
            {
                circulos.Add(Instantiate(gameManager.circulo, new Vector2((float) 12, (float) 1.03), Quaternion.identity));
                Introducir_lista("C_7");
                gameManager.client.SendMessage("C_7");
            }
            else
            {
                if (Challenge == "C")
                {
                    int c = circulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(circulos[i]);
                    }
                    arbcompletoC.Clear();
                    gameManager.client.SendMessage("Reiniciar_C");
                }
                if (Challenge == "R")
                {
                    int c = rombos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(rombos[i]);
                    }
                    arbcompletoR.Clear();
                    gameManager.client.SendMessage("Reiniciar_R");
                }
                if (Challenge == "Cu")
                {
                    int c = cuadrados.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(cuadrados[i]);
                    }
                    arbcompletoCu.Clear();
                    gameManager.client.SendMessage("Reiniciar_Cu");
                }
                if (Challenge == "T")
                {
                    int c = triangulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(triangulos[i]);
                    }
                    arbcompletoT.Clear();
                    gameManager.client.SendMessage("Reiniciar_T");
                }
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "C_4")
        {
            Destroy(Instantiate(s_token), 5);
            if (ParseString(collision.gameObject.tag, 1) == "C" && Challenge == "C")
            {
                circulos.Add(Instantiate(gameManager.circulo, new Vector2((float) 10.99, (float) 1.04), Quaternion.identity));
                Introducir_lista("C_4");
                gameManager.client.SendMessage("C_4");
            }
            else
            {
                if (Challenge == "C")
                {
                    int c = circulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(circulos[i]);
                    }
                    arbcompletoC.Clear();
                    gameManager.client.SendMessage("Reiniciar_C");
                }
                if (Challenge == "R")
                {
                    int c = rombos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(rombos[i]);
                    }
                    arbcompletoR.Clear();
                    gameManager.client.SendMessage("Reiniciar_R");
                }
                if (Challenge == "Cu")
                {
                    int c = cuadrados.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(cuadrados[i]);
                    }
                    arbcompletoCu.Clear();
                    gameManager.client.SendMessage("Reiniciar_Cu");
                }
                if (Challenge == "T")
                {
                    int c = triangulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(triangulos[i]);
                    }
                    arbcompletoT.Clear();
                    gameManager.client.SendMessage("Reiniciar_T");
                }
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "C_5")
        {
            Destroy(Instantiate(s_token), 5);
            if (ParseString(collision.gameObject.tag, 1) == "C" && Challenge == "C")
            {
                circulos.Add(Instantiate(gameManager.circulo, new Vector2((float) 11.5, (float) 0.05), Quaternion.identity));
                Introducir_lista("C_5");
                gameManager.client.SendMessage("C_5");
            }
            else
            {
                if (Challenge == "C")
                {
                    int c = circulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(circulos[i]);
                    }
                    arbcompletoC.Clear();
                    gameManager.client.SendMessage("Reiniciar_C");
                }
                if (Challenge == "R")
                {
                    int c = rombos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(rombos[i]);
                    }
                    arbcompletoR.Clear();
                    gameManager.client.SendMessage("Reiniciar_R");
                }
                if (Challenge == "Cu")
                {
                    int c = cuadrados.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(cuadrados[i]);
                    }
                    arbcompletoCu.Clear();
                    gameManager.client.SendMessage("Reiniciar_Cu");
                }
                if (Challenge == "T")
                {
                    int c = triangulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(triangulos[i]);
                    }
                    arbcompletoT.Clear();
                    gameManager.client.SendMessage("Reiniciar_T");
                }
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "C_23")
        {
            Destroy(Instantiate(s_token), 5);
            if (ParseString(collision.gameObject.tag, 1) == "C" && Challenge == "C")
            {
                circulos.Add(Instantiate(gameManager.circulo, new Vector2((float) 13.01, (float) 1.03), Quaternion.identity));
                Introducir_lista("C_23");
                gameManager.client.SendMessage("C_23");
            }
            else
            {
                if (Challenge == "C")
                {
                    int c = circulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(circulos[i]);
                    }
                    arbcompletoC.Clear();
                    gameManager.client.SendMessage("Reiniciar_C");
                }
                if (Challenge == "R")
                {
                    int c = rombos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(rombos[i]);
                    }
                    arbcompletoR.Clear();
                    gameManager.client.SendMessage("Reiniciar_R");
                }
                if (Challenge == "Cu")
                {
                    int c = cuadrados.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(cuadrados[i]);
                    }
                    arbcompletoCu.Clear();
                    gameManager.client.SendMessage("Reiniciar_Cu");
                }
                if (Challenge == "T")
                {
                    int c = triangulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(triangulos[i]);
                    }
                    arbcompletoT.Clear();
                    gameManager.client.SendMessage("Reiniciar_T");
                }
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "C_50")
        {
            Destroy(Instantiate(s_token), 5);
            if (ParseString(collision.gameObject.tag, 1) == "C" && Challenge == "C")
            {
                circulos.Add(Instantiate(gameManager.circulo, new Vector2((float) 13.5, (float) 1.97), Quaternion.identity));
                Introducir_lista("C_50");
                gameManager.client.SendMessage("C_50");
            }
            else
            {
                if (Challenge == "C")
                {
                    int c = circulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(circulos[i]);
                    }
                    arbcompletoC.Clear();
                    gameManager.client.SendMessage("Reiniciar_C");
                }
                if (Challenge == "R")
                {
                    int c = rombos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(rombos[i]);
                    }
                    arbcompletoR.Clear();
                    gameManager.client.SendMessage("Reiniciar_R");
                }
                if (Challenge == "Cu")
                {
                    int c = cuadrados.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(cuadrados[i]);
                    }
                    arbcompletoCu.Clear();
                    gameManager.client.SendMessage("Reiniciar_Cu");
                }
                if (Challenge == "T")
                {
                    int c = triangulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(triangulos[i]);
                    }
                    arbcompletoT.Clear();
                    gameManager.client.SendMessage("Reiniciar_T");
                }
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "C_71")
        {
            Destroy(Instantiate(s_token), 5);
            if (ParseString(collision.gameObject.tag, 1) == "C" && Challenge == "C")
            {
                circulos.Add(Instantiate(gameManager.circulo, new Vector2((float) 13.98, (float) 1.02), Quaternion.identity));
                Introducir_lista("C_71");
                gameManager.client.SendMessage("C_71");
            }
            else
            {
                if (Challenge == "C")
                {
                    int c = circulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(circulos[i]);
                    }
                    arbcompletoC.Clear();
                    gameManager.client.SendMessage("Reiniciar_C");
                }
                if (Challenge == "R")
                {
                    int c = rombos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(rombos[i]);
                    }
                    arbcompletoR.Clear();
                    gameManager.client.SendMessage("Reiniciar_R");
                }
                if (Challenge == "Cu")
                {
                    int c = cuadrados.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(cuadrados[i]);
                    }
                    arbcompletoCu.Clear();
                    gameManager.client.SendMessage("Reiniciar_Cu");
                }
                if (Challenge == "T")
                {
                    int c = triangulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(triangulos[i]);
                    }
                    arbcompletoT.Clear();
                    gameManager.client.SendMessage("Reiniciar_T");
                }
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "C_cuadrado")
        {
            if (Challenge == "null")
            {
                Destroy(Instantiate(s_token), 5);
                Challenge = "Cu";
                gameManager.ATiempoBtree = true;
                Destroy(collision.gameObject);
                gameManager.Challenge_cuadrado = true;
            }
        }
        if (collision.gameObject.tag == "Cu_21")
        {
            Destroy(Instantiate(s_token), 5);
            if (ParseString(collision.gameObject.tag, 2) == "Cu" && Challenge == "Cu")
            {
                cuadrados.Add(Instantiate(gameManager.cuadrado, new Vector2((float) 6.704, (float) 1.317), Quaternion.identity));
                Introducir_lista("Cu_21");
                gameManager.client.SendMessage("Cu_21");
            }
            else
            {
                if (Challenge == "C")
                {
                    int c = circulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(circulos[i]);
                    }
                    arbcompletoC.Clear();
                    gameManager.client.SendMessage("Reiniciar_C");
                }
                if (Challenge == "R")
                {
                    int c = rombos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(rombos[i]);
                    }
                    arbcompletoR.Clear();
                    gameManager.client.SendMessage("Reiniciar_R");
                }
                if (Challenge == "Cu")
                {
                    int c = cuadrados.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(cuadrados[i]);
                    }
                    arbcompletoCu.Clear();
                    gameManager.client.SendMessage("Reiniciar_Cu");
                }
                if (Challenge == "T")
                {
                    int c = triangulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(triangulos[i]);
                    }
                    arbcompletoT.Clear();
                    gameManager.client.SendMessage("Reiniciar_T");
                }
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Cu_23")
        {
            Destroy(Instantiate(s_token), 5);
            if (ParseString(collision.gameObject.tag, 2) == "Cu" && Challenge == "Cu")
            {
                cuadrados.Add(Instantiate(gameManager.cuadrado, new Vector2((float) 7.023, (float) 2.309), Quaternion.identity));
                Introducir_lista("Cu_23");
                gameManager.client.SendMessage("Cu_23");
            }
            else
            {
                if (Challenge == "C")
                {
                    int c = circulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(circulos[i]);
                    }
                    arbcompletoC.Clear();
                    gameManager.client.SendMessage("Reiniciar_C");
                }
                if (Challenge == "R")
                {
                    int c = rombos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(rombos[i]);
                    }
                    arbcompletoR.Clear();
                    gameManager.client.SendMessage("Reiniciar_R");
                }
                if (Challenge == "Cu")
                {
                    int c = cuadrados.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(cuadrados[i]);
                    }
                    arbcompletoCu.Clear();
                    gameManager.client.SendMessage("Reiniciar_Cu");
                }
                if (Challenge == "T")
                {
                    int c = triangulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(triangulos[i]);
                    }
                    arbcompletoT.Clear();
                    gameManager.client.SendMessage("Reiniciar_T");
                }
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Cu_44")
        {
            Destroy(Instantiate(s_token), 5);
            if (ParseString(collision.gameObject.tag, 2) == "Cu" && Challenge == "Cu")
            {
                cuadrados.Add(Instantiate(gameManager.cuadrado, new Vector2((float) 7.34, (float) 1.32), Quaternion.identity));
                Introducir_lista("Cu_44");
                gameManager.client.SendMessage("Cu_44");
            }
            else
            {
                if (Challenge == "C")
                {
                    int c = circulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(circulos[i]);
                    }
                    arbcompletoC.Clear();
                    gameManager.client.SendMessage("Reiniciar_C");
                }
                if (Challenge == "R")
                {
                    int c = rombos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(rombos[i]);
                    }
                    arbcompletoR.Clear();
                    gameManager.client.SendMessage("Reiniciar_R");
                }
                if (Challenge == "Cu")
                {
                    int c = cuadrados.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(cuadrados[i]);
                    }
                    arbcompletoCu.Clear();
                    gameManager.client.SendMessage("Reiniciar_Cu");
                }
                if (Challenge == "T")
                {
                    int c = triangulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(triangulos[i]);
                    }
                    arbcompletoT.Clear();
                    gameManager.client.SendMessage("Reiniciar_T");
                }
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Cu_45")
        {
            Destroy(Instantiate(s_token), 5);
            if (ParseString(collision.gameObject.tag, 2) == "Cu" && Challenge == "Cu")
            {
                cuadrados.Add(Instantiate(gameManager.cuadrado, new Vector2((float) 8.01, (float) 3.33), Quaternion.identity));
                Introducir_lista("Cu_45");
                gameManager.client.SendMessage("Cu_45");
            }
            else
            {
                if (Challenge == "C")
                {
                    int c = circulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(circulos[i]);
                    }
                    arbcompletoC.Clear();
                    gameManager.client.SendMessage("Reiniciar_C");
                }
                if (Challenge == "R")
                {
                    int c = rombos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(rombos[i]);
                    }
                    arbcompletoR.Clear();
                    gameManager.client.SendMessage("Reiniciar_R");
                }
                if (Challenge == "Cu")
                {
                    int c = cuadrados.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(cuadrados[i]);
                    }
                    arbcompletoCu.Clear();
                    gameManager.client.SendMessage("Reiniciar_Cu");
                }
                if (Challenge == "T")
                {
                    int c = triangulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(triangulos[i]);
                    }
                    arbcompletoT.Clear();
                    gameManager.client.SendMessage("Reiniciar_T");
                }
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Cu_55")
        {
            Destroy(Instantiate(s_token), 5);
            if (ParseString(collision.gameObject.tag, 2) == "Cu" && Challenge == "Cu")
            {
                cuadrados.Add(Instantiate(gameManager.cuadrado, new Vector2((float) 8.702, (float) 1.317), Quaternion.identity));
                Introducir_lista("Cu_55");
                gameManager.client.SendMessage("Cu_55");
            }
            else
            {
                if (Challenge == "C")
                {
                    int c = circulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(circulos[i]);
                    }
                    arbcompletoC.Clear();
                    gameManager.client.SendMessage("Reiniciar_C");
                }
                if (Challenge == "R")
                {
                    int c = rombos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(rombos[i]);
                    }
                    arbcompletoR.Clear();
                    gameManager.client.SendMessage("Reiniciar_R");
                }
                if (Challenge == "Cu")
                {
                    int c = cuadrados.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(cuadrados[i]);
                    }
                    arbcompletoCu.Clear();
                    gameManager.client.SendMessage("Reiniciar_Cu");
                }
                if (Challenge == "T")
                {
                    int c = triangulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(triangulos[i]);
                    }
                    arbcompletoT.Clear();
                    gameManager.client.SendMessage("Reiniciar_T");
                }
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Cu_58")
        {
            Destroy(Instantiate(s_token), 5);
            if (ParseString(collision.gameObject.tag, 2) == "Cu" && Challenge == "Cu")
            {
                cuadrados.Add(Instantiate(gameManager.cuadrado, new Vector2((float) 9.001, (float) 2.313), Quaternion.identity));
                Introducir_lista("Cu_58");
                gameManager.client.SendMessage("Cu_58");
            }
            else
            {
                if (Challenge == "C")
                {
                    int c = circulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(circulos[i]);
                    }
                    arbcompletoC.Clear();
                    gameManager.client.SendMessage("Reiniciar_C");
                }
                if (Challenge == "R")
                {
                    int c = rombos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(rombos[i]);
                    }
                    arbcompletoR.Clear();
                    gameManager.client.SendMessage("Reiniciar_R");
                }
                if (Challenge == "Cu")
                {
                    int c = cuadrados.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(cuadrados[i]);
                    }
                    arbcompletoCu.Clear();
                    gameManager.client.SendMessage("Reiniciar_Cu");
                }
                if (Challenge == "T")
                {
                    int c = triangulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(triangulos[i]);
                    }
                    arbcompletoT.Clear();
                    gameManager.client.SendMessage("Reiniciar_T");
                }
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Cu_77")
        {
            Destroy(Instantiate(s_token), 5);
            if (ParseString(collision.gameObject.tag, 2) == "Cu" && Challenge == "Cu")
            {
                cuadrados.Add(Instantiate(gameManager.cuadrado, new Vector2((float) 9.334, (float) 1.321), Quaternion.identity));
                Introducir_lista("Cu_77");
                gameManager.client.SendMessage("Cu_77");
            }
            else
            {
                if (Challenge == "C")
                {
                    int c = circulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(circulos[i]);
                    }
                    arbcompletoC.Clear();
                    gameManager.client.SendMessage("Reiniciar_C");
                }
                if (Challenge == "R")
                {
                    int c = rombos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(rombos[i]);
                    }
                    arbcompletoR.Clear();
                    gameManager.client.SendMessage("Reiniciar_R");
                }
                if (Challenge == "Cu")
                {
                    int c = cuadrados.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(cuadrados[i]);
                    }
                    arbcompletoCu.Clear();
                    gameManager.client.SendMessage("Reiniciar_Cu");
                }
                if (Challenge == "T")
                {
                    int c = triangulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(triangulos[i]);
                    }
                    arbcompletoT.Clear();
                    gameManager.client.SendMessage("Reiniciar_T");
                }
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "C_rombo")
        {
            if (Challenge == "null")
            {
                Destroy(Instantiate(s_token), 5);
                Challenge = "R";
                gameManager.ATiempoBTS = true;
                Destroy(collision.gameObject);
                gameManager.Challenge_rombo = true;
            }

            
        }
        if (collision.gameObject.tag == "R_34")
        {
            Destroy(Instantiate(s_token), 5);
            if (ParseString(collision.gameObject.tag, 1) == "R" && Challenge == "R")
            {
                rombos.Add(Instantiate(gameManager.rombo, new Vector2((float) 6.5, (float) -5.42), Quaternion.identity));
                Introducir_lista("R_34");
                gameManager.client.SendMessage("R_34");
            }
            else
            {
                if (Challenge == "C")
                {
                    int c = circulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(circulos[i]);
                    }
                    arbcompletoC.Clear();
                    gameManager.client.SendMessage("Reiniciar_C");
                }
                if (Challenge == "R")
                {
                    int c = rombos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(rombos[i]);
                    }
                    arbcompletoR.Clear();
                    gameManager.client.SendMessage("Reiniciar_R");
                }
                if (Challenge == "Cu")
                {
                    int c = cuadrados.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(cuadrados[i]);
                    }
                    arbcompletoCu.Clear();
                    gameManager.client.SendMessage("Reiniciar_Cu");
                }
                if (Challenge == "T")
                {
                    int c = triangulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(triangulos[i]);
                    }
                    arbcompletoT.Clear();
                    gameManager.client.SendMessage("Reiniciar_T");
                }
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "R_36")
        {
            Destroy(Instantiate(s_token), 5);
            if (ParseString(collision.gameObject.tag, 1) == "R" && Challenge == "R")
            {
                rombos.Add(Instantiate(gameManager.rombo, new Vector2((float) 6.98, (float) -4.4), Quaternion.identity));
                Introducir_lista("R_36");
                gameManager.client.SendMessage("R_36");
            }
            else
            {
                if (Challenge == "C")
                {
                    int c = circulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(circulos[i]);
                    }
                    arbcompletoC.Clear();
                    gameManager.client.SendMessage("Reiniciar_C");
                }
                if (Challenge == "R")
                {
                    int c = rombos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(rombos[i]);
                    }
                    arbcompletoR.Clear();
                    gameManager.client.SendMessage("Reiniciar_R");
                }
                if (Challenge == "Cu")
                {
                    int c = cuadrados.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(cuadrados[i]);
                    }
                    arbcompletoCu.Clear();
                    gameManager.client.SendMessage("Reiniciar_Cu");
                }
                if (Challenge == "T")
                {
                    int c = triangulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(triangulos[i]);
                    }
                    arbcompletoT.Clear();
                    gameManager.client.SendMessage("Reiniciar_T");
                }
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "R_38")
        {
            Destroy(Instantiate(s_token), 5);
            if (ParseString(collision.gameObject.tag, 1) == "R" && Challenge == "R")
            {
                rombos.Add(Instantiate(gameManager.rombo, new Vector2((float) 7.5, (float) -5.42), Quaternion.identity));
                Introducir_lista("R_38");
                gameManager.client.SendMessage("R_38");
            }
            else
            {
                if (Challenge == "C")
                {
                    int c = circulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(circulos[i]);
                    }
                    arbcompletoC.Clear();
                    gameManager.client.SendMessage("Reiniciar_C");
                }
                if (Challenge == "R")
                {
                    int c = rombos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(rombos[i]);
                    }
                    arbcompletoR.Clear();
                    gameManager.client.SendMessage("Reiniciar_R");
                }
                if (Challenge == "Cu")
                {
                    int c = cuadrados.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(cuadrados[i]);
                    }
                    arbcompletoCu.Clear();
                    gameManager.client.SendMessage("Reiniciar_Cu");
                }
                if (Challenge == "T")
                {
                    int c = triangulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(triangulos[i]);
                    }
                    arbcompletoT.Clear();
                    gameManager.client.SendMessage("Reiniciar_T");
                }
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "R_39")
        {
            Destroy(Instantiate(s_token), 5);
            if (ParseString(collision.gameObject.tag, 1) == "R" && Challenge == "R")
            {
                rombos.Add(Instantiate(gameManager.rombo, new Vector2((float) 7.99, (float) -6.48), Quaternion.identity));
                Introducir_lista("R_39");
                gameManager.client.SendMessage("R_39");
            }
            else
            {
                if (Challenge == "C")
                {
                    int c = circulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(circulos[i]);
                    }
                    arbcompletoC.Clear();
                    gameManager.client.SendMessage("Reiniciar_C");
                }
                if (Challenge == "R")
                {
                    int c = rombos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(rombos[i]);
                    }
                    arbcompletoR.Clear();
                    gameManager.client.SendMessage("Reiniciar_R");
                }
                if (Challenge == "Cu")
                {
                    int c = cuadrados.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(cuadrados[i]);
                    }
                    arbcompletoCu.Clear();
                    gameManager.client.SendMessage("Reiniciar_Cu");
                }
                if (Challenge == "T")
                {
                    int c = triangulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(triangulos[i]);
                    }
                    arbcompletoT.Clear();
                    gameManager.client.SendMessage("Reiniciar_T");
                }
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "R_44")
        {
            Destroy(Instantiate(s_token), 5);
            if (ParseString(collision.gameObject.tag, 1) == "R" && Challenge == "R")
            {
                rombos.Add(Instantiate(gameManager.rombo, new Vector2((float) 7.99, (float) -3.41), Quaternion.identity));
                Introducir_lista("R_44");
                gameManager.client.SendMessage("R_44");
            }
            else
            {
                if (Challenge == "C")
                {
                    int c = circulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(circulos[i]);
                    }
                    arbcompletoC.Clear();
                    gameManager.client.SendMessage("Reiniciar_C");
                }
                if (Challenge == "R")
                {
                    int c = rombos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(rombos[i]);
                    }
                    arbcompletoR.Clear();
                    gameManager.client.SendMessage("Reiniciar_R");
                }
                if (Challenge == "Cu")
                {
                    int c = cuadrados.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(cuadrados[i]);
                    }
                    arbcompletoCu.Clear();
                    gameManager.client.SendMessage("Reiniciar_Cu");
                }
                if (Challenge == "T")
                {
                    int c = triangulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(triangulos[i]);
                    }
                    arbcompletoT.Clear();
                    gameManager.client.SendMessage("Reiniciar_T");
                }
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "R_50")
        {
            Destroy(Instantiate(s_token), 5);
            if (ParseString(collision.gameObject.tag, 1) == "R" && Challenge == "R")
            {
                rombos.Add(Instantiate(gameManager.rombo, new Vector2((float) 8.48, (float) -5.43), Quaternion.identity));
                Introducir_lista("R_50");
                gameManager.client.SendMessage("R_50");
            }
            else
            {
                if (Challenge == "C")
                {
                    int c = circulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(circulos[i]);
                    }
                    arbcompletoC.Clear();
                    gameManager.client.SendMessage("Reiniciar_C");
                }
                if (Challenge == "R")
                {
                    int c = rombos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(rombos[i]);
                    }
                    arbcompletoR.Clear();
                    gameManager.client.SendMessage("Reiniciar_R");
                }
                if (Challenge == "Cu")
                {
                    int c = cuadrados.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(cuadrados[i]);
                    }
                    arbcompletoCu.Clear();
                    gameManager.client.SendMessage("Reiniciar_Cu");
                }
                if (Challenge == "T")
                {
                    int c = triangulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(triangulos[i]);
                    }
                    arbcompletoT.Clear();
                    gameManager.client.SendMessage("Reiniciar_T");
                }
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "R_69")
        {
            Destroy(Instantiate(s_token), 5);
            if (ParseString(collision.gameObject.tag, 1) == "R" && Challenge == "R")
            {
                rombos.Add(Instantiate(gameManager.rombo, new Vector2((float) 9.01, (float) -4.44), Quaternion.identity));
                Introducir_lista("R_69");
                gameManager.client.SendMessage("R_69");
            }
            else
            {
                if (Challenge == "C")
                {
                    int c = circulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(circulos[i]);
                    }
                    arbcompletoC.Clear();
                    gameManager.client.SendMessage("Reiniciar_C");
                }
                if (Challenge == "R")
                {
                    int c = rombos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(rombos[i]);
                    }
                    arbcompletoR.Clear();
                    gameManager.client.SendMessage("Reiniciar_R");
                }
                if (Challenge == "Cu")
                {
                    int c = cuadrados.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(cuadrados[i]);
                    }
                    arbcompletoCu.Clear();
                    gameManager.client.SendMessage("Reiniciar_Cu");
                }
                if (Challenge == "T")
                {
                    int c = triangulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(triangulos[i]);
                    }
                    arbcompletoT.Clear();
                    gameManager.client.SendMessage("Reiniciar_T");
                }
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "R_91")
        {
            Destroy(Instantiate(s_token), 5);
            if (ParseString(collision.gameObject.tag, 1) == "R" && Challenge == "R")
            {
                rombos.Add(Instantiate(gameManager.rombo, new Vector2((float) 9.55, (float) -5.39), Quaternion.identity));
                Introducir_lista("R_91");
                gameManager.client.SendMessage("R_91");
            }
            else
            {
                if (Challenge == "C")
                {
                    int c = circulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(circulos[i]);
                    }
                    arbcompletoC.Clear();
                    gameManager.client.SendMessage("Reiniciar_C");
                }
                if (Challenge == "R")
                {
                    int c = rombos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(rombos[i]);
                    }
                    arbcompletoR.Clear();
                    gameManager.client.SendMessage("Reiniciar_R");
                }
                if (Challenge == "Cu")
                {
                    int c = cuadrados.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(cuadrados[i]);
                    }
                    arbcompletoCu.Clear();
                    gameManager.client.SendMessage("Reiniciar_Cu");
                }
                if (Challenge == "T")
                {
                    int c = triangulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(triangulos[i]);
                    }
                    arbcompletoT.Clear();
                    gameManager.client.SendMessage("Reiniciar_T");
                }
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "C_triangulo")
        {
            if (Challenge == "null")
            {
                Destroy(Instantiate(s_token), 5);
                Challenge = "T";
                gameManager.ATiempoSplay = true;
                Destroy(collision.gameObject);
                gameManager.Challenge_triangulo = true;
            }
        }
        if (collision.gameObject.tag == "T_11")
        {
            Destroy(Instantiate(s_token), 5);
            if (ParseString(collision.gameObject.tag, 1) == "T" && Challenge == "T")
            {
                triangulos.Add(Instantiate(gameManager.triangulo, new Vector2((float) 10.981, (float) -5.614), Quaternion.identity));
                Introducir_lista("T_11");
                gameManager.client.SendMessage("T_11");
            }
            else
            {
                if (Challenge == "C")
                {
                    int c = circulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(circulos[i]);
                    }
                    arbcompletoC.Clear();
                    gameManager.client.SendMessage("Reiniciar_C");
                }
                if (Challenge == "R")
                {
                    int c = rombos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(rombos[i]);
                    }
                    arbcompletoR.Clear();
                    gameManager.client.SendMessage("Reiniciar_R");
                }
                if (Challenge == "Cu")
                {
                    int c = cuadrados.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(cuadrados[i]);
                    }
                    arbcompletoCu.Clear();
                    gameManager.client.SendMessage("Reiniciar_Cu");
                }
                if (Challenge == "T")
                {
                    int c = triangulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(triangulos[i]);
                    }
                    arbcompletoT.Clear();
                    gameManager.client.SendMessage("Reiniciar_T");
                }
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "T_12")
        {
            Destroy(Instantiate(s_token), 5);
            if (ParseString(collision.gameObject.tag, 1) == "T" && Challenge == "T")
            {
                triangulos.Add(Instantiate(gameManager.triangulo, new Vector2((float) 11.87, (float) -4.54), Quaternion.identity));
                Introducir_lista("T_12");
                gameManager.client.SendMessage("T_12");
            }
            else
            {
                if (Challenge == "C")
                {
                    int c = circulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(circulos[i]);
                    }
                    arbcompletoC.Clear();
                    gameManager.client.SendMessage("Reiniciar_C");
                }
                if (Challenge == "R")
                {
                    int c = rombos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(rombos[i]);
                    }
                    arbcompletoR.Clear();
                    gameManager.client.SendMessage("Reiniciar_R");
                }
                if (Challenge == "Cu")
                {
                    int c = cuadrados.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(cuadrados[i]);
                    }
                    arbcompletoCu.Clear();
                    gameManager.client.SendMessage("Reiniciar_Cu");
                }
                if (Challenge == "T")
                {
                    int c = triangulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(triangulos[i]);
                    }
                    arbcompletoT.Clear();
                    gameManager.client.SendMessage("Reiniciar_T");
                }
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "T_15")
        {
            Destroy(Instantiate(s_token), 5);
            if (ParseString(collision.gameObject.tag, 1) == "T" && Challenge == "T")
            {
                triangulos.Add(Instantiate(gameManager.triangulo, new Vector2((float) 12.491, (float) -3.594), Quaternion.identity));
                Introducir_lista("T_15");
                gameManager.client.SendMessage("T_15");
            }
            else
            {
                if (Challenge == "C")
                {
                    int c = circulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(circulos[i]);
                    }
                    arbcompletoC.Clear();
                    gameManager.client.SendMessage("Reiniciar_C");
                }
                if (Challenge == "R")
                {
                    int c = rombos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(rombos[i]);
                    }
                    arbcompletoR.Clear();
                    gameManager.client.SendMessage("Reiniciar_R");
                }
                if (Challenge == "Cu")
                {
                    int c = cuadrados.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(cuadrados[i]);
                    }
                    arbcompletoCu.Clear();
                    gameManager.client.SendMessage("Reiniciar_Cu");
                }
                if (Challenge == "T")
                {
                    int c = triangulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(triangulos[i]);
                    }
                    arbcompletoT.Clear();
                    gameManager.client.SendMessage("Reiniciar_T");
                }
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "T_44")
        {
            Destroy(Instantiate(s_token), 5);
            if (ParseString(collision.gameObject.tag, 1) == "T" && Challenge == "T")
            {
                triangulos.Add(Instantiate(gameManager.triangulo, new Vector2((float) 12.43, (float) -5.61), Quaternion.identity));
                Introducir_lista("T_44");
                gameManager.client.SendMessage("T_44");
            }
            else
            {
                if (Challenge == "C")
                {
                    int c = circulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(circulos[i]);
                    }
                    arbcompletoC.Clear();
                    gameManager.client.SendMessage("Reiniciar_C");
                }
                if (Challenge == "R")
                {
                    int c = rombos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(rombos[i]);
                    }
                    arbcompletoR.Clear();
                    gameManager.client.SendMessage("Reiniciar_R");
                }
                if (Challenge == "Cu")
                {
                    int c = cuadrados.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(cuadrados[i]);
                    }
                    arbcompletoCu.Clear();
                    gameManager.client.SendMessage("Reiniciar_Cu");
                }
                if (Challenge == "T")
                {
                    int c = triangulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(triangulos[i]);
                    }
                    arbcompletoT.Clear();
                    gameManager.client.SendMessage("Reiniciar_T");
                }
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "T_55")
        {
            Destroy(Instantiate(s_token), 5);
            if (ParseString(collision.gameObject.tag, 1) == "T" && Challenge == "T")
            {
                triangulos.Add(Instantiate(gameManager.triangulo, new Vector2((float) 13.347, (float) -6.593), Quaternion.identity));
                Introducir_lista("T_55");
                gameManager.client.SendMessage("T_55");
            }
            else
            {
                if (Challenge == "C")
                {
                    int c = circulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(circulos[i]);
                    }
                    arbcompletoC.Clear();
                    gameManager.client.SendMessage("Reiniciar_C");
                }
                if (Challenge == "R")
                {
                    int c = rombos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(rombos[i]);
                    }
                    arbcompletoR.Clear();
                    gameManager.client.SendMessage("Reiniciar_R");
                }
                if (Challenge == "Cu")
                {
                    int c = cuadrados.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(cuadrados[i]);
                    }
                    arbcompletoCu.Clear();
                    gameManager.client.SendMessage("Reiniciar_Cu");
                }
                if (Challenge == "T")
                {
                    int c = triangulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(triangulos[i]);
                    }
                    arbcompletoT.Clear();
                    gameManager.client.SendMessage("Reiniciar_T");
                }
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "T_59")
        {
            Destroy(Instantiate(s_token), 5);
            if (ParseString(collision.gameObject.tag, 1) == "T" && Challenge == "T")
            {
                triangulos.Add(Instantiate(gameManager.triangulo, new Vector2((float) 12.951, (float) -4.614), Quaternion.identity));
                Introducir_lista("T_59");
                gameManager.client.SendMessage("T_59");
            }
            else
            {
                if (Challenge == "C")
                {
                    int c = circulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(circulos[i]);
                    }
                    arbcompletoC.Clear();
                    gameManager.client.SendMessage("Reiniciar_C");
                }
                if (Challenge == "R")
                {
                    int c = rombos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(rombos[i]);
                    }
                    arbcompletoR.Clear();
                    gameManager.client.SendMessage("Reiniciar_R");
                }
                if (Challenge == "Cu")
                {
                    int c = cuadrados.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(cuadrados[i]);
                    }
                    arbcompletoCu.Clear();
                    gameManager.client.SendMessage("Reiniciar_Cu");
                }
                if (Challenge == "T")
                {
                    int c = triangulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(triangulos[i]);
                    }
                    arbcompletoT.Clear();
                    gameManager.client.SendMessage("Reiniciar_T");
                }
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "T_70")
        {
            Destroy(Instantiate(s_token), 5);
            if (ParseString(collision.gameObject.tag, 1) == "T" && Challenge == "T")
            {
                triangulos.Add(Instantiate(gameManager.triangulo, new Vector2((float) 13.981, (float) -5.614), Quaternion.identity));
                Introducir_lista("T_70");
                gameManager.client.SendMessage("T_70");
            }
            else
            {
                if (Challenge == "C")
                {
                    int c = circulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(circulos[i]);
                    }
                    arbcompletoC.Clear();
                    gameManager.client.SendMessage("Reiniciar_C");
                }
                if (Challenge == "R")
                {
                    int c = rombos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(rombos[i]);
                    }
                    arbcompletoR.Clear();
                    gameManager.client.SendMessage("Reiniciar_R");
                }
                if (Challenge == "Cu")
                {
                    int c = cuadrados.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(cuadrados[i]);
                    }
                    arbcompletoCu.Clear();
                    gameManager.client.SendMessage("Reiniciar_Cu");
                }
                if (Challenge == "T")
                {
                    int c = triangulos.Count();
                    for (int i = 0; i < c; i++)
                    {
                        Destroy(triangulos[i]);
                    }
                    arbcompletoT.Clear();
                    gameManager.client.SendMessage("Reiniciar_T");
                }
            }
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "PAtaque")
        {
            Destroy(Instantiate(s_poder), 5);
            Escudo = false;
            DobleSalto = false;
            force_push = true;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "PEscudo")
        {
            Destroy(Instantiate(s_poder), 5);
            Escudo = true;
            DobleSalto = false;
            force_push = false;
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "PDoubleJ")
        {
            Destroy(Instantiate(s_poder), 5);
            Escudo = false;
            DobleSalto = true;
            force_push = false;
            Destroy(collision.gameObject);
        }
    }
}