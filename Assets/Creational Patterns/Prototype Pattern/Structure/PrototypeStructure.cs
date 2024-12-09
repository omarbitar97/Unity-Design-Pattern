//-------------------------------------------------------------------------------------
//	PrototypeStructure.cs
//-------------------------------------------------------------------------------------

using UnityEngine;
using System.Collections;

public class PrototypeStructure : MonoBehaviour
{
    void Start()
    {
        // Create two instances and clone each
        ConcretePrototype1 p1 = new ConcretePrototype1("I");
        ConcretePrototype1 c1 = (ConcretePrototype1)p1.Clone();
        Debug.Log("Cloned: " + c1.GetId());

        ConcretePrototype2 p2 = new ConcretePrototype2("II");
        ConcretePrototype2 c2 = (ConcretePrototype2)p2.Clone();
        Debug.Log("Cloned: " + c2.GetId());
    }
}

/// <summary>
/// The 'Prototype' abstract class
/// </summary>
abstract class Prototype
{
    private string _id;

    // Constructor
    protected Prototype(string id)
    {
        _id = id;
    }

    // Gets id
    public string GetId()
    {
        return _id;
    }

    public abstract Prototype Clone();
}

/// <summary>
/// A 'ConcretePrototype' class
/// </summary>
class ConcretePrototype1 : Prototype
{
    public ConcretePrototype1(string id) : base(id) { }

    public override Prototype Clone()
    {
        return (Prototype)MemberwiseClone();
    }
}

/// <summary>
/// A 'ConcretePrototype' class
/// </summary>
class ConcretePrototype2 : Prototype
{
    public ConcretePrototype2(string id) : base(id) { }

    public override Prototype Clone()
    {
        return (Prototype)MemberwiseClone();
    }
}