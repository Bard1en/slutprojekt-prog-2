using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Alien_Invaders
{
    public class Player
    {
        private Texture2D texture; 
        private Vector2 position;
        private Texture2D bulletTexture;
        private Texture2D minigunTexture;
        private List<Bullet> bullets;
        private List<MiniGun> minigun;
        private float timeLastShot = 0f;
        private float shotCooldown = 1f;
        private float shotCdMinigun = 0.1f;
        private float timeLastMinigun = 0f;
        private Rectangle hitbox;
        private int health;
        public int Health{
            get{return health;}
        }
        public Rectangle Hitbox{get{return hitbox;}set{hitbox=value;}}
       
    
        public List<Bullet> Bullets{get{return bullets;}}
       public Player(Texture2D texture, Texture2D bulletTexture, Texture2D minigunTexture, int health = 100){
        this.texture = texture;
        this.bulletTexture = bulletTexture;
        this.minigunTexture = minigunTexture;
        position = new Vector2(300,450);
        bullets = new List<Bullet>();
        this.health = health;
    }
      public void Update(GameTime gameTime){
        hitbox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        timeLastShot += (float)gameTime.ElapsedGameTime.TotalSeconds;
        timeLastMinigun += (float)gameTime.ElapsedGameTime.TotalSeconds;
        KeyboardState kState = Keyboard.GetState();
        if(kState.IsKeyDown(Keys.A)) position.X -=5;
        if(kState.IsKeyDown(Keys.D)) position.X +=5;
        if(kState.IsKeyDown(Keys.Space) && timeLastShot >= shotCooldown)
            {
                Shoot();
                timeLastShot = 0f;  
            }
        if(kState.IsKeyDown(Keys.LeftShift) && timeLastMinigun >= shotCdMinigun)
            {
                MinigunShoot();
                timeLastMinigun = 0f;
            }
            for(int i = bullets.Count -1; i >= 0; i--){
            bullets[i].Update();
            if(!bullets[i].IsActive)bullets.RemoveAt(i);
        }  
    }
    private void Shoot(){
        
         Vector2 bulletPosition = new Vector2(position.X + texture.Width / 2 - 13, position.Y); 
         bullets.Add(new Bullet(bulletTexture, bulletPosition,20));
    }
    private void MinigunShoot(){
        Vector2 minigunPosition = new Vector2(position.X + 23, position.Y + 35); //1//
         bullets.Add(new Bullet(minigunTexture, minigunPosition,1));
         minigunPosition = new Vector2(position.X + 33, position.Y + 27); //2//
         bullets.Add(new Bullet(minigunTexture, minigunPosition,1));
         minigunPosition = new Vector2(position.X + 59, position.Y + 27); //3//
         bullets.Add(new Bullet(minigunTexture, minigunPosition,1));
         minigunPosition = new Vector2(position.X +69, position.Y + 35); //4//
         bullets.Add(new Bullet(minigunTexture, minigunPosition,1));
    }
    public void TakeDamage(int amount)
            {  
                health -= amount;
            }
     public void Draw(SpriteBatch spriteBatch){
        spriteBatch.Draw(texture, position, Color.White);
         foreach (var bullet in bullets)
            {
                bullet.Draw(spriteBatch);
            }
    }
    }
}
