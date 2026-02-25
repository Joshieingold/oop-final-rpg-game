using GameData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace UI.Helpers
{
    public static class SpriteHandler
    {
        // Returns a sprite based on its file name
        public static BitmapImage CreateSprite(string spriteName) 
        {
            string imgPath = DataPasser.PictureLocation();
            Uri spriteUri = new Uri(imgPath + "/" + spriteName);
            return new BitmapImage(spriteUri);
        }
    }
}
