using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using Sitecore;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.ExperienceForms.Mvc.Models.Fields;
using Sitecore.Resources.Media;

namespace ToyBox.Feature.Controls.Models.Fields
{
    [Serializable]
    public class ImagePickerViewModel : InputViewModel<string>
    {
        public string ImageBucket { get; set; }

        //public List<ImageModel> ModelList { get; set; }
        public List<Item> ModelList { get; set; }

        protected override void InitItemProperties(Item item)
        {
            Assert.ArgumentNotNull((object)item, nameof(item));
            base.InitItemProperties(item);
            this.Value = StringUtil.GetString((object) item.Fields["Default Value"]);
            this.ImageBucket = StringUtil.GetString((object)item.Fields["Image Bucket"]);

            var masterDb = Sitecore.Configuration.Factory.GetDatabase("master");
            var container = masterDb.GetItem(Value);

            var children = container?.GetChildren();

            //var modelList = new List<ImageModel>();

            /*if (children != null)
                foreach (Item model in children)
                {
                    var imageModel = new ImageModel();
                    imageModel.Title = model["Title"];
                    Sitecore.Data.Fields.ImageField imgf = model.Fields["Image"];
                    var imageurl = new MediaItem(imgf.MediaItem);
                    imageModel.Image = MediaManager.GetMediaUrl(imageurl);

                    modelList.Add(imageModel);
                }*/

            this.ModelList = children.ToList();
        }

        protected override void UpdateItemFields(Item item)
        {
            Assert.ArgumentNotNull((object)item, nameof(item));
            base.UpdateItemFields(item);
            item.Fields["Default Value"]?.SetValue(this.Value,false);
            item.Fields["Image Bucket"]?.SetValue(this.ImageBucket, false);
        }

        protected override void InitializeValue(object value)
        {
            this.Value = value?.ToString();
        }

    }

    public class ImageModel
    {
        public string Title { get; set; }
        public string Image { get; set; }
    }
}