using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetTextureColor : MonoBehaviour
{
    //sourceTex�̃T�C�Y���画�f���A�J���[�f�[�^������Ă���悤�ɂ���B
    //sourceRect�̔p�~�B
    
    public Texture2D sourceTex;

    //public Rect sourceRect;

    [SerializeField]
    CastingParameter castingParameter = null;

    [SerializeField]
    CastingEvent castingAlphaParameterInputEndEvent = null;
    void Start()
    {
        //int x = Mathf.FloorToInt(sourceRect.x);
        int x = 0;
        //int y = Mathf.FloorToInt(sourceRect.y);
        int y = 0;
        //int width = Mathf.FloorToInt(sourceRect.width);
        int width = 1;//���P�̂ݕK�v�Ȃ̂�
        //int height = Mathf.FloorToInt(sourceRect.height); 
        int height = Mathf.FloorToInt(sourceTex.height); //�摜�̍������K�v�Ȃ̂ŁB

        Color[] pix = sourceTex.GetPixels(x, y, width, height);  //��������擾����B
        //Texture2D destTex = new Texture2D(width, height);
        //destTex.SetPixels(pix);
        //destTex.Apply();

        // Set the current object's texture to show the
        // extracted rectangle.
        //GetComponent<Renderer>().material.mainTexture = destTex;
        SetCastingParameter(pix);
    }
    /// <summary>
    /// CastingParameter��Color��R�i�Ƃ肠�����j������B
    /// </summary>
    void SetCastingParameter(Color[] pix)
    {
        float[] Colordata = new float[pix.Length];
        for (int i = 0; i < pix.Length; i++)  //�J���[�̔z�񂩂�float�̔z��ɕϊ��B
        {
            Colordata[i] = pix[i].r;
        }
        castingParameter.CastingAlpha = new List<float>(Colordata);
        castingAlphaParameterInputEndEvent.Raise();  //�C�x���g����
    }
}
