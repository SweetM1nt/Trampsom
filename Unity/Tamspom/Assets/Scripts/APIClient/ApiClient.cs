using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class ApiClient : MonoBehaviour
{
    const string baseUrl = "http://localhost:64600/API";

    // Use this for initialization
    void Start()
    {
        StartCoroutine(GetItensApiAsync());
    }

    IEnumerator GetItensApiAsync()
    {
        UnityWebRequest request = UnityWebRequest.Get(baseUrl + "/Bichos");
        yield return request.Send();
        if (request.isNetworkError || request.isHttpError)
        {
            Debug.Log(request.error);
        }
        else
        {
            string response = request.downloadHandler.text;
            //Debug.Log(response);

            //byte[] bytes = request.downloadHandler.data;

            Bicho[] itens = JsonHelper.getJsonArray<Bicho>(response);

            foreach (Bicho i in itens)
            {
                ImprimirItem(i);
            }
        }
    }



    private void ImprimirItem(Bicho i)
    {
        Debug.Log("======= Dados Objeto ==========");      
        Debug.Log("Id: " + i.BichoID);
        Debug.Log("Nome: " + i.Nome);
        Debug.Log("Descrição: " + i.Descricao);
        Debug.Log("Forca: " + i.Forca);
    }

}