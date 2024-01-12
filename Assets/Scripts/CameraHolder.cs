using UnityEngine;

public class CameraHolder : MonoBehaviour
{
	public GameObject player;
	private float posX;
	private float posY;

	// Start is called before the first frame update
	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	// Update is called once per frame
	void Update()
	{
        if (player.transform.position.y < -5.58f || player.transform.position.y > 4.78f)
		{
			posY = transform.position.y;
		}
		else
		{
			posY = player.transform.position.y;
		}

		if(player.transform.position.x > 5.83f || player.transform.position.x < -4.85f)
		{
			posX = transform.position.x;
		}
		else
		{
			posX = player.transform.position.x;
		}

		transform.position = new Vector2(posX, posY);
		
		
	}
}
