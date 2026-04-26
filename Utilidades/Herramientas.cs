using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utilidades
{
    public static class Herramientas
    {
        public static void cargarImagen(System.Windows.Forms.PictureBox pbox, string url)
        {
            try
            {
                if (!string.IsNullOrEmpty(url))
                    pbox.Load(url);
                else
                    cargarImagenDefault(pbox);
            }
            catch (Exception)
            {
                cargarImagenDefault(pbox);
            }
        }
        private static void cargarImagenDefault(System.Windows.Forms.PictureBox pbox)
        {
            pbox.Load("https://img.freepik.com/free-vector/illustration-gallery-icon_53876-27002.jpg");
        }
    }
}
