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
using System.Text.RegularExpressions;

namespace TheraWii
{
    public class GameTextBox
    {
        private const int LINE_HEIGHT = 20;         /* height of a line of text in pixels */
        private const int CHARACTER_WIDTH = 10;     /* width of one character in pixels */
        private const int BORDER_SIZE = 20;        /* the border size between the text and edge of background */
        private String[] displayStrings;
        private int textWidth, textHeight, boxWidth, boxHeight, textX, textY, boxX, boxY, centerX, centerY;
        private SpriteFont font;
        private SpriteBatch spriteBatch;
        private Texture2D textBackground;

        public GameTextBox() {}

        public void Initialize(String str, ContentManager c, SpriteBatch sb, int screenWidth, int screenHeight)
        {
            displayStrings = Regex.Split(str, "\n");;
            spriteBatch = sb;
            
            font = c.Load<SpriteFont>("Fonts\\GameFont");
            textBackground = c.Load<Texture2D>("Textures\\text_background");

            /* Determine the number lines in the display string and the number of characters in the longest line */
            int maxLength = 0, numLines = 0;
            foreach( String s in this.displayStrings ) {
                numLines++;
                if ( s.Length > maxLength ) 
                    maxLength = s.Length;
            }

            /* determine the size in screen coords of the text and the background */
            textWidth = CHARACTER_WIDTH * maxLength;
            textHeight = LINE_HEIGHT * numLines;
            boxWidth = textWidth + 2 * BORDER_SIZE;
            boxHeight = textHeight + 2 * BORDER_SIZE;

            /* determine where the center of the screen is */
            centerX = screenWidth / 2;
            centerY = screenHeight / 2;

            /* determine where the upper left corner of the text and background box should be by centering 
             * the text and box in the screen coordinates */
            textX = centerX - textWidth / 2;
            textY = centerY - textHeight / 2;
            boxX = centerX - boxWidth / 2;
            boxY = centerY - boxHeight / 2; 
        }

        public void Draw()
        {
            /* draw all the characters in the display string letter by letter */
            spriteBatch.Begin(SpriteBlendMode.AlphaBlend);
            spriteBatch.Draw(textBackground, new Rectangle(boxX, boxY, boxWidth, boxHeight), Color.White);
            int x = textX, y = textY;
            foreach (String s in this.displayStrings)
            {
                spriteBatch.DrawString(font, s, new Vector2(x, y), Color.Orange);
                y += LINE_HEIGHT;
            }
            spriteBatch.End();
        }
    }
}
