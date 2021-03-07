using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject cubePrefab;
    public MeshRenderer GroundMeshRenderer;
    public Transform cubeParent;
    const int DAY_COUNT = 25;
    public int[] points = new int[DAY_COUNT];
    
    Color GetRGBFromHex(string hex){
        Color color;
        ColorUtility.TryParseHtmlString(hex, out color);
        return color;
    }

    List<Color> GetGradationColor(int number, string startHex, string endHex){
        List<Color> colorList = new List<Color>();
        Color startRGB;
        Color endRGB;

        ColorUtility.TryParseHtmlString(startHex, out startRGB);
        ColorUtility.TryParseHtmlString(endHex, out endRGB);

        for (int i = 0; i < number; i++)
        {
            float r;
            float g;
            float b;
            if(startRGB.r > endRGB.r){
                r = (startRGB.r - (startRGB.r - endRGB.r) * ((1.0f / number) * i));
            } else {
                r = (startRGB.r + (endRGB.r- startRGB.r) * ((1.0f / number) * i));
            }
            if(startRGB.g > endRGB.g){
                g = (startRGB.g - (startRGB.g - endRGB.g) * ((1.0f / number) * i));
            } else {
                g = (startRGB.g + (endRGB.g- startRGB.g) * ((1.0f / number) * i));
            }
            if(startRGB.b > endRGB.b){
                b = (startRGB.b - (startRGB.b - endRGB.b) * ((1.0f / number) * i));
            } else {
                b = (startRGB.b + (endRGB.b- startRGB.b) * ((1.0f / number) * i));
            }

            Color result = new Color(r,g,b);
            colorList.Add(result);
        }
        return colorList;
    }

    void Start()
    {
        List<Color> colorList = GetGradationColor(DAY_COUNT, "#00C9FF", "#92FE9D");

        GroundMeshRenderer.material.color = colorList[0];
        for (int i = 0; i < DAY_COUNT; i++)
        {
            GameObject cube = Instantiate(cubePrefab, new Vector3(0, 1.75f + 0.25f * i, 0.33f), Quaternion.Euler(-10,45,-10));
            cube.transform.parent = cubeParent;
            cube.transform.localScale = new Vector3(1, 0.25f, 1);

            switch (points[i])
            {
                case 0:
                    cube.GetComponent<MeshRenderer>().material.color = colorList[i];
                break;
                case 1:
                    cube.GetComponent<MeshRenderer>().material.color = GetRGBFromHex("#fabc04");
                break;
                case 2:
                    cube.GetComponent<MeshRenderer>().material.color = GetRGBFromHex("#e84d3c");
                break;
                case 3:
                    cube.GetComponent<MeshRenderer>().material.color = Color.black;
                break;
                default:
                break;
            }
        }
        
    }
}
