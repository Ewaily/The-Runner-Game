using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {
	private Rigidbody rb;
	private int x=0;
	private double z;
	private int scoreCounter = 0;
	public Text scoreText, winText;
	public Text lives;
	private int livesCounter=3 ,pp = 50;
	public Camera myCamera;
	public GameObject lvl2,lvl1, lvl3;
	public GameObject pick,die,Player;
	private bool left=false,center=true,right=false,lost=false;
	float g,Q,gg;
	float[] pos = new float[] {-3,0,3};

	void Start(){
		rb = GetComponent<Rigidbody> ();
		x = 0;

	}

	void FixedUpdate(){ 
			if (Input.GetKeyDown (KeyCode.D) && x < 3) {       /* if x == -3 then i am at the left .. else if x == 0 then i am at center          */
			if (x == -3 && left==true) {
				x = 0;
				center = true;
				left = false;
				transform.position = new Vector3 (x, 0.5f, 0f);
			} else if (x == 0 && center==true) {
				x = 3;
				right=true;
				center=false;
				transform.position = new Vector3 (x, 0.5f, 0f);
			}
		} else if (Input.GetKeyDown (KeyCode.A) && x > -3) {
			if (x == 3 && right==true) {
					x = 0;
				center = true;
				right=false;
					transform.position = new Vector3 (x, 0.5f, 0f);
			} else if(x== 0 && center==true) {
					x =-3;
				left=true;
				center=false;
					transform.position = new Vector3 (x, 0.5f, 0f);
				}

			}
			z = z + 0.3;
	
			transform.position = new Vector3 (x, 0.5f, (float)z); 
		if (pick.transform.position.z<transform.position.z) {
			g = transform.position.z + pp;                                           // put picks randomly after disappearing
			int a = Random.Range (0, 3);

			pick.transform.position = new Vector3 (pos [a], 0.5f, g);

		}

		if (die.transform.position.z<transform.position.z) {
			g = transform.position.z + 80;        /* put risists randomly after disappearing */
			int a = Random.Range (0, 3);

			die.transform.position = new Vector3 (pos [a], 0.5f, g);

		}


		if (transform.position.z>200)
		{z = z + 0.1;
			g = transform.position.z +20;
			Q = transform.position.z + 400;
		}

		if (transform.position.z>400)
		{z = z + 0.1;
			g = transform.position.z +30;
			Q = transform.position.z + 40;
		}

		if (transform.position.z>600)
		{z = z + 0.1;
			g = transform.position.z +30;
			Q = transform.position.z + 40;

		}

		if (transform.position.z>800)
		{z = z + 0.1;
			g = transform.position.z +30;
			Q = transform.position.z + 40;

		}

		if (transform.position.z>1000)
		{z = z + 0.1;
			g = transform.position.z +30;
			Q = transform.position.z + 40;

		}

		if (transform.position.z>1600)
		{z = z + 0.2;
			g = transform.position.z +40;
			Q = transform.position.z + 40;

		}


		if (Input.GetKey (KeyCode.Escape)) {
			SceneManager.LoadScene ("menu");

		}

			
	}

	void OnTriggerEnter (Collider y)
	{
			
		if (y.gameObject.tag == "pick") {

		
			int a= Random.Range(0,3);

			y.transform.position = new Vector3 (pos[a], 0.5f, g);
			scoreCounter++;
			scoreText.text = "Score: " + scoreCounter;

		}

	

		if (y.gameObject.tag == "die") {



			livesCounter--;
			lives.text = "Lives: " + livesCounter;

		}


		if(livesCounter < 0){
			lives.text = "Lives: 0" ;
			lost = true;
			winText.text = "YOU LOSE :(";
			Player.gameObject.SetActive (false);
			winText.color = Color.red;
			winText.gameObject.SetActive (true);
			pick.gameObject.SetActive (false);
			die.gameObject.SetActive (false);
			//SceneManager.LoadScene ("menu");
			//System.Threading.Thread.Sleep (5000);
		}

		if (y.gameObject.tag == "lvl2") {
		//	winText.gameObject.SetActive (false);
			lvl2.gameObject.SetActive (true);
			livesCounter++;
			lives.text = "Lives : " + livesCounter;
			die.gameObject.SetActive (true);
			pp = 20;

		}

	/*	if (y.gameObject.tag == "lvl1") {
			winText.gameObject.SetActive (true);
			die.gameObject.SetActive (false);

		}*/

		/*if (y.gameObject.tag == "win") {
			winText.text = " YOU WIN !!";

			Player.gameObject.SetActive (false);
			winText.gameObject.SetActive (true);
			pick.gameObject.SetActive (false);
			die.gameObject.SetActive (false);
		}*/


		if (y.gameObject.tag == "lvl3") {
			
			winText.text = " YOU WIN !!";

			winText.gameObject.SetActive (true);
			Player.gameObject.SetActive (false);


			pick.gameObject.SetActive (false);
			die.gameObject.SetActive (false);

		}


	}
}



