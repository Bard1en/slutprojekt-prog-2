using System.Windows.Forms;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Alien_Invaders
{
    public class Enemy
    {
        private Texture2D enemyTexture; 
        private Vector2 enemyPosition;
        private int HP = 1;
        

        public Enemy(Texture2D enemyTexture){
        this.enemyTexture = enemyTexture;
        enemyPosition = new Vector2(300,50);
        }
        public void Update(GameTime gameTime){

        }
         public void Draw(SpriteBatch spriteBatch){
        spriteBatch.Draw(enemyTexture, enemyPosition, Color.White);
         }
    }
}