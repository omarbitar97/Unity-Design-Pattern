//-------------------------------------------------------------------------------------
//	PrototypePatternExample1.cs
//-------------------------------------------------------------------------------------

using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

//This real-world code demonstrates the Prototype pattern in which new Color objects are created by copying pre-existing, user-defined Colors of the same type.

namespace PrototypePatternExample1
{
    public class PrototypePatternExample1 : MonoBehaviour
    {
        void Start()
        {
            var colorManager = new ColorManager();

            // Initialize standard colors
            colorManager.SetColor("red", new Color(255, 0, 0));
            colorManager.SetColor("green", new Color(0, 255, 0));
            colorManager.SetColor("blue", new Color(0, 0, 255));

            // User-defined colors
            colorManager.SetColor("angry", new Color(255, 54, 0));
            colorManager.SetColor("peace", new Color(128, 211, 128));
            colorManager.SetColor("flame", new Color(211, 34, 20));

            // Clone colors
            var color1 = (Color)colorManager.GetColor("red").Clone();
            var color2 = (Color)colorManager.GetColor("peace").Clone();
            var color3 = (Color)colorManager.GetColor("flame").Clone();
        }
    }

    abstract class ColorPrototype
    {
        public abstract ColorPrototype Clone();
    }

    class Color : ColorPrototype
    {
        private int _red;
        private int _green;
        private int _blue;

        public Color(int red, int green, int blue)
        {
            _red = red;
            _green = green;
            _blue = blue;
        }

        public override ColorPrototype Clone()
        {
            Debug.Log("Cloning color RGB: (" + _red + ", " + _green + ", " + _blue + ")");
            return (ColorPrototype)MemberwiseClone();
        }
    }

    class ColorManager
    {
        private Dictionary<string, ColorPrototype> _colors = new Dictionary<string, ColorPrototype>();

        public void SetColor(string key, ColorPrototype color)
        {
            _colors[key] = color;
        }

        public ColorPrototype GetColor(string key)
        {
            return _colors[key];
        }
    }
}