using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImposterGameApp
//Template Method Design Pattern
{
    public class GameObject //: Player
    {
        public String Name;
        public String Description;
        public bool Taken;
        public bool Takeable;
        public bool isWeapon;
        public double Weight;


        /*bool Taken { get => taken; set => taken = false; }*/


        public GameObject() { Taken = false; }
        public GameObject(string name) { Taken = false; }
        public GameObject(string obj, string description, double weight, bool takeable)
        {
            Name = obj;
            Description = description;
            Weight = weight;
            Takeable = takeable;
            isWeapon = false;
        }

        public virtual void AddItem(GameObject item) { }
        public virtual GameObject RemoveItem(string name)
        {
            return null;
        }

        public bool IsObjectTaken()
        {
            return Taken;
        }

        public string GetName()
        {
            return Name;
        }
    }

        //Template game design
        public class Weapon : GameObject
        {
            /* public Weapon() { Taken = false; }
             public Weapon(string name) { Name = name; Taken = false; }*/
            public Weapon(string obj, string description, double weight)
            {
               Taken = false;
               Name = obj;
               Description = description;
               Weight = weight;
               Takeable = true;
               isWeapon = true;
            }
        }

    

    //Container
    class BackPack 
    {
        public Dictionary<string, GameObject> inventory;
        public double maxCapacity = 5;
        public double BackPackWeight()
        {
       
                double tempWeight = 0;
                foreach (GameObject item in inventory.Values)
                {
                    tempWeight += item.Weight;
                }
                return tempWeight;
        
        }


        public BackPack()   //to call super 
        {
            inventory = new Dictionary<string, GameObject>();
        }

        public GameObject GetObject(string obj)
        {
            inventory.TryGetValue(obj, out GameObject item);
            return item;
        }

       
        public void AddObject(GameObject item)
        {
            inventory.Add(item.Name, item);
        }

        /*
         * public GameObject Take(string itemName)
        {
            return inventory.RemoveObject(itemName);
        }
        */

        public bool RemoveObject(string name)
        {
            //GetObject() method
            if (GetObject(name) != null)
            {
                inventory.Remove(name);
                return true;
            }
            return false;
        }

        public bool Contains(string obj)
        {
            return inventory.TryGetValue(obj, out GameObject item);
            //return true;
        }
    }
    

}