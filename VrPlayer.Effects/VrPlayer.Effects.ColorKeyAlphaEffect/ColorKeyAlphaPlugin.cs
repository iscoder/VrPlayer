﻿using System;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using VrPlayer.Contracts;
using VrPlayer.Contracts.Effects;
using VrPlayer.Helpers;

namespace VrPlayer.Effects.ColorKeyAlpha
{
    [Export(typeof(IPlugin<EffectBase>))]
    public class ColorKeyAlphaPlugin : PluginBase<EffectBase>
    {
        public ColorKeyAlphaPlugin()
        {
            try
            {
                Name = "ColorKey Alpha";
                var effect = new ColorKeyAlphaEffect();
                Content = effect;
                Panel = new ColorKeyAlphaPanel(effect);
                InjectConfig(PluginConfig.FromSettings(ConfigHelper.LoadConfig().AppSettings.Settings));
            }
            catch (Exception exc)
            {
                Logger.Instance.Error(string.Format("Error while loading '{0}'", GetType().FullName), exc);
            }
        }
    }
}
