using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.ExperienceForms.Mvc.Models.Fields;

namespace ToyBox.Feature.Controls.Models.Fields
{
    [Serializable]
    public class LocationPickerViewModel : InputViewModel<string>
    {
        public int Width { get; set; }
        public int Height { get; set; }

        protected override void InitItemProperties(Item item)
        {
            Assert.ArgumentNotNull((object)item, nameof(item));
            base.InitItemProperties(item);
            Width = MainUtil.GetInt(item.Fields["Width"]?.Value, 0);
            Height = MainUtil.GetInt(item.Fields["Height"]?.Value, 0);
        }

        protected override void UpdateItemFields(Item item)
        {
            Assert.ArgumentNotNull((object)item, nameof(item));
            base.UpdateItemFields(item);
            item.Fields["Width"]?.SetValue(Width.ToString(CultureInfo.InvariantCulture), true);
            item.Fields["Height"]?.SetValue(Height.ToString(CultureInfo.InvariantCulture), true);
        }

        protected override void InitializeValue(object value)
        {
            this.Value = value?.ToString();
        }
    }
}