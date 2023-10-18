using PS.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PS.Data.Entities
{
    [DataContract]
    public abstract class ResourceItemBase : INotifyPropertyChanged, INamedEntity
    {
        [DataMember(Name = "Id")]
        public string Id { get; set; }

        private string _name;

        [DataMember(Name = "Name")]
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        protected ResourceItemBase(string name)
        {
            Name = name;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string property)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(property));
        }

    }

    [DataContract]
    public class ResourceTypeItem : ResourceItemBase
    {
        public ResourceTypeItem(string name)
            : base(name)
        {
        }

        public ResourceTypeItem()
            : base(string.Empty)
        {
        }
    }

    [DataContract]
    public class ResourceCategoryItem : ResourceItemBase
    {
        [DataMember(Name = "TypeId")]
        public string TypeId { get; set; }

        public ResourceCategoryItem(string name, string typeId)
            : base(name)
        {
            TypeId = typeId;
        }

        public ResourceCategoryItem()
            : base(string.Empty)
        {
        }
    }

    [DataContract]
    public class Resource : IEntity
    {
        [DataMember]
        public string Id { get; set; }

        [DataMember]
        public string ResourceQSpaceID { get; set; }

        [DataMember]
        public string ResourceQSpaceName { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string ShortDescription { get; set; }

        [DataMember]
        public string LongDescription { get; set; }

        [DataMember]
        public string ResourceContentUrl { get; set; }
        
        [DataMember]
        public double MSRP { get; set; }

        [DataMember]
        public int[] CompanyIds { get; set; }

        [DataMember]
        public string[] MediaUrlList { get; set; }

        [DataMember]
        public string[] VideoUrlList { get; set; }

        [DataMember]
        public string[] deletedMediaUrlList { get; set; }

        [DataMember]
        public string ExtensionData { get; set; }
    }
}
