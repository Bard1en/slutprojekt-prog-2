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

        public Enemy(Texture2D enemyTexture, Vector2 position){
        this.enemyTexture = enemyTexture;
        this.enemyPosition = position;
        }
        public void Update(GameTime gameTime){
            enemyPosition.Y +=0.01f;
        }
         public void Draw(SpriteBatch spriteBatch){
                spriteBatch.Draw(enemyTexture, enemyPosition, Color.White);
         }
         
    }
}