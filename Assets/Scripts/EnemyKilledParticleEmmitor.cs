using UnityEngine;
using System.Collections;
using PE2D;

/**
 * Adapted from script in Paricle Emmitor folder
 * 
 * */
public class EnemyKilledParticleEmmitor : MonoBehaviour
{

    public float speedOffset = .01f;
    public float lengthMultiplier = 40f;
    public int numToSpawn = 200;
    public WrapAroundType wrapAround;


    //spawns an explosion at the position given and changes the color depending on the enemy
    public void SpawnExplosion(Vector3 position, GameObject enemy)
    {
        float hue1 = Random.Range(0, 6);
        float hue2 = (hue1 + Random.Range(0, 2)) % 6f;
        Color color = Color.white;

        for (int i = 0; i < numToSpawn; i++)
        {
            float speed = (18f * (1f - 1 / Random.Range(1f, 10f))) * speedOffset;

            var state = new ParticleBuilder()
            {
                velocity = StaticExtensions.Random.RandomVector2(speed, speed),
                wrapAroundType = wrapAround,
                lengthMultiplier = lengthMultiplier,
                velocityDampModifier = 0.94f,
                removeWhenAlphaReachesThreshold = true
            };

            //custom code for the game to change the color depending on the enemy
            if (enemy.name.Contains("basic"))
            {
                color = Color.white;
            }
            else if (enemy.name.Contains("Health"))
            {
                color = Color.green;
            }
            else if (enemy.name.Contains("Sharp"))
            {
                color = Color.yellow;
            }

            float duration = 320f;
            var initialScale = new Vector2(2f, 1f);


            ParticleFactory.instance.CreateParticle(position, color, duration, initialScale, state);
        }
    }


}
