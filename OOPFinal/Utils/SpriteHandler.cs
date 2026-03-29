using GameData;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media.Imaging;

namespace UI.Utils
{
    public static class SpriteHandler
    {
public static BitmapImage CreateSprite(string spriteName) 
        {
            string imgPath = DataPasser.PictureLocation();
            Uri spriteUri = new Uri(imgPath + "/" + spriteName);
            return new BitmapImage(spriteUri);
        }
    }
}
