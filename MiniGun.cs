using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Alien_Invaders
{
    public class MiniGun
    {
        
        private Texture2D texture;
        private Vector2 position;
        private int DMG = 1;
        private float speed;
        private bool isActive;

        public MiniGun(Texture2D texture, Vector2 startPosition)
        {
            this.texture = texture;
            this.position = startPosition;
            this.speed = 5f; 
            this.isActive = true;
        }

        public void Update()
        {
            if (isActive)
            {
                position.Y -= speed; 
                if (position.Y < 0) 
                {
                    isActive = false;
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
        public bool IsActive => isActive;
    
    }
}