using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.ExperienceForms.Mvc.Models.Fields;

namespace ToyBox.Feature.Controls.Models.Fields
{
    [Serializable]
    public class CustomSliderViewModel : InputViewModel<string>
    {
        public string Range { get; set; }

        protected override void InitItemProperties(Item item)
        {
            Assert.ArgumentNotNull((object)item, nameof(item));
            base.InitItemProperties(item);
            this.Value = StringUtil.GetString((object) item.Fields["Default Value"]);
            //this.Range = StringUtil.GetString((object)item.Fields["Range"]);
        }

        protected override void UpdateItemFields(Item item)
        {
            Assert.ArgumentNotNull((object)item, nameof(item));
            base.UpdateItemFields(item);
            item.Fields["Default Value"]?.SetValue(this.Value,true);
            //item.Fields["Range"]?.SetValue(this.Range, true);
        }

        protected override void InitializeValue(object value)
        {
            this.Value = value?.ToString();
        }
    }
}