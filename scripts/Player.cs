using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static float speed = 6f;
    float gravity = 9.81f;
    private CharacterController characterController;
    public GameObject particle;
    public GameObject hitMarker;
    public GameObject hitBlood;

    public int lifes;
    public static int points = 0;
    private int position = 0;
    public static int[] vetor = new int[3];

    private UI ui;

    public static int deaths;
    public int de;

    public GameObject keySilver;
    
    public AudioSource sounds;
    public AudioSource sounds2;
    public AudioSource blood;

    public AudioClip shootSound;
    public AudioClip emptyAmmoSound;

    public static bool varPause = false;

    public static bool isReload = false;

    public int balas;
    public static int bullets; //balas que ja tenho disponivel na arma
    public static int yourBullets = 500; // balas que vao ser mostradas na tela, e que coletarei para estar disponivel
    public int maxBullets = 200; //maximo de bala que posso colocar na arma para comparar


        // Use this for initialization
    
    void Start()
    {
        //da acesso ao metodo Move
        characterController = GetComponent<CharacterController>();
        bullets = 200;
        speed = 6f;
        Time.timeScale = 1;

        ui = GameObject.Find("Canvas").GetComponent<UI>();
        sounds = GameObject.Find("Weapon").GetComponent<AudioSource>();
        sounds2 = GameObject.Find("Reload").GetComponent<AudioSource>();
        blood = GameObject.Find("blood").GetComponent<AudioSource>();
        varPause = false;
        lifes = 11;
        points = 0;
        yourBullets = 500;
        deaths = 0;

        ui.hideVictory();
        ui.hideLose();

    }

    //Update is called once per frame
    void Update()
    {
        de = deaths;
        playerMovement();
        raycast();
        reload();
        balas = bullets;
        messageGetKey();
        pause();
        lose();

        ui.updateLifes(lifes);
    }

    void playerMovement()
    {
        //Z frente tras
        float vertical = Input.GetAxis("Vertical");
        //X esquerda , direita
        float horizontal = Input.GetAxis("Horizontal");


        Vector3 direction = new Vector3(horizontal, 0, vertical);

        //velocidade * direção que é as direçoes la de cima , vertical e horizontal , y=0 pq nao pula quando anda

        Vector3 velocity = direction * speed;
        velocity = transform.transform.TransformDirection(velocity);
        //gravidade quando eu andar 
        velocity.y -= gravity;


        characterController.Move(velocity * Time.deltaTime);

    }

    //Raycast

    void raycast()
    {
        if(varPause == false)
        {
            if (Input.GetMouseButton(0))
            {
                if (bullets > 0 && isReload == false)
                {
                    shoot();

                }
                else if (bullets == 0)
                {
                    if (sounds2.isPlaying == false)
                    {
                        sounds2.PlayOneShot(emptyAmmoSound);
                    }

                    WeaponAnimations.shooting = false;
                    particle.SetActive(false);
                    sounds.Stop();
                    Debug.Log("Nao tem balas seu burro, recarrega");


                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                WeaponAnimations.shooting = false;
                particle.SetActive(false);
                sounds.Stop();
            }
        }
        
    }

    void shoot()
    {
        if (varPause == false)
        {
            particle.SetActive(true);
            bullets--;
            ui.updateBullets(bullets, yourBullets);


            if (sounds.isPlaying == false)
            {
                sounds.PlayOneShot(shootSound);
            }


            //A mira irá aparecer na tela independente do tamanho da screen pois o calculo cola a mira no meio
            Ray look = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
            RaycastHit hitInfo;

            //O if usando raycast por si só ja retorna algo , caso esse raio colida com algo
            if (Physics.Raycast(look, out hitInfo))
            {

                enemy enemyOK = hitInfo.transform.GetComponent<enemy>();
                if (enemyOK != null)
                {
                    if (enemyOK.tag == "zombie")
                    {

                        enemyOK.dano();
                        Debug.Log("PEEi");
                        blood.Play();
                    }

                }


                if (hitInfo.transform.gameObject.tag != "zombie")
                {
                    Instantiate(hitMarker, hitInfo.point, Quaternion.identity);
                }

            }
        }
        
    }

    void reload()
    {
        if (bullets < maxBullets)
        {
            if (Input.GetMouseButtonDown(1))
            {
                if (yourBullets != 0)
                {
                    if (yourBullets > 0)
                    {
                        int preciso = maxBullets - bullets;

                        if (preciso <= yourBullets)
                        {
                            StartCoroutine(waitReload());
                            yourBullets = yourBullets - preciso;
                            bullets = bullets + preciso;

                        }
                        else if (preciso > yourBullets)
                        {
                            StartCoroutine(waitReload());
                            bullets = bullets + yourBullets;
                            yourBullets = 0;

                        }
                        else if ((bullets == 0) && (yourBullets >= maxBullets))
                        {
                            StartCoroutine(waitReload());
                            bullets = maxBullets;
                            yourBullets = yourBullets - maxBullets;

                        }            
                    }

                    if (sounds.isPlaying == false)
                    {
                        sounds2.Play();
                    }


                }


            }
        }
    }

    void messageGetKey()
    {
        if(deaths == 2)
        {
            deaths +=1;
            keySilver.SetActive(true);
            ui.showGetKey();
            
            StartCoroutine(waitKey());

        }
    }

    void pause()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            varPause = true;
            Time.timeScale = 0;
            ui.cursorTrue();
            ui.pauseScreenOn();
        }
    }

    void lose()
    {
        if(lifes == 0)
        {

            vetor[position] = points;
            position++;
            insertionSort(vetor);
  

            varPause = true;
            ui.showLose();
            Time.timeScale = 0;
            ui.cursorTrue();

            
        }
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "zombie")
        {
            lifes -= 1;
            
        }

    }

    IEnumerator waitReload()
    {
        isReload = true;
        yield return new WaitForSeconds(3.2f);
        isReload = false;
        ui.updateBullets(bullets, yourBullets);
    }

    IEnumerator waitKey()
    {
        yield return new WaitForSeconds(10f);
        ui.hideShowGetKey();
    }
    
    public void insertionSort(int[] array)
    {

        int[] antigoVetor = new int[3]; //caso der erro colocar 2 pois o vetor tem 3 posições
        int[] novoVetor = new int[3];

        for (int i = 0; i < array.Length; i++)
        {
            novoVetor[i] = array[i];
            antigoVetor[i] = array[i];
        }
    
        int aux = 0;
        int j = 0;
        for (int i = 1; i < novoVetor.Length; i++)
        {
            aux = novoVetor[i];
            j = i;
            while (j != 0 && novoVetor[j - 1] > aux)
            {
                novoVetor[j] = novoVetor[j - 1];
                j--;
            }
            novoVetor[j] = aux;
            
        }

        ui.updateRank(novoVetor[3]);

    }

    void verificar(int position)
    {
        if(position == 3)
        {
            position = 0;
            //no update
        }

        }
    }



























    public void BubbleSort()
    {
        if(points > vetor[0])
        {
            vetor[0] = points;
        }
        else
        {
            vetor[0] = vetor[0];
        }
    }
}
