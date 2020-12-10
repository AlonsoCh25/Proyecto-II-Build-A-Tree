using UnityEngine;


public class Node()
{
    private string tipo;
    private GameObject _gameObject;
    public Node(string tipo, GameObject _gameObject)
    {
        this.tipo = tipo;
        this._gameObject = _gameObject;
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