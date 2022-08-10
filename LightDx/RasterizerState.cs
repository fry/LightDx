using LightDx.Natives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightDx
{
    public enum FillMode {
        Wireframe = 2,
        Solid = 3
    };

    public enum CullMode {
        None = 1,
        Front = 2,
        Back = 3
    };

    public sealed class RasterizerState
    {
        private readonly FillMode _fillMode;
        private readonly CullMode _cullMode;

        public RasterizerState(FillMode fillMode, CullMode cullMode)
        {
            _fillMode = fillMode;
            _cullMode = cullMode;
        }

        internal unsafe IntPtr CreateRasterizerState(LightDevice device)
        {
            RasterizerDecription d = new RasterizerDecription();

            d.FillMode = (int)_fillMode;
            d.CullMode = (int)_cullMode;
            d.FrontCounterClockwise = 0;
            d.DepthBias = 0;
            d.SlopeScaledDepthBias = 0.0f;
            d.DepthBiasClamp = 0.0f;
            d.DepthClipEnable = 1;
            d.ScissorEnable = 0;
            d.MultisampleEnable = 0;
            d.AntialiasedLineEnable = 0;

            Device.CreateRasterizerState(device.DevicePtr, new IntPtr(&d), out var ret).Check();
            return ret;
        }
    }
}
