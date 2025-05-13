using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Alien_Invaders
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Player player;
        private Texture2D enemyBulletTexture;

        List<Enemy> enemies = new List<Enemy>();
        private double enemySpawnTimer = 0.0;
        private double spawnDelay = 1.0;
        private Random r = new Random();

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
            Texture2D texture = Content.Load<Texture2D>("Images/skeppet");
            Texture2D bulletTexture = Content.Load<Texture2D>("Images/Bull1");
            Texture2D minigunTexture = Content.Load<Texture2D>("Images/Minigun");
            Texture2D enemyTexture = Content.Load<Texture2D>("Images/Alienskepp");
            enemyBulletTexture = Content.Load<Texture2D>("Images/bullet");

            // TODO: use this.Content to load your game content here
            player = new Player(texture, bulletTexture, minigunTexture);


            
             Vector2 position = new Vector2(25,250);
             enemies.Add(new Enemy(enemyTexture, enemyBulletTexture, position));
            
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Update game elements
            player.Update(gameTime);

            foreach (var enemy in enemies)
                enemy.Update(gameTime);

            BulletCollision();
            RemoveInactiveBullets();

            enemySpawnTimer += gameTime.ElapsedGameTime.TotalSeconds;
            if (enemySpawnTimer >= spawnDelay)
            {
                enemySpawnTimer = 0.0;
                SpawnEnemy();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();
            player.Draw(_spriteBatch);

            foreach (var enemy in enemies)
                enemy.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }

        private void RemoveInactiveBullets()
        {
            var bullets = player.Bullets;
            for (int i = bullets.Count - 1; i >= 0; i--){
                if (!bullets[i].IsActive){
                    bullets.RemoveAt(i);
                }
            }
        }

        private void BulletCollision()
        {
            for (int i = 0; i < player.Bullets.Count; i++)
            {
                for (int j = 0; j < enemies.Count; j++){
                    if (player.Bullets[i].Hitbox.Intersects(enemies[j].Hitbox)){
                        player.Bullets[i].Deactivate();
                        enemies[j].TakeDamage(player.Bullets[i].Damage);

                        if (enemies[j].Health <= 0)
                        {
                            enemies.RemoveAt(j);
                        }

                        break; 
                    }
                }
            }
        }

        private void SpawnEnemy()
        {
            Texture2D enemyTexture = Content.Load<Texture2D>("Images/Alienskepp");
            int randomX = r.Next(0, 650); 
            int randomY = r.Next(0,100);
            Vector2 spawnPosition = new Vector2(randomX, randomY); 
            enemies.Add(new Enemy(enemyTexture,enemyBulletTexture, spawnPosition));
        }
    }
}
