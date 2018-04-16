﻿using LightDx;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawString
{
    static class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var form = new Form();
            form.ClientSize = new Size(800, 600);

            using (var device = LightDevice.Create(form))
            {
                var targetObj = device.GetDefaultTarget();
                targetObj.ClearColor = new Float4(Color.White, 1);

                var target = new RenderTarget(targetObj);
                target.Apply();

                var sprite = new Sprite(device);
                var guiFont = new TextureFontCache(device, SystemFonts.DefaultFont);

                form.Show();
                device.RunMultithreadLoop(delegate ()
                {
                    target.ClearAll();

                    sprite.Apply();
                    sprite.DrawString(guiFont, "Hello World!", 0, 0, 800);

                    device.Present(true);
                });
            }
        }
    }
}
