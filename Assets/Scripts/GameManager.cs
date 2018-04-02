using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    //Método que contiene las instacias de los constructores, las matrices que conteienen, los colores y los nombres que se asignara de manera aleatoria.
	void Start ()
    {
        Color[] color = new Color[] { Color.cyan, Color.green, Color.magenta};
        string[] name = new string[]
        {
            "Adolfo",
            "Ramiro",
            "Bob",
            "Jimmy",
            "Josefo",
            "Leopoldo",
            "Cirilo",
            "Fabio",
            "Yisus",
            "Jasinto",
            "Arnulfa",
            "Berta",
            "Gregoria",
            "Gertrudis",
            "Lola",
            "Marta",
            "Eva",
            "Beatriz",
            "Facunda",
            "Pepa"
        };
        //Bucle "for", instancia los zombies y ciudadanos de manera aleatoria entre 5 y 10.
        for (int i = 0; i < Random.Range(5, 10); i++)
        {
            int age = Random.Range(15, 100);
            int spawn = Random.Range(1, 3);
            switch (spawn)
            {
                case 1:
                    new Zombie(color[Random.Range(0, 3)]);
                    break;
                case 2:
                    new Citizen(name[Random.Range(0, 20)], age);
                    break;
            }
        }
        new Hero();
    }
}
//Clase que contiene el constructor de ciudadanos. Posee variables para nombre y edad de cada aldeano.
class Citizen
{
    public string name;
    public int age;
    GameObject citizen;
    //Constructor de ciudadano, se crea la primitiva del cubo y se le otorga el nombre, edad y diagolo.
    public Citizen(string n, int a)
    {
        name = n;
        age = a;
        citizen = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Vector3 pos = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
        citizen.transform.position = pos;
        Debug.Log(Identity());
    }
    //Función que otorga el dialogo al ciudadano creado.
    public string Identity()
    {
        return "Hola soy " + name + " y tengo " + age + " años";
    }
}
//Clase que contiene el constructor de zombies. Posee la variable de color para cada zombie.
class Zombie
{
    public Color color;
    GameObject zombie;
    //Constructor de zombie, crea la primitiva del cubo y se le otorga el color y el dialogo.
    public Zombie(Color c)
    {
        color = c;
        zombie = GameObject.CreatePrimitive(PrimitiveType.Cube);
        Vector3 pos = new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
        zombie.transform.position = pos;
        zombie.GetComponent<Renderer>().material.color = color;
        Debug.Log(Identity());
    }
    //Función que otorga el dialogo al zombie creado.
    public string Identity()
    {
        if(color == Color.cyan)
            return "Soy un zombie color Cyan";
        if (color == Color.green)
            return "Soy un zombie color Green";
        if (color == Color.magenta)
            return "Soy un zombie color Magenta";
        return "";
    }
}
//Clase que contiene el constructor del heroe. Añade los scripts que le otorgan movimiento.
class Hero
{
    GameObject hero;
    //Constructor de heroe, crea la primitiva del cubo y añade la camara como hijo de este.
    public Hero()
    {
        hero = GameObject.CreatePrimitive(PrimitiveType.Cube);
        hero.AddComponent<FPSMove>();
        hero.AddComponent<FPSAim>();
        Camera.main.transform.SetParent(this.hero.transform);
        Camera.main.gameObject.AddComponent<FPSAim>();
    }
}
