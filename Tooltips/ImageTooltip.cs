using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscordRichPresence.Tooltips
{
    public class ImageTooltip : ToolTip
    {
        private Bitmap? image = null;

        public ImageTooltip() 
        {
            this.OwnerDraw = true;
            this.Popup += new PopupEventHandler(OnPopup);
            this.Draw += new DrawToolTipEventHandler(OnDraw);
        }

        public void SetImage(Bitmap? image)
        {
            this.image = image;
        }

        private void OnPopup(object sender, PopupEventArgs e) // use this event to set the size of the tool tip
        {
            if(image != null)
                e.ToolTipSize = new Size(image.Width, image.Height);
        }

        private void OnDraw(object sender, DrawToolTipEventArgs e) // use this to customzie the tool tip
        {
            if(image != null)
            {
                Graphics g = e.Graphics;
                g.Clear(Color.Transparent);
                //create your own custom brush to fill the background with the image
                TextureBrush b = new TextureBrush(image);// get the image from Tag

                g.FillRectangle(b, e.Bounds);
                b.Dispose();
            }
        }
    }
}
