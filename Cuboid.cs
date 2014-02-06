using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace TheraWii
{
    class Cuboid
    {
        public Vector3 Scale;
        public Vector3 Position;
        public Vector3 color;

        protected float aspectRatio;
        protected Model cuboidModel;
        protected Vector3 cameraPosition = new Vector3(0.0f, 0.0f, 10.0f);
        protected GraphicsDeviceManager graphics;
        protected ContentManager Content;

        public Cuboid()
        {
        }

        public Cuboid(GraphicsDeviceManager g, ContentManager c, Vector3 position, Vector3 scale, Color color)
        {
            this.Scale = scale;
            this.Position = position;
            this.color = color.ToVector3();

            graphics = g;
            Content = c;

            aspectRatio = graphics.GraphicsDevice.Viewport.AspectRatio;

            cuboidModel = Content.Load<Model>("Models\\cube");
        }

        public virtual void Draw()
        {
            // Copy any parent transforms.
            Matrix[] transforms = new Matrix[cuboidModel.Bones.Count];
            cuboidModel.CopyAbsoluteBoneTransformsTo(transforms);

            // Draw the model. A model can have multiple meshes, so loop.
            foreach (ModelMesh mesh in cuboidModel.Meshes)
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
                                    * Matrix.CreateScale(0.5f * Scale.X, 0.5f * Scale.Y, 0.5f * Scale.Z)
                                    * Matrix.CreateTranslation(Position) 
                                    ;
                }
                // Draw the mesh, using the effects set above.
                mesh.Draw();
            }
        }
    }
}
