using GameFramework.Content.Engine;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameFramework
{
    public abstract class Component
    {
        public GameObject Owner { get; private set; }
        public void Attach(GameObject owner)
        {
            Owner = owner;
            OnAttach(); 
        }

        protected virtual void OnAttach() { }
        public virtual void Update(GameTime gameTime) { }
    }
}


// --Learning Opertunity--

// Learnign about components for the first time. Components are a way to give objects funcitonality without having to put all of that functionality
// directly inside of their class. For the monogame framework, this might look something like giving a player movment, an inventory, etc all by
// attaching seperate compents instead of writing everything inside player.cs. A basic component class looks like this. 

//  public abstract class Component
//  {
//       public GameObject Owner { get; private set; }

//       public void Attach(GameObject owner)
//       {
//           Owner = owner;
//        }

//       public virtual void Update(GameTime gameTime)
//       {
//       }
//  }

// Compenent is the base class that all of my components inherit from. Owner is the GameObject that the component belongs to. Attach() assigns 
// the woning object to the component. Update() allows each ocmponenet to rune logic every frame. 

//  namespace GameFramework
//  {
//       public class Player : GameObject
//      {
//            public Player(Vector2 position)
//           {
//               Transform.Position = position;
//               Tag = "Player";

//               // Add components
//               AddComponent(new BasicMovementModule{Speed  = 150f, UseWASD = true});
//           }
//      }
//  }

// As seen above, you are able to set the {get; set;} fields in the basic movment module, which allows you to tweak the module, and maybe 
// toggle between things like wasd. This is what it might look like if implemented into a class. 


