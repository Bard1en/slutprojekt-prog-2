using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Alien_Invaders
{
    public class Enemy 
    {
        private Texture2D enemyTexture; 
        private Vector2 enemyPosition;
        private Rectangle hitbox;
        public Rectangle Hitbox{get{return hitbox;}set{hitbox=value;}}
        private int health;
        public int Health{
            get{return health;}
        }
        

        public Enemy(Texture2D enemyTexture, Vector2 position, int health = 20){
        this.enemyTexture = enemyTexture;
        this.enemyPosition = position;
        this.health = health;
        }
        public void Update(GameTime gameTime){
             enemyPosition.Y += 0f;
             hitbox = new Rectangle((int)enemyPosition.X, (int)enemyPosition.Y, enemyTexture.Width, enemyTexture.Height);
         }
         public void TakeDamage(int amount)
            {  
                health -= amount;
            }

         public void Draw(SpriteBatch spriteBatch){
                spriteBatch.Draw(enemyTexture, enemyPosition, Color.White);
         }
         
    }
}
