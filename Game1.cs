using System.Collections.Generic;
using System.Windows.Forms.VisualStyles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Alien_Invaders;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Player player;
    List<Enemy> enemies = new List<Enemy>();



    public Game1()
    {
        GraphicsDeviceManager graphics;
        graphics = new GraphicsDeviceManager(this);
        graphics.ToggleFullScreen();
        Content.RootDirectory = "Content";
        IsMouseVisible = false;
        
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
       
        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);
        Texture2D texture = Content.Load<Texture2D> ("Images/skeppet");
        Texture2D bulletTexture = Content.Load<Texture2D> ("Images/Bull1");
        Texture2D minigunTexture = Content.Load<Texture2D>("Images/Minigun");
        Texture2D enemyTexture = Content.Load<Texture2D>("Images/Alienskepp");
        // TODO: use this.Content to load your game content here
        player = new Player(texture, bulletTexture, minigunTexture);
        enemies.Add(new Enemy(enemyTexture));
    
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        player.Update(gameTime);
        base.Update(gameTime);
        foreach(var Enemy in enemies)
            Enemy.Update(gameTime);
        BulletCollision();
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.Black);
        _spriteBatch.Begin();
        player.Draw(_spriteBatch);
         foreach(var Enemy in enemies)
            Enemy.Draw(_spriteBatch);
        _spriteBatch.End();
        // TODO: Add your drawing code here

        base.Draw(gameTime);
    }

    private void BulletCollision(){
        for(int i = 0; i < player.Bullets.Count; i++ ){
            for(int j = 0; j < enemies.Count; j++ ){
                if(player.Bullets[i].Hitbox.Intersects(enemies[j].Hitbox)){
                    player.Bullets[i].Deactivate();
                    enemies.RemoveAt(j);
                    i--;
                    break;
                }
            }
        }
        
    }
}
