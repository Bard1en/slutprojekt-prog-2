using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Alien_Invaders
{
    public class Bullet
    {
        private Texture2D texture;
        private Vector2 position;
        private float speed;
        public bool isActive;
        private int damage;
        public int Damage{
            get{return damage;}
        }
      
        private Rectangle hitbox;
        public Rectangle Hitbox{get{return hitbox;}set{hitbox=value;}}
        
        public Bullet(Texture2D texture, Vector2 startPosition, int damage)
        {
            this.texture = texture;
            this.position = startPosition;
            this.speed = 3.5f; 
            this.isActive = true;
            this.damage = damage;
            Hitbox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }
        public void Deactivate(){
            isActive = false;
        }
        public void Update()
        {
            if (isActive)
            {
                position.Y -= speed; 

                Hitbox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

                if (position.Y < 0) 
                {
                    Deactivate();
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (isActive)
            {
                spriteBatch.Draw(texture, position, Color.White);
            }
        } 
        public bool IsActive{
            get{return isActive;}
        } 

    }
}