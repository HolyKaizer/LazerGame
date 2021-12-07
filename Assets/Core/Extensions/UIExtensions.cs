using UnityEngine;
using UnityEngine.UI;

namespace Core.Extensions
{
    public static class UiExtension
    {
        public static void SetSafeActive(this GameObject go, bool active)
        {
            if (go.activeSelf != active)
                go.SetActive(active);
        }
        
        public static void SetAlpha(this Graphic icon, float alpha)
        {
            var color = icon.color;
            color.a = Mathf.Clamp01(alpha);
            icon.color = color;
        }

        public static void SetNotEvenColor(this Graphic image, Color color)
        {
            Color32 color32 = color;

            color32.r = FormatColorToNotEven(color32.r);
            color32.g = FormatColorToNotEven(color32.g);
            color32.b = FormatColorToNotEven(color32.b);

            image.color = color32;
        }

        public static Color GetPreparedColor(Color color, Color spriteItemColor)
        {
            Color32 color32 = color;

            color32.r = FormatColorToNotEven(color32.r);
            color32.g = FormatColorToNotEven(color32.g);
            color32.b = FormatColorToNotEven(color32.b);

            if (spriteItemColor == Color.red)
            {
                color32.r = FormatColorToEven(color32.r);
            }
            else if (spriteItemColor == Color.green)
            {
                color32.g = FormatColorToEven(color32.g);
            }
            else if (spriteItemColor == Color.blue)
            {
                color32.b = FormatColorToEven(color32.b);
            }

            return color32;
        }

        // In "UI Texture Combine Math" Shader, the sprite texture is determined by its color:
        // If only red component of the color is an even integer value(for example, 254), then Shader get Texture Red.
        // If only green - Shader get Texture Green.
        // If only blue - Shader get Texture Blue.
        // If all component of colors are not even - Shader get UI Texture.
        // This method deforms the color in the desired way, and when the Shader gets information about the texture, it will restore the color.
        public static Color GetPreparedColor(Color color, int colorChannel)
        {
            Color32 color32 = color;

            color32.r = FormatColorToNotEven(color32.r);
            color32.g = FormatColorToNotEven(color32.g);
            color32.b = FormatColorToNotEven(color32.b);

            switch (colorChannel)
            {
                case 0:
                    color32.r = FormatColorToEven(color32.r);
                    break;

                case 1:
                    color32.g = FormatColorToEven(color32.g);
                    break;

                case 2:
                    color32.b = FormatColorToEven(color32.b);
                    break;
            }

            return color32;
        }

        private static byte FormatColorToNotEven(int colorChannelInt)
        {
            colorChannelInt = colorChannelInt % 2 == 0 ? colorChannelInt + 1 : colorChannelInt;

            return (byte) colorChannelInt;
        }

        private static byte FormatColorToEven(int colorChannelInt)
        {
            colorChannelInt = colorChannelInt % 2 != 0 ? colorChannelInt - 1 : colorChannelInt;

            return (byte) colorChannelInt;
        }

        private static int GetClearColorChannel(float colorChannel, int startAccuracy, out int accuracy)
        {
            var intValue = (int) colorChannel * startAccuracy;
            int modulo = 0;

            while (modulo == 0)
            {
                modulo = intValue % 10;
                if (modulo == 0)
                {
                    intValue /= 10;
                    startAccuracy /= 10;
                }
            }

            accuracy = startAccuracy;
            return intValue;
        }
    }
}