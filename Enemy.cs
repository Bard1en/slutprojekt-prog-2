using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Alien_Invaders
{
    public class Enemy 
    {
        private Texture2D enemyTexture; 
        private Vector2 enemyPosition;
        private Texture2D enemyBulletTexture;
        private Rectangle hitbox;
        private Texture2D bulletTexture;
        private float timeLastShot = 0f;
        private float shotCooldown = 5f;
        private List<EnemyBullet> enemybullets;
        public List<EnemyBullet> Enemybullets{
            get{return enemybullets;}
        }
        public Rectangle Hitbox{get{return hitbox;}set{hitbox=value;}}
        private int health;
        public int Health{
            get{return health;}
        }
        

       public Enemy(Texture2D enemyTexture, Texture2D enemyBulletTexture, Vector2 position, int health = 20)
        {
            this.enemyTexture = enemyTexture;
            this.enemyBulletTexture = enemyBulletTexture;
            this.enemyPosition = position;
            this.health = health;
            this.enemybullets = new List<EnemyBullet>();
        }

        public void Update(GameTime gameTime){
        hitbox = new Rectangle((int)enemyPosition.X, (int)enemyPosition.Y, enemyTexture.Width, enemyTexture.Height);
        timeLastShot += (float)gameTime.ElapsedGameTime.TotalSeconds;
         if(timeLastShot >= shotCooldown)
            {
                EnemyShoot();
                timeLastShot = 0f;  
            }
            for(int i = enemybullets.Count -1; i >= 0; i--){
            enemybullets[i].Update();
            if(!enemybullets[i].IsActive)enemybullets.RemoveAt(i);
        }  
    }   
        private void EnemyShoot(){
        
         Vector2 enemybulletPosition = new Vector2(enemyPosition.X, enemyPosition.Y); 
         enemybullets.Add(new EnemyBullet(enemyBulletTexture, enemybulletPosition,5));
    }
         
         public void TakeDamage(int amount)
            {  
                health -= amount;
            }
         public void Draw(SpriteBatch spriteBatch){
                spriteBatch.Draw(enemyTexture, enemyPosition, Color.White);
                foreach (var enemybullet in enemybullets)
            {
                enemybullet.Draw(spriteBatch);
            }
         }
         
    }
}
