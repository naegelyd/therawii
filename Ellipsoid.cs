using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Net;
using Microsoft.Xna.Framework.Storage;

namespace TheraWii
{
    class Ellipsoid
    {
        public virtual Vector3 Scale { get; set; }
        public Vector3 Position;
        public Vector3 color;

        protected float aspectRatio;
        protected Model ellipsoidModel;
        protected Vector3 cameraPosition = new Vector3(0.0f, 0.0f, 10.0f);
        protected GraphicsDeviceManager graphics;
        protected ContentManager Content;

        public Ellipsoid()
        {
        }

        public Ellipsoid(GraphicsDeviceManager g, ContentManager c, Vector3 position, Vector3 scale, Color color)
        {
            this.Scale = scale;
            this.Position = position;
            this.color = color.ToVector3();

            graphics = g;
            Content = c;

            aspectRatio = graphics.GraphicsDevice.Viewport.AspectRatio;

            ellipsoidModel = Content.Load<Model>("Models\\sphere");
        }

        public virtual void Draw()
        {
            // Copy any parent transforms.
            Matrix[] transforms = new Matrix[ellipsoidModel.Bones.Count];
            ellipsoidModel.CopyAbsoluteBoneTransformsTo(transforms);

            // Draw the model. A model can have multiple meshes, so loop.
            foreach (ModelMesh mesh in ellipsoidModel.Meshes)
            {
                // This is where the mesh orientation is set, as well as our camera and projection.
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.PreferPerPixelLighting = true;
                    effect.DiffuseColor = this.color;
                    effect.LightingEnabled = false;
                    //effect.DirectionalLight0.Direction = new Vector3(0.0f, 0.0f, 1.0f);

                    effect.View = Matrix.CreateLookAt(cameraPosition, Vector3.Zero, Vector3.Up);
                    effect.Projection = Matrix.CreatePerspective(0.2f, 0.2f, 1.0f, 1000.0f);
                    effect.World = transforms[mesh.ParentBone.Index]
                                    //* Matrix.CreateRotationZ(MathHelper.ToRadians(30.0f))
                                    * Matrix.CreateScale(Scale.X/aspectRatio, Scale.Y, Scale.Z)
                                    * Matrix.CreateTranslation(Position) 
                                    ;
                }
                // Draw the mesh, using the effects set above.
                mesh.Draw();
            }
        }
    }
}
