using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {
	private UnityEngine.AI.NavMeshAgent agent;
	private GameObject player;
	private Animator ani;
	private AudioSource audioSource;
	public int Audiocount=0;
	//[SerializeField]
	private int healthPoint = 1;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
		ani = this.GetComponent<Animator> ();
		agent = this.GetComponent<UnityEngine.AI.NavMeshAgent> ();
		audioSource = GetComponent<AudioSource> ();
	}
	void SwitchAttack(bool value)
	{
		ani.SetBool ("isAttack", value);
	}
	void SwitchDead()
	{
		ani.SetBool ("isDead", true);
		agent.Stop ();
		this.GetComponent<CapsuleCollider> ().enabled = false;
		PlaySoundDead(deadAC);
        
	}
	// Update is called once per frame
	void Update () 
	{
		if (agent.enabled && healthPoint > 0) {
			agent.destination = player.transform.position;
			if (Vector3.Distance (this.transform.position, player.transform.position) < 2.2f) {
				SwitchAttack (true);
				agent.Stop ();
				PlaySound (attackAC);
			} else {
				SwitchAttack (false);
				agent.Resume ();
				PlaySound (walkAC);
			}
		} 
		if (healthPoint <= 0)
		{
			AnimatorStateInfo asi = this.GetComponent<Animator> ().GetCurrentAnimatorStateInfo (0);
			if (asi.normalizedTime > 1f && asi.IsName ("back_fall")) 
			{
				Destroy (this.gameObject);
			}
		}
	}

	public void Hit(int point)
	{
		int t = healthPoint - point;
		if (t > 0) {
			healthPoint = t;
		} else {
			healthPoint = 0;
			SwitchDead ();
			GameManager.enemyCount1[GameManager.level]--;
        }
	}

	[SerializeField]
	private  AudioClip attackAC;
	[SerializeField]
	private  AudioClip deadAC;
	[SerializeField]
	private  AudioClip walkAC;

	void PlaySoundDead(AudioClip ac)
	{
		if (!audioSource.isPlaying) {
			audioSource.clip = ac;
			audioSource.Play ();
		}
	}
	void PlaySound(AudioClip ac)
	{
		/*if (Audiocount > 3) {
			return;
		}*/
		if (!audioSource.isPlaying) {
			audioSource.clip = ac;
			audioSource.Play ();
			Audiocount = Audiocount + 1;
		}
	}
}
