using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Target : MonoBehaviour
{
    public GameObject cannonstandObj, targetObj, distPos;
    public Text distance;
    public GameObject starPrefab;
    SpriteRenderer rend;

    void Start()
    {
        rend = starPrefab.GetComponent<SpriteRenderer>();
        Color c = rend.sharedMaterial.color;
        c.a = 0f;
        rend.material.color = c;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "cannonball")
        {
            startFading();
        }
    }

    void OnMouseDrag()
    {
        Camera cam = Camera.main;
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 distancePos = Camera.main.WorldToScreenPoint(distPos.transform.position);

        distance.text = CalculateBetween(cannonstandObj, targetObj).ToString("F") + " m";
        transform.position = new Vector2(Mathf.Clamp(direction.x, -3.60f, 14.33f), transform.position.y);
        distance.transform.position = new Vector2(distancePos.x, distancePos.y);
    }

    float CalculateBetween(GameObject postionA, GameObject postionB)
    {
        return postionB.transform.position.x - postionA.transform.position.x;
    }

    IEnumerator FadeIn()
    {
        for (float f = 0.05f; f <= 1; f += 0.05f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }

        for (float f = 1f; f >= -0.03f; f -= 0.03f)
        {
            Color c = rend.material.color;
            c.a = f;
            rend.material.color = c;
            yield return new WaitForSeconds(0.05f);
        }
    }
    public void startFading()
    {
        StartCoroutine("FadeIn");
    }


}
