using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Negocio
{
    public static class Herramientas
    {
        public static void cargarImagen(PictureBox pbox, string url)
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

        public static void cargarImagenDefault(PictureBox pbox)
        {
            pbox.Load("https://img.freepik.com/free-vector/illustration-gallery-icon_53876-27002.jpg");
        }

        public static bool checkNumero(string cadena)
        {
            if (string.IsNullOrEmpty(cadena)) return false;

            foreach (char item in cadena)
            {
                if (!(char.IsNumber(item))) return false;
            }
            return true;
        }
    }
}
