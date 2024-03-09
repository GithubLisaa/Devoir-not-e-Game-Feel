using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class shake : MonoBehaviour
{
    public bool Script_Actif = false;
    public float Start_délai = 0;
    public AnimationCurve Strengh_over_time;
    public float duré = 1f;
    void Update()
    {
        if (Script_Actif)
        {
            Script_Actif = false;
            StartCoroutine(wait());
            StartCoroutine(Shaking());
        }

        IEnumerator wait()
        {
            yield return new WaitForSeconds(Start_délai);
        }

        IEnumerator Shaking()
        {
            yield return new WaitForSeconds(Start_délai);
            Vector3 startpos = transform.position;
            float timepass = 0f;

            while (timepass < duré)
            {
                timepass += Time.deltaTime;
                float strengh = Strengh_over_time.Evaluate(timepass / duré);
                transform.position = startpos+Random.insideUnitSphere * strengh;
                yield return null;
            }
            transform.position = startpos;
        }
    }
}
