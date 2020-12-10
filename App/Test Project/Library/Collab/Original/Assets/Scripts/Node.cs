using UnityEngine;

public class Node()
{
    private string tipo;
    private GameObject _gameObject;

    public Node(string s, GameObject c15)
    {
        throw new System.NotImplementedException();
        this.tipo = s;
        this._gameObject = c15;
    }

    public string GetTipo()
    {
        return this.tipo;
    }
    public GameObject GetObject()
    {
        return this._gameObject;
    }
}