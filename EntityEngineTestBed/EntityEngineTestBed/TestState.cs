using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityEnginev2.Diagnostics;
using EntityEnginev2.Engine;
using EntityEnginev2.GUI;
using EntityEnginev2.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace EntityEngineTestBed
{
    public sealed class TestState : EntityState
    {
        private FramesPerSecondCounter _fpscounter;
        private DoubleInput _testkey = new DoubleInput(null, "TestKey", Keys.Space, Buttons.A, PlayerIndex.One);
        private Text _entitiestext;
        private int _totalcreated, _totaldestroyed;
        private int _totalactive
        {
            get { return _totalcreated - _totaldestroyed; }
        }

        public TestState(EntityGame eg) : base(eg, "TestState")
        {
            Start();
        }

        public override void Start()
        {
            base.Start();

            GameRef.BGColor = Color.Red;

            //GUI 
            _entitiestext = new Text(this, "entitestext", GameRef.Game.Content.Load<SpriteFont>(@"font"), "none",
                                    new Vector2(5, 5));
            AddEntity(_entitiestext);

            _fpscounter = new FramesPerSecondCounter(this, "FPSCounter", GameRef.Game.Content.Load<SpriteFont>(@"font"),
                                                     new Vector2(400, 400));
            _fpscounter.Body.Position = new Vector2(GameRef.Viewport.Width - _fpscounter.TextRender.DrawRect.Width, GameRef.Viewport.Height - _fpscounter.TextRender.DrawRect.Height);
            AddEntity(_fpscounter);
        }

        public override void Update()
        {
            base.Update();

            //Update Text Fields
            _fpscounter.Body.Position = new Vector2(GameRef.Viewport.Width - _fpscounter.TextRender.DrawRect.Width, GameRef.Viewport.Height - _fpscounter.TextRender.DrawRect.Height);
            _entitiestext.TextRender.Text =
                "Entites Created: " + _totalcreated +
                "\nEntites Destoryed: " + _totaldestroyed +
                "\nActive Entities: " + _totalactive;
        }

        public override void AddEntity(Entity e)
        {
            base.AddEntity(e);
            _totalcreated++;
        }

        public override void RemoveEntity(Entity e)
        {
            base.RemoveEntity(e);
            _totaldestroyed++;
        }
    }
}
