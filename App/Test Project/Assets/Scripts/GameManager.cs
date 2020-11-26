using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
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
    public Renderer fondo;
    public bool gameOver = false;
    public bool start = false;

    public List<GameObject> cols;
    public List<GameObject> obstaculos;
    public List<GameObject> plataformas;
    // Start is called before the first frame update
    void Start()
    {
        // Crear Plataformas
        plataformas.Add(Instantiate(plataforma1, new Vector2((float)-13,(float)4.5),Quaternion.identity));
        plataformas.Add(Instantiate(plataforma2, new Vector2((float)-5.5,(float)4.5),Quaternion.identity));
        plataformas.Add(Instantiate(plataforma3, new Vector2((float)-9.5,(float)1),Quaternion.identity));
        plataformas.Add(Instantiate(plataforma4,new Vector2((float)-1.5,(float)1),Quaternion.identity));
        plataformas.Add(Instantiate(plataforma5,new Vector2((float)-13.5,(float)-2.5),Quaternion.identity));
        plataformas.Add(Instantiate(plataforma6,new Vector2((float)-6,(float)-2.5),Quaternion.identity));
        plataformas.Add(Instantiate(plataforma7,new Vector2((float)-12.5,(float)-6),Quaternion.identity));
        plataformas.Add(Instantiate(plataforma8,new Vector2((float)-2,(float)-6),Quaternion.identity));
    }

    // Update is called once per frame
    void Update()
    {
        if (start == false)
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                start = true;
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
    }
}
