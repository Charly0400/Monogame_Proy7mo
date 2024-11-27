using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SandBoxMG.Content.Code.InputManager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SandBoxMG.Content.Code.Scenes.GameObjects.Components
{
    public class CollisionComponent : Component
    {
        Vector2 _collisionSize;
        Rectangle _collisionRectangle;
        public CollisionComponent() { }

        public override void InitializeComponent(GameObject _GOref)
        {
            base.InitializeComponent(_GOref);
            _collisionSize = new Vector2();
        }

        public void InitializeCollisionComponent(Vector2 collisionSize, GameObject parentGO) {
            _collisionRectangle = new ((int)parentGO._positionOfTheGameObject.X, (int)parentGO._positionOfTheGameObject.Y, 
            (int)collisionSize.X, (int)collisionSize.Y);
            Debug.WriteLine(_collisionRectangle.Location);
        }

        public override void UpdateComponent()
        {
            
            if (InputManager.InputManager.Clicked) {
                Debug.WriteLine(InputManager.InputManager.mouseCursor);
                {
                    Debug.WriteLine("Choca con collider");
                    
                }
            }

        }
    }
}
