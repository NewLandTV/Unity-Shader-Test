using System.Collections;
using UnityEngine;

public class FENeon : MonoBehaviour
{
    private byte showType;

    // Components
    private MeshRenderer meshRenderer;

    // Wait for seconds
    private WaitForSeconds waitTime1f;

    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();

        waitTime1f = new WaitForSeconds(1f);
    }

    private IEnumerator Start()
    {
        StartCoroutine(ChangeShowType());

        Vector4 value = Vector4.zero;
        Vector4 offset = Vector4.one;

        while (true)
        {
            switch (showType)
            {
                case 0:
                    yield return waitTime1f;

                    value = new Vector4(Random.Range(0, 256), Random.Range(0, 256), Random.Range(0, 256), Random.Range(0, 256));

                    break;
                case 1:
                    yield return null;

                    value += Vector4.one;

                    if (value.x >= 256f && value.y >= 256f && value.z >= 256f && value.w >= 256f)
                    {
                        value = Vector4.zero;
                    }

                    break;
                case 2:
                    yield return null;

                    value -= Vector4.one;

                    if (value.x <= 0f && value.y <= 0f && value.z <= 0f && value.w <= 0f)
                    {
                        value = Vector4.one * 255f;
                    }

                    break;
                case 3:
                    yield return waitTime1f;

                    value = new Vector4(Random.Range(0, 256), 0f, 0f, 0f);

                    break;
                case 4:
                    yield return waitTime1f;

                    value = new Vector4(0f, Random.Range(0, 256), 0f, 0f);

                    break;
                case 5:
                    yield return waitTime1f;

                    value = new Vector4(0f, 0f, Random.Range(0, 256), 0f);

                    break;
                case 6:
                    yield return null;

                    value += offset * 128 * Time.deltaTime;

                    if (value.x >= 256f && value.y >= 256f && value.z >= 256f && value.w >= 256f)
                    {
                        offset = -Vector4.one;
                    }
                    else if (value.x <= 0f && value.y <= 0f && value.z <= 0f && value.w <= 0f)
                    {
                        offset = Vector4.one;
                    }

                    break;
            }

            meshRenderer.material.SetVector("_Light_Color", value);
        }
    }

    private IEnumerator ChangeShowType()
    {
        while (true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                showType = (byte)((showType + 1) % 7);
            }

            yield return null;
        }
    }
}
