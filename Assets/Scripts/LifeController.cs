using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEditor.SearchService;
using System.Runtime.InteropServices.WindowsRuntime;

public class LifeController : MonoBehaviour
{
    public int life;
    public UnityEvent action;
    public TextMeshProUGUI lifetext;
    public GameObject Mushie;
    private void Update()
    {
        lifetext.text = " " + life;
        
    }
    public void SetDamage(int damage)
    {
        life -= damage;
        if (life<=0)
        {
            action.Invoke();
            AudioManager.instance.Play("Hurt");
        }
    }
    public void DestroyObject(GameObject obj)
    {
        Destroy(obj);
    }   
    public void LoadScene(int scene)
    {
        SceneManager.LoadScene(scene);
       
    }
 
}
