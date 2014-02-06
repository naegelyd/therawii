using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace TheraWii
{
    class Hoop : Cuboid
    {

        public Hoop(GraphicsDeviceManager g, ContentManager c, Vector3 position, Vector3 scale, Color color)
        {
            this.Scale = scale;
            this.Position = position;
            this.color = color.ToVector3();

            graphics = g;
            Content = c;

            aspectRatio = graphics.GraphicsDevice.Viewport.AspectRatio;

            cuboidModel = Content.Load<Model>("Models\\hoop");
            
        }

        public override void Draw()
        {
            // Copy any parent transforms.
            Matrix[] transforms = new Matrix[cuboidModel.Bones.Count];
            cuboidModel.CopyAbsoluteBoneTransformsTo(transforms);

            // Draw the model. A model can have multiple meshes, so loop.
            foreach (ModelMesh mesh in cuboidModel.Meshes)
            //ModelMesh mesh = cuboidModel.Meshes[1];
            {
                // This is where the mesh orientation is set, as well as our camera and projection.
                foreach (BasicEffect effect in mesh.Effects)
                //BasicEffect effect = (BasicEffect)mesh.Effects[5];
                {
                    effect.EnableDefaultLighting();
                    effect.PreferPerPixelLighting = true;
                    //effect.DiffuseColor = this.color;
                    effect.LightingEnabled = true;
                    //effect.DirectionalLight0.Direction = new Vector3(0.0f, 0.0f, 1.0f);

                    effect.View = Matrix.CreateLookAt(cameraPosition, Vector3.Zero, Vector3.Up);
                    effect.Projection = Matrix.CreatePerspective(0.2f, 0.2f, 1.0f, 1000.0f);

                    effect.World = transforms[mesh.ParentBone.Index]
                                    * Matrix.CreateTranslation(0.0f, -12.5f, -67.0f)
                                    * Matrix.CreateRotationY(MathHelper.ToRadians(-38.0f))
                                    * Matrix.CreateRotationX(MathHelper.ToRadians(10.0f))
                                    * Matrix.CreateScale(0.5f * 0.038f * Scale.X,
                                                         0.5f * 0.044f * Scale.Y,
                                                         0.5f * 0.038f * Scale.Z)

                                    * Matrix.CreateTranslation(Position)
                                    //* Matrix.CreateTranslation(2.08f, -0.15f, -3.0f)

                                    ;
                }
                // Draw the mesh, using the effects set above.
                mesh.Draw();
            }
        }
    }
}
