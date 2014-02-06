using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace TheraWii
{
    // A straight, single-segment line.
    class Line
    {
        GraphicsDevice graphicsDevice;
        VertexPositionColor[] pointList;
        VertexBuffer vertexBuffer;

        public Line(GraphicsDevice gd, Vector3 start, Vector3 end, Color color) 
        {
            graphicsDevice = gd;
            pointList = new VertexPositionColor[2];
            pointList[0] = new VertexPositionColor(start, color);
            pointList[1] = new VertexPositionColor(end, color);
            // Initialize the vertex buffer, allocating memory for each vertex.
            vertexBuffer = new VertexBuffer(graphicsDevice,
                VertexPositionColor.SizeInBytes * (pointList.Length),
                BufferUsage.None);
            // Set the vertex buffer data to the array of vertices.
            vertexBuffer.SetData<VertexPositionColor>(pointList);
        }

        public void Draw()
        {
            graphicsDevice.DrawUserPrimitives<VertexPositionColor>(
                PrimitiveType.LineList,
                pointList,
                0,  // vertex buffer offset to add to each element of the index buffer
                1   // number of vertices in pointList
            );
        }
    }
}
