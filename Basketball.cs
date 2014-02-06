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
    class Basketball : Ellipsoid
    {
        private Vector3 _scale;
        //private Vector3 ambient;
        //private Texture2D bbalTex;

        public Basketball(GraphicsDeviceManager g, ContentManager c, Vector3 position, Vector3 scale, Color color)
        {
            this.Scale = 0.1f*scale;
            this.Position = position;
            //this.color = new Vector3(0.8f, 0.4f, 0.0f);
            //this.ambient = new Vector3(0.4f, 0.4f, 0.4f);

            graphics = g;
            Content = c;

            aspectRatio = graphics.GraphicsDevice.Viewport.AspectRatio;

            ellipsoidModel = Content.Load<Model>("Models\\basketball");

            // Fix missing logo texture by coloring the patch orange
            BasicEffect e = (BasicEffect)ellipsoidModel.Meshes[1].Effects[2];
            e.DiffuseColor = new Vector3(0.827847719192505f, 0.432608515024185f, 0.20047302544117f);
            e.SpecularColor = new Vector3(0.2f, 0.2f, 0.2f);
            e.SpecularPower = 64.0f;
            //bbalTex = Content.Load<Texture2D>("Textures\\spalding");
            //e.Texture = bbalTex;
            //e.TextureEnabled = true;
        }

        public override Vector3 Scale
        {
            set { this._scale = 0.04f * value; }
            get { return this._scale; }
        }

        public override void Draw()
        {
            // Copy any parent transforms.
            Matrix[] transforms = new Matrix[ellipsoidModel.Bones.Count];
            ellipsoidModel.CopyAbsoluteBoneTransformsTo(transforms);
            

            // Draw the model. A model can have multiple meshes, so loop.
            //foreach (ModelMesh mesh in ellipsoidModel.Meshes)
            ModelMesh mesh = ellipsoidModel.Meshes[1];
            {
                // This is where the mesh orientation is set, as well as our camera and projection.
                foreach (BasicEffect effect in mesh.Effects)
                //BasicEffect effect = (BasicEffect)mesh.Effects[3];
                {
                    effect.EnableDefaultLighting();
                    effect.PreferPerPixelLighting = true;
                    //effect.TextureEnabled = true;
                    //effect.Texture = bbalTex;
                    //effect.TextureEnabled = true;
                    //effect.DiffuseColor = this.color;
                    //effect.AmbientLightColor = this.ambient;
                    effect.LightingEnabled = true;
                    //effect.DirectionalLight0.Direction = new Vector3(0.0f, 0.0f, 1.0f);

                    effect.View = Matrix.CreateLookAt(cameraPosition, Vector3.Zero, Vector3.Up);
                    effect.Projection = Matrix.CreatePerspective(0.2f, 0.2f, 1.0f, 1000.0f);
                    effect.World = transforms[mesh.ParentBone.Index]
                                    //* Matrix.CreateRotationX(MathHelper.ToRadians(189.0f))
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
