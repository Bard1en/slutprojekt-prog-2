using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation;

namespace Alien_Invaders
{
    public class Player
    {
        private Texture2D texture; 
        private Vector2 position;
        private Texture2D bulletTexture;
        private List<Bullet> bullets;
    
       public Player(Texture2D texture, Texture2D bulletTexture){
        this.texture = texture;
        this.bulletTexture = bulletTexture;
        position = new Vector2(300,450);
        bullets = new List<Bullet>();
    }
      public void Update(){
        KeyboardState kState = Keyboard.GetState();
        if(kState.IsKeyDown(Keys.A)) position.X -=5;
        if(kState.IsKeyDown(Keys.D)) position.X +=5;
        if(kState.IsKeyDown(Keys.Space)){
            Shoot();
        }
        for(int i = bullets.Count -1; i >= 0; i--){
            bullets[i].Update();
            if(!bullets[i].IsActive)bullets.RemoveAt(i);
        }
    }
    private void Shoot(){
         Vector2 bulletPosition = new Vector2(position.X + texture.Width / 2 - 5, position.Y); 
         bullets.Add(new Bullet(bulletTexture, bulletPosition));
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
