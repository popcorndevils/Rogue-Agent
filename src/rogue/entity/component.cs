using System.Collections.Generic;

namespace Rogue.Entity
{
    public abstract class Component<T> where T : Component<T>
    {
        public static SortedList<int, List<T>>? Instances = new SortedList<int, List<T>>();
        private SortedList<int, List<T>>? InstancesLink {
            get => Component<T>.Instances;
        }

        public int Layer;

        public Component()
        {
            // TODO implement Non default Layer options.
            this.Layer = 0;
            this.Register();
        }

        public void Register()
        {
            if(this.InstancesLink is not null)
            {
                if(!this.InstancesLink.ContainsKey(this.Layer))
                {
                    this.InstancesLink[this.Layer] = new List<T>();
                }
                this.InstancesLink[this.Layer].Add((T)this);
            }
        }

        public void Unregister()
        {
            if(this.InstancesLink is not null)
            {
                if(this.InstancesLink.ContainsKey(this.Layer))
                {
                    this.InstancesLink[this.Layer].Remove((T)this);
                }
            }
        }

        /// <summary>
        /// Free component
        /// </summary>
        public void Free()
        {
            this.Unregister();
        }
    }
}