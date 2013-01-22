using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityEnginev2.Engine;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EntityEngineTestBed
{
    public class TestGame : EntityGame
    {
        private TestState _ts;
        public TestGame(Game game, GraphicsDeviceManager g, SpriteBatch spriteBatch) : base(game, g, new Rectangle(0,0,600,600), spriteBatch)
        {
            _ts = new TestState(this);
            _ts.Show();
        }
    }
}
