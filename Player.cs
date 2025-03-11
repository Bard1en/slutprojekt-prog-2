using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Alien_Invaders
{
    public class Player
    {
        private Texture2D texture; 
        private Vector2 position;
    
       public Player(Texture2D texture){
        this.texture = texture;
        position = new Vector2(300,450);
    }
      public void Update(){
        KeyboardState kState = Keyboard.GetState();
        if(kState.IsKeyDown(Keys.A)) position.X -=5;
        if(kState.IsKeyDown(Keys.D)) position.X +=5;
    }
     public void Draw(SpriteBatch spriteBatch){
        spriteBatch.Draw(texture, position, Color.White);
    }
    }
}
