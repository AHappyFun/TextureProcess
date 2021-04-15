using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class Yasuo : MonoBehaviour
{
    public Texture2D source;
    public int smaller = 512;
    public int bigger = 2048;

    public void BiCubicSmallTex()
    {
        int width = smaller;
        int height = smaller;
        Texture2D newtex = new Texture2D(width, height);
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                float newx = (i + 0.5f) * ((float)source.width / (float)width);
                float newy = (j + 0.5f) * ((float)source.height / (float)height);

                float u = (float)i / (float)width;
                float v = (float)j / (float)height;

                float tx = (newx - ((int)newx + 0.5f)) / 1;
                float ty = (newy - ((int)newy + 0.5f)) / 1;

                float[] wx = new float[4]
                {
                    0.5f * (-tx + 2 * tx*tx + -tx*tx*tx),
                    0.5f*  (2 - 5 * tx*tx + 3 * tx*tx*tx),
                    0.5f  *(tx+ 4 *tx*tx - 3*tx*tx*tx),
                    0.5f * (-tx*tx + tx*tx*tx)
                };
                float[] wy = new float[4]
                {
                    0.5f * (-ty + 2 * ty*ty + -ty*ty*ty),
                    0.5f*  (2 - 5 * ty*ty + 3 * ty*ty*ty),
                    0.5f  *(ty+ 4 *ty*ty - 3*ty*ty*ty),
                    0.5f * (-ty*ty + ty*ty*ty)
                };

                Color b_1 = source.GetPixel((int)newx - 1, (int)newy - 1) * wx[0] +
                                    source.GetPixel((int)newx , (int)newy - 1) * wx[1] +
                                    source.GetPixel((int)newx +1, (int)newy - 1) * wx[2] +
                                    source.GetPixel((int)newx +2, (int)newy - 1) * wx[3];
                                                              
                Color b_0 = source.GetPixel((int)newx - 1, (int)newy) * wx[0] +
                                    source.GetPixel((int)newx, (int)newy) * wx[1] +
                                    source.GetPixel((int)newx + 1, (int)newy) * wx[2] +
                                    source.GetPixel((int)newx + 2, (int)newy) * wx[3];

                Color b_11 = source.GetPixel((int)newx - 1, (int)newy + 1) * wx[0] +
                                    source.GetPixel((int)newx, (int)newy + 1) * wx[1] +
                                    source.GetPixel((int)newx + 1, (int)newy + 1) * wx[2] +
                                    source.GetPixel((int)newx + 2, (int)newy + 1) * wx[3];
                                                          
                Color b_2 = source.GetPixel((int)newx - 1, (int)newy + 2) * wx[0] +
                                    source.GetPixel((int)newx, (int)newy + 2) * wx[1] +
                                    source.GetPixel((int)newx + 1, (int)newy + 2) * wx[2] +
                                    source.GetPixel((int)newx + 2, (int)newy + 2) * wx[3];

                Color c = b_1 * wy[0] + b_0 * wy[1] + b_11 * wy[2] + b_2 * wy[3];

                newtex.SetPixel(i, j, c);

                

            }
        }

        File.WriteAllBytes("Assets/PNG/new.png", newtex.EncodeToPNG());
    }

    public void BiCubicBigTex()
    {
        int width = bigger;
        int height = bigger;
        Texture2D newtex = new Texture2D(width, height);
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                float newx = (i + 0.5f) * ((float)source.width / (float)width);
                float newy = (j + 0.5f) * ((float)source.height / (float)height);

                float tx = (newx - ((int)newx + 0.5f)) / 1;
                float ty = (newy - ((int)newy + 0.5f)) / 1;

                float[] wx = new float[4]
                {
                    0.5f * (-tx + 2 * tx*tx + -tx*tx*tx),
                    0.5f*  (2 - 5 * tx*tx + 3 * tx*tx*tx),
                    0.5f  *(tx+ 4 *tx*tx - 3*tx*tx*tx),
                    0.5f * (-tx*tx + tx*tx*tx)
                };
                float[] wy = new float[4]
                {
                    0.5f * (-ty + 2 * ty*ty + -ty*ty*ty),
                    0.5f*  (2 - 5 * ty*ty + 3 * ty*ty*ty),
                    0.5f  *(ty+ 4 *ty*ty - 3*ty*ty*ty),
                    0.5f * (-ty*ty + ty*ty*ty)
                };

                Color b_1 = source.GetPixel((int)newx - 1, (int)newy - 1) * wx[0] +
                                    source.GetPixel((int)newx, (int)newy - 1) * wx[1] +
                                    source.GetPixel((int)newx + 1, (int)newy - 1) * wx[2] +
                                    source.GetPixel((int)newx + 2, (int)newy - 1) * wx[3];

                Color b_0 = source.GetPixel((int)newx - 1, (int)newy) * wx[0] +
                                    source.GetPixel((int)newx, (int)newy) * wx[1] +
                                    source.GetPixel((int)newx + 1, (int)newy) * wx[2] +
                                    source.GetPixel((int)newx + 2, (int)newy) * wx[3];

                Color b_11 = source.GetPixel((int)newx - 1, (int)newy + 1) * wx[0] +
                                    source.GetPixel((int)newx, (int)newy + 1) * wx[1] +
                                    source.GetPixel((int)newx + 1, (int)newy + 1) * wx[2] +
                                    source.GetPixel((int)newx + 2, (int)newy + 1) * wx[3];

                Color b_2 = source.GetPixel((int)newx - 1, (int)newy + 2) * wx[0] +
                                    source.GetPixel((int)newx, (int)newy + 2) * wx[1] +
                                    source.GetPixel((int)newx + 1, (int)newy + 2) * wx[2] +
                                    source.GetPixel((int)newx + 2, (int)newy + 2) * wx[3];

                Color c = b_1 * wy[0] + b_0 * wy[1] + b_11 * wy[2] + b_2 * wy[3];

                newtex.SetPixel(i, j, c);

            }
        }

        File.WriteAllBytes("Assets/PNG/big2048.png", newtex.EncodeToPNG());
    }

    public void BilinearTex()
    {
        int width = bigger;
        int height = bigger;
        Texture2D newtex = new Texture2D(width, height);
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                float newx = (i + 0.5f) * ((float)source.width / (float)width);
                float newy = (j + 0.5f) * ((float)source.height / (float)height);

                float tx = (newx - ((int)newx + 0.5f)) / 1;
                float ty = (newy - ((int)newy + 0.5f)) / 1;

                float[] wx = new float[2]
                {
                    1 - tx,
                    tx,
                };
                float[] wy = new float[2]
                {
                    1-ty,
                     ty,
                };

                Color b_0 = source.GetPixel((int)newx, (int)newy) * wx[0] +
                                    source.GetPixel((int)newx + 1, (int)newy) * wx[1];

                Color b_1 = source.GetPixel((int)newx, (int)newy + 1) * wx[0] +
                                    source.GetPixel((int)newx + 1, (int)newy + 1) * wx[1];

                Color c = b_0 * wy[0] + b_1 * wy[1];

                newtex.SetPixel(i, j, c);

            }
        }

        File.WriteAllBytes("Assets/PNG/mybilinear.png", newtex.EncodeToPNG());
    }

    float a = -0.5f;
    float Get_W(float x)
    {
        float w;
        x = Mathf.Abs(x);
        if(x <= 1)
        {
            w = (a + 2) * x * x * x - (a + 3) * x * x + 1;
        }
        else if (x < 2)
        {
            w = a * x * x * x - 5 * a * x * x + 8 * a * x - 4 * a;
        }
        else
        {
            w = 0;
        }
        return w;
    }
    
}

[CustomEditor(typeof(Yasuo))]
public class YasuoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        if (GUILayout.Button("双立方插值变小"))
        {
            Yasuo s = target as Yasuo;
            s.BiCubicSmallTex();
        }
        if (GUILayout.Button("双立方插值变大"))
        {
            Yasuo s = target as Yasuo;
            s.BiCubicBigTex();
        }
        if (GUILayout.Button("双线性插值变大"))
        {
            Yasuo s = target as Yasuo;
            s.BilinearTex();
        }
        base.OnInspectorGUI();
    }
}