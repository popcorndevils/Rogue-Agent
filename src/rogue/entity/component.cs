using System.Collections.Generic;

namespace Rogue.Entity
{
    public abstract class Component<T> where T : Component<T>
    {
        public static SortedList<int, List<T>>? Instances = new SortedList<int, List<T>>();
        public SortedList<int, List<T>>? InstancesTest {
            get => Component<T>.Instances;
        }

        public int Layer;

        public Component()
        {
            // TODO implement Non default Layer options.
            this.Layer = 0;
            this.Register((T)this);
        }

        public void Register(T component)
        {
            if(component.InstancesTest is not null)
            {
                if(!component.InstancesTest.ContainsKey(component.Layer))
                {
                    component.InstancesTest[component.Layer] = new List<T>();
                }
                component.InstancesTest[component.Layer].Add(component);
            }
        }
    }
}