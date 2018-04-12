using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupScript : MonoBehaviour
{
    /// <summary>
    /// Array of Sprites for powerup objects.
    /// </summary>
    public Sprite[] sprites;
    /// <summary>
    /// The number of possible powerups in the game.
    /// </summary>
    public int numberOfPowerups;
    /// <summary>
    /// The type of this powerup.
    /// 0. Empty.
    /// 1. Small Energy.
    /// 2. Large Energy.
    /// 3. Small Health.
    /// 4. Large Health.
    /// </summary>
    public int type;
    /// <summary>
    /// Array of strings used to invoke a function corresponding to the type of powerup.
    /// </summary>
    public string[] collisionFunctions;

    private Collider2D player;

	void Start ()
    {
        if (type == 0)
        {
            type = Random.Range(1, numberOfPowerups + 1);
        }
        GetComponent<SpriteRenderer>().sprite = sprites[type-1];
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player = collision;
            Invoke(collisionFunctions[type -1], 0f);
            Destroy(gameObject);
        }
    }

    private void SmallEnergy()
    {
        player.SendMessage("RestoreEnergy", 2);
    }

    private void LargeEnergy()
    {
        player.SendMessage("RestoreEnergy", 4);
    }

    private void SmallHealth()
    {
        player.SendMessage("RestoreHealth", 2);
    }

    private void LargeHealth()
    {
        player.SendMessage("RestoreHealth", 4);
    }
}
